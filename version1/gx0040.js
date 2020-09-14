gx.evt.autoSkip = false;
gx.define('version1.gx0040', false, function () {
   this.ServerClass =  "version1.gx0040" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV9pParametro=gx.fn.getControlValue("vPPARAMETRO") ;
   };
   this.e14151_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class") == "AdvancedContainer" )
      {
         gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class", "AdvancedContainer"+" "+"AdvancedContainerVisible" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Class", gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" "+"BtnToggleActive" );
      }
      else
      {
         gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class", "AdvancedContainer" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Class", "BtnToggle" );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]);
      return gx.$.Deferred().resolve();
   };
   this.e11151_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("PARAMETROFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("PARAMETROFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCPARAMETRO","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("PARAMETROFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCPARAMETRO","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PARAMETROFILTERCONTAINER","Class")',ctrl:'PARAMETROFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCPARAMETRO","Visible")',ctrl:'vCPARAMETRO',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e12151_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CLAVE1FILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CLAVE1FILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLAVE1","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLAVE1FILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLAVE1","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLAVE1FILTERCONTAINER","Class")',ctrl:'CLAVE1FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVE1","Visible")',ctrl:'vCCLAVE1',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e13151_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CLAVE2FILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CLAVE2FILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLAVE2","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLAVE2FILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLAVE2","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLAVE2FILTERCONTAINER","Class")',ctrl:'CLAVE2FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVE2","Visible")',ctrl:'vCCLAVE2',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e17152_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e18151_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51];
   this.GXLastCtrlId =51;
   this.Grid1Container = new gx.grid.grid(this, 2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"version1.gx0040",[],false,1,false,true,10,true,false,false,"",0,"px",0,"px","New row",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Grid1Container = this.Grid1Container;
   Grid1Container.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");
   Grid1Container.addSingleLineEdit(26,46,"PARAMETRO","Parametro","","Parametro","svchar",0,"px",100,80,"left",null,[],26,"Parametro",true,0,false,false,"Attribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(27,47,"CLAVE1","Clave1","","Clave1","int",0,"px",4,4,"right",null,[],27,"Clave1",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(28,48,"CLAVE2","Clave2","","Clave2","int",0,"px",4,4,"right",null,[],28,"Clave2",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   this.Grid1Container.emptyText = "";
   this.setGrid(Grid1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"ADVANCEDCONTAINER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"PARAMETROFILTERCONTAINER",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"LBLPARAMETROFILTER", format:1,grid:0,evt:"e11151_client"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPARAMETRO",gxz:"ZV6cParametro",gxold:"OV6cParametro",gxvar:"AV6cParametro",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV6cParametro=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV6cParametro=Value},v2c:function(){gx.fn.setControlValue("vCPARAMETRO",gx.O.AV6cParametro,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV6cParametro=this.val()},val:function(){return gx.fn.getControlValue("vCPARAMETRO")},nac:gx.falseFn};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"CLAVE1FILTERCONTAINER",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"LBLCLAVE1FILTER", format:1,grid:0,evt:"e12151_client"};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLAVE1",gxz:"ZV7cClave1",gxold:"OV7cClave1",gxvar:"AV7cClave1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7cClave1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV7cClave1=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCLAVE1",gx.O.AV7cClave1,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV7cClave1=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCLAVE1",',')},nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"CLAVE2FILTERCONTAINER",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"LBLCLAVE2FILTER", format:1,grid:0,evt:"e13151_client"};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLAVE2",gxz:"ZV8cClave2",gxold:"OV8cClave2",gxvar:"AV8cClave2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8cClave2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV8cClave2=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCLAVE2",gx.O.AV8cClave2,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV8cClave2=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCLAVE2",',')},nac:gx.falseFn};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"GRIDTABLE",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"BTNTOGGLE",grid:0,evt:"e14151_client"};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[45]={ id:45 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV5LinkSelection=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5LinkSelection=Value},v2c:function(row){gx.fn.setGridMultimediaValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV13Linkselection_GXI)},c2v:function(row){gx.O.AV13Linkselection_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.AV5LinkSelection=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(44))},val_GXI:function(row){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",row || gx.fn.currentGridRowImpl(44))}, gxvar_GXI:'AV13Linkselection_GXI',nac:gx.falseFn};
   GXValidFnc[46]={ id:46 ,lvl:2,type:"svchar",len:100,dec:0,sign:false,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PARAMETRO",gxz:"Z26Parametro",gxold:"O26Parametro",gxvar:"A26Parametro",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A26Parametro=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z26Parametro=Value},v2c:function(row){gx.fn.setGridControlValue("PARAMETRO",row || gx.fn.currentGridRowImpl(44),gx.O.A26Parametro,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A26Parametro=this.val(row)},val:function(row){return gx.fn.getGridControlValue("PARAMETRO",row || gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};
   GXValidFnc[47]={ id:47 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLAVE1",gxz:"Z27Clave1",gxold:"O27Clave1",gxvar:"A27Clave1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A27Clave1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z27Clave1=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLAVE1",row || gx.fn.currentGridRowImpl(44),gx.O.A27Clave1,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A27Clave1=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLAVE1",row || gx.fn.currentGridRowImpl(44),',')},nac:gx.falseFn};
   GXValidFnc[48]={ id:48 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLAVE2",gxz:"Z28Clave2",gxold:"O28Clave2",gxvar:"A28Clave2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A28Clave2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z28Clave2=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLAVE2",row || gx.fn.currentGridRowImpl(44),gx.O.A28Clave2,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A28Clave2=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLAVE2",row || gx.fn.currentGridRowImpl(44),',')},nac:gx.falseFn};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"BTN_CANCEL",grid:0,evt:"e18151_client"};
   this.AV6cParametro = "" ;
   this.ZV6cParametro = "" ;
   this.OV6cParametro = "" ;
   this.AV7cClave1 = 0 ;
   this.ZV7cClave1 = 0 ;
   this.OV7cClave1 = 0 ;
   this.AV8cClave2 = 0 ;
   this.ZV8cClave2 = 0 ;
   this.OV8cClave2 = 0 ;
   this.ZV5LinkSelection = "" ;
   this.OV5LinkSelection = "" ;
   this.Z26Parametro = "" ;
   this.O26Parametro = "" ;
   this.Z27Clave1 = 0 ;
   this.O27Clave1 = 0 ;
   this.Z28Clave2 = 0 ;
   this.O28Clave2 = 0 ;
   this.AV6cParametro = "" ;
   this.AV7cClave1 = 0 ;
   this.AV8cClave2 = 0 ;
   this.AV9pParametro = "" ;
   this.AV5LinkSelection = "" ;
   this.A26Parametro = "" ;
   this.A27Clave1 = 0 ;
   this.A28Clave2 = 0 ;
   this.Events = {"e17152_client": ["ENTER", true] ,"e18151_client": ["CANCEL", true] ,"e14151_client": ["'TOGGLE'", false] ,"e11151_client": ["LBLPARAMETROFILTER.CLICK", false] ,"e12151_client": ["LBLCLAVE1FILTER.CLICK", false] ,"e13151_client": ["LBLCLAVE2FILTER.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametro',fld:'vCPARAMETRO',pic:''},{av:'AV7cClave1',fld:'vCCLAVE1',pic:'ZZZ9'},{av:'AV8cClave2',fld:'vCCLAVE2',pic:'ZZZ9'}],[]];
   this.EvtParms["START"] = [[],[{ctrl:'FORM',prop:'Caption'}]];
   this.EvtParms["'TOGGLE'"] = [[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]];
   this.EvtParms["LBLPARAMETROFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("PARAMETROFILTERCONTAINER","Class")',ctrl:'PARAMETROFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("PARAMETROFILTERCONTAINER","Class")',ctrl:'PARAMETROFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCPARAMETRO","Visible")',ctrl:'vCPARAMETRO',prop:'Visible'}]];
   this.EvtParms["LBLCLAVE1FILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLAVE1FILTERCONTAINER","Class")',ctrl:'CLAVE1FILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLAVE1FILTERCONTAINER","Class")',ctrl:'CLAVE1FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVE1","Visible")',ctrl:'vCCLAVE1',prop:'Visible'}]];
   this.EvtParms["LBLCLAVE2FILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLAVE2FILTERCONTAINER","Class")',ctrl:'CLAVE2FILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLAVE2FILTERCONTAINER","Class")',ctrl:'CLAVE2FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLAVE2","Visible")',ctrl:'vCCLAVE2',prop:'Visible'}]];
   this.EvtParms["LOAD"] = [[],[{av:'AV5LinkSelection',fld:'vLINKSELECTION',pic:''}]];
   this.EvtParms["ENTER"] = [[{av:'A26Parametro',fld:'PARAMETRO',pic:'',hsh:true}],[{av:'AV9pParametro',fld:'vPPARAMETRO',pic:''}]];
   this.EvtParms["GRID1_FIRSTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametro',fld:'vCPARAMETRO',pic:''},{av:'AV7cClave1',fld:'vCCLAVE1',pic:'ZZZ9'},{av:'AV8cClave2',fld:'vCCLAVE2',pic:'ZZZ9'}],[]];
   this.EvtParms["GRID1_PREVPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametro',fld:'vCPARAMETRO',pic:''},{av:'AV7cClave1',fld:'vCCLAVE1',pic:'ZZZ9'},{av:'AV8cClave2',fld:'vCCLAVE2',pic:'ZZZ9'}],[]];
   this.EvtParms["GRID1_NEXTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametro',fld:'vCPARAMETRO',pic:''},{av:'AV7cClave1',fld:'vCCLAVE1',pic:'ZZZ9'},{av:'AV8cClave2',fld:'vCCLAVE2',pic:'ZZZ9'}],[]];
   this.EvtParms["GRID1_LASTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cParametro',fld:'vCPARAMETRO',pic:''},{av:'AV7cClave1',fld:'vCCLAVE1',pic:'ZZZ9'},{av:'AV8cClave2',fld:'vCCLAVE2',pic:'ZZZ9'}],[]];
   this.setVCMap("AV9pParametro", "vPPARAMETRO", 0, "svchar", 100, 0);
   Grid1Container.addRefreshingVar(this.GXValidFnc[16]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[26]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[36]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[16]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[26]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[36]);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.gx0040);});
