function UCSD($)
{
	 this.setResumen = function(value) {
			this.Resumen = value;
		}

		this.getResumen = function() {
			return this.Resumen;
		} 
	  

	var template = '<div id="sankey" style="width: 900px; height: 300px;"><script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script><script type="text/javascript" src="https://www.google.com/jsapi"></script><script>		google.charts.load(\'current\', {\'packages\':[\'sankey\']});		google.charts.setOnLoadCallback(drawChart);			function drawChart() {			var data = new google.visualization.DataTable();			data.addColumn(\'string\', \'From\');			data.addColumn(\'string\', \'To\');			data.addColumn(\'number\', \'Weight\');			data.addRows([{{#Resumen}}               				[\'{{From}}\',							\'{{To}}\',							{{Weight}}],             			{{/Resumen}}]    					);						var options = {				width: 800,				sankey: { node: { labelPadding: 30 } },			}			var chart = new google.visualization.Sankey(document.getElementById(\'sankey\'));			chart.draw(data, options);		}</script></div>';
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