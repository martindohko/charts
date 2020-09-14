gx.evt.autoSkip = false;
gx.define('version1.wcsemicirculo1', true, function (CmpContext) {
   this.ServerClass =  "version1.wcsemicirculo1" ;
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
   this.e131a2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e141a2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   this.UCSEMICIRCLE1Container = gx.uc.getNew(this, 6, 0, "Version1_UCSemicircle", this.CmpContext + "UCSEMICIRCLE1Container", "this", "UCSEMICIRCLE1");
   var UCSEMICIRCLE1Container = this.UCSEMICIRCLE1Container;
   UCSEMICIRCLE1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCSEMICIRCLE1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.Events = {"e131a2_client": ["ENTER", true] ,"e141a2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[],[]];
   this.Initialize( );
});
