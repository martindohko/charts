gx.evt.autoSkip = false;
gx.define('version2.wcpieplotly', true, function (CmpContext) {
   this.ServerClass =  "version2.wcpieplotly" ;
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
   this.e121o2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e131o2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   this.UCPIECHART1Container = gx.uc.getNew(this, 6, 0, "Version2_UCPiePlotly", this.CmpContext + "UCPIECHART1Container", "Ucpiechart1", "UCPIECHART1");
   var UCPIECHART1Container = this.UCPIECHART1Container;
   UCPIECHART1Container.setProp("Class", "Class", "", "char");
   UCPIECHART1Container.setProp("Enabled", "Enabled", true, "boolean");
   UCPIECHART1Container.setProp("Visible", "Visible", true, "bool");
   UCPIECHART1Container.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCPIECHART1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCPIECHART1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.Events = {"e121o2_client": ["ENTER", true] ,"e131o2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
});
