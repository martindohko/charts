gx.evt.autoSkip = false;
gx.define('version1.tresumenrfm', false, function () {
   this.ServerClass =  "version1.tresumenrfm" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("trn");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV7Region=gx.fn.getIntegerValue("vREGION",',') ;
      this.AV8Sucursal=gx.fn.getIntegerValue("vSUCURSAL",',') ;
      this.AV12Pgmname=gx.fn.getControlValue("vPGMNAME") ;
      this.Gx_mode=gx.fn.getControlValue("vMODE") ;
      this.AV10TrnContext=gx.fn.getControlValue("vTRNCONTEXT") ;
   };
   this.Valid_Region=function()
   {
      return this.validCliEvt("Valid_Region", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("REGION");
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
   this.Valid_Sucursal=function()
   {
      return this.validCliEvt("Valid_Sucursal", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("SUCURSAL");
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
   this.e12012_client=function()
   {
      return this.executeServerEvent("AFTER TRN", true, null, false, false);
   };
   this.e13011_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e14011_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63];
   this.GXLastCtrlId =63;
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
   GXValidFnc[21]={ id: 21, fld:"BTN_FIRST",grid:0,evt:"e15011_client",std:"FIRST"};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"BTN_PREVIOUS",grid:0,evt:"e16011_client",std:"PREVIOUS"};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"BTN_NEXT",grid:0,evt:"e17011_client",std:"NEXT"};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"BTN_LAST",grid:0,evt:"e18011_client",std:"LAST"};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"BTN_SELECT",grid:0,evt:"e19011_client",std:"SELECT"};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id:34 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Region,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGION",gxz:"Z1Region",gxold:"O1Region",gxvar:"A1Region",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1Region=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1Region=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("REGION",gx.O.A1Region,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1Region=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("REGION",',')},nac:function(){return !((0==this.AV7Region))}};
   GXValidFnc[35]={ id: 35, fld:"",grid:0};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id:39 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Sucursal,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSAL",gxz:"Z2Sucursal",gxold:"O2Sucursal",gxvar:"A2Sucursal",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2Sucursal=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2Sucursal=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("SUCURSAL",gx.O.A2Sucursal,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2Sucursal=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("SUCURSAL",',')},nac:function(){return !((0==this.AV8Sucursal))}};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id:44 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMANT",gxz:"Z3RFMAnt",gxold:"O3RFMAnt",gxvar:"A3RFMAnt",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A3RFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3RFMAnt=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("RFMANT",gx.O.A3RFMAnt,0)},c2v:function(){if(this.val()!==undefined)gx.O.A3RFMAnt=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("RFMANT",',')},nac:gx.falseFn};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"",grid:0};
   GXValidFnc[47]={ id: 47, fld:"",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id:49 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMACT",gxz:"Z4RFMAct",gxold:"O4RFMAct",gxvar:"A4RFMAct",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A4RFMAct=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z4RFMAct=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("RFMACT",gx.O.A4RFMAct,0)},c2v:function(){if(this.val()!==undefined)gx.O.A4RFMAct=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("RFMACT",',')},nac:gx.falseFn};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id:54 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTES",gxz:"Z5Clientes",gxold:"O5Clientes",gxvar:"A5Clientes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A5Clientes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z5Clientes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLIENTES",gx.O.A5Clientes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A5Clientes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLIENTES",',')},nac:gx.falseFn};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id: 59, fld:"BTN_ENTER",grid:0,evt:"e13011_client",std:"ENTER"};
   GXValidFnc[60]={ id: 60, fld:"",grid:0};
   GXValidFnc[61]={ id: 61, fld:"BTN_CANCEL",grid:0,evt:"e14011_client"};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"BTN_DELETE",grid:0,evt:"e20011_client",std:"DELETE"};
   this.A1Region = 0 ;
   this.Z1Region = 0 ;
   this.O1Region = 0 ;
   this.A2Sucursal = 0 ;
   this.Z2Sucursal = 0 ;
   this.O2Sucursal = 0 ;
   this.A3RFMAnt = 0 ;
   this.Z3RFMAnt = 0 ;
   this.O3RFMAnt = 0 ;
   this.A4RFMAct = 0 ;
   this.Z4RFMAct = 0 ;
   this.O4RFMAct = 0 ;
   this.A5Clientes = 0 ;
   this.Z5Clientes = 0 ;
   this.O5Clientes = 0 ;
   this.AV12Pgmname = "" ;
   this.AV10TrnContext = {CallerObject:"",CallerOnDelete:false,CallerURL:"",TransactionName:"",Attributes:[]} ;
   this.AV7Region = 0 ;
   this.AV8Sucursal = 0 ;
   this.AV11WebSession = {} ;
   this.A1Region = 0 ;
   this.A2Sucursal = 0 ;
   this.A3RFMAnt = 0 ;
   this.A4RFMAct = 0 ;
   this.A5Clientes = 0 ;
   this.Gx_mode = "" ;
   this.Events = {"e12012_client": ["AFTER TRN", true] ,"e13011_client": ["ENTER", true] ,"e14011_client": ["CANCEL", true]};
   this.EvtParms["ENTER"] = [[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'AV8Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true}],[]];
   this.EvtParms["REFRESH"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'AV8Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true}],[]];
   this.EvtParms["START"] = [[{av:'AV12Pgmname',fld:'vPGMNAME',pic:''}],[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]];
   this.EvtParms["AFTER TRN"] = [[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}],[]];
   this.EvtParms["VALID_REGION"] = [[],[]];
   this.EvtParms["VALID_SUCURSAL"] = [[],[]];
   this.EnterCtrl = ["BTN_ENTER"];
   this.setVCMap("AV7Region", "vREGION", 0, "int", 4, 0);
   this.setVCMap("AV8Sucursal", "vSUCURSAL", 0, "int", 4, 0);
   this.setVCMap("AV12Pgmname", "vPGMNAME", 0, "char", 129, 0);
   this.setVCMap("Gx_mode", "vMODE", 0, "char", 3, 0);
   this.setVCMap("AV10TrnContext", "vTRNCONTEXT", 0, "Version1\TransactionContext", 0, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.tresumenrfm);});
