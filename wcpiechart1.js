gx.evt.autoSkip=!1;gx.define("wcpiechart1",!0,function(n){var i,t;this.ServerClass="wcpiechart1";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e12192_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e13192_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;this.QUERYVIEWER1Container=gx.uc.getNew(this,6,0,"QueryViewer",this.CmpContext+"QUERYVIEWER1Container","Queryviewer1","QUERYVIEWER1");t=this.QUERYVIEWER1Container;t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("ObjectId","Objectid","5","str");t.setProp("ObjectType","Objecttype","Query","str");t.setProp("QueryInfo","Queryinfo","","char");t.setProp("IsExternalQuery","Isexternalquery",!1,"boolean");t.setProp("ExternalQueryResult","Externalqueryresult","","char");t.setProp("ObjectInfo","Objectinfo","","char");t.addV2CFunction("AV9Axes","vAXES","SetAxes");t.addC2VFunction(function(n){n.ParentObject.AV9Axes=n.GetAxes();gx.fn.setControlValue("vAXES",n.ParentObject.AV9Axes)});t.setProp("AllowChangeAxesOrder","Allowchangeaxesorder",!1,"bool");t.addV2CFunction("AV7Parameters","vPARAMETERS","SetParameters");t.addC2VFunction(function(n){n.ParentObject.AV7Parameters=n.GetParameters();gx.fn.setControlValue("vPARAMETERS",n.ParentObject.AV7Parameters)});t.setProp("ObjectName","Objectname","QPieChart","str");t.setProp("Object","Objectcall","","str");t.setProp("Class","Class","QueryViewer","str");t.setProp("ShrinkToFit","Shrinktofit",!1,"boolean");t.setProp("AutoResize","Autoresize",!1,"boolean");t.setProp("AutoResizeType","Autoresizetype","","char");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100%","str");t.setProp("Axes Selectors","Showaxesselectors","","char");t.setProp("FontFamily","Fontfamily","","char");t.setProp("FontSize","Fontsize","","int");t.setProp("FontColor","Fontcolor","","int");t.setProp("AutoRefreshGroup","Autorefreshgroup","","str");t.setProp("DisableColumnSort","Disablecolumnsort",!1,"boolean");t.setProp("AllowSelection","Allowselection",!1,"bool");t.setProp("RememberLayout","Rememberlayout",!0,"bool");t.setProp("ExportToXML","Exporttoxml",!0,"bool");t.setProp("ExportToHTML","Exporttohtml",!0,"bool");t.setProp("ExportToXLS","Exporttoxls",!0,"bool");t.setProp("ExportToXLSX","Exporttoxlsx",!0,"bool");t.setProp("ExportToPDF","Exporttopdf",!0,"bool");t.setProp("Type","Type","Chart","str");t.setProp("ShowDataAs","Showdataas","","char");t.setProp("Orientation","Orientation","","char");t.setProp("IncludeTrend","Includetrend",!1,"boolean");t.setProp("TrendPeriod","Trendperiod","","char");t.setProp("IncludeSparkline","Includesparkline",!1,"boolean");t.setProp("IncludeMaxAndMin","Includemaxandmin",!1,"boolean");t.setProp("ChartType","Charttype","Pie","str");t.setProp("Title","Title","Clientes Fidelizados","str");t.setProp("PlotSeries","Plotseries","InTheSameChart","str");t.setProp("ShowValues","Showvalues",!0,"bool");t.setProp("XAxisLabels","Xaxislabels","Horizontally","str");t.setProp("XAxisIntersectionAtZero","Xaxisintersectionatzero",!1,"bool");t.setProp("XAxisTitle","Xaxistitle","RFM","str");t.setProp("YAxisTitle","Yaxistitle","Clientes","str");t.setProp("Paging","Paging",!1,"boolean");t.setProp("PageSize","Pagesize","","int");t.setProp("CurrentPage","Currentpage","","int");t.setProp("ShowDataLabelsIn","Showdatalabelsin","","char");t.addV2CFunction("AV15ItemClickData","vITEMCLICKDATA","SetItemClickData");t.addC2VFunction(function(n){n.ParentObject.AV15ItemClickData=n.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",n.ParentObject.AV15ItemClickData)});t.addV2CFunction("AV16ItemDoubleClickData","vITEMDOUBLECLICKDATA","SetItemDoubleClickData");t.addC2VFunction(function(n){n.ParentObject.AV16ItemDoubleClickData=n.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",n.ParentObject.AV16ItemDoubleClickData)});t.addV2CFunction("AV11DragAndDropData","vDRAGANDDROPDATA","SetDragAndDropData");t.addC2VFunction(function(n){n.ParentObject.AV11DragAndDropData=n.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",n.ParentObject.AV11DragAndDropData)});t.addV2CFunction("AV14FilterChangedData","vFILTERCHANGEDDATA","SetFilterChangedData");t.addC2VFunction(function(n){n.ParentObject.AV14FilterChangedData=n.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",n.ParentObject.AV14FilterChangedData)});t.addV2CFunction("AV12ItemExpandData","vITEMEXPANDDATA","SetItemExpandData");t.addC2VFunction(function(n){n.ParentObject.AV12ItemExpandData=n.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",n.ParentObject.AV12ItemExpandData)});t.addV2CFunction("AV13ItemCollapseData","vITEMCOLLAPSEDATA","SetItemCollapseData");t.addC2VFunction(function(n){n.ParentObject.AV13ItemCollapseData=n.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",n.ParentObject.AV13ItemCollapseData)});t.setProp("AppSettings","Appsettings","","char");t.setProp("AvoidAutomaticShow","Avoidautomaticshow",!1,"boolean");t.setProp("ExecuteShow","Executeshow",!1,"boolean");t.setProp("ServiceUrl","Serviceurl","","char");t.setProp("GenType","Gentype","","char");t.setProp("DesignRenderOutputType","Designrenderoutputtype","","char");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"MAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};this.AV9Axes=[];this.Events={e12192_client:["ENTER",!0],e13192_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.Initialize()})