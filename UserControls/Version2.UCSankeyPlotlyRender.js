function Version2_UCSankeyPlotly($)
{

	var template = '<script src="https://cdn.plot.ly/plotly-latest.min.js"></script><script>	var div = document.createElement("div");	/*div.style.width = "100%";	div.style.height = "100%";*/	div.id = \'divSankey\'		document.getElementById(\'MAINTABLE\').appendChild(div);		var data = {		type: "sankey",		orientation: "h",		node: {			pad: 15,			thickness: 30,			line: {			color: "black",			width: 0.5			},		label: ["A1", "A2", "B1", "B2", "C1", "C2"],		color: ["blue", "blue", "blue", "blue", "blue", "blue"]			},				link: {			source: [0,1,0,2,3,3],			target: [2,3,3,4,4,5],			value:  [8,4,2,8,4,2]		}		}				var data = [data]				var layout = {			title: "Basic Sankey",				font: {				size: 10			}		}		var config = {responsive: true}		Plotly.newPlot(\'divSankey\', data, layout, config)</script>';
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