gx.evt.autoSkip=!1;gx.define("wclinechart2",!0,function(n){var i,t;this.ServerClass="wclinechart2";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e131d2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e141d2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;this.QUERYVIEWER1Container=gx.uc.getNew(this,6,0,"QueryViewer",this.CmpContext+"QUERYVIEWER1Container","Queryviewer1","QUERYVIEWER1");t=this.QUERYVIEWER1Container;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ObjectId","Objectid","8","str");t.setProp("ObjectType","Objecttype","Query","str");t.setProp("QueryInfo","Queryinfo","","char");t.setProp("IsExternalQuery","Isexternalquery",!1,"boolean");t.setProp("ExternalQueryResult","Externalqueryresult","","char");t.setProp("ObjectInfo","Objectinfo","","char");t.addV2CFunction("AV11Axes","vAXES","SetAxes");t.addC2VFunction(function(n){n.ParentObject.AV11Axes=n.GetAxes();gx.fn.setControlValue("vAXES",n.ParentObject.AV11Axes)});t.setProp("AllowChangeAxesOrder","Allowchangeaxesorder",!1,"bool");t.addV2CFunction("AV9Parameters","vPARAMETERS","SetParameters");t.addC2VFunction(function(n){n.ParentObject.AV9Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV9Parameters)});t.setProp("ObjectName","Objectname","QLineChartFac","str");t.setProp("Object","Objectcall","","str");t.setProp("Class","Class","QueryViewer","str");t.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");t.setProp("AutoResize","Autoresize",!1,"boolean");t.setProp("AutoResizeType","Autoresizetype","","char");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100%","str");t.setProp("Axes Selectors","Showaxesselectors","","char");t.setProp("FontFamily","Fontfamily","","char");t.setProp("FontSize","Fontsize","","int");t.setProp("FontColor","Fontcolor","","int");t.setProp("AutoRefreshGroup","Autorefreshgroup","","str");t.setProp("DisableColumnSort","Disablecolumnsort",!1,"boolean");t.setProp("AllowSelection","Allowselection",!1,"bool");t.setProp("RememberLayout","Rememberlayout",!0,"bool");t.setProp("ExportToXML","Exporttoxml",!0,"bool");t.setProp("ExportToHTML","Exporttohtml",!0,"bool");t.setProp("ExportToXLS","Exporttoxls",!0,"bool");t.setProp("ExportToXLSX","Exporttoxlsx",!0,"bool");t.setProp("ExportToPDF","Exporttopdf",!0,"bool");t.setProp("Type","Type","Chart","str");t.setProp("ShowDataAs","Showdataas","","char");t.setProp("Orientation","Orientation","","char");t.setProp("IncludeTrend","Includetrend",!1,"boolean");t.setProp("TrendPeriod","Trendperiod","","char");t.setProp("IncludeSparkline","Includesparkline",!1,"boolean");t.setProp("IncludeMaxAndMin","Includemaxandmin",!1,"boolean");t.setProp("ChartType","Charttype","Line","str");t.setProp("Title","Title","","str");t.setProp("PlotSeries","Plotseries","InTheSameChart","str");t.setProp("ShowValues","Showvalues",!0,"bool");t.setProp("XAxisLabels","Xaxislabels","Horizontally","str");t.setProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!0,"bool");t.setProp("XAxisTitle","Xaxistitle","RFM","str");t.setProp("YAxisTitle","Yaxistitle","Clientes","str");t.setProp("Paging","Paging",!1,"boolean");t.setProp("PageSize","Pagesize","","int");t.setProp("CurrentPage","Currentpage","","int");t.setProp("ShowDataLabelsIn","Showdatalabelsin","","char");t.addV2CFunction("AV17ItemClickData","vITEMCLICKDATA","SetItemClickData");t.addC2VFunction(function(n){n.ParentObject.AV17ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV17ItemClickData)});t.addV2CFunction("AV18ItemDoubleClickData","vITEMDOUBLECLICKDATA","SetItemDoubleClickData");t.addC2VFunction(function(n){n.ParentObject.AV18ItemDoubleClickData=n.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",n.ParentObject.AV18ItemDoubleClickData)});t.addV2CFunction("AV13DragAndDropData","vDRAGANDDROPDATA","SetDragAndDropData");t.addC2VFunction(function(n){n.ParentObject.AV13DragAndDropData=n.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",n.ParentObject.AV13DragAndDropData)});t.addV2CFunction("AV16FilterChangedData","vFILTERCHANGEDDATA","SetFilterChangedData");t.addC2VFunction(function(n){n.ParentObject.AV16FilterChangedData=n.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",n.ParentObject.AV16FilterChangedData)});t.addV2CFunction("AV14ItemExpandData","vITEMEXPANDDATA","SetItemExpandData");t.addC2VFunction(function(n){n.ParentObject.AV14ItemExpandData=n.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",n.ParentObject.AV14ItemExpandData)});t.addV2CFunction("AV15ItemCollapseData","vITEMCOLLAPSEDATA","SetItemCollapseData");t.addC2VFunction(function(n){n.ParentObject.AV15ItemCollapseData=n.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",n.ParentObject.AV15ItemCollapseData)});t.setProp("AppSettings","Appsettings","","char");t.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");t.setProp("ExecuteShow","Executeshow",!1,"boolean");t.setProp("ServiceUrl","Serviceurl","","char");t.setProp("GenType","Gentype","","char");t.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"MAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};this.AV11Axes=[];this.Events={e131d2_client:["ENTER",!0],e141d2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.START=[[],[]];this.Initialize()})