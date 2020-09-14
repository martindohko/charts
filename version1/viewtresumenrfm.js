gx.evt.autoSkip = false;
gx.define('version1.viewtresumenrfm', false, function () {
   this.ServerClass =  "version1.viewtresumenrfm" ;
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
      this.AV11LoadAllTabs=gx.fn.getControlValue("vLOADALLTABS") ;
      this.AV7SelectedTabCode=gx.fn.getControlValue("vSELECTEDTABCODE") ;
      this.AV12Region=gx.fn.getIntegerValue("vREGION",',') ;
      this.AV13Sucursal=gx.fn.getIntegerValue("vSUCURSAL",',') ;
      this.AV6TabCode=gx.fn.getControlValue("vTABCODE") ;
      this.AV12Region=gx.fn.getIntegerValue("vREGION",',') ;
      this.AV13Sucursal=gx.fn.getIntegerValue("vSUCURSAL",',') ;
      this.AV11LoadAllTabs=gx.fn.getControlValue("vLOADALLTABS") ;
      this.AV7SelectedTabCode=gx.fn.getControlValue("vSELECTEDTABCODE") ;
   };
   this.s112_client=function()
   {
      if ( this.AV11LoadAllTabs || ( this.AV7SelectedTabCode == "" ) || ( this.AV7SelectedTabCode == "General" ) )
      {
         this.createWebComponent('Generalwc','Version1.tResumenRFMGeneral',[this.AV12Region,this.AV13Sucursal]);
      }
   };
   this.e130c1_client=function()
   {
      this.clearMessages();
      this.AV7SelectedTabCode =  this.TABContainer.ActivePageControlName  ;
      this.AV11LoadAllTabs =  false  ;
      this.s112_client();
      this.refreshOutputs([{av:'AV7SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{ctrl:'GENERALWC'}]);
      return gx.$.Deferred().resolve();
   };
   this.e140c2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e150c2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,24,25,27,28,29];
   this.GXLastCtrlId =29;
   this.TABContainer = gx.uc.getNew(this, 22, 19, "gx.ui.controls.Tab", "TABContainer", "Tab", "TAB");
   var TABContainer = this.TABContainer;
   TABContainer.setProp("Enabled", "Enabled", true, "boolean");
   TABContainer.setProp("ActivePage", "Activepage", '', "int");
   TABContainer.setDynProp("ActivePageControlName", "Activepagecontrolname", "", "char");
   TABContainer.setProp("PageCount", "Pagecount", 1, "num");
   TABContainer.setProp("Class", "Class", "WWTab", "str");
   TABContainer.setProp("HistoryManagement", "Historymanagement", true, "bool");
   TABContainer.setProp("Visible", "Visible", true, "bool");
   TABContainer.setC2ShowFunction(function(UC) { UC.show(); });
   TABContainer.addEventHandler("TabChanged", this.e130c1_client);
   this.setUserControl(TABContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLETOP",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"VIEWTITLE", format:0,grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"VIEWALL", format:0,grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"TABTABLE_1",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id:19 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMANT",gxz:"Z3RFMAnt",gxold:"O3RFMAnt",gxvar:"A3RFMAnt",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A3RFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3RFMAnt=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("RFMANT",gx.O.A3RFMAnt,0)},c2v:function(){if(this.val()!==undefined)gx.O.A3RFMAnt=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("RFMANT",',')},nac:gx.falseFn};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"GENERAL_TITLE", format:0,grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"TABLEGENERAL",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   this.A3RFMAnt = 0 ;
   this.Z3RFMAnt = 0 ;
   this.O3RFMAnt = 0 ;
   this.A3RFMAnt = 0 ;
   this.AV12Region = 0 ;
   this.AV13Sucursal = 0 ;
   this.AV6TabCode = "" ;
   this.A2Sucursal = 0 ;
   this.A1Region = 0 ;
   this.AV11LoadAllTabs = false ;
   this.AV7SelectedTabCode = "" ;
   this.Events = {"e140c2_client": ["ENTER", true] ,"e150c2_client": ["CANCEL", true] ,"e130c1_client": ["TAB.TABCHANGED", false]};
   this.EvtParms["REFRESH"] = [[{av:'AV12Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'AV13Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true},{av:'AV6TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'A3RFMAnt',fld:'RFMANT',pic:'ZZZZZZZ9'}],[]];
   this.EvtParms["START"] = [[{av:'AV16Pgmname',fld:'vPGMNAME',pic:''},{av:'A1Region',fld:'REGION',pic:'ZZZ9'},{av:'AV12Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'A2Sucursal',fld:'SUCURSAL',pic:'ZZZ9'},{av:'AV13Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true},{av:'A3RFMAnt',fld:'RFMANT',pic:'ZZZZZZZ9'},{av:'AV6TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{av:'AV7SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''}],[{ctrl:'FORM',prop:'Caption'},{av:'gx.fn.getCtrlProperty("VIEWALL","Link")',ctrl:'VIEWALL',prop:'Link'},{av:'gx.fn.getCtrlProperty("VIEWALL","Visible")',ctrl:'VIEWALL',prop:'Visible'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{av:'AV7SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'this.TABContainer.ActivePageControlName',ctrl:'TAB',prop:'ActivePageControlName'},{ctrl:'GENERALWC'}]];
   this.EvtParms["TAB.TABCHANGED"] = [[{av:'this.TABContainer.ActivePageControlName',ctrl:'TAB',prop:'ActivePageControlName'},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{av:'AV7SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV12Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'AV13Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true}],[{av:'AV7SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV11LoadAllTabs',fld:'vLOADALLTABS',pic:''},{ctrl:'GENERALWC'}]];
   this.setVCMap("AV11LoadAllTabs", "vLOADALLTABS", 0, "boolean", 4, 0);
   this.setVCMap("AV7SelectedTabCode", "vSELECTEDTABCODE", 0, "char", 50, 0);
   this.setVCMap("AV12Region", "vREGION", 0, "int", 4, 0);
   this.setVCMap("AV13Sucursal", "vSUCURSAL", 0, "int", 4, 0);
   this.setVCMap("AV6TabCode", "vTABCODE", 0, "char", 50, 0);
   this.setVCMap("AV12Region", "vREGION", 0, "int", 4, 0);
   this.setVCMap("AV13Sucursal", "vSUCURSAL", 0, "int", 4, 0);
   this.setVCMap("AV11LoadAllTabs", "vLOADALLTABS", 0, "boolean", 4, 0);
   this.setVCMap("AV7SelectedTabCode", "vSELECTEDTABCODE", 0, "char", 50, 0);
   this.Initialize( );
   this.setComponent({id: "GENERALWC" ,GXClass: null , Prefix: "W0030" , lvl: 1 });
});
gx.wi( function() { gx.createParentObj(version1.viewtresumenrfm);});
