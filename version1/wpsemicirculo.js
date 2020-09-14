gx.evt.autoSkip = false;
gx.define('version1.wpsemicirculo', false, function () {
   this.ServerClass =  "version1.wpsemicirculo" ;
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
   this.e120p2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e130p2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3];
   this.GXLastCtrlId =3;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   this.Events = {"e120p2_client": ["ENTER", true] ,"e130p2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.wpsemicirculo);});
