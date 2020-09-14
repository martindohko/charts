gx.evt.autoSkip = false;
gx.define('version1.wctable', true, function (CmpContext) {
   this.ServerClass =  "version1.wctable" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e121g2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e131g2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   this.QUERYVIEWER1Container = gx.uc.getNew(this, 6, 0, "QueryViewer", this.CmpContext + "QUERYVIEWER1Container", "Queryviewer1", "QUERYVIEWER1");
   var QUERYVIEWER1Container = this.QUERYVIEWER1Container;
   QUERYVIEWER1Container.setProp("Enabled", "Enabled", true, "boolean");
   QUERYVIEWER1Container.setProp("ObjectId", "Objectid", "17", "str");
   QUERYVIEWER1Container.setProp("ObjectType", "Objecttype", "Query", "str");
   QUERYVIEWER1Container.setProp("QueryInfo", "Queryinfo", "", "char");
   QUERYVIEWER1Container.setProp("IsExternalQuery", "Isexternalquery", false, "boolean");
   QUERYVIEWER1Container.setProp("ExternalQueryResult", "Externalqueryresult", "", "char");
   QUERYVIEWER1Container.setProp("ObjectInfo", "Objectinfo", "", "char");
   QUERYVIEWER1Container.addV2CFunction('AV7Axes', "vAXES", 'SetAxes');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV7Axes=UC.GetAxes();gx.fn.setControlValue("vAXES",UC.ParentObject.AV7Axes); });
   QUERYVIEWER1Container.setProp("AllowChangeAxesOrder", "Allowchangeaxesorder", false, "bool");
   QUERYVIEWER1Container.addV2CFunction('AV5Parameters', "vPARAMETERS", 'SetParameters');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV5Parameters=UC.GetParameters();gx.fn.setControlValue("vPARAMETERS",UC.ParentObject.AV5Parameters); });
   QUERYVIEWER1Container.setProp("ObjectName", "Objectname", "QTableChart", "str");
   QUERYVIEWER1Container.setProp("Object", "Objectcall", "", "str");
   QUERYVIEWER1Container.setProp("Class", "Class", "QueryViewer", "str");
   QUERYVIEWER1Container.setProp("ShrinkToFit", "Shrinktofit", false, "boolean");
   QUERYVIEWER1Container.setProp("AutoResize", "Autoresize", false, "bool");
   QUERYVIEWER1Container.setProp("AutoResizeType", "Autoresizetype", "", "char");
   QUERYVIEWER1Container.setProp("Width", "Width", "100%", "str");
   QUERYVIEWER1Container.setProp("Height", "Height", "100%", "str");
   QUERYVIEWER1Container.setProp("Axes Selectors", "Showaxesselectors", "", "char");
   QUERYVIEWER1Container.setProp("FontFamily", "Fontfamily", "", "char");
   QUERYVIEWER1Container.setProp("FontSize", "Fontsize", '', "int");
   QUERYVIEWER1Container.setProp("FontColor", "Fontcolor", '', "int");
   QUERYVIEWER1Container.setProp("AutoRefreshGroup", "Autorefreshgroup", "", "str");
   QUERYVIEWER1Container.setProp("DisableColumnSort", "Disablecolumnsort", false, "bool");
   QUERYVIEWER1Container.setProp("AllowSelection", "Allowselection", false, "bool");
   QUERYVIEWER1Container.setProp("RememberLayout", "Rememberlayout", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToXML", "Exporttoxml", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToHTML", "Exporttohtml", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToXLS", "Exporttoxls", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToXLSX", "Exporttoxlsx", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToPDF", "Exporttopdf", true, "bool");
   QUERYVIEWER1Container.setProp("Type", "Type", "Table", "str");
   QUERYVIEWER1Container.setProp("ShowDataAs", "Showdataas", "", "char");
   QUERYVIEWER1Container.setProp("Orientation", "Orientation", "", "char");
   QUERYVIEWER1Container.setProp("IncludeTrend", "Includetrend", false, "boolean");
   QUERYVIEWER1Container.setProp("TrendPeriod", "Trendperiod", "", "char");
   QUERYVIEWER1Container.setProp("IncludeSparkline", "Includesparkline", false, "boolean");
   QUERYVIEWER1Container.setProp("IncludeMaxAndMin", "Includemaxandmin", false, "boolean");
   QUERYVIEWER1Container.setProp("ChartType", "Charttype", "", "char");
   QUERYVIEWER1Container.setProp("Title", "Title", "", "char");
   QUERYVIEWER1Container.setProp("PlotSeries", "Plotseries", "", "char");
   QUERYVIEWER1Container.setProp("ShowValues", "Showvalues", false, "boolean");
   QUERYVIEWER1Container.setProp("XAxisLabels", "Xaxislabels", "", "char");
   QUERYVIEWER1Container.setProp("XAxisIntersectionAtZero", "Xaxisintersectionatzero", false, "boolean");
   QUERYVIEWER1Container.setProp("XAxisTitle", "Xaxistitle", "", "char");
   QUERYVIEWER1Container.setProp("YAxisTitle", "Yaxistitle", "", "char");
   QUERYVIEWER1Container.setProp("Paging", "Paging", true, "bool");
   QUERYVIEWER1Container.setProp("PageSize", "Pagesize", 20, "num");
   QUERYVIEWER1Container.setProp("CurrentPage", "Currentpage", '', "int");
   QUERYVIEWER1Container.setProp("ShowDataLabelsIn", "Showdatalabelsin", "", "char");
   QUERYVIEWER1Container.addV2CFunction('AV13ItemClickData', "vITEMCLICKDATA", 'SetItemClickData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV13ItemClickData=UC.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",UC.ParentObject.AV13ItemClickData); });
   QUERYVIEWER1Container.addV2CFunction('AV14ItemDoubleClickData', "vITEMDOUBLECLICKDATA", 'SetItemDoubleClickData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV14ItemDoubleClickData=UC.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",UC.ParentObject.AV14ItemDoubleClickData); });
   QUERYVIEWER1Container.addV2CFunction('AV9DragAndDropData', "vDRAGANDDROPDATA", 'SetDragAndDropData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV9DragAndDropData=UC.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",UC.ParentObject.AV9DragAndDropData); });
   QUERYVIEWER1Container.addV2CFunction('AV12FilterChangedData', "vFILTERCHANGEDDATA", 'SetFilterChangedData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV12FilterChangedData=UC.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",UC.ParentObject.AV12FilterChangedData); });
   QUERYVIEWER1Container.addV2CFunction('AV10ItemExpandData', "vITEMEXPANDDATA", 'SetItemExpandData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV10ItemExpandData=UC.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",UC.ParentObject.AV10ItemExpandData); });
   QUERYVIEWER1Container.addV2CFunction('AV11ItemCollapseData', "vITEMCOLLAPSEDATA", 'SetItemCollapseData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV11ItemCollapseData=UC.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",UC.ParentObject.AV11ItemCollapseData); });
   QUERYVIEWER1Container.setProp("AppSettings", "Appsettings", "", "char");
   QUERYVIEWER1Container.setProp("AvoidAutomaticShow", "Avoidautomaticshow", false, "boolean");
   QUERYVIEWER1Container.setProp("ExecuteShow", "Executeshow", false, "boolean");
   QUERYVIEWER1Container.setProp("ServiceUrl", "Serviceurl", "", "char");
   QUERYVIEWER1Container.setProp("GenType", "Gentype", "", "char");
   QUERYVIEWER1Container.setProp("DesignRenderOutputType", "Designrenderoutputtype", "", "char");
   QUERYVIEWER1Container.setProp("Visible", "Visible", true, "bool");
   QUERYVIEWER1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(QUERYVIEWER1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.AV7Axes = [ ] ;
   this.Events = {"e121g2_client": ["ENTER", true] ,"e131g2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
});