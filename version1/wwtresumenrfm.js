gx.evt.autoSkip = false;
gx.define('version1.wwtresumenrfm', false, function () {
   this.ServerClass =  "version1.wwtresumenrfm" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.anyGridBaseTable = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV16ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE") ;
      this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.AV16ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE") ;
      this.AV22Pgmname=gx.fn.getControlValue("vPGMNAME") ;
   };
   this.e110d1_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("FILTERSCONTAINER","Class") == "AdvancedContainer" )
      {
         gx.fn.setCtrlProperty("FILTERSCONTAINER","Class", "AdvancedContainer"+" "+"AdvancedContainerVisible" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Class", "HideFiltersButton" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Caption", "Hide Filters" );
         gx.fn.setCtrlProperty("GRIDCELL","Class", "WWGridCell" );
      }
      else
      {
         gx.fn.setCtrlProperty("FILTERSCONTAINER","Class", "AdvancedContainer" );
         gx.fn.setCtrlProperty("GRIDCELL","Class", "WWGridCellExpanded" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Class", "ShowFiltersButton" );
         gx.fn.setCtrlProperty("BTNTOGGLE","Caption", "Show Filters" );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:'FILTERSCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:'GRIDCELL',prop:'Class'}]);
      return gx.$.Deferred().resolve();
   };
   this.e120d1_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("SUCURSALFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vSUCURSAL","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("SUCURSALFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vSUCURSAL","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class")',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vSUCURSAL","Visible")',ctrl:'vSUCURSAL',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e130d1_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("RFMANTFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vRFMANT","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("RFMANTFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vRFMANT","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class")',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vRFMANT","Visible")',ctrl:'vRFMANT',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e140d1_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("RFMACTFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vRFMACT","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("RFMACTFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vRFMACT","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class")',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vRFMACT","Visible")',ctrl:'vRFMACT',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e180d2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e190d2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,53,54,56,57,58,59,60];
   this.GXLastCtrlId =60;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",55,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"version1.wwtresumenrfm",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","New row",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(1,56,"REGION","Region","","Region","int",0,"px",4,4,"right",null,[],1,"Region",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(2,57,"SUCURSAL","Sucursal","","Sucursal","int",0,"px",4,4,"right",null,[],2,"Sucursal",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(3,58,"RFMANT","RFMAnt","","RFMAnt","int",0,"px",8,8,"right",null,[],3,"RFMAnt",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   GridContainer.addSingleLineEdit(4,59,"RFMACT","RFMAct","","RFMAct","int",0,"px",8,8,"right",null,[],4,"RFMAct",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(5,60,"CLIENTES","Clientes","","Clientes","int",0,"px",8,8,"right",null,[],5,"Clientes",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLETOP",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"BTNTOGGLE",grid:0,evt:"e110d1_client"};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"TITLETEXT", format:0,grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id:14 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vREGION",gxz:"ZV17Region",gxold:"OV17Region",gxvar:"AV17Region",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV17Region=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV17Region=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vREGION",gx.O.AV17Region,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV17Region=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vREGION",',')},nac:gx.falseFn};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"FILTERSCONTAINER",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"SUCURSALFILTERCONTAINER",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"LBLSUCURSALFILTER", format:1,grid:0,evt:"e120d1_client"};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id:27 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vSUCURSAL",gxz:"ZV18Sucursal",gxold:"OV18Sucursal",gxvar:"AV18Sucursal",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV18Sucursal=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV18Sucursal=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vSUCURSAL",gx.O.AV18Sucursal,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV18Sucursal=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vSUCURSAL",',')},nac:gx.falseFn};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"RFMANTFILTERCONTAINER",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"LBLRFMANTFILTER", format:1,grid:0,evt:"e130d1_client"};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id:37 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vRFMANT",gxz:"ZV13RFMAnt",gxold:"OV13RFMAnt",gxvar:"AV13RFMAnt",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV13RFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV13RFMAnt=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vRFMANT",gx.O.AV13RFMAnt,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV13RFMAnt=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vRFMANT",',')},nac:gx.falseFn};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"RFMACTFILTERCONTAINER",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"LBLRFMACTFILTER", format:1,grid:0,evt:"e140d1_client"};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id:47 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vRFMACT",gxz:"ZV19RFMAct",gxold:"OV19RFMAct",gxvar:"AV19RFMAct",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV19RFMAct=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV19RFMAct=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vRFMACT",gx.O.AV19RFMAct,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV19RFMAct=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vRFMACT",',')},nac:gx.falseFn};
   GXValidFnc[48]={ id: 48, fld:"GRIDCELL",grid:0};
   GXValidFnc[49]={ id: 49, fld:"GRIDTABLE",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[56]={ id:56 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:55,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGION",gxz:"Z1Region",gxold:"O1Region",gxvar:"A1Region",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A1Region=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1Region=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("REGION",row || gx.fn.currentGridRowImpl(55),gx.O.A1Region,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A1Region=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("REGION",row || gx.fn.currentGridRowImpl(55),',')},nac:gx.falseFn};
   GXValidFnc[57]={ id:57 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:55,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSAL",gxz:"Z2Sucursal",gxold:"O2Sucursal",gxvar:"A2Sucursal",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A2Sucursal=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2Sucursal=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("SUCURSAL",row || gx.fn.currentGridRowImpl(55),gx.O.A2Sucursal,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A2Sucursal=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("SUCURSAL",row || gx.fn.currentGridRowImpl(55),',')},nac:gx.falseFn};
   GXValidFnc[58]={ id:58 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:55,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMANT",gxz:"Z3RFMAnt",gxold:"O3RFMAnt",gxvar:"A3RFMAnt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A3RFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3RFMAnt=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("RFMANT",row || gx.fn.currentGridRowImpl(55),gx.O.A3RFMAnt,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A3RFMAnt=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("RFMANT",row || gx.fn.currentGridRowImpl(55),',')},nac:gx.falseFn};
   GXValidFnc[59]={ id:59 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:55,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMACT",gxz:"Z4RFMAct",gxold:"O4RFMAct",gxvar:"A4RFMAct",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A4RFMAct=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z4RFMAct=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("RFMACT",row || gx.fn.currentGridRowImpl(55),gx.O.A4RFMAct,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A4RFMAct=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("RFMACT",row || gx.fn.currentGridRowImpl(55),',')},nac:gx.falseFn};
   GXValidFnc[60]={ id:60 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:55,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTES",gxz:"Z5Clientes",gxold:"O5Clientes",gxvar:"A5Clientes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A5Clientes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z5Clientes=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLIENTES",row || gx.fn.currentGridRowImpl(55),gx.O.A5Clientes,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A5Clientes=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLIENTES",row || gx.fn.currentGridRowImpl(55),',')},nac:gx.falseFn};
   this.AV17Region = 0 ;
   this.ZV17Region = 0 ;
   this.OV17Region = 0 ;
   this.AV18Sucursal = 0 ;
   this.ZV18Sucursal = 0 ;
   this.OV18Sucursal = 0 ;
   this.AV13RFMAnt = 0 ;
   this.ZV13RFMAnt = 0 ;
   this.OV13RFMAnt = 0 ;
   this.AV19RFMAct = 0 ;
   this.ZV19RFMAct = 0 ;
   this.OV19RFMAct = 0 ;
   this.Z1Region = 0 ;
   this.O1Region = 0 ;
   this.Z2Sucursal = 0 ;
   this.O2Sucursal = 0 ;
   this.Z3RFMAnt = 0 ;
   this.O3RFMAnt = 0 ;
   this.Z4RFMAct = 0 ;
   this.O4RFMAct = 0 ;
   this.Z5Clientes = 0 ;
   this.O5Clientes = 0 ;
   this.AV17Region = 0 ;
   this.AV18Sucursal = 0 ;
   this.AV13RFMAnt = 0 ;
   this.AV19RFMAct = 0 ;
   this.A1Region = 0 ;
   this.A2Sucursal = 0 ;
   this.A3RFMAnt = 0 ;
   this.A4RFMAct = 0 ;
   this.A5Clientes = 0 ;
   this.AV16ADVANCED_LABEL_TEMPLATE = "" ;
   this.AV22Pgmname = "" ;
   this.Events = {"e180d2_client": ["ENTER", true] ,"e190d2_client": ["CANCEL", true] ,"e110d1_client": ["'TOGGLE'", false] ,"e120d1_client": ["LBLSUCURSALFILTER.CLICK", false] ,"e130d1_client": ["LBLRFMANTFILTER.CLICK", false] ,"e140d1_client": ["LBLRFMACTFILTER.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("LBLSUCURSALFILTER","Caption")',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMANTFILTER","Caption")',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMACTFILTER","Caption")',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]];
   this.EvtParms["START"] = [[{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}],[{ctrl:'GRID',prop:'Rows'},{av:'gx.fn.getCtrlProperty("vSUCURSAL","Visible")',ctrl:'vSUCURSAL',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vRFMANT","Visible")',ctrl:'vRFMANT',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vRFMACT","Visible")',ctrl:'vRFMACT',prop:'Visible'},{ctrl:'FORM',prop:'Caption'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]];
   this.EvtParms["'TOGGLE'"] = [[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:'FILTERSCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:'FILTERSCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:'GRIDCELL',prop:'Class'}]];
   this.EvtParms["LBLSUCURSALFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class")',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class")',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vSUCURSAL","Visible")',ctrl:'vSUCURSAL',prop:'Visible'}]];
   this.EvtParms["LBLRFMANTFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class")',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class")',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vRFMANT","Visible")',ctrl:'vRFMANT',prop:'Visible'}]];
   this.EvtParms["LBLRFMACTFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class")',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class")',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vRFMACT","Visible")',ctrl:'vRFMACT',prop:'Visible'}]];
   this.EvtParms["GRID.LOAD"] = [[],[]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}],[{av:'gx.fn.getCtrlProperty("LBLSUCURSALFILTER","Caption")',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMANTFILTER","Caption")',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMACTFILTER","Caption")',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}],[{av:'gx.fn.getCtrlProperty("LBLSUCURSALFILTER","Caption")',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMANTFILTER","Caption")',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMACTFILTER","Caption")',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}],[{av:'gx.fn.getCtrlProperty("LBLSUCURSALFILTER","Caption")',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMANTFILTER","Caption")',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMACTFILTER","Caption")',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}],[{av:'gx.fn.getCtrlProperty("LBLSUCURSALFILTER","Caption")',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMANTFILTER","Caption")',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMACTFILTER","Caption")',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]];
   this.setVCMap("AV16ADVANCED_LABEL_TEMPLATE", "vADVANCED_LABEL_TEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV22Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV16ADVANCED_LABEL_TEMPLATE", "vADVANCED_LABEL_TEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV22Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV16ADVANCED_LABEL_TEMPLATE", "vADVANCED_LABEL_TEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV22Pgmname", "vPGMNAME", 0, "char", 129, 0);
   GridContainer.addRefreshingVar(this.GXValidFnc[14]);
   GridContainer.addRefreshingVar(this.GXValidFnc[27]);
   GridContainer.addRefreshingVar(this.GXValidFnc[37]);
   GridContainer.addRefreshingVar(this.GXValidFnc[47]);
   GridContainer.addRefreshingVar({rfrVar:"AV16ADVANCED_LABEL_TEMPLATE"});
   GridContainer.addRefreshingVar({rfrVar:"AV22Pgmname"});
   GridContainer.addRefreshingParm(this.GXValidFnc[14]);
   GridContainer.addRefreshingParm(this.GXValidFnc[27]);
   GridContainer.addRefreshingParm(this.GXValidFnc[37]);
   GridContainer.addRefreshingParm(this.GXValidFnc[47]);
   GridContainer.addRefreshingParm({rfrVar:"AV16ADVANCED_LABEL_TEMPLATE"});
   GridContainer.addRefreshingParm({rfrVar:"AV22Pgmname"});
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.wwtresumenrfm);});
