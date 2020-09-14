function UCPie($)
{

	var template = '<script src="https://cdn.plot.ly/plotly-latest.min.js"></script><div id="myDiv" style="width:600px;height:250px;"></div><script>	var trace1 = {		type: \'bar\',		x: [1, 2, 3, 4],		y: [5, 10, 2, 8],		marker: {			color: \'#C8A2C8\',			line: {				width: 2.5			}		}	};		var data = [ trace1 ];		var layout = { 	title: \'Responsive to window\\'s size!\',	font: {size: 18}	};		var config = {responsive: true}		Plotly.newPlot(\'myDiv\', data, layout, config );</script>';
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