gx.evt.autoSkip = false;
gx.define('version1.resumenrfmglobal', false, function () {
   this.ServerClass =  "version1.resumenrfmglobal" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV7Periodo=gx.fn.getControlValue("vPERIODO") ;
      this.AV11Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.Gx_mode=gx.fn.getControlValue("vMODE") ;
      this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT") ;
   };
   this.Valid_Periodo=function()
   {
      return this.validCliEvt("Valid_Periodo", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("PERIODO");
         this.AnyError  = 0;

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.e12072_client=function()
   {
      return this.executeServerEvent("AFTER TRN", true, null, false, false);
   };
   this.e13073_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e14073_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124,125,126,127,128];
   this.GXLastCtrlId =128;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TITLECONTAINER",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TITLE", format:0,grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"FORMCONTAINER",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"TOOLBARCELL",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"BTN_FIRST",grid:0,evt:"e15073_client",std:"FIRST"};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"BTN_PREVIOUS",grid:0,evt:"e16073_client",std:"PREVIOUS"};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"BTN_NEXT",grid:0,evt:"e17073_client",std:"NEXT"};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"BTN_LAST",grid:0,evt:"e18073_client",std:"LAST"};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"BTN_SELECT",grid:0,evt:"e19073_client",std:"SELECT"};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id:34 ,lvl:0,type:"svchar",len:6,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Periodo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERIODO",gxz:"Z7Periodo",gxold:"O7Periodo",gxvar:"A7Periodo",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A7Periodo=Value},v2z:function(Value){if(Value!==undefined)gx.O.Z7Periodo=Value},v2c:function(){gx.fn.setControlValue("PERIODO",gx.O.A7Periodo,0)},c2v:function(){if(this.val()!==undefined)gx.O.A7Periodo=this.val()},val:function(){return gx.fn.getControlValue("PERIODO")},nac:function(){return !((''==this.AV7Periodo))}};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id:39 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORTE1",gxz:"Z8Corte1",gxold:"O8Corte1",gxvar:"A8Corte1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A8Corte1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z8Corte1=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CORTE1",gx.O.A8Corte1,0)},c2v:function(){if(this.val()!==undefined)gx.O.A8Corte1=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CORTE1",',')},nac:gx.falseFn};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id:44 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CORTE2",gxz:"Z9Corte2",gxold:"O9Corte2",gxvar:"A9Corte2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A9Corte2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z9Corte2=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CORTE2",gx.O.A9Corte2,0)},c2v:function(){if(this.val()!==undefined)gx.O.A9Corte2=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CORTE2",',')},nac:gx.falseFn};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id:49 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFM",gxz:"Z10RFM",gxold:"O10RFM",gxvar:"A10RFM",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A10RFM=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z10RFM=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("RFM",gx.O.A10RFM,0)},c2v:function(){if(this.val()!==undefined)gx.O.A10RFM=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("RFM",',')},nac:gx.falseFn};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id:54 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTESDELANIO",gxz:"Z11ClientesDelAnio",gxold:"O11ClientesDelAnio",gxvar:"A11ClientesDelAnio",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A11ClientesDelAnio=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z11ClientesDelAnio=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLIENTESDELANIO",gx.O.A11ClientesDelAnio,0)},c2v:function(){if(this.val()!==undefined)gx.O.A11ClientesDelAnio=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLIENTESDELANIO",',')},nac:gx.falseFn};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id:59 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTESDELMES",gxz:"Z12ClientesDelMes",gxold:"O12ClientesDelMes",gxvar:"A12ClientesDelMes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A12ClientesDelMes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z12ClientesDelMes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLIENTESDELMES",gx.O.A12ClientesDelMes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A12ClientesDelMes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLIENTESDELMES",',')},nac:gx.falseFn};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"",grid:0};
   GXValidFnc[64]={ id:64 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINRECENCIA",gxz:"Z13MinRecencia",gxold:"O13MinRecencia",gxvar:"A13MinRecencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A13MinRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z13MinRecencia=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MINRECENCIA",gx.O.A13MinRecencia,0)},c2v:function(){if(this.val()!==undefined)gx.O.A13MinRecencia=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MINRECENCIA",',')},nac:gx.falseFn};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"",grid:0};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id: 68, fld:"",grid:0};
   GXValidFnc[69]={ id:69 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXRECENCIA",gxz:"Z14MaxRecencia",gxold:"O14MaxRecencia",gxvar:"A14MaxRecencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A14MaxRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z14MaxRecencia=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("MAXRECENCIA",gx.O.A14MaxRecencia,0)},c2v:function(){if(this.val()!==undefined)gx.O.A14MaxRecencia=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("MAXRECENCIA",',')},nac:gx.falseFn};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id: 73, fld:"",grid:0};
   GXValidFnc[74]={ id:74 ,lvl:0,type:"int",len:10,dec:0,sign:false,pic:"ZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGRECENCIA",gxz:"Z24AvgRecencia",gxold:"O24AvgRecencia",gxvar:"A24AvgRecencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A24AvgRecencia=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z24AvgRecencia=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("AVGRECENCIA",gx.O.A24AvgRecencia,0)},c2v:function(){if(this.val()!==undefined)gx.O.A24AvgRecencia=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("AVGRECENCIA",',')},nac:gx.falseFn};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"",grid:0};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"",grid:0};
   GXValidFnc[79]={ id:79 ,lvl:0,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINFRECUENCIA",gxz:"Z15MinFrecuencia",gxold:"O15MinFrecuencia",gxvar:"A15MinFrecuencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A15MinFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z15MinFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("MINFRECUENCIA",gx.O.A15MinFrecuencia,6,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A15MinFrecuencia=this.val()},val:function(){return gx.fn.getDecimalValue("MINFRECUENCIA",',','.')},nac:gx.falseFn};
   GXValidFnc[80]={ id: 80, fld:"",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[83]={ id: 83, fld:"",grid:0};
   GXValidFnc[84]={ id:84 ,lvl:0,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXFRECUENCIA",gxz:"Z16MaxFrecuencia",gxold:"O16MaxFrecuencia",gxvar:"A16MaxFrecuencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A16MaxFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z16MaxFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("MAXFRECUENCIA",gx.O.A16MaxFrecuencia,6,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A16MaxFrecuencia=this.val()},val:function(){return gx.fn.getDecimalValue("MAXFRECUENCIA",',','.')},nac:gx.falseFn};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id: 88, fld:"",grid:0};
   GXValidFnc[89]={ id:89 ,lvl:0,type:"decimal",len:10,dec:6,sign:false,pic:"ZZ9.999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGFRECUENCIA",gxz:"Z17AvgFrecuencia",gxold:"O17AvgFrecuencia",gxvar:"A17AvgFrecuencia",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A17AvgFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z17AvgFrecuencia=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("AVGFRECUENCIA",gx.O.A17AvgFrecuencia,6,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A17AvgFrecuencia=this.val()},val:function(){return gx.fn.getDecimalValue("AVGFRECUENCIA",',','.')},nac:gx.falseFn};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id: 92, fld:"",grid:0};
   GXValidFnc[93]={ id: 93, fld:"",grid:0};
   GXValidFnc[94]={ id:94 ,lvl:0,type:"decimal",len:12,dec:8,sign:false,pic:"ZZ9.99999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MINVALORMONETARIO",gxz:"Z18MinValorMonetario",gxold:"O18MinValorMonetario",gxvar:"A18MinValorMonetario",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A18MinValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z18MinValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("MINVALORMONETARIO",gx.O.A18MinValorMonetario,8,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A18MinValorMonetario=this.val()},val:function(){return gx.fn.getDecimalValue("MINVALORMONETARIO",',','.')},nac:gx.falseFn};
   GXValidFnc[95]={ id: 95, fld:"",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id: 98, fld:"",grid:0};
   GXValidFnc[99]={ id:99 ,lvl:0,type:"decimal",len:12,dec:8,sign:false,pic:"ZZ9.99999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"MAXVALORMONETARIO",gxz:"Z19MaxValorMonetario",gxold:"O19MaxValorMonetario",gxvar:"A19MaxValorMonetario",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A19MaxValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z19MaxValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("MAXVALORMONETARIO",gx.O.A19MaxValorMonetario,8,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A19MaxValorMonetario=this.val()},val:function(){return gx.fn.getDecimalValue("MAXVALORMONETARIO",',','.')},nac:gx.falseFn};
   GXValidFnc[100]={ id: 100, fld:"",grid:0};
   GXValidFnc[101]={ id: 101, fld:"",grid:0};
   GXValidFnc[102]={ id: 102, fld:"",grid:0};
   GXValidFnc[103]={ id: 103, fld:"",grid:0};
   GXValidFnc[104]={ id:104 ,lvl:0,type:"decimal",len:12,dec:8,sign:false,pic:"ZZ9.99999999",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AVGVALORMONETARIO",gxz:"Z20AvgValorMonetario",gxold:"O20AvgValorMonetario",gxvar:"A20AvgValorMonetario",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A20AvgValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z20AvgValorMonetario=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("AVGVALORMONETARIO",gx.O.A20AvgValorMonetario,8,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A20AvgValorMonetario=this.val()},val:function(){return gx.fn.getDecimalValue("AVGVALORMONETARIO",',','.')},nac:gx.falseFn};
   GXValidFnc[105]={ id: 105, fld:"",grid:0};
   GXValidFnc[106]={ id: 106, fld:"",grid:0};
   GXValidFnc[107]={ id: 107, fld:"",grid:0};
   GXValidFnc[108]={ id: 108, fld:"",grid:0};
   GXValidFnc[109]={ id:109 ,lvl:0,type:"int",len:12,dec:0,sign:false,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPRASTICKETS_ANIOMOVIL",gxz:"Z21ComprasTickets_AnioMovil",gxold:"O21ComprasTickets_AnioMovil",gxvar:"A21ComprasTickets_AnioMovil",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A21ComprasTickets_AnioMovil=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z21ComprasTickets_AnioMovil=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COMPRASTICKETS_ANIOMOVIL",gx.O.A21ComprasTickets_AnioMovil,0)},c2v:function(){if(this.val()!==undefined)gx.O.A21ComprasTickets_AnioMovil=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COMPRASTICKETS_ANIOMOVIL",',')},nac:gx.falseFn};
   GXValidFnc[110]={ id: 110, fld:"",grid:0};
   GXValidFnc[111]={ id: 111, fld:"",grid:0};
   GXValidFnc[112]={ id: 112, fld:"",grid:0};
   GXValidFnc[113]={ id: 113, fld:"",grid:0};
   GXValidFnc[114]={ id:114 ,lvl:0,type:"decimal",len:12,dec:2,sign:false,pic:"ZZZZZZZZ9.99",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPRASIMPORTE_ANIOMOVIL",gxz:"Z22ComprasImporte_AnioMovil",gxold:"O22ComprasImporte_AnioMovil",gxvar:"A22ComprasImporte_AnioMovil",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A22ComprasImporte_AnioMovil=gx.fn.toDecimalValue(Value,',','.')},v2z:function(Value){if(Value!==undefined)gx.O.Z22ComprasImporte_AnioMovil=gx.fn.toDecimalValue(Value,',','.')},v2c:function(){gx.fn.setDecimalValue("COMPRASIMPORTE_ANIOMOVIL",gx.O.A22ComprasImporte_AnioMovil,2,'.')},c2v:function(){if(this.val()!==undefined)gx.O.A22ComprasImporte_AnioMovil=this.val()},val:function(){return gx.fn.getDecimalValue("COMPRASIMPORTE_ANIOMOVIL",',','.')},nac:gx.falseFn};
   GXValidFnc[115]={ id: 115, fld:"",grid:0};
   GXValidFnc[116]={ id: 116, fld:"",grid:0};
   GXValidFnc[117]={ id: 117, fld:"",grid:0};
   GXValidFnc[118]={ id: 118, fld:"",grid:0};
   GXValidFnc[119]={ id:119 ,lvl:0,type:"int",len:12,dec:0,sign:false,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COMPRASARTICULOS_ANIOMOVIL",gxz:"Z23ComprasArticulos_AnioMovil",gxold:"O23ComprasArticulos_AnioMovil",gxvar:"A23ComprasArticulos_AnioMovil",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A23ComprasArticulos_AnioMovil=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z23ComprasArticulos_AnioMovil=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("COMPRASARTICULOS_ANIOMOVIL",gx.O.A23ComprasArticulos_AnioMovil,0)},c2v:function(){if(this.val()!==undefined)gx.O.A23ComprasArticulos_AnioMovil=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("COMPRASARTICULOS_ANIOMOVIL",',')},nac:gx.falseFn};
   GXValidFnc[120]={ id: 120, fld:"",grid:0};
   GXValidFnc[121]={ id: 121, fld:"",grid:0};
   GXValidFnc[122]={ id: 122, fld:"",grid:0};
   GXValidFnc[123]={ id: 123, fld:"",grid:0};
   GXValidFnc[124]={ id: 124, fld:"BTN_ENTER",grid:0,evt:"e13073_client",std:"ENTER"};
   GXValidFnc[125]={ id: 125, fld:"",grid:0};
   GXValidFnc[126]={ id: 126, fld:"BTN_CANCEL",grid:0,evt:"e14073_client"};
   GXValidFnc[127]={ id: 127, fld:"",grid:0};
   GXValidFnc[128]={ id: 128, fld:"BTN_DELETE",grid:0,evt:"e20073_client",std:"DELETE"};
   this.A7Periodo = "" ;
   this.Z7Periodo = "" ;
   this.O7Periodo = "" ;
   this.A8Corte1 = 0 ;
   this.Z8Corte1 = 0 ;
   this.O8Corte1 = 0 ;
   this.A9Corte2 = 0 ;
   this.Z9Corte2 = 0 ;
   this.O9Corte2 = 0 ;
   this.A10RFM = 0 ;
   this.Z10RFM = 0 ;
   this.O10RFM = 0 ;
   this.A11ClientesDelAnio = 0 ;
   this.Z11ClientesDelAnio = 0 ;
   this.O11ClientesDelAnio = 0 ;
   this.A12ClientesDelMes = 0 ;
   this.Z12ClientesDelMes = 0 ;
   this.O12ClientesDelMes = 0 ;
   this.A13MinRecencia = 0 ;
   this.Z13MinRecencia = 0 ;
   this.O13MinRecencia = 0 ;
   this.A14MaxRecencia = 0 ;
   this.Z14MaxRecencia = 0 ;
   this.O14MaxRecencia = 0 ;
   this.A24AvgRecencia = 0 ;
   this.Z24AvgRecencia = 0 ;
   this.O24AvgRecencia = 0 ;
   this.A15MinFrecuencia = 0 ;
   this.Z15MinFrecuencia = 0 ;
   this.O15MinFrecuencia = 0 ;
   this.A16MaxFrecuencia = 0 ;
   this.Z16MaxFrecuencia = 0 ;
   this.O16MaxFrecuencia = 0 ;
   this.A17AvgFrecuencia = 0 ;
   this.Z17AvgFrecuencia = 0 ;
   this.O17AvgFrecuencia = 0 ;
   this.A18MinValorMonetario = 0 ;
   this.Z18MinValorMonetario = 0 ;
   this.O18MinValorMonetario = 0 ;
   this.A19MaxValorMonetario = 0 ;
   this.Z19MaxValorMonetario = 0 ;
   this.O19MaxValorMonetario = 0 ;
   this.A20AvgValorMonetario = 0 ;
   this.Z20AvgValorMonetario = 0 ;
   this.O20AvgValorMonetario = 0 ;
   this.A21ComprasTickets_AnioMovil = 0 ;
   this.Z21ComprasTickets_AnioMovil = 0 ;
   this.O21ComprasTickets_AnioMovil = 0 ;
   this.A22ComprasImporte_AnioMovil = 0 ;
   this.Z22ComprasImporte_AnioMovil = 0 ;
   this.O22ComprasImporte_AnioMovil = 0 ;
   this.A23ComprasArticulos_AnioMovil = 0 ;
   this.Z23ComprasArticulos_AnioMovil = 0 ;
   this.O23ComprasArticulos_AnioMovil = 0 ;
   this.AV11Pgmname = "" ;
   this.AV9TrnContext = {CallerObject:"",CallerOnDelete:false,CallerURL:"",TransactionName:"",Attributes:[]} ;
   this.AV7Periodo = "" ;
   this.AV10WebSession = {} ;
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
   this.Gx_mode = "" ;
   this.Events = {"e12072_client": ["AFTER TRN", true] ,"e13073_client": ["ENTER", true] ,"e14073_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Periodo',fld:'vPERIODO',pic:'',hsh:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Periodo',fld:'vPERIODO',pic:'',hsh:true}],[]];
   this.EvtParms["START"] = [[{av:'AV11Pgmname',fld:'vPGMNAME',pic:''}],[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]];
   this.EvtParms["AFTER TRN"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}],[]];
   this.EvtParms["VALID_PERIODO"] = [[],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("AV7Periodo", "vPERIODO", 0, "svchar", 6, 0);
   this.setVCMap("AV11Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("Gx_mode", "vMODE", 0, "char", 3, 0);
   this.setVCMap("AV9TrnContext", "vTRNCONTEXT", 0, "Version1\TransactionContext", 0, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.resumenrfmglobal);});
