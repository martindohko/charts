function UCColumnChart($)
{
	 this.setSDTRFMAct = function(value) {
			this.SDTRFMAct = value;
		}

		this.getSDTRFMAct = function() {
			return this.SDTRFMAct;
		} 
	  

	var template = ' <script type="text/javascript">    google.charts.load("current", {packages:[\'corechart\']});    google.charts.setOnLoadCallback(drawChart);    function drawChart() {      var data = google.visualization.arrayToDataTable([        ["RFM", "Cantidad",        [{{#SDTRFMAct}}			[\'{{RFMAct}}\',			\'{{Clientes}}\',			{{Weight}}],		{{/Resumen}}]      ]);      var view = new google.visualization.DataView(data);      view.setColumns([0, 1,                       { calc: "stringify",                         sourceColumn: 1,                         type: "string",                         role: "annotation" },                       2]);      var options = {        title: "Clientes Fidelizados",        width: 600,        height: 400,        bar: {groupWidth: "95%"},        legend: { position: "none" },      };      var chart = new google.visualization.ColumnChart(document.getElementById("columnchart_values"));      chart.draw(view, options);  }  </script><div id="columnchart_values" style="width: 900px; height: 300px;"></div>';
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