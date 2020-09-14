gx.evt.autoSkip = false;
gx.define('version1.wpinicio', false, function () {
   this.ServerClass =  "version1.wpinicio" ;
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
   this.e120w2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e130w2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,7,8,10,12,14,15,16,17,18,20,22,23,25,27,28,30,31];
   this.GXLastCtrlId =31;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"TABLE1",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   this.Events = {"e120w2_client": ["ENTER", true] ,"e130w2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.Initialize( );
   this.setComponent({id: "COMPONENT6" ,GXClass: "version1.wccantcli" , Prefix: "W0006" , lvl: 1 });
   this.setComponent({id: "COMPONENT1" ,GXClass: "version1.wcpiechartcli" , Prefix: "W0009" , lvl: 1 });
   this.setComponent({id: "COMPONENT4" ,GXClass: "version1.wcpiechartfac" , Prefix: "W0011" , lvl: 1 });
   this.setComponent({id: "COMPONENT5" ,GXClass: "version1.wcpiecharttks" , Prefix: "W0013" , lvl: 1 });
   this.setComponent({id: "COMPONENT2" ,GXClass: "version1.wccolumnchart" , Prefix: "W0019" , lvl: 1 });
   this.setComponent({id: "COMPONENT8" ,GXClass: "version1.wctable" , Prefix: "W0021" , lvl: 1 });
   this.setComponent({id: "COMPONENT10" ,GXClass: "version1.wctable" , Prefix: "W0024" , lvl: 1 });
   this.setComponent({id: "COMPONENT9" ,GXClass: "version1.wctable2" , Prefix: "W0026" , lvl: 1 });
   this.setComponent({id: "COMPONENT3" ,GXClass: "version1.wcsankey" , Prefix: "W0029" , lvl: 1 });
   this.setComponent({id: "COMPONENT7" ,GXClass: "version1.wclinechartfac" , Prefix: "W0032" , lvl: 1 });
});
gx.wi( function() { gx.createParentObj(version1.wpinicio);});
