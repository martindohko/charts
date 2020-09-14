function Version2_UCPiePlotly($)
{

	var template = '<script src="https://cdn.plot.ly/plotly-latest.min.js"></script><script>	var div = document.createElement("div");	/*div.style.width = "100%";	div.style.height = "100%";*/	div.id = \'divPie\'		document.getElementById(\'MAINTABLE\').appendChild(div);		var data = [{		type: "pie",		values: [2, 3, 4, 4],		labels: ["Wages", "Operating expenses", "Cost of sales", "Insurance"],		textinfo: "label+percent",		textposition: "outside",		automargin: true		}]				var layout = {				margin: {"t": 0, "b": 0, "l": 0, "r": 0},		showlegend: false		}		var config = {responsive: true}		Plotly.newPlot(\'divPie\', data, layout,config);</script>';
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