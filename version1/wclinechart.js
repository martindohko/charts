gx.evt.autoSkip = false;
gx.define('version1.wclinechart', true, function (CmpContext) {
   this.ServerClass =  "version1.wclinechart" ;
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
      this.AV20corte1=gx.fn.getIntegerValue("vCORTE1",',') ;
      this.AV19corte2=gx.fn.getIntegerValue("vCORTE2",',') ;
   };
   this.e120m2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e130m2_client=function()
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
   QUERYVIEWER1Container.setProp("ObjectId", "Objectid", "4", "str");
   QUERYVIEWER1Container.setProp("ObjectType", "Objecttype", "Query", "str");
   QUERYVIEWER1Container.setProp("QueryInfo", "Queryinfo", "", "char");
   QUERYVIEWER1Container.setProp("IsExternalQuery", "Isexternalquery", false, "boolean");
   QUERYVIEWER1Container.setProp("ExternalQueryResult", "Externalqueryresult", "", "char");
   QUERYVIEWER1Container.setProp("ObjectInfo", "Objectinfo", "", "char");
   QUERYVIEWER1Container.addV2CFunction('AV11Axes', "vAXES", 'SetAxes');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV11Axes=UC.GetAxes();gx.fn.setControlValue("vAXES",UC.ParentObject.AV11Axes); });
   QUERYVIEWER1Container.setProp("AllowChangeAxesOrder", "Allowchangeaxesorder", false, "bool");
   QUERYVIEWER1Container.addV2CFunction('AV9Parameters', "vPARAMETERS", 'SetParameters');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV9Parameters=UC.GetParameters();gx.fn.setControlValue("vPARAMETERS",UC.ParentObject.AV9Parameters); });
   QUERYVIEWER1Container.setProp("ObjectName", "Objectname", "QLineChart", "str");
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
   QUERYVIEWER1Container.setProp("ChartType", "Charttype", "Line", "str");
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
   QUERYVIEWER1Container.addV2CFunction('AV17ItemClickData', "vITEMCLICKDATA", 'SetItemClickData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV17ItemClickData=UC.GetItemClickData();gx.fn.setControlValue("vITEMCLICKDATA",UC.ParentObject.AV17ItemClickData); });
   QUERYVIEWER1Container.addV2CFunction('AV18ItemDoubleClickData', "vITEMDOUBLECLICKDATA", 'SetItemDoubleClickData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV18ItemDoubleClickData=UC.GetItemDoubleClickData();gx.fn.setControlValue("vITEMDOUBLECLICKDATA",UC.ParentObject.AV18ItemDoubleClickData); });
   QUERYVIEWER1Container.addV2CFunction('AV13DragAndDropData', "vDRAGANDDROPDATA", 'SetDragAndDropData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV13DragAndDropData=UC.GetDragAndDropData();gx.fn.setControlValue("vDRAGANDDROPDATA",UC.ParentObject.AV13DragAndDropData); });
   QUERYVIEWER1Container.addV2CFunction('AV16FilterChangedData', "vFILTERCHANGEDDATA", 'SetFilterChangedData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV16FilterChangedData=UC.GetFilterChangedData();gx.fn.setControlValue("vFILTERCHANGEDDATA",UC.ParentObject.AV16FilterChangedData); });
   QUERYVIEWER1Container.addV2CFunction('AV14ItemExpandData', "vITEMEXPANDDATA", 'SetItemExpandData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV14ItemExpandData=UC.GetItemExpandData();gx.fn.setControlValue("vITEMEXPANDDATA",UC.ParentObject.AV14ItemExpandData); });
   QUERYVIEWER1Container.addV2CFunction('AV15ItemCollapseData', "vITEMCOLLAPSEDATA", 'SetItemCollapseData');
   QUERYVIEWER1Container.addC2VFunction(function(UC) { UC.ParentObject.AV15ItemCollapseData=UC.GetItemCollapseData();gx.fn.setControlValue("vITEMCOLLAPSEDATA",UC.ParentObject.AV15ItemCollapseData); });
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
   this.AV11Axes = [ ] ;
   this.AV20corte1 = 0 ;
   this.AV19corte2 = 0 ;
   this.Events = {"e120m2_client": ["ENTER", true] ,"e130m2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["LOAD"] = [[{av:'AV20corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV9Parameters',fld:'vPARAMETERS',pic:''},{av:'AV19corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'}],[{av:'AV9Parameters',fld:'vPARAMETERS',pic:''}]];
   this.setVCMap("AV20corte1", "vCORTE1", 0, "int", 8, 0);
   this.setVCMap("AV19corte2", "vCORTE2", 0, "int", 8, 0);
   this.Initialize( );
});
