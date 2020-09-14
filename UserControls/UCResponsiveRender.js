function UCResponsive($)
{

	var template = '<script src=\'https://cdn.plot.ly/plotly-latest.min.js\'></script><div id="tester" style="width:90%;height:250px;"></div><script>	TESTER = document.getElementById(\'tester\');	Plotly.plot( TESTER, [{		x: [1, 2, 3, 4, 5],		y: [1, 2, 4, 8, 16] }], { 		margin: { t: 0 } }, {showSendToCloud:true} );</script>';
	Mustache.parse(template);
	var $container;
	this.show = function()
	{
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this));
			this.renderChildContainers();



			this.toggleVisibility();

			// Raise after show scripts

	}

	this.Scripts = [  ];




	this.toggleVisibility = function () {
		if (this.Visible) {
			$container.show();
		}
		else {
			$container.hide();
		}
	};

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(this.ControlName + '_' + slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}