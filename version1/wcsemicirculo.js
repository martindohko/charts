gx.evt.autoSkip = false;
gx.define('version1.wcsemicirculo', true, function (CmpContext) {
   this.ServerClass =  "version1.wcsemicirculo" ;
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
   this.e130l2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140l2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   this.UCSEMICIRCLE1Container = gx.uc.getNew(this, 6, 0, "UCSemicircle", this.CmpContext + "UCSEMICIRCLE1Container", "Ucsemicircle1", "UCSEMICIRCLE1");
   var UCSEMICIRCLE1Container = this.UCSEMICIRCLE1Container;
   UCSEMICIRCLE1Container.setProp("Class", "Class", "", "char");
   UCSEMICIRCLE1Container.setProp("Enabled", "Enabled", true, "boolean");
   UCSEMICIRCLE1Container.setDynProp("value", "Value", "2.3", "str");
   UCSEMICIRCLE1Container.setDynProp("text2remzise", "Text2remzise", "4", "str");
   UCSEMICIRCLE1Container.setDynProp("colour", "Colour", "green", "str");
   UCSEMICIRCLE1Container.setDynProp("text1remzise", "Text1remzise", "2", "str");
   UCSEMICIRCLE1Container.setDynProp("deg", "Deg", "83", "str");
   UCSEMICIRCLE1Container.setDynProp("percentage", "Percentage", "46", "str");
   UCSEMICIRCLE1Container.setProp("Visible", "Visible", true, "bool");
   UCSEMICIRCLE1Container.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCSEMICIRCLE1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCSEMICIRCLE1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.Events = {"e130l2_client": ["ENTER", true] ,"e140l2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[],[{av:'this.UCSEMICIRCLE1Container.percentage',ctrl:'UCSEMICIRCLE1',prop:'percentage'},{av:'this.UCSEMICIRCLE1Container.value',ctrl:'UCSEMICIRCLE1',prop:'value'},{av:'this.UCSEMICIRCLE1Container.deg',ctrl:'UCSEMICIRCLE1',prop:'deg'},{av:'this.UCSEMICIRCLE1Container.colour',ctrl:'UCSEMICIRCLE1',prop:'colour'},{av:'this.UCSEMICIRCLE1Container.text1remzise',ctrl:'UCSEMICIRCLE1',prop:'text1remzise'},{av:'this.UCSEMICIRCLE1Container.text2remzise',ctrl:'UCSEMICIRCLE1',prop:'text2remzise'}]];
   this.Initialize( );
});
