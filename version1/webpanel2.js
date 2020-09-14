gx.evt.autoSkip = false;
gx.define('version1.webpanel2', false, function () {
   this.ServerClass =  "version1.webpanel2" ;
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
   };
   this.e121k2_client=function()
   {
      this.refreshInputs([["Corte1","vCORTE1","AV5Corte1"]]);
      this.clearMessages();
      var gxEvtVar = this.getContextObject("vCORTE1");
      this.refreshOutputs([{ctrl:'vCORTE1'},{av:'AV5Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{ctrl:'vCORTE2'},{av:'AV6Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'}]);
      return gxEvtVar;
   };
   this.e131k2_client=function()
   {
      this.refreshInputs([["Corte2","vCORTE2","AV6Corte2"]]);
      this.clearMessages();
      var gxEvtVar = this.getContextObject("vCORTE2");
      this.refreshOutputs([{ctrl:'vCORTE1'},{av:'AV5Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{ctrl:'vCORTE2'},{av:'AV6Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'}]);
      return gxEvtVar;
   };
   this.e141k2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e151k2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16];
   this.GXLastCtrlId =16;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id:8 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCORTE1",gxz:"ZV5Corte1",gxold:"OV5Corte1",gxvar:"AV5Corte1",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"dyncombo",v2v:function(Value){if(Value!==undefined)gx.O.AV5Corte1=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV5Corte1=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("vCORTE1",gx.O.AV5Corte1)},c2v:function(){if(this.val()!==undefined)gx.O.AV5Corte1=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCORTE1",',')},nac:gx.falseFn};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id:12 ,lvl:0,type:"int",len:8,dec:0,sign:false,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCORTE2",gxz:"ZV6Corte2",gxold:"OV6Corte2",gxvar:"AV6Corte2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"dyncombo",v2v:function(Value){if(Value!==undefined)gx.O.AV6Corte2=gx.num.intval(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV6Corte2=gx.num.intval(Value)},v2c:function(){gx.fn.setComboBoxValue("vCORTE2",gx.O.AV6Corte2)},c2v:function(){if(this.val()!==undefined)gx.O.AV6Corte2=gx.num.intval(this.val())},val:function(){return gx.fn.getIntegerValue("vCORTE2",',')},nac:gx.falseFn};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"REFRESH",grid:0,evt:"e161k1_client"};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   this.AV5Corte1 = 0 ;
   this.ZV5Corte1 = 0 ;
   this.OV5Corte1 = 0 ;
   this.AV6Corte2 = 0 ;
   this.ZV6Corte2 = 0 ;
   this.OV6Corte2 = 0 ;
   this.AV5Corte1 = 0 ;
   this.AV6Corte2 = 0 ;
   this.addContextSetter("vCORTE1", "Attribute", ["Corte1"], this.e121k2_client);
   this.addContextSetter("vCORTE2", "Attribute", ["Corte2"], this.e131k2_client);
   this.Events = {"e141k2_client": ["ENTER", true] ,"e151k2_client": ["CANCEL", true] ,"e121k2_client": ["CORTE1.SETCONTEXT", false] ,"e131k2_client": ["CORTE2.SETCONTEXT", false]};
   this.EvtParms["REFRESH"] = [[{ctrl:'vCORTE1'},{av:'AV5Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{ctrl:'vCORTE2'},{av:'AV6Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'}],[{ctrl:'vCORTE1'},{av:'AV5Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{ctrl:'vCORTE2'},{av:'AV6Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'}]];
   this.Initialize( );
   this.setComponent({id: "COMPONENT1" ,GXClass: "version1.wcpiechartcli" , Prefix: "W0017" , lvl: 1 });
});
gx.wi( function() { gx.createParentObj(version1.webpanel2);});
