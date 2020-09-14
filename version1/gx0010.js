gx.evt.autoSkip = false;
gx.define('version1.gx0010', false, function () {
   this.ServerClass =  "version1.gx0010" ;
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
      this.AV11pRegion=gx.fn.getIntegerValue("vPREGION",',') ;
      this.AV12pSucursal=gx.fn.getIntegerValue("vPSUCURSAL",',') ;
   };
   this.e16081_client=function()
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
   this.e11081_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("REGIONFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("REGIONFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCREGION","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("REGIONFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCREGION","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("REGIONFILTERCONTAINER","Class")',ctrl:'REGIONFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCREGION","Visible")',ctrl:'vCREGION',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e12081_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("SUCURSALFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCSUCURSAL","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("SUCURSALFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCSUCURSAL","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class")',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCSUCURSAL","Visible")',ctrl:'vCSUCURSAL',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e13081_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("RFMANTFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCRFMANT","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("RFMANTFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCRFMANT","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class")',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCRFMANT","Visible")',ctrl:'vCRFMANT',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e14081_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("RFMACTFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCRFMACT","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("RFMACTFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCRFMACT","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class")',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCRFMACT","Visible")',ctrl:'vCRFMACT',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e15081_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CLIENTESFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CLIENTESFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLIENTES","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLIENTESFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLIENTES","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLIENTESFILTERCONTAINER","Class")',ctrl:'CLIENTESFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLIENTES","Visible")',ctrl:'vCCLIENTES',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e19082_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e20081_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,65,66,67,68,69,70,71,72,73];
   this.GXLastCtrlId =73;
   this.Grid1Container = new gx.grid.grid(this, 2,"WbpLvl2",64,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"version1.gx0010",[],false,1,false,true,10,true,false,false,"",0,"px",0,"px","New row",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Grid1Container = this.Grid1Container;
   Grid1Container.addBitmap("&Linkselection","vLINKSELECTION",65,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");
   Grid1Container.addSingleLineEdit(1,66,"REGION","Region","","Region","int",0,"px",4,4,"right",null,[],1,"Region",true,0,false,false,"Attribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(2,67,"SUCURSAL","Sucursal","","Sucursal","int",0,"px",4,4,"right",null,[],2,"Sucursal",true,0,false,false,"Attribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(3,68,"RFMANT","RFMAnt","","RFMAnt","int",0,"px",8,8,"right",null,[],3,"RFMAnt",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(4,69,"RFMACT","RFMAct","","RFMAct","int",0,"px",8,8,"right",null,[],4,"RFMAct",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(5,70,"CLIENTES","Clientes","","Clientes","int",0,"px",8,8,"right",null,[],5,"Clientes",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   this.Grid1Container.emptyText = "";
   this.setGrid(Grid1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"ADVANCEDCONTAINER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"REGIONFILTERCONTAINER",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"LBLREGIONFILTER", format:1,grid:0,evt:"e11081_client"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCREGION",gxz:"ZV6cRegion",gxold:"OV6cRegion",gxvar:"AV6cRegion",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV6cRegion=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV6cRegion=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCREGION",gx.O.AV6cRegion,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV6cRegion=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCREGION",',')},nac:gx.falseFn};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"SUCURSALFILTERCONTAINER",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"LBLSUCURSALFILTER", format:1,grid:0,evt:"e12081_client"};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSUCURSAL",gxz:"ZV7cSucursal",gxold:"OV7cSucursal",gxvar:"AV7cSucursal",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7cSucursal=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV7cSucursal=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCSUCURSAL",gx.O.AV7cSucursal,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV7cSucursal=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCSUCURSAL",',')},nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"RFMANTFILTERCONTAINER",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"LBLRFMANTFILTER", format:1,grid:0,evt:"e13081_client"};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRFMANT",gxz:"ZV8cRFMAnt",gxold:"OV8cRFMAnt",gxvar:"AV8cRFMAnt",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8cRFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV8cRFMAnt=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCRFMANT",gx.O.AV8cRFMAnt,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV8cRFMAnt=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCRFMANT",',')},nac:gx.falseFn};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"RFMACTFILTERCONTAINER",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"LBLRFMACTFILTER", format:1,grid:0,evt:"e14081_client"};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRFMACT",gxz:"ZV9cRFMAct",gxold:"OV9cRFMAct",gxvar:"AV9cRFMAct",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV9cRFMAct=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV9cRFMAct=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCRFMACT",gx.O.AV9cRFMAct,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV9cRFMAct=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCRFMACT",',')},nac:gx.falseFn};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id: 49, fld:"CLIENTESFILTERCONTAINER",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"LBLCLIENTESFILTER", format:1,grid:0,evt:"e15081_client"};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLIENTES",gxz:"ZV10cClientes",gxold:"OV10cClientes",gxvar:"AV10cClientes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV10cClientes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV10cClientes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCLIENTES",gx.O.AV10cClientes,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV10cClientes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCLIENTES",',')},nac:gx.falseFn};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"GRIDTABLE",grid:0};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"BTNTOGGLE",grid:0,evt:"e16081_client"};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"",grid:0};
   GXValidFnc[65]={ id:65 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV5LinkSelection=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5LinkSelection=Value},v2c:function(row){gx.fn.setGridMultimediaValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(64),gx.O.AV5LinkSelection,gx.O.AV16Linkselection_GXI)},c2v:function(row){gx.O.AV16Linkselection_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.AV5LinkSelection=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(64))},val_GXI:function(row){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",row || gx.fn.currentGridRowImpl(64))}, gxvar_GXI:'AV16Linkselection_GXI',nac:gx.falseFn};
   GXValidFnc[66]={ id:66 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGION",gxz:"Z1Region",gxold:"O1Region",gxvar:"A1Region",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A1Region=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1Region=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("REGION",row || gx.fn.currentGridRowImpl(64),gx.O.A1Region,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A1Region=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("REGION",row || gx.fn.currentGridRowImpl(64),',')},nac:gx.falseFn};
   GXValidFnc[67]={ id:67 ,lvl:2,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSAL",gxz:"Z2Sucursal",gxold:"O2Sucursal",gxvar:"A2Sucursal",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A2Sucursal=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2Sucursal=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("SUCURSAL",row || gx.fn.currentGridRowImpl(64),gx.O.A2Sucursal,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A2Sucursal=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("SUCURSAL",row || gx.fn.currentGridRowImpl(64),',')},nac:gx.falseFn};
   GXValidFnc[68]={ id:68 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMANT",gxz:"Z3RFMAnt",gxold:"O3RFMAnt",gxvar:"A3RFMAnt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A3RFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3RFMAnt=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("RFMANT",row || gx.fn.currentGridRowImpl(64),gx.O.A3RFMAnt,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A3RFMAnt=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("RFMANT",row || gx.fn.currentGridRowImpl(64),',')},nac:gx.falseFn};
   GXValidFnc[69]={ id:69 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMACT",gxz:"Z4RFMAct",gxold:"O4RFMAct",gxvar:"A4RFMAct",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A4RFMAct=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z4RFMAct=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("RFMACT",row || gx.fn.currentGridRowImpl(64),gx.O.A4RFMAct,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A4RFMAct=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("RFMACT",row || gx.fn.currentGridRowImpl(64),',')},nac:gx.falseFn};
   GXValidFnc[70]={ id:70 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTES",gxz:"Z5Clientes",gxold:"O5Clientes",gxvar:"A5Clientes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A5Clientes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z5Clientes=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLIENTES",row || gx.fn.currentGridRowImpl(64),gx.O.A5Clientes,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A5Clientes=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLIENTES",row || gx.fn.currentGridRowImpl(64),',')},nac:gx.falseFn};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id: 73, fld:"BTN_CANCEL",grid:0,evt:"e20081_client"};
   this.AV6cRegion = 0 ;
   this.ZV6cRegion = 0 ;
   this.OV6cRegion = 0 ;
   this.AV7cSucursal = 0 ;
   this.ZV7cSucursal = 0 ;
   this.OV7cSucursal = 0 ;
   this.AV8cRFMAnt = 0 ;
   this.ZV8cRFMAnt = 0 ;
   this.OV8cRFMAnt = 0 ;
   this.AV9cRFMAct = 0 ;
   this.ZV9cRFMAct = 0 ;
   this.OV9cRFMAct = 0 ;
   this.AV10cClientes = 0 ;
   this.ZV10cClientes = 0 ;
   this.OV10cClientes = 0 ;
   this.ZV5LinkSelection = "" ;
   this.OV5LinkSelection = "" ;
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
   this.AV6cRegion = 0 ;
   this.AV7cSucursal = 0 ;
   this.AV8cRFMAnt = 0 ;
   this.AV9cRFMAct = 0 ;
   this.AV10cClientes = 0 ;
   this.AV11pRegion = 0 ;
   this.AV12pSucursal = 0 ;
   this.AV5LinkSelection = "" ;
   this.A1Region = 0 ;
   this.A2Sucursal = 0 ;
   this.A3RFMAnt = 0 ;
   this.A4RFMAct = 0 ;
   this.A5Clientes = 0 ;
   this.Events = {"e19082_client": ["ENTER", true] ,"e20081_client": ["CANCEL", true] ,"e16081_client": ["'TOGGLE'", false] ,"e11081_client": ["LBLREGIONFILTER.CLICK", false] ,"e12081_client": ["LBLSUCURSALFILTER.CLICK", false] ,"e13081_client": ["LBLRFMANTFILTER.CLICK", false] ,"e14081_client": ["LBLRFMACTFILTER.CLICK", false] ,"e15081_client": ["LBLCLIENTESFILTER.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cRegion',fld:'vCREGION',pic:'ZZZ9'},{av:'AV7cSucursal',fld:'vCSUCURSAL',pic:'ZZZ9'},{av:'AV8cRFMAnt',fld:'vCRFMANT',pic:'ZZZZZZZ9'},{av:'AV9cRFMAct',fld:'vCRFMACT',pic:'ZZZZZZZ9'},{av:'AV10cClientes',fld:'vCCLIENTES',pic:'ZZZZZZZ9'}],[]];
   this.EvtParms["START"] = [[],[{ctrl:'FORM',prop:'Caption'}]];
   this.EvtParms["'TOGGLE'"] = [[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]];
   this.EvtParms["LBLREGIONFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("REGIONFILTERCONTAINER","Class")',ctrl:'REGIONFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("REGIONFILTERCONTAINER","Class")',ctrl:'REGIONFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCREGION","Visible")',ctrl:'vCREGION',prop:'Visible'}]];
   this.EvtParms["LBLSUCURSALFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class")',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("SUCURSALFILTERCONTAINER","Class")',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCSUCURSAL","Visible")',ctrl:'vCSUCURSAL',prop:'Visible'}]];
   this.EvtParms["LBLRFMANTFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class")',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("RFMANTFILTERCONTAINER","Class")',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCRFMANT","Visible")',ctrl:'vCRFMANT',prop:'Visible'}]];
   this.EvtParms["LBLRFMACTFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class")',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("RFMACTFILTERCONTAINER","Class")',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCRFMACT","Visible")',ctrl:'vCRFMACT',prop:'Visible'}]];
   this.EvtParms["LBLCLIENTESFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLIENTESFILTERCONTAINER","Class")',ctrl:'CLIENTESFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLIENTESFILTERCONTAINER","Class")',ctrl:'CLIENTESFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLIENTES","Visible")',ctrl:'vCCLIENTES',prop:'Visible'}]];
   this.EvtParms["LOAD"] = [[],[{av:'AV5LinkSelection',fld:'vLINKSELECTION',pic:''}]];
   this.EvtParms["ENTER"] = [[{av:'A1Region',fld:'REGION',pic:'ZZZ9',hsh:true},{av:'A2Sucursal',fld:'SUCURSAL',pic:'ZZZ9',hsh:true}],[{av:'AV11pRegion',fld:'vPREGION',pic:'ZZZ9'},{av:'AV12pSucursal',fld:'vPSUCURSAL',pic:'ZZZ9'}]];
   this.EvtParms["GRID1_FIRSTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cRegion',fld:'vCREGION',pic:'ZZZ9'},{av:'AV7cSucursal',fld:'vCSUCURSAL',pic:'ZZZ9'},{av:'AV8cRFMAnt',fld:'vCRFMANT',pic:'ZZZZZZZ9'},{av:'AV9cRFMAct',fld:'vCRFMACT',pic:'ZZZZZZZ9'},{av:'AV10cClientes',fld:'vCCLIENTES',pic:'ZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_PREVPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cRegion',fld:'vCREGION',pic:'ZZZ9'},{av:'AV7cSucursal',fld:'vCSUCURSAL',pic:'ZZZ9'},{av:'AV8cRFMAnt',fld:'vCRFMANT',pic:'ZZZZZZZ9'},{av:'AV9cRFMAct',fld:'vCRFMACT',pic:'ZZZZZZZ9'},{av:'AV10cClientes',fld:'vCCLIENTES',pic:'ZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_NEXTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cRegion',fld:'vCREGION',pic:'ZZZ9'},{av:'AV7cSucursal',fld:'vCSUCURSAL',pic:'ZZZ9'},{av:'AV8cRFMAnt',fld:'vCRFMANT',pic:'ZZZZZZZ9'},{av:'AV9cRFMAct',fld:'vCRFMACT',pic:'ZZZZZZZ9'},{av:'AV10cClientes',fld:'vCCLIENTES',pic:'ZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_LASTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cRegion',fld:'vCREGION',pic:'ZZZ9'},{av:'AV7cSucursal',fld:'vCSUCURSAL',pic:'ZZZ9'},{av:'AV8cRFMAnt',fld:'vCRFMANT',pic:'ZZZZZZZ9'},{av:'AV9cRFMAct',fld:'vCRFMACT',pic:'ZZZZZZZ9'},{av:'AV10cClientes',fld:'vCCLIENTES',pic:'ZZZZZZZ9'}],[]];
   this.setVCMap("AV11pRegion", "vPREGION", 0, "int", 4, 0);
   this.setVCMap("AV12pSucursal", "vPSUCURSAL", 0, "int", 4, 0);
   Grid1Container.addRefreshingVar(this.GXValidFnc[16]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[26]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[36]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[46]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[56]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[16]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[26]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[36]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[46]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[56]);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.gx0010);});
