gx.evt.autoSkip = false;
gx.define('version1.wcsankey', true, function (CmpContext) {
   this.ServerClass =  "version1.wcsankey" ;
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
   this.e130j2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140j2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5];
   this.GXLastCtrlId =5;
   this.UCSANKEYDIAGRAM1Container = gx.uc.getNew(this, 6, 0, "Version1_UCSankeyDiagram", this.CmpContext + "UCSANKEYDIAGRAM1Container", "Ucsankeydiagram1", "UCSANKEYDIAGRAM1");
   var UCSANKEYDIAGRAM1Container = this.UCSANKEYDIAGRAM1Container;
   UCSANKEYDIAGRAM1Container.setProp("Class", "Class", "", "char");
   UCSANKEYDIAGRAM1Container.setProp("Enabled", "Enabled", true, "boolean");
   UCSANKEYDIAGRAM1Container.addV2CFunction('AV5Resumen', "vRESUMEN", 'setResumen');
   UCSANKEYDIAGRAM1Container.addC2VFunction(function(UC) { UC.ParentObject.AV5Resumen=UC.getResumen();gx.fn.setControlValue("vRESUMEN",UC.ParentObject.AV5Resumen); });
   UCSANKEYDIAGRAM1Container.setProp("ResumenCurrentIndex", "Resumencurrentindex", 0, "num");
   UCSANKEYDIAGRAM1Container.setProp("Visible", "Visible", true, "bool");
   UCSANKEYDIAGRAM1Container.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCSANKEYDIAGRAM1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   this.AV5Resumen = [ ] ;
   this.A1Region = 0 ;
   this.A2Sucursal = 0 ;
   this.A5Clientes = 0 ;
   this.A4RFMAct = 0 ;
   this.A3RFMAnt = 0 ;
   this.Events = {"e130j2_client": ["ENTER", true] ,"e140j2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[{av:'AV8corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV7corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'A3RFMAnt',fld:'RFMANT',pic:'ZZZZZZZ9'},{av:'A4RFMAct',fld:'RFMACT',pic:'ZZZZZZZ9'},{av:'A1Region',fld:'REGION',pic:'ZZZ9'},{av:'A2Sucursal',fld:'SUCURSAL',pic:'ZZZ9'},{av:'A5Clientes',fld:'CLIENTES',pic:'ZZZZZZZ9'},{av:'AV5Resumen',fld:'vRESUMEN',pic:''}],[{av:'AV7corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV8corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV5Resumen',fld:'vRESUMEN',pic:''}]];
   this.Initialize( );
});
