gx.evt.autoSkip=!1;gx.define("tresumenrfm",!1,function(){this.ServerClass="tresumenrfm";this.PackageName="GeneXus.Programs";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7Region=gx.fn.getIntegerValue("vREGION",",");this.AV8Sucursal=gx.fn.getIntegerValue("vSUCURSAL",",");this.AV12Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV10TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Region=function(){return this.validCliEvt("Valid_Region",0,function(){try{var n=gx.util.balloon.getNew("REGION");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sucursal=function(){return this.validCliEvt("Valid_Sucursal",0,function(){try{var n=gx.util.balloon.getNew("SUCURSAL");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12012_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13011_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14011_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63];this.GXLastCtrlId=63;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15011_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16011_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17011_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18011_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19011_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Region,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REGION",gxz:"Z1Region",gxold:"O1Region",gxvar:"A1Region",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1Region=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1Region=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("REGION",gx.O.A1Region,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1Region=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("REGION",",")},nac:function(){return!(0==this.AV7Region)}};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Sucursal,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SUCURSAL",gxz:"Z2Sucursal",gxold:"O2Sucursal",gxvar:"A2Sucursal",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2Sucursal=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z2Sucursal=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SUCURSAL",gx.O.A2Sucursal,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2Sucursal=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SUCURSAL",",")},nac:function(){return!(0==this.AV8Sucursal)}};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMANT",gxz:"Z3RFMAnt",gxold:"O3RFMAnt",gxvar:"A3RFMAnt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A3RFMAnt=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3RFMAnt=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("RFMANT",gx.O.A3RFMAnt,0)},c2v:function(){this.val()!==undefined&&(gx.O.A3RFMAnt=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("RFMANT",",")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"RFMACT",gxz:"Z4RFMAct",gxold:"O4RFMAct",gxvar:"A4RFMAct",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4RFMAct=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4RFMAct=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("RFMACT",gx.O.A4RFMAct,0)},c2v:function(){this.val()!==undefined&&(gx.O.A4RFMAct=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("RFMACT",",")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTES",gxz:"Z5Clientes",gxold:"O5Clientes",gxvar:"A5Clientes",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5Clientes=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5Clientes=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIENTES",gx.O.A5Clientes,0)},c2v:function(){this.val()!==undefined&&(gx.O.A5Clientes=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIENTES",",")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"BTN_ENTER",grid:0,evt:"e13011_client",std:"ENTER"};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"BTN_CANCEL",grid:0,evt:"e14011_client"};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"BTN_DELETE",grid:0,evt:"e20011_client",std:"DELETE"};this.A1Region=0;this.Z1Region=0;this.O1Region=0;this.A2Sucursal=0;this.Z2Sucursal=0;this.O2Sucursal=0;this.A3RFMAnt=0;this.Z3RFMAnt=0;this.O3RFMAnt=0;this.A4RFMAct=0;this.Z4RFMAct=0;this.O4RFMAct=0;this.A5Clientes=0;this.Z5Clientes=0;this.O5Clientes=0;this.AV12Pgmname="";this.AV10TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7Region=0;this.AV8Sucursal=0;this.AV11WebSession={};this.A1Region=0;this.A2Sucursal=0;this.A3RFMAnt=0;this.A4RFMAct=0;this.A5Clientes=0;this.Gx_mode="";this.Events={e12012_client:["AFTER TRN",!0],e13011_client:["ENTER",!0],e14011_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7Region",fld:"vREGION",pic:"ZZZ9",hsh:!0},{av:"AV8Sucursal",fld:"vSUCURSAL",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7Region",fld:"vREGION",pic:"ZZZ9",hsh:!0},{av:"AV8Sucursal",fld:"vSUCURSAL",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV12Pgmname",fld:"vPGMNAME",pic:""}],[{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_REGION=[[],[]];this.EvtParms.VALID_SUCURSAL=[[],[]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7Region","vREGION",0,"int",4,0);this.setVCMap("AV8Sucursal","vSUCURSAL",0,"int",4,0);this.setVCMap("AV12Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV10TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(tresumenrfm)})