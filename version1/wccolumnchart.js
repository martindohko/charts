gx.evt.autoSkip = false;
gx.define('version1.wccolumnchart', true, function (CmpContext) {
   this.ServerClass =  "version1.wccolumnchart" ;
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
   this.e130v2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140v2_client=function()
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
   QUERYVIEWER1Container.setProp("ObjectId", "Objectid", "14", "str");
   QUERYVIEWER1Container.setProp("ObjectType", "Objecttype", "Query", "str");
   QUERYVIEWER1Container.setProp("QueryInfo", "Queryinfo", "", "char");
   QUERYVIEWER1Container.setProp("IsExternalQuery", "Isexternalquery", false, "boolean");
   QUERYVIEWER1Container.setProp("ExternalQueryResult", "Externalqueryresult", "", "char");
   QUERYVIEWER1Container.setProp("ObjectInfo", "Objectinfo", "", "char");
   QUERYVIEWER1Container.addV2CFunction('AV16Axes', "vAXES", 'SetAxes');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV16Axes=UC.GetAxes();gx.fn.setControlValue("vAXES",UC.ParentObject.AV16Axes); });
   QUERYVIEWER1Container.setProp("AllowChangeAxesOrder", "Allowchangeaxesorder", false, "bool");
   QUERYVIEWER1Container.addV2CFunction('AV14Parameters', "vPARAMETERS", 'SetParameters');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV14Parameters=UC.GetParameters();gx.fn.setControlValue("vPARAMETERS",UC.ParentObject.AV14Parameters); });
   QUERYVIEWER1Container.setProp("ObjectName", "Objectname", "QColumnChart", "str");
   QUERYVIEWER1Container.setProp("Object", "Objectcall", "", "str");
   QUERYVIEWER1Container.setProp("Class", "Class", "QueryViewer", "str");
   QUERYVIEWER1Container.setProp("ShrinkToFit", "Shrinktofit", false, "boolean");
   QUERYVIEWER1Container.setProp("AutoResize", "Autoresize", false, "boolean");
   QUERYVIEWER1Container.setProp("AutoResizeType", "Autoresizetype", "", "char");
   QUERYVIEWER1Container.setProp("Width", "Width", "100%", "str");
   QUERYVIEWER1Container.setProp("Height", "Height", "100%", "str");
   QUERYVIEWER1Container.setProp("Axes Selectors", "Showaxesselectors", "", "char");
   QUERYVIEWER1Container.setProp("FontFamily", "Fontfamily", "", "char");
   QUERYVIEWER1Container.setProp("FontSize", "Fontsize", '', "int");
   QUERYVIEWER1Container.setProp("FontColor", "Fontcolor", '', "int");
   QUERYVIEWER1Container.setProp("AutoRefreshGroup", "Autorefreshgroup", "", "str");
   QUERYVIEWER1Container.setProp("DisableColumnSort", "Disablecolumnsort", false, "boolean");
   QUERYVIEWER1Container.setProp("AllowSelection", "Allowselection", false, "bool");
   QUERYVIEWER1Container.setProp("RememberLayout", "Rememberlayout", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToXML", "Exporttoxml", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToHTML", "Exporttohtml", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToXLS", "Exporttoxls", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToXLSX", "Exporttoxlsx", true, "bool");
   QUERYVIEWER1Container.setProp("ExportToPDF", "Exporttopdf", true, "bool");
   QUERYVIEWER1Container.setProp("Type", "Type", "Chart", "str");
   QUERYVIEWER1Container.setProp("ShowDataAs", "Showdataas", "", "char");
   QUERYVIEWER1Container.setProp("Orientation", "Orientation", "", "char");
   QUERYVIEWER1Container.setProp("IncludeTrend", "Includetrend", false, "boolean");
   QUERYVIEWER1Container.setProp("TrendPeriod", "Trendperiod", "", "char");
   QUERYVIEWER1Container.setProp("IncludeSparkline", "Includesparkline", false, "boolean");
   QUERYVIEWER1Container.setProp("IncludeMaxAndMin", "Includemaxandmin", false, "boolean");
   QUERYVIEWER1Container.setProp("ChartType", "Charttype", "Column", "str");
   QUERYVIEWER1Container.setProp("Title", "Title", "", "str");
   QUERYVIEWER1Container.setProp("PlotSeries", "Plotseries", "InTheSameChart", "str");
   QUERYVIEWER1Container.setProp("ShowValues", "Showvalues", true, "bool");
   QUERYVIEWER1Container.setProp("XAxisLabels", "Xaxislabels", "Horizontally", "str");
   QUERYVIEWER1Container.setProp("XAxisIntersectionAtZero", "Xaxisintersectionatzero", true, "bool");
   QUERYVIEWER1Container.setProp("XAxisTitle", "Xaxistitle", "RFM", "str");
   QUERYVIEWER1Container.setProp("YAxisTitle", "Yaxistitle", "Clientes", "str");
   QUERYVIEWER1Container.setProp("Paging", "Paging", false, "boolean");
   QUERYVIEWER1Container.setProp("PageSize", "Pagesize", '', "int");
   QUERYVIEWER1Container.setProp("CurrentPage", "Currentpage", '', "int");
   QUERYVIEWER1Container.setProp("ShowDataLabelsIn", "Showdatalabelsin", "", "char");
   QUERYVIEWER1Container.addV2CFunction('AV10ItemClickData', "vITEMCLICKDATA", 'SetItemClickData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV10ItemClickData=UC.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",UC.ParentObject.AV10ItemClickData); });
   QUERYVIEWER1Container.addV2CFunction('AV22ItemDoubleClickData', "vITEMDOUBLECLICKDATA", 'SetItemDoubleClickData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV22ItemDoubleClickData=UC.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",UC.ParentObject.AV22ItemDoubleClickData); });
   QUERYVIEWER1Container.addV2CFunction('AV18DragAndDropData', "vDRAGANDDROPDATA", 'SetDragAndDropData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV18DragAndDropData=UC.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",UC.ParentObject.AV18DragAndDropData); });
   QUERYVIEWER1Container.addV2CFunction('AV21FilterChangedData', "vFILTERCHANGEDDATA", 'SetFilterChangedData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV21FilterChangedData=UC.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",UC.ParentObject.AV21FilterChangedData); });
   QUERYVIEWER1Container.addV2CFunction('AV19ItemExpandData', "vITEMEXPANDDATA", 'SetItemExpandData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV19ItemExpandData=UC.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",UC.ParentObject.AV19ItemExpandData); });
   QUERYVIEWER1Container.addV2CFunction('AV20ItemCollapseData', "vITEMCOLLAPSEDATA", 'SetItemCollapseData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV20ItemCollapseData=UC.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",UC.ParentObject.AV20ItemCollapseData); });
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
   this.AV16Axes = [ ] ;
   this.Events = {"e130v2_client": ["ENTER", true] ,"e140v2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[],[]];
   this.Initialize( );
});
