gx.evt.autoSkip = false;
gx.define('version2.wpinicio', false, function () {
   this.ServerClass =  "version2.wpinicio" ;
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
   this.e121n2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e131n2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10];
   this.GXLastCtrlId =10;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TEXTBLOCK1", format:0,grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   this.Events = {"e121n2_client": ["ENTER", true] ,"e131n2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
   this.setComponent({id: "COMPONENT1" ,GXClass: "version2.wcpieplotly" , Prefix: "W0009" , lvl: 1 });
   this.setComponent({id: "COMPONENT2" ,GXClass: "version2.wcsankeyplotly" , Prefix: "W0011" , lvl: 1 });
});
gx.wi( function() { gx.createParentObj(version2.wpinicio);});
