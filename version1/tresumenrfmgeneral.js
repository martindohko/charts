gx.evt.autoSkip = false;
gx.define('version1.tresumenrfmgeneral', true, function (CmpContext) {
   this.ServerClass =  "version1.tresumenrfmgeneral" ;
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
   this.e130e2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140e2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31];
   this.GXLastCtrlId =31;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"ATTRIBUTESTABLE",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id:11 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Region,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGION",gxz:"Z1Region",gxold:"O1Region",gxvar:"A1Region",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A1Region=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z1Region=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("REGION",gx.O.A1Region,0)},c2v:function(){if(this.val()!==undefined)gx.O.A1Region=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("REGION",',')},nac:gx.falseFn};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id:16 ,lvl:0,type:"int",len:4,dec:0,sign:false,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Sucursal,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSAL",gxz:"Z2Sucursal",gxold:"O2Sucursal",gxvar:"A2Sucursal",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A2Sucursal=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z2Sucursal=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("SUCURSAL",gx.O.A2Sucursal,0)},c2v:function(){if(this.val()!==undefined)gx.O.A2Sucursal=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("SUCURSAL",',')},nac:gx.falseFn};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id:21 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMANT",gxz:"Z3RFMAnt",gxold:"O3RFMAnt",gxvar:"A3RFMAnt",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A3RFMAnt=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z3RFMAnt=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("RFMANT",gx.O.A3RFMAnt,0)},c2v:function(){if(this.val()!==undefined)gx.O.A3RFMAnt=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("RFMANT",',')},nac:gx.falseFn};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMACT",gxz:"Z4RFMAct",gxold:"O4RFMAct",gxvar:"A4RFMAct",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A4RFMAct=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z4RFMAct=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("RFMACT",gx.O.A4RFMAct,0)},c2v:function(){if(this.val()!==undefined)gx.O.A4RFMAct=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("RFMACT",',')},nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id:31 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTES",gxz:"Z5Clientes",gxold:"O5Clientes",gxvar:"A5Clientes",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.A5Clientes=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.Z5Clientes=gx.num.intval(Value)},v2c:function(){gx.fn.setControlValue("CLIENTES",gx.O.A5Clientes,0)},c2v:function(){if(this.val()!==undefined)gx.O.A5Clientes=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("CLIENTES",',')},nac:gx.falseFn};
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
   this.A1Region = 0 ;
   this.A2Sucursal = 0 ;
   this.A3RFMAnt = 0 ;
   this.A4RFMAct = 0 ;
   this.A5Clientes = 0 ;
   this.Events = {"e130e2_client": ["ENTER", true] ,"e140e2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'A1Region',fld:'REGION',pic:'ZZZ9'},{av:'A2Sucursal',fld:'SUCURSAL',pic:'ZZZ9'}],[]];
   this.EvtParms["START"] = [[{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'AV6Region',fld:'vREGION',pic:'ZZZ9'},{av:'AV7Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'}],[]];
   this.EvtParms["LOAD"] = [[],[]];
   this.EvtParms["VALID_REGION"] = [[],[]];
   this.EvtParms["VALID_SUCURSAL"] = [[],[]];
   this.Initialize( );
});
