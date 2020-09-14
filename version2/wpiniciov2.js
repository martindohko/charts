gx.evt.autoSkip = false;
gx.define('version2.wpiniciov2', false, function () {
   this.ServerClass =  "version2.wpiniciov2" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e121m2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e131m2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   this.UCSANKEYPLOTLY1Container = gx.uc.getNew(this, 6, 0, "Version2_UCSankeyPlotly", "UCSANKEYPLOTLY1Container", "Ucsankeyplotly1", "UCSANKEYPLOTLY1");
   var UCSANKEYPLOTLY1Container = this.UCSANKEYPLOTLY1Container;
   UCSANKEYPLOTLY1Container.setProp("Class", "Class", "", "char");
   UCSANKEYPLOTLY1Container.setProp("Enabled", "Enabled", true, "boolean");
   UCSANKEYPLOTLY1Container.setProp("Visible", "Visible", true, "bool");
   UCSANKEYPLOTLY1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCSANKEYPLOTLY1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.Events = {"e121m2_client": ["ENTER", true] ,"e131m2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version2.wpiniciov2);});
