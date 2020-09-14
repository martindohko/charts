gx.evt.autoSkip = false;
gx.define('version1.wwresumenrfmglobal', false, function () {
   this.ServerClass =  "version1.wwresumenrfmglobal" ;
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
      this.AV13OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",',') ;
      this.AV18ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE") ;
      this.AV21Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.AV13OrderedBy=gx.fn.getIntegerValue("vORDEREDBY",',') ;
      this.AV18ADVANCED_LABEL_TEMPLATE=gx.fn.getControlValue("vADVANCED_LABEL_TEMPLATE") ;
      this.AV21Pgmname=gx.fn.getControlValue("vPGMNAME") ;
   };
   this.e11121_client=function()
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
   this.e12121_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("ORDERBYCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
      }
      else
      {
         gx.fn.setCtrlProperty("ORDERBYCONTAINER","Class", "AdvancedContainerItem" );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class")',ctrl:'ORDERBYCONTAINER',prop:'Class'}]);
      return gx.$.Deferred().resolve();
   };
   this.e13121_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CORTE1FILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCORTE1","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CORTE1FILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCORTE1","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class")',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCORTE1","Visible")',ctrl:'vCORTE1',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e14121_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CORTE2FILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCORTE2","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CORTE2FILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCORTE2","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class")',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCORTE2","Visible")',ctrl:'vCORTE2',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e15121_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("RFMFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vRFM","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("RFMFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vRFM","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class")',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vRFM","Visible")',ctrl:'vRFM',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e16122_client=function()
   {
      return this.executeServerEvent("ORDERBY1.CLICK", true, null, false, true);
   };
   this.e17122_client=function()
   {
      return this.executeServerEvent("ORDERBY2.CLICK", true, null, false, true);
   };
   this.e18122_client=function()
   {
      return this.executeServerEvent("ORDERBY3.CLICK", true, null, false, true);
   };
   this.e19122_client=function()
   {
      return this.executeServerEvent("ORDERBY4.CLICK", true, null, false, true);
   };
   this.e23122_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e24122_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,71,72,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91];
   this.GXLastCtrlId =91;
   this.GridContainer = new gx.grid.grid(this, 2,"WbpLvl2",73,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"version1.wwresumenrfmglobal",[],false,1,false,true,0,true,false,false,"",0,"px",0,"px","New row",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var GridContainer = this.GridContainer;
   GridContainer.addSingleLineEdit(7,74,"PERIODO","Periodo","","Periodo","svchar",0,"px",6,6,"left",null,[],7,"Periodo",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(8,75,"CORTE1","Corte1","","Corte1","int",0,"px",8,8,"right",null,[],8,"Corte1",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   GridContainer.addSingleLineEdit(9,76,"CORTE2","Corte2","","Corte2","int",0,"px",8,8,"right",null,[],9,"Corte2",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(10,77,"RFM","RFM","","RFM","int",0,"px",8,8,"right",null,[],10,"RFM",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(11,78,"CLIENTESDELANIO","Del Anio","","ClientesDelAnio","int",0,"px",10,10,"right",null,[],11,"ClientesDelAnio",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(12,79,"CLIENTESDELMES","Del Mes","","ClientesDelMes","int",0,"px",10,10,"right",null,[],12,"ClientesDelMes",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(13,80,"MINRECENCIA","Recencia","","MinRecencia","int",0,"px",10,10,"right",null,[],13,"MinRecencia",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(14,81,"MAXRECENCIA","Recencia","","MaxRecencia","int",0,"px",10,10,"right",null,[],14,"MaxRecencia",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(24,82,"AVGRECENCIA","Recencia","","AvgRecencia","int",0,"px",10,10,"right",null,[],24,"AvgRecencia",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(15,83,"MINFRECUENCIA","Frecuencia","","MinFrecuencia","decimal",0,"px",10,10,"right",null,[],15,"MinFrecuencia",true,6,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(16,84,"MAXFRECUENCIA","Frecuencia","","MaxFrecuencia","decimal",0,"px",10,10,"right",null,[],16,"MaxFrecuencia",true,6,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(17,85,"AVGFRECUENCIA","Frecuencia","","AvgFrecuencia","decimal",0,"px",10,10,"right",null,[],17,"AvgFrecuencia",true,6,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(18,86,"MINVALORMONETARIO","Valor Monetario","","MinValorMonetario","decimal",0,"px",12,12,"right",null,[],18,"MinValorMonetario",true,8,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(19,87,"MAXVALORMONETARIO","Valor Monetario","","MaxValorMonetario","decimal",0,"px",12,12,"right",null,[],19,"MaxValorMonetario",true,8,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(20,88,"AVGVALORMONETARIO","Valor Monetario","","AvgValorMonetario","decimal",0,"px",12,12,"right",null,[],20,"AvgValorMonetario",true,8,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(21,89,"COMPRASTICKETS_ANIOMOVIL","Tickets_Anio Movil","","ComprasTickets_AnioMovil","int",0,"px",12,12,"right",null,[],21,"ComprasTickets_AnioMovil",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(22,90,"COMPRASIMPORTE_ANIOMOVIL","Importe_Anio Movil","","ComprasImporte_AnioMovil","decimal",0,"px",12,12,"right",null,[],22,"ComprasImporte_AnioMovil",true,2,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   GridContainer.addSingleLineEdit(23,91,"COMPRASARTICULOS_ANIOMOVIL","Articulos_Anio Movil","","ComprasArticulos_AnioMovil","int",0,"px",12,12,"right",null,[],23,"ComprasArticulos_AnioMovil",true,0,false,false,"Attribute",1,"WWColumn WWOptionalColumn");
   this.GridContainer.emptyText = "";
   this.setGrid(GridContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLETOP",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"BTNTOGGLE",grid:0,evt:"e11121_client"};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"TITLETEXT", format:0,grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id:14 ,lvl:0,type:"svchar",len:6,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vPERIODO",gxz:"ZV14Periodo",gxold:"OV14Periodo",gxvar:"AV14Periodo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV14Periodo=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV14Periodo=Value},v2c:function(){gx.fn.setControlValue("vPERIODO",gx.O.AV14Periodo,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV14Periodo=this.val()},val:function(){return gx.fn.getControlValue("vPERIODO")},nac:gx.falseFn};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"FILTERSCONTAINER",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"ORDERBYCONTAINER",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"LBLORDERBY", format:1,grid:0,evt:"e12121_client"};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"ORDERBYCONTAINER2",grid:0};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"ORDERBY1", format:0,grid:0,evt:"e16122_client"};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"ORDERBY2", format:0,grid:0,evt:"e17122_client"};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"ORDERBY3", format:0,grid:0,evt:"e18122_client"};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"ORDERBY4", format:0,grid:0,evt:"e19122_client"};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"CORTE1FILTERCONTAINER",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"LBLCORTE1FILTER", format:1,grid:0,evt:"e13121_client"};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id:45 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vCORTE1",gxz:"ZV15Corte1",gxold:"OV15Corte1",gxvar:"AV15Corte1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV15Corte1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV15Corte1=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCORTE1",gx.O.AV15Corte1,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV15Corte1=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCORTE1",',')},nac:gx.falseFn};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"CORTE2FILTERCONTAINER",grid:0};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"LBLCORTE2FILTER", format:1,grid:0,evt:"e14121_client"};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id:55 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vCORTE2",gxz:"ZV16Corte2",gxold:"OV16Corte2",gxvar:"AV16Corte2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV16Corte2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV16Corte2=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCORTE2",gx.O.AV16Corte2,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV16Corte2=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCORTE2",',')},nac:gx.falseFn};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"RFMFILTERCONTAINER",grid:0};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"LBLRFMFILTER", format:1,grid:0,evt:"e15121_client"};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"",grid:0};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id:65 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vRFM",gxz:"ZV17RFM",gxold:"OV17RFM",gxvar:"AV17RFM",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV17RFM=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV17RFM=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vRFM",gx.O.AV17RFM,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV17RFM=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vRFM",',')},nac:gx.falseFn};
   GXValidFnc[66]={ id: 66, fld:"GRIDCELL",grid:0};
   GXValidFnc[67]={ id: 67, fld:"GRIDTABLE",grid:0};
   GXValidFnc[68]={ id: 68, fld:"",grid:0};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[74]={ id:74 ,lvl:2,type:"svchar",len:6,dec:0,sign:false,ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERIODO",gxz:"Z7Periodo",gxold:"O7Periodo",gxvar:"A7Periodo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A7Periodo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z7Periodo=Value},v2c:function(row){gx.fn.setGridControlValue("PERIODO",row || gx.fn.currentGridRowImpl(73),gx.O.A7Periodo,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A7Periodo=this.val(row)},val:function(row){return gx.fn.getGridControlValue("PERIODO",row || gx.fn.currentGridRowImpl(73))},nac:gx.falseFn};
   GXValidFnc[75]={ id:75 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORTE1",gxz:"Z8Corte1",gxold:"O8Corte1",gxvar:"A8Corte1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A8Corte1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z8Corte1=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CORTE1",row || gx.fn.currentGridRowImpl(73),gx.O.A8Corte1,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A8Corte1=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CORTE1",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[76]={ id:76 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORTE2",gxz:"Z9Corte2",gxold:"O9Corte2",gxvar:"A9Corte2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A9Corte2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z9Corte2=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CORTE2",row || gx.fn.currentGridRowImpl(73),gx.O.A9Corte2,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A9Corte2=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CORTE2",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[77]={ id:77 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFM",gxz:"Z10RFM",gxold:"O10RFM",gxvar:"A10RFM",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A10RFM=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z10RFM=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("RFM",row || gx.fn.currentGridRowImpl(73),gx.O.A10RFM,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A10RFM=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("RFM",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[78]={ id:78 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTESDELANIO",gxz:"Z11ClientesDelAnio",gxold:"O11ClientesDelAnio",gxvar:"A11ClientesDelAnio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A11ClientesDelAnio=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11ClientesDelAnio=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLIENTESDELANIO",row || gx.fn.currentGridRowImpl(73),gx.O.A11ClientesDelAnio,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A11ClientesDelAnio=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLIENTESDELANIO",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[79]={ id:79 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTESDELMES",gxz:"Z12ClientesDelMes",gxold:"O12ClientesDelMes",gxvar:"A12ClientesDelMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A12ClientesDelMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z12ClientesDelMes=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLIENTESDELMES",row || gx.fn.currentGridRowImpl(73),gx.O.A12ClientesDelMes,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A12ClientesDelMes=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLIENTESDELMES",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[80]={ id:80 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINRECENCIA",gxz:"Z13MinRecencia",gxold:"O13MinRecencia",gxvar:"A13MinRecencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A13MinRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z13MinRecencia=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MINRECENCIA",row || gx.fn.currentGridRowImpl(73),gx.O.A13MinRecencia,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A13MinRecencia=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MINRECENCIA",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[81]={ id:81 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXRECENCIA",gxz:"Z14MaxRecencia",gxold:"O14MaxRecencia",gxvar:"A14MaxRecencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A14MaxRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14MaxRecencia=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MAXRECENCIA",row || gx.fn.currentGridRowImpl(73),gx.O.A14MaxRecencia,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A14MaxRecencia=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MAXRECENCIA",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[82]={ id:82 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGRECENCIA",gxz:"Z24AvgRecencia",gxold:"O24AvgRecencia",gxvar:"A24AvgRecencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A24AvgRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z24AvgRecencia=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("AVGRECENCIA",row || gx.fn.currentGridRowImpl(73),gx.O.A24AvgRecencia,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A24AvgRecencia=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("AVGRECENCIA",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[83]={ id:83 ,lvl:2,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINFRECUENCIA",gxz:"Z15MinFrecuencia",gxold:"O15MinFrecuencia",gxvar:"A15MinFrecuencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A15MinFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z15MinFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("MINFRECUENCIA",row || gx.fn.currentGridRowImpl(73),gx.O.A15MinFrecuencia,6,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A15MinFrecuencia=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("MINFRECUENCIA",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[84]={ id:84 ,lvl:2,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXFRECUENCIA",gxz:"Z16MaxFrecuencia",gxold:"O16MaxFrecuencia",gxvar:"A16MaxFrecuencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A16MaxFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z16MaxFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("MAXFRECUENCIA",row || gx.fn.currentGridRowImpl(73),gx.O.A16MaxFrecuencia,6,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A16MaxFrecuencia=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("MAXFRECUENCIA",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[85]={ id:85 ,lvl:2,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGFRECUENCIA",gxz:"Z17AvgFrecuencia",gxold:"O17AvgFrecuencia",gxvar:"A17AvgFrecuencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A17AvgFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z17AvgFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("AVGFRECUENCIA",row || gx.fn.currentGridRowImpl(73),gx.O.A17AvgFrecuencia,6,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A17AvgFrecuencia=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("AVGFRECUENCIA",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[86]={ id:86 ,lvl:2,type:"decimal",len:12,dec:8,sign:false,pic:"ZZ9.99999999",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINVALORMONETARIO",gxz:"Z18MinValorMonetario",gxold:"O18MinValorMonetario",gxvar:"A18MinValorMonetario",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A18MinValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z18MinValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("MINVALORMONETARIO",row || gx.fn.currentGridRowImpl(73),gx.O.A18MinValorMonetario,8,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A18MinValorMonetario=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("MINVALORMONETARIO",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[87]={ id:87 ,lvl:2,type:"decimal",len:12,dec:8,sign:false,pic:"ZZ9.99999999",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXVALORMONETARIO",gxz:"Z19MaxValorMonetario",gxold:"O19MaxValorMonetario",gxvar:"A19MaxValorMonetario",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A19MaxValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z19MaxValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("MAXVALORMONETARIO",row || gx.fn.currentGridRowImpl(73),gx.O.A19MaxValorMonetario,8,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A19MaxValorMonetario=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("MAXVALORMONETARIO",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[88]={ id:88 ,lvl:2,type:"decimal",len:12,dec:8,sign:false,pic:"ZZ9.99999999",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGVALORMONETARIO",gxz:"Z20AvgValorMonetario",gxold:"O20AvgValorMonetario",gxvar:"A20AvgValorMonetario",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A20AvgValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z20AvgValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("AVGVALORMONETARIO",row || gx.fn.currentGridRowImpl(73),gx.O.A20AvgValorMonetario,8,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A20AvgValorMonetario=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("AVGVALORMONETARIO",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[89]={ id:89 ,lvl:2,type:"int",len:12,dec:0,sign:false,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPRASTICKETS_ANIOMOVIL",gxz:"Z21ComprasTickets_AnioMovil",gxold:"O21ComprasTickets_AnioMovil",gxvar:"A21ComprasTickets_AnioMovil",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A21ComprasTickets_AnioMovil=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z21ComprasTickets_AnioMovil=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("COMPRASTICKETS_ANIOMOVIL",row || gx.fn.currentGridRowImpl(73),gx.O.A21ComprasTickets_AnioMovil,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A21ComprasTickets_AnioMovil=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("COMPRASTICKETS_ANIOMOVIL",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   GXValidFnc[90]={ id:90 ,lvl:2,type:"decimal",len:12,dec:2,sign:false,pic:"ZZZZZZZZ9.99",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPRASIMPORTE_ANIOMOVIL",gxz:"Z22ComprasImporte_AnioMovil",gxold:"O22ComprasImporte_AnioMovil",gxvar:"A22ComprasImporte_AnioMovil",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A22ComprasImporte_AnioMovil=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z22ComprasImporte_AnioMovil=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("COMPRASIMPORTE_ANIOMOVIL",row || gx.fn.currentGridRowImpl(73),gx.O.A22ComprasImporte_AnioMovil,2,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A22ComprasImporte_AnioMovil=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("COMPRASIMPORTE_ANIOMOVIL",row || gx.fn.currentGridRowImpl(73),',','.')},nac:gx.falseFn};
   GXValidFnc[91]={ id:91 ,lvl:2,type:"int",len:12,dec:0,sign:false,pic:"ZZZZZZZZZZZ9",ro:1,isacc:0,grid:73,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPRASARTICULOS_ANIOMOVIL",gxz:"Z23ComprasArticulos_AnioMovil",gxold:"O23ComprasArticulos_AnioMovil",gxvar:"A23ComprasArticulos_AnioMovil",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A23ComprasArticulos_AnioMovil=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z23ComprasArticulos_AnioMovil=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("COMPRASARTICULOS_ANIOMOVIL",row || gx.fn.currentGridRowImpl(73),gx.O.A23ComprasArticulos_AnioMovil,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A23ComprasArticulos_AnioMovil=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("COMPRASARTICULOS_ANIOMOVIL",row || gx.fn.currentGridRowImpl(73),',')},nac:gx.falseFn};
   this.AV14Periodo = "" ;
   this.ZV14Periodo = "" ;
   this.OV14Periodo = "" ;
   this.AV15Corte1 = 0 ;
   this.ZV15Corte1 = 0 ;
   this.OV15Corte1 = 0 ;
   this.AV16Corte2 = 0 ;
   this.ZV16Corte2 = 0 ;
   this.OV16Corte2 = 0 ;
   this.AV17RFM = 0 ;
   this.ZV17RFM = 0 ;
   this.OV17RFM = 0 ;
   this.Z7Periodo = "" ;
   this.O7Periodo = "" ;
   this.Z8Corte1 = 0 ;
   this.O8Corte1 = 0 ;
   this.Z9Corte2 = 0 ;
   this.O9Corte2 = 0 ;
   this.Z10RFM = 0 ;
   this.O10RFM = 0 ;
   this.Z11ClientesDelAnio = 0 ;
   this.O11ClientesDelAnio = 0 ;
   this.Z12ClientesDelMes = 0 ;
   this.O12ClientesDelMes = 0 ;
   this.Z13MinRecencia = 0 ;
   this.O13MinRecencia = 0 ;
   this.Z14MaxRecencia = 0 ;
   this.O14MaxRecencia = 0 ;
   this.Z24AvgRecencia = 0 ;
   this.O24AvgRecencia = 0 ;
   this.Z15MinFrecuencia = 0 ;
   this.O15MinFrecuencia = 0 ;
   this.Z16MaxFrecuencia = 0 ;
   this.O16MaxFrecuencia = 0 ;
   this.Z17AvgFrecuencia = 0 ;
   this.O17AvgFrecuencia = 0 ;
   this.Z18MinValorMonetario = 0 ;
   this.O18MinValorMonetario = 0 ;
   this.Z19MaxValorMonetario = 0 ;
   this.O19MaxValorMonetario = 0 ;
   this.Z20AvgValorMonetario = 0 ;
   this.O20AvgValorMonetario = 0 ;
   this.Z21ComprasTickets_AnioMovil = 0 ;
   this.O21ComprasTickets_AnioMovil = 0 ;
   this.Z22ComprasImporte_AnioMovil = 0 ;
   this.O22ComprasImporte_AnioMovil = 0 ;
   this.Z23ComprasArticulos_AnioMovil = 0 ;
   this.O23ComprasArticulos_AnioMovil = 0 ;
   this.AV14Periodo = "" ;
   this.AV15Corte1 = 0 ;
   this.AV16Corte2 = 0 ;
   this.AV17RFM = 0 ;
   this.A7Periodo = "" ;
   this.A8Corte1 = 0 ;
   this.A9Corte2 = 0 ;
   this.A10RFM = 0 ;
   this.A11ClientesDelAnio = 0 ;
   this.A12ClientesDelMes = 0 ;
   this.A13MinRecencia = 0 ;
   this.A14MaxRecencia = 0 ;
   this.A24AvgRecencia = 0 ;
   this.A15MinFrecuencia = 0 ;
   this.A16MaxFrecuencia = 0 ;
   this.A17AvgFrecuencia = 0 ;
   this.A18MinValorMonetario = 0 ;
   this.A19MaxValorMonetario = 0 ;
   this.A20AvgValorMonetario = 0 ;
   this.A21ComprasTickets_AnioMovil = 0 ;
   this.A22ComprasImporte_AnioMovil = 0 ;
   this.A23ComprasArticulos_AnioMovil = 0 ;
   this.AV13OrderedBy = 0 ;
   this.AV18ADVANCED_LABEL_TEMPLATE = "" ;
   this.AV21Pgmname = "" ;
   this.Events = {"e16122_client": ["ORDERBY1.CLICK", true] ,"e17122_client": ["ORDERBY2.CLICK", true] ,"e18122_client": ["ORDERBY3.CLICK", true] ,"e19122_client": ["ORDERBY4.CLICK", true] ,"e23122_client": ["ENTER", true] ,"e24122_client": ["CANCEL", true] ,"e11121_client": ["'TOGGLE'", false] ,"e12121_client": ["LBLORDERBY.CLICK", false] ,"e13121_client": ["LBLCORTE1FILTER.CLICK", false] ,"e14121_client": ["LBLCORTE2FILTER.CLICK", false] ,"e15121_client": ["LBLRFMFILTER.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["START"] = [[{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}],[{ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("vCORTE1","Visible")',ctrl:'vCORTE1',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vCORTE2","Visible")',ctrl:'vCORTE2',prop:'Visible'},{av:'gx.fn.getCtrlProperty("vRFM","Visible")',ctrl:'vRFM',prop:'Visible'},{ctrl:'FORM',prop:'Caption'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]];
   this.EvtParms["'TOGGLE'"] = [[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:'FILTERSCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("FILTERSCONTAINER","Class")',ctrl:'FILTERSCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{av:'gx.fn.getCtrlProperty("GRIDCELL","Class")',ctrl:'GRIDCELL',prop:'Class'}]];
   this.EvtParms["LBLORDERBY.CLICK"] = [[{av:'gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class")',ctrl:'ORDERBYCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("ORDERBYCONTAINER","Class")',ctrl:'ORDERBYCONTAINER',prop:'Class'}]];
   this.EvtParms["ORDERBY1.CLICK"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("ORDERBY1","Class")',ctrl:'ORDERBY1',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY2","Class")',ctrl:'ORDERBY2',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY3","Class")',ctrl:'ORDERBY3',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY4","Class")',ctrl:'ORDERBY4',prop:'Class'},{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["ORDERBY2.CLICK"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("ORDERBY1","Class")',ctrl:'ORDERBY1',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY2","Class")',ctrl:'ORDERBY2',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY3","Class")',ctrl:'ORDERBY3',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY4","Class")',ctrl:'ORDERBY4',prop:'Class'},{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["ORDERBY3.CLICK"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("ORDERBY1","Class")',ctrl:'ORDERBY1',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY2","Class")',ctrl:'ORDERBY2',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY3","Class")',ctrl:'ORDERBY3',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY4","Class")',ctrl:'ORDERBY4',prop:'Class'},{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["ORDERBY4.CLICK"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}],[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'gx.fn.getCtrlProperty("ORDERBY1","Class")',ctrl:'ORDERBY1',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY2","Class")',ctrl:'ORDERBY2',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY3","Class")',ctrl:'ORDERBY3',prop:'Class'},{av:'gx.fn.getCtrlProperty("ORDERBY4","Class")',ctrl:'ORDERBY4',prop:'Class'},{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["LBLCORTE1FILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class")',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class")',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCORTE1","Visible")',ctrl:'vCORTE1',prop:'Visible'}]];
   this.EvtParms["LBLCORTE2FILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class")',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class")',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCORTE2","Visible")',ctrl:'vCORTE2',prop:'Visible'}]];
   this.EvtParms["LBLRFMFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class")',ctrl:'RFMFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class")',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vRFM","Visible")',ctrl:'vRFM',prop:'Visible'}]];
   this.EvtParms["GRID.LOAD"] = [[],[]];
   this.EvtParms["GRID_FIRSTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["GRID_PREVPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["GRID_NEXTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.EvtParms["GRID_LASTPAGE"] = [[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}],[{av:'gx.fn.getCtrlProperty("LBLORDERBY","Caption")',ctrl:'LBLORDERBY',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE1FILTER","Caption")',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLCORTE2FILTER","Caption")',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'gx.fn.getCtrlProperty("LBLRFMFILTER","Caption")',ctrl:'LBLRFMFILTER',prop:'Caption'}]];
   this.setVCMap("AV13OrderedBy", "vORDEREDBY", 0, "int", 4, 0);
   this.setVCMap("AV18ADVANCED_LABEL_TEMPLATE", "vADVANCED_LABEL_TEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV21Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV13OrderedBy", "vORDEREDBY", 0, "int", 4, 0);
   this.setVCMap("AV18ADVANCED_LABEL_TEMPLATE", "vADVANCED_LABEL_TEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV21Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("AV13OrderedBy", "vORDEREDBY", 0, "int", 4, 0);
   this.setVCMap("AV18ADVANCED_LABEL_TEMPLATE", "vADVANCED_LABEL_TEMPLATE", 0, "char", 20, 0);
   this.setVCMap("AV21Pgmname", "vPGMNAME", 0, "char", 129, 0);
   GridContainer.addRefreshingVar(this.GXValidFnc[14]);
   GridContainer.addRefreshingVar(this.GXValidFnc[45]);
   GridContainer.addRefreshingVar(this.GXValidFnc[55]);
   GridContainer.addRefreshingVar(this.GXValidFnc[65]);
   GridContainer.addRefreshingVar({rfrVar:"AV13OrderedBy"});
   GridContainer.addRefreshingVar({rfrVar:"AV18ADVANCED_LABEL_TEMPLATE"});
   GridContainer.addRefreshingVar({rfrVar:"AV21Pgmname"});
   GridContainer.addRefreshingParm(this.GXValidFnc[14]);
   GridContainer.addRefreshingParm(this.GXValidFnc[45]);
   GridContainer.addRefreshingParm(this.GXValidFnc[55]);
   GridContainer.addRefreshingParm(this.GXValidFnc[65]);
   GridContainer.addRefreshingParm({rfrVar:"AV13OrderedBy"});
   GridContainer.addRefreshingParm({rfrVar:"AV18ADVANCED_LABEL_TEMPLATE"});
   GridContainer.addRefreshingParm({rfrVar:"AV21Pgmname"});
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.wwresumenrfmglobal);});
