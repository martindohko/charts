gx.evt.autoSkip = false;
gx.define('version1.notauthorized', false, function () {
   this.ServerClass =  "version1.notauthorized" ;
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
      this.GxObject=gx.fn.getControlValue("vGXOBJECT") ;
   };
   this.e130a2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140a2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[4,7,13,16];
   this.GXLastCtrlId =16;
   GXValidFnc[4]={ id: 4, fld:"TABLE1",grid:0};
   GXValidFnc[7]={ id: 7, fld:"TITLETEXT", format:0,grid:0};
   GXValidFnc[13]={ id: 13, fld:"TABLE2",grid:0};
   GXValidFnc[16]={ id: 16, fld:"TABLE3",grid:0};
   this.GxObject = "" ;
   this.Events = {"e130a2_client": ["ENTER", true] ,"e140a2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[{av:'AV8Pgmname',fld:'vPGMNAME',pic:''}],[{ctrl:'RECENTLINKS'}]];
   this.setVCMap("GxObject", "vGXOBJECT", 0, "svchar", 256, 0);
   this.Initialize( );
   this.setComponent({id: "HEADERBC" ,GXClass: null , Prefix: "W0002" , lvl: 1 });
   this.setComponent({id: "RECENTLINKS" ,GXClass: null , Prefix: "W0003" , lvl: 1 });
});
gx.wi( function() { gx.createParentObj(version1.notauthorized);});
