gx.evt.autoSkip=!1;gx.define("gam_login",!1,function(){this.ServerClass="gam_login";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV23LogOnTo=gx.fn.getControlValue("vLOGONTO");this.AV10AuxUserName=gx.fn.getControlValue("vAUXUSERNAME");this.AV33UserRememberMe=gx.fn.getIntegerValue("vUSERREMEMBERME",gx.thousandSeparator)};this.e132v2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e152v2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40];this.GXLastCtrlId=40;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLELOGIN",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TEXTBLOCK1",format:0,grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"CURRENTREPOSITORY",format:0,grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERNAME",gxz:"ZV31UserName",gxold:"OV31UserName",gxvar:"AV31UserName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV31UserName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV31UserName=n)},v2c:function(){gx.fn.setControlValue("vUSERNAME",gx.O.AV31UserName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV31UserName=this.val())},val:function(){return gx.fn.getControlValue("vUSERNAME")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:50,dec:0,sign:!1,isPwd:!0,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUSERPASSWORD",gxz:"ZV32UserPassword",gxold:"OV32UserPassword",gxvar:"AV32UserPassword",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV32UserPassword=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32UserPassword=n)},v2c:function(){gx.fn.setControlValue("vUSERPASSWORD",gx.O.AV32UserPassword,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV32UserPassword=this.val())},val:function(){return gx.fn.getControlValue("vUSERPASSWORD")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vKEEPMELOGGEDIN",gxz:"ZV20KeepMeLoggedIn",gxold:"OV20KeepMeLoggedIn",gxvar:"AV20KeepMeLoggedIn",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV20KeepMeLoggedIn=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV20KeepMeLoggedIn=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vKEEPMELOGGEDIN",gx.O.AV20KeepMeLoggedIn,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV20KeepMeLoggedIn=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vKEEPMELOGGEDIN")},nac:gx.falseFn,values:["true","false"]};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vREMEMBERME",gxz:"ZV25RememberMe",gxold:"OV25RememberMe",gxvar:"AV25RememberMe",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV25RememberMe=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV25RememberMe=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vREMEMBERME",gx.O.AV25RememberMe,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV25RememberMe=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vREMEMBERME")},nac:gx.falseFn,values:["true","false"]};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"LOGIN",grid:0,evt:"e132v2_client",std:"ENTER"};n[40]={id:40,fld:"",grid:0};this.AV31UserName="";this.ZV31UserName="";this.OV31UserName="";this.AV32UserPassword="";this.ZV32UserPassword="";this.OV32UserPassword="";this.AV20KeepMeLoggedIn=!1;this.ZV20KeepMeLoggedIn=!1;this.OV20KeepMeLoggedIn=!1;this.AV25RememberMe=!1;this.ZV25RememberMe=!1;this.OV25RememberMe=!1;this.AV31UserName="";this.AV32UserPassword="";this.AV20KeepMeLoggedIn=!1;this.AV25RememberMe=!1;this.AV23LogOnTo="";this.AV10AuxUserName="";this.AV33UserRememberMe=0;this.Events={e132v2_client:["ENTER",!0],e152v2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV23LogOnTo",fld:"vLOGONTO",pic:"",hsh:!0},{av:"AV10AuxUserName",fld:"vAUXUSERNAME",pic:"",hsh:!0},{av:"AV33UserRememberMe",fld:"vUSERREMEMBERME",pic:"Z9",hsh:!0},{av:"AV20KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV25RememberMe",fld:"vREMEMBERME",pic:""}],[{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:'gx.fn.getCtrlProperty("vKEEPMELOGGEDIN","Visible")',ctrl:"vKEEPMELOGGEDIN",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vREMEMBERME","Visible")',ctrl:"vREMEMBERME",prop:"Visible"},{av:"AV20KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV25RememberMe",fld:"vREMEMBERME",pic:""}]];this.EvtParms.START=[[{av:"AV20KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV25RememberMe",fld:"vREMEMBERME",pic:""}],[{av:'gx.fn.getCtrlProperty("CURRENTREPOSITORY","Visible")',ctrl:"CURRENTREPOSITORY",prop:"Visible"},{av:'gx.fn.getCtrlProperty("CURRENTREPOSITORY","Caption")',ctrl:"CURRENTREPOSITORY",prop:"Caption"},{av:"AV20KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV25RememberMe",fld:"vREMEMBERME",pic:""}]];this.EvtParms.ENTER=[[{av:"AV23LogOnTo",fld:"vLOGONTO",pic:"",hsh:!0},{av:"AV31UserName",fld:"vUSERNAME",pic:""},{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV20KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV25RememberMe",fld:"vREMEMBERME",pic:""}],[{av:"AV32UserPassword",fld:"vUSERPASSWORD",pic:""},{av:"AV20KeepMeLoggedIn",fld:"vKEEPMELOGGEDIN",pic:""},{av:"AV25RememberMe",fld:"vREMEMBERME",pic:""}]];this.EnterCtrl=["LOGIN"];this.setVCMap("AV23LogOnTo","vLOGONTO",0,"char",60,0);this.setVCMap("AV10AuxUserName","vAUXUSERNAME",0,"svchar",100,60);this.setVCMap("AV33UserRememberMe","vUSERREMEMBERME",0,"int",2,0);this.Initialize()});gx.wi(function(){gx.createParentObj(gam_login)})