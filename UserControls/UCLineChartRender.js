function UCLineChart($)
{
	  
	  
	 this.setResumen = function(value) {
			this.Resumen = value;
		}

		this.getResumen = function() {
			return this.Resumen;
		} 
	  
	  

	var template = '<script type="text/javascript">      google.charts.load(\'current\', {\'packages\':[\'corechart\']});      google.charts.setOnLoadCallback(drawChart);      function drawChart() {        var data = google.visualization.arrayToDataTable([          [{{EjeX}}, {{EjeY}}],          [{{#Resumen}}            [\'{{RFM}}\',			\'{{SumClientes}}\'],          {{/Resumen}}]        ]);        var options = {          title: \'{{Titulo}}\',          curveType: \'function\',          legend: { position: \'bottom\' }        };        var chart = new google.visualization.LineChart(document.getElementById(\'curve_chart\'));        chart.draw(data, options);      }    </script>  <body>    <div id="curve_chart" style="width: 900px; height: 500px"></div>  </body>';
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