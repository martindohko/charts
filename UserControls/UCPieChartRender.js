function UCPieChart($)
{

	var template = '<script type="text/javascript">      google.charts.load(\'current\', {\'packages\':[\'corechart\']});      google.charts.setOnLoadCallback(drawChart);      function drawChart() {        var data = google.visualization.arrayToDataTable([          [\'Task\', \'Hours per Day\'],          [\'Work\',     11],          [\'Eat\',      2],          [\'Commute\',  2],          [\'Watch TV\', 2],          [\'Sleep\',    7]        ]);        var options = {          title: \'My Daily Activities\'        };        var chart = new google.visualization.PieChart(document.getElementById(\'piechart\'));        chart.draw(data, options);      }    </script>  </head>  <body>    <div id="piechart" style="width: 900px; height: 500px;"></div>  </body>';
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