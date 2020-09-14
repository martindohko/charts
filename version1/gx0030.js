gx.evt.autoSkip = false;
gx.define('version1.gx0030', false, function () {
   this.ServerClass =  "version1.gx0030" ;
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
      this.AV13pPeriodo=gx.fn.getControlValue("vPPERIODO") ;
   };
   this.e18101_client=function()
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
   this.e11101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("PERIODOFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("PERIODOFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCPERIODO","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("PERIODOFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCPERIODO","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PERIODOFILTERCONTAINER","Class")',ctrl:'PERIODOFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCPERIODO","Visible")',ctrl:'vCPERIODO',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e12101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CORTE1FILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCORTE1","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CORTE1FILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCORTE1","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class")',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCORTE1","Visible")',ctrl:'vCCORTE1',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e13101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CORTE2FILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCORTE2","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CORTE2FILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCORTE2","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class")',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCORTE2","Visible")',ctrl:'vCCORTE2',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e14101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("RFMFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCRFM","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("RFMFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCRFM","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class")',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCRFM","Visible")',ctrl:'vCRFM',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e15101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CLIENTESDELANIOFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CLIENTESDELANIOFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLIENTESDELANIO","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLIENTESDELANIOFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLIENTESDELANIO","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLIENTESDELANIOFILTERCONTAINER","Class")',ctrl:'CLIENTESDELANIOFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLIENTESDELANIO","Visible")',ctrl:'vCCLIENTESDELANIO',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e16101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("CLIENTESDELMESFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("CLIENTESDELMESFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCCLIENTESDELMES","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("CLIENTESDELMESFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCCLIENTESDELMES","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("CLIENTESDELMESFILTERCONTAINER","Class")',ctrl:'CLIENTESDELMESFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLIENTESDELMES","Visible")',ctrl:'vCCLIENTESDELMES',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e17101_client=function()
   {
      this.clearMessages();
      if ( gx.fn.getCtrlProperty("MINRECENCIAFILTERCONTAINER","Class") == "AdvancedContainerItem" )
      {
         gx.fn.setCtrlProperty("MINRECENCIAFILTERCONTAINER","Class", "AdvancedContainerItem"+" "+"AdvancedContainerItemExpanded" );
         gx.fn.setCtrlProperty("vCMINRECENCIA","Visible", true );
      }
      else
      {
         gx.fn.setCtrlProperty("MINRECENCIAFILTERCONTAINER","Class", "AdvancedContainerItem" );
         gx.fn.setCtrlProperty("vCMINRECENCIA","Visible", false );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MINRECENCIAFILTERCONTAINER","Class")',ctrl:'MINRECENCIAFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCMINRECENCIA","Visible")',ctrl:'vCMINRECENCIA',prop:'Visible'}]);
      return gx.$.Deferred().resolve();
   };
   this.e21102_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e22101_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92,93,94,95,96,97,98];
   this.GXLastCtrlId =98;
   this.Grid1Container = new gx.grid.grid(this, 2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"version1.gx0030",[],false,1,false,true,10,true,false,false,"",0,"px",0,"px","New row",true,false,false,null,null,false,"",false,[1,1,1,1],false,0,true,false);
   var Grid1Container = this.Grid1Container;
   Grid1Container.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");
   Grid1Container.addSingleLineEdit(7,86,"PERIODO","Periodo","","Periodo","svchar",0,"px",6,6,"left",null,[],7,"Periodo",true,0,false,false,"Attribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(8,87,"CORTE1","Corte1","","Corte1","int",0,"px",8,8,"right",null,[],8,"Corte1",true,0,false,false,"DescriptionAttribute",1,"WWColumn");
   Grid1Container.addSingleLineEdit(9,88,"CORTE2","Corte2","","Corte2","int",0,"px",8,8,"right",null,[],9,"Corte2",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(10,89,"RFM","RFM","","RFM","int",0,"px",8,8,"right",null,[],10,"RFM",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(11,90,"CLIENTESDELANIO","Del Anio","","ClientesDelAnio","int",0,"px",10,10,"right",null,[],11,"ClientesDelAnio",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(12,91,"CLIENTESDELMES","Del Mes","","ClientesDelMes","int",0,"px",10,10,"right",null,[],12,"ClientesDelMes",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(13,92,"MINRECENCIA","Recencia","","MinRecencia","int",0,"px",10,10,"right",null,[],13,"MinRecencia",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(14,93,"MAXRECENCIA","Recencia","","MaxRecencia","int",0,"px",10,10,"right",null,[],14,"MaxRecencia",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(24,94,"AVGRECENCIA","Recencia","","AvgRecencia","int",0,"px",10,10,"right",null,[],24,"AvgRecencia",true,0,false,false,"Attribute",1,"WWColumn OptionalColumn");
   Grid1Container.addSingleLineEdit(15,95,"MINFRECUENCIA","Frecuencia","","MinFrecuencia","decimal",0,"px",10,10,"right",null,[],15,"MinFrecuencia",true,6,false,false,"Attribute",1,"WWColumn OptionalColumn");
   this.Grid1Container.emptyText = "";
   this.setGrid(Grid1Container);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAIN",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"ADVANCEDCONTAINER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"PERIODOFILTERCONTAINER",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"LBLPERIODOFILTER", format:1,grid:0,evt:"e11101_client"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"svchar",len:6,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPERIODO",gxz:"ZV6cPeriodo",gxold:"OV6cPeriodo",gxvar:"AV6cPeriodo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV6cPeriodo=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV6cPeriodo=Value},v2c:function(){gx.fn.setControlValue("vCPERIODO",gx.O.AV6cPeriodo,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV6cPeriodo=this.val()},val:function(){return gx.fn.getControlValue("vCPERIODO")},nac:gx.falseFn};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"CORTE1FILTERCONTAINER",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"LBLCORTE1FILTER", format:1,grid:0,evt:"e12101_client"};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCORTE1",gxz:"ZV7cCorte1",gxold:"OV7cCorte1",gxvar:"AV7cCorte1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7cCorte1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV7cCorte1=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCORTE1",gx.O.AV7cCorte1,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV7cCorte1=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCORTE1",',')},nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"CORTE2FILTERCONTAINER",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"LBLCORTE2FILTER", format:1,grid:0,evt:"e13101_client"};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id:36 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCORTE2",gxz:"ZV8cCorte2",gxold:"OV8cCorte2",gxvar:"AV8cCorte2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8cCorte2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV8cCorte2=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCORTE2",gx.O.AV8cCorte2,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV8cCorte2=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCORTE2",',')},nac:gx.falseFn};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"RFMFILTERCONTAINER",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"LBLRFMFILTER", format:1,grid:0,evt:"e14101_client"};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id: 44, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id:46 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCRFM",gxz:"ZV9cRFM",gxold:"OV9cRFM",gxvar:"AV9cRFM",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV9cRFM=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV9cRFM=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCRFM",gx.O.AV9cRFM,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV9cRFM=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCRFM",',')},nac:gx.falseFn};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id: 49, fld:"CLIENTESDELANIOFILTERCONTAINER",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"LBLCLIENTESDELANIOFILTER", format:1,grid:0,evt:"e15101_client"};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLIENTESDELANIO",gxz:"ZV10cClientesDelAnio",gxold:"OV10cClientesDelAnio",gxvar:"AV10cClientesDelAnio",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV10cClientesDelAnio=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV10cClientesDelAnio=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCLIENTESDELANIO",gx.O.AV10cClientesDelAnio,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV10cClientesDelAnio=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCLIENTESDELANIO",',')},nac:gx.falseFn};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id: 59, fld:"CLIENTESDELMESFILTERCONTAINER",grid:0};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"LBLCLIENTESDELMESFILTER", format:1,grid:0,evt:"e16101_client"};
   GXValidFnc[63]={ id: 63, fld:"",grid:0};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCLIENTESDELMES",gxz:"ZV11cClientesDelMes",gxold:"OV11cClientesDelMes",gxvar:"AV11cClientesDelMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV11cClientesDelMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV11cClientesDelMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCCLIENTESDELMES",gx.O.AV11cClientesDelMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV11cClientesDelMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCCLIENTESDELMES",',')},nac:gx.falseFn};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id: 68, fld:"",grid:0};
   GXValidFnc[69]={ id: 69, fld:"MINRECENCIAFILTERCONTAINER",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"LBLMINRECENCIAFILTER", format:1,grid:0,evt:"e17101_client"};
   GXValidFnc[73]={ id: 73, fld:"",grid:0};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCMINRECENCIA",gxz:"ZV12cMinRecencia",gxold:"OV12cMinRecencia",gxvar:"AV12cMinRecencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV12cMinRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV12cMinRecencia=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("vCMINRECENCIA",gx.O.AV12cMinRecencia,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV12cMinRecencia=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCMINRECENCIA",',')},nac:gx.falseFn};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"GRIDTABLE",grid:0};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"BTNTOGGLE",grid:0,evt:"e18101_client"};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id: 83, fld:"",grid:0};
   GXValidFnc[85]={ id:85 ,lvl:2,type:"bits",len:1024,dec:0,sign:false,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.AV5LinkSelection=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5LinkSelection=Value},v2c:function(row){gx.fn.setGridMultimediaValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV17Linkselection_GXI)},c2v:function(row){gx.O.AV17Linkselection_GXI=this.val_GXI();if(this.val(row)!==undefined)gx.O.AV5LinkSelection=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vLINKSELECTION",row || gx.fn.currentGridRowImpl(84))},val_GXI:function(row){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",row || gx.fn.currentGridRowImpl(84))}, gxvar_GXI:'AV17Linkselection_GXI',nac:gx.falseFn};
   GXValidFnc[86]={ id:86 ,lvl:2,type:"svchar",len:6,dec:0,sign:false,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERIODO",gxz:"Z7Periodo",gxold:"O7Periodo",gxvar:"A7Periodo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.A7Periodo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z7Periodo=Value},v2c:function(row){gx.fn.setGridControlValue("PERIODO",row || gx.fn.currentGridRowImpl(84),gx.O.A7Periodo,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A7Periodo=this.val(row)},val:function(row){return gx.fn.getGridControlValue("PERIODO",row || gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};
   GXValidFnc[87]={ id:87 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORTE1",gxz:"Z8Corte1",gxold:"O8Corte1",gxvar:"A8Corte1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A8Corte1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z8Corte1=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CORTE1",row || gx.fn.currentGridRowImpl(84),gx.O.A8Corte1,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A8Corte1=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CORTE1",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[88]={ id:88 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORTE2",gxz:"Z9Corte2",gxold:"O9Corte2",gxvar:"A9Corte2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A9Corte2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z9Corte2=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CORTE2",row || gx.fn.currentGridRowImpl(84),gx.O.A9Corte2,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A9Corte2=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CORTE2",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[89]={ id:89 ,lvl:2,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFM",gxz:"Z10RFM",gxold:"O10RFM",gxvar:"A10RFM",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A10RFM=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z10RFM=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("RFM",row || gx.fn.currentGridRowImpl(84),gx.O.A10RFM,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A10RFM=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("RFM",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[90]={ id:90 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTESDELANIO",gxz:"Z11ClientesDelAnio",gxold:"O11ClientesDelAnio",gxvar:"A11ClientesDelAnio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A11ClientesDelAnio=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11ClientesDelAnio=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLIENTESDELANIO",row || gx.fn.currentGridRowImpl(84),gx.O.A11ClientesDelAnio,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A11ClientesDelAnio=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLIENTESDELANIO",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[91]={ id:91 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTESDELMES",gxz:"Z12ClientesDelMes",gxold:"O12ClientesDelMes",gxvar:"A12ClientesDelMes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A12ClientesDelMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z12ClientesDelMes=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("CLIENTESDELMES",row || gx.fn.currentGridRowImpl(84),gx.O.A12ClientesDelMes,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A12ClientesDelMes=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("CLIENTESDELMES",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[92]={ id:92 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINRECENCIA",gxz:"Z13MinRecencia",gxold:"O13MinRecencia",gxvar:"A13MinRecencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A13MinRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z13MinRecencia=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MINRECENCIA",row || gx.fn.currentGridRowImpl(84),gx.O.A13MinRecencia,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A13MinRecencia=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MINRECENCIA",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[93]={ id:93 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXRECENCIA",gxz:"Z14MaxRecencia",gxold:"O14MaxRecencia",gxvar:"A14MaxRecencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A14MaxRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14MaxRecencia=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("MAXRECENCIA",row || gx.fn.currentGridRowImpl(84),gx.O.A14MaxRecencia,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A14MaxRecencia=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("MAXRECENCIA",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[94]={ id:94 ,lvl:2,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGRECENCIA",gxz:"Z24AvgRecencia",gxold:"O24AvgRecencia",gxvar:"A24AvgRecencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'number',v2v:function(Value){if(Value!==undefined)gx.O.A24AvgRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z24AvgRecencia=gx.num.intval(Value)},v2c:function(row){gx.fn.setGridControlValue("AVGRECENCIA",row || gx.fn.currentGridRowImpl(84),gx.O.A24AvgRecencia,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.A24AvgRecencia=gx.num.intval(this.val(row))},val:function(row){return gx.fn.getGridIntegerValue("AVGRECENCIA",row || gx.fn.currentGridRowImpl(84),',')},nac:gx.falseFn};
   GXValidFnc[95]={ id:95 ,lvl:2,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINFRECUENCIA",gxz:"Z15MinFrecuencia",gxold:"O15MinFrecuencia",gxvar:"A15MinFrecuencia",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',v2v:function(Value){if(Value!==undefined)gx.O.A15MinFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z15MinFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(row){gx.fn.setGridDecimalValue("MINFRECUENCIA",row || gx.fn.currentGridRowImpl(84),gx.O.A15MinFrecuencia,6,'.')},c2v:function(row){if(this.val(row)!==undefined)gx.O.A15MinFrecuencia=this.val(row)},val:function(row){return gx.fn.getGridDecimalValue("MINFRECUENCIA",row || gx.fn.currentGridRowImpl(84),',','.')},nac:gx.falseFn};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id: 98, fld:"BTN_CANCEL",grid:0,evt:"e22101_client"};
   this.AV6cPeriodo = "" ;
   this.ZV6cPeriodo = "" ;
   this.OV6cPeriodo = "" ;
   this.AV7cCorte1 = 0 ;
   this.ZV7cCorte1 = 0 ;
   this.OV7cCorte1 = 0 ;
   this.AV8cCorte2 = 0 ;
   this.ZV8cCorte2 = 0 ;
   this.OV8cCorte2 = 0 ;
   this.AV9cRFM = 0 ;
   this.ZV9cRFM = 0 ;
   this.OV9cRFM = 0 ;
   this.AV10cClientesDelAnio = 0 ;
   this.ZV10cClientesDelAnio = 0 ;
   this.OV10cClientesDelAnio = 0 ;
   this.AV11cClientesDelMes = 0 ;
   this.ZV11cClientesDelMes = 0 ;
   this.OV11cClientesDelMes = 0 ;
   this.AV12cMinRecencia = 0 ;
   this.ZV12cMinRecencia = 0 ;
   this.OV12cMinRecencia = 0 ;
   this.ZV5LinkSelection = "" ;
   this.OV5LinkSelection = "" ;
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
   this.AV6cPeriodo = "" ;
   this.AV7cCorte1 = 0 ;
   this.AV8cCorte2 = 0 ;
   this.AV9cRFM = 0 ;
   this.AV10cClientesDelAnio = 0 ;
   this.AV11cClientesDelMes = 0 ;
   this.AV12cMinRecencia = 0 ;
   this.AV13pPeriodo = "" ;
   this.AV5LinkSelection = "" ;
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
   this.Events = {"e21102_client": ["ENTER", true] ,"e22101_client": ["CANCEL", true] ,"e18101_client": ["'TOGGLE'", false] ,"e11101_client": ["LBLPERIODOFILTER.CLICK", false] ,"e12101_client": ["LBLCORTE1FILTER.CLICK", false] ,"e13101_client": ["LBLCORTE2FILTER.CLICK", false] ,"e14101_client": ["LBLRFMFILTER.CLICK", false] ,"e15101_client": ["LBLCLIENTESDELANIOFILTER.CLICK", false] ,"e16101_client": ["LBLCLIENTESDELMESFILTER.CLICK", false] ,"e17101_client": ["LBLMINRECENCIAFILTER.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["START"] = [[],[{ctrl:'FORM',prop:'Caption'}]];
   this.EvtParms["'TOGGLE'"] = [[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]];
   this.EvtParms["LBLPERIODOFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("PERIODOFILTERCONTAINER","Class")',ctrl:'PERIODOFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("PERIODOFILTERCONTAINER","Class")',ctrl:'PERIODOFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCPERIODO","Visible")',ctrl:'vCPERIODO',prop:'Visible'}]];
   this.EvtParms["LBLCORTE1FILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class")',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CORTE1FILTERCONTAINER","Class")',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCORTE1","Visible")',ctrl:'vCCORTE1',prop:'Visible'}]];
   this.EvtParms["LBLCORTE2FILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class")',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CORTE2FILTERCONTAINER","Class")',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCORTE2","Visible")',ctrl:'vCCORTE2',prop:'Visible'}]];
   this.EvtParms["LBLRFMFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class")',ctrl:'RFMFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("RFMFILTERCONTAINER","Class")',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCRFM","Visible")',ctrl:'vCRFM',prop:'Visible'}]];
   this.EvtParms["LBLCLIENTESDELANIOFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLIENTESDELANIOFILTERCONTAINER","Class")',ctrl:'CLIENTESDELANIOFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLIENTESDELANIOFILTERCONTAINER","Class")',ctrl:'CLIENTESDELANIOFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLIENTESDELANIO","Visible")',ctrl:'vCCLIENTESDELANIO',prop:'Visible'}]];
   this.EvtParms["LBLCLIENTESDELMESFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("CLIENTESDELMESFILTERCONTAINER","Class")',ctrl:'CLIENTESDELMESFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("CLIENTESDELMESFILTERCONTAINER","Class")',ctrl:'CLIENTESDELMESFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCCLIENTESDELMES","Visible")',ctrl:'vCCLIENTESDELMES',prop:'Visible'}]];
   this.EvtParms["LBLMINRECENCIAFILTER.CLICK"] = [[{av:'gx.fn.getCtrlProperty("MINRECENCIAFILTERCONTAINER","Class")',ctrl:'MINRECENCIAFILTERCONTAINER',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("MINRECENCIAFILTERCONTAINER","Class")',ctrl:'MINRECENCIAFILTERCONTAINER',prop:'Class'},{av:'gx.fn.getCtrlProperty("vCMINRECENCIA","Visible")',ctrl:'vCMINRECENCIA',prop:'Visible'}]];
   this.EvtParms["LOAD"] = [[],[{av:'AV5LinkSelection',fld:'vLINKSELECTION',pic:''}]];
   this.EvtParms["ENTER"] = [[{av:'A7Periodo',fld:'PERIODO',pic:'',hsh:true}],[{av:'AV13pPeriodo',fld:'vPPERIODO',pic:''}]];
   this.EvtParms["GRID1_FIRSTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_PREVPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_NEXTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}],[]];
   this.EvtParms["GRID1_LASTPAGE"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}],[]];
   this.setVCMap("AV13pPeriodo", "vPPERIODO", 0, "svchar", 6, 0);
   Grid1Container.addRefreshingVar(this.GXValidFnc[16]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[26]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[36]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[46]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[56]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[66]);
   Grid1Container.addRefreshingVar(this.GXValidFnc[76]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[16]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[26]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[36]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[46]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[56]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[66]);
   Grid1Container.addRefreshingParm(this.GXValidFnc[76]);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.gx0030);});
