function UCSemicircle1($)
{
	 this.setSDTSemicirculo = function(value) {
			this.SDTSemicirculo = value;
		}

		this.getSDTSemicirculo = function() {
			return this.SDTSemicirculo;
		} 
	  

	var template = '[{{#SDTSemicirculo}}<style>	body {	font: normal 16px/1.5 \'Roboto\', sans-serif;	padding: 130px 0 0 0;	background: #f1f1f1;	}			/* RESET STYLES	–––––––––––––––––––––––––––––––––––––––––––––––––– */		.chart-skills {	margin: 0 auto;	padding: 0;	list-style-type: none;	}		.chart-skills *,	.chart-skills::before {	box-sizing: border-box;	}			/* CHART-SKILLS STYLES –––––––––––––––––––––––––––––––––––––––––––––––––– */		.chart-skills {	position: relative;	width: 350px;	height: 175px;	overflow: hidden;	}		.chart-skills::before,	.chart-skills::after {	position: absolute;	}		.chart-skills::before {	content: \'\';	width: inherit;	height: inherit;	border: 45px solid rgba(211, 211, 211, .3);	border-bottom: none;	border-top-left-radius: 175px;	border-top-right-radius: 175px;	}		.chart-skills::after {	content: [\'{{value}}\',;	left: 50%;	bottom: 10px;	transform: translateX(-50%);	font-size: {{text2remzise}},rem;	font-weight: bold;	color: cadetblue;	}		.chart-skills li {	position: absolute;	top: 100%;	left: 0;	width: inherit;	height: inherit;	border: 45px solid;	border-top: none;	border-bottom-left-radius: 175px;	border-bottom-right-radius: 175px;	transform-origin: 50% 0;	transform-style: preserve-3d;	backface-visibility: hidden;	animation-fill-mode: forwards;	animation-duration: .4s;	animation-timing-function: linear;	}		.chart-skills li:nth-child(1) {	z-index: 4;	border-color: {{colour}},;	animation-name: rotate-one;	}			.chart-skills span {	position: absolute;	font-size: {{text1remzise}},rem;	backface-visibility: hidden;	animation: fade-in .4s linear forwards;	}		.chart-skills li:nth-child(1) span {	top: 5px;	left: 10px;	transform: rotate(-{{deg}},deg);	}			/* ANIMATIONS––––––––––––––––––––––––––––––––––––––––––––––––– */		@keyframes rotate-one {	100% {		transform: rotate({{deg}},deg);	}	}}</style><ul class="chart-skills">  <li>    <span>{{percentage}}]%</span>  </li></ul>{{/SDTSemicirculo}}]';
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