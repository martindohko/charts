gx.evt.autoSkip=!1;gx.define("gam_appmenuoptionentry",!1,function(){this.ServerClass="gam_appmenuoptionentry";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV10ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV22MenuId=gx.fn.getIntegerValue("vMENUID",gx.thousandSeparator);this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV18Id=gx.fn.getIntegerValue("vID",gx.thousandSeparator);this.AV6isOK=gx.fn.getControlValue("vISOK")};this.Validv_Type=function(){return this.validCliEvt("Validv_Type",0,function(){try{var n=gx.util.balloon.getNew("vTYPE");if(this.AnyError=0,!(this.AV37Type=="S"||this.AV37Type=="M"))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Type"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e122j2_client=function(){return this.executeServerEvent("VTYPE.CLICK",!0,null,!1,!0)};this.e132j2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e142j2_client=function(){return this.executeServerEvent("VRELRESID.CONTROLVALUECHANGED",!0,null,!1,!0)};this.e162j1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72];this.GXLastCtrlId=72;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE3",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLE2",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAME",gxz:"ZV41GXV1",gxold:"OV41GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV41GXV1=n)},v2c:function(){gx.fn.setControlValue("CTLNAME",gx.O.GXV1,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=this.val())},val:function(){return gx.fn.getControlValue("CTLNAME")},nac:gx.falseFn};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAMEMENU",gxz:"ZV42GXV2",gxold:"OV42GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV42GXV2=n)},v2c:function(){gx.fn.setControlValue("CTLNAMEMENU",gx.O.GXV2,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV2=this.val())},val:function(){return gx.fn.getControlValue("CTLNAMEMENU")},nac:gx.falseFn};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGUID",gxz:"ZV17GUID",gxold:"OV17GUID",gxvar:"AV17GUID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV17GUID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17GUID=n)},v2c:function(){gx.fn.setControlValue("vGUID",gx.O.AV17GUID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV17GUID=this.val())},val:function(){return gx.fn.getControlValue("vGUID")},nac:gx.falseFn};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV25Name",gxold:"OV25Name",gxvar:"AV25Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV25Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV25Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV25Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",gxz:"ZV13Dsc",gxold:"OV13Dsc",gxvar:"AV13Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Dsc=n)},v2c:function(){gx.fn.setControlValue("vDSC",gx.O.AV13Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13Dsc=this.val())},val:function(){return gx.fn.getControlValue("vDSC")},nac:gx.falseFn};this.declareDomainHdlr(40,function(){});n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Type,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTYPE",gxz:"ZV37Type",gxold:"OV37Type",gxvar:"AV37Type",ucs:[],op:[45],ip:[45],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV37Type=n)},v2z:function(n){n!==undefined&&(gx.O.ZV37Type=n)},v2c:function(){gx.fn.setComboBoxValue("vTYPE",gx.O.AV37Type);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV37Type=this.val())},val:function(){return gx.fn.getControlValue("vTYPE")},nac:gx.falseFn,evt:"e122j2_client"};this.declareDomainHdlr(45,function(){});n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"MENUSCELL",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,lvl:0,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMENUSID",gxz:"ZV24MenusId",gxold:"OV24MenusId",gxvar:"AV24MenusId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV24MenusId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV24MenusId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vMENUSID",gx.O.AV24MenusId);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV24MenusId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vMENUSID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(50,function(){});n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"PERMISSIONCELL",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,lvl:0,type:"char",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:"e142j2_client",evt_cvcing:null,rgrid:[],fld:"vRELRESID",gxz:"ZV32RelResId",gxold:"OV32RelResId",gxvar:"AV32RelResId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV32RelResId=n)},v2z:function(n){n!==undefined&&(gx.O.ZV32RelResId=n)},v2c:function(){gx.fn.setComboBoxValue("vRELRESID",gx.O.AV32RelResId);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV32RelResId=this.val())},val:function(){return gx.fn.getControlValue("vRELRESID")},nac:gx.falseFn};this.declareDomainHdlr(55,function(){});n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"RESOURCECELL",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESOURCE",gxz:"ZV34Resource",gxold:"OV34Resource",gxvar:"AV34Resource",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV34Resource=n)},v2z:function(n){n!==undefined&&(gx.O.ZV34Resource=n)},v2c:function(){gx.fn.setControlValue("vRESOURCE",gx.O.AV34Resource,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV34Resource=this.val())},val:function(){return gx.fn.getControlValue("vRESOURCE")},nac:gx.falseFn};this.declareDomainHdlr(60,function(){});n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"RESOURCEPARAMETERSCELL",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vRESOURCEPARAMETERS",gxz:"ZV35ResourceParameters",gxold:"OV35ResourceParameters",gxvar:"AV35ResourceParameters",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV35ResourceParameters=n)},v2z:function(n){n!==undefined&&(gx.O.ZV35ResourceParameters=n)},v2c:function(){gx.fn.setControlValue("vRESOURCEPARAMETERS",gx.O.AV35ResourceParameters,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV35ResourceParameters=this.val())},val:function(){return gx.fn.getControlValue("vRESOURCEPARAMETERS")},nac:gx.falseFn};this.declareDomainHdlr(65,function(){});n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"BRNCANCEL",grid:0,evt:"e162j1_client"};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"BTNCONFIRM",grid:0,evt:"e132j2_client",std:"ENTER"};this.GXV1="";this.ZV41GXV1="";this.OV41GXV1="";this.GXV2="";this.ZV42GXV2="";this.OV42GXV2="";this.AV17GUID="";this.ZV17GUID="";this.OV17GUID="";this.AV25Name="";this.ZV25Name="";this.OV25Name="";this.AV13Dsc="";this.ZV13Dsc="";this.OV13Dsc="";this.AV37Type="";this.ZV37Type="";this.OV37Type="";this.AV24MenusId=0;this.ZV24MenusId=0;this.OV24MenusId=0;this.AV32RelResId="";this.ZV32RelResId="";this.OV32RelResId="";this.AV34Resource="";this.ZV34Resource="";this.OV34Resource="";this.AV35ResourceParameters="";this.ZV35ResourceParameters="";this.OV35ResourceParameters="";this.GXV1="";this.GXV2="";this.AV17GUID="";this.AV25Name="";this.AV13Dsc="";this.AV37Type="";this.AV24MenusId=0;this.AV32RelResId="";this.AV34Resource="";this.AV35ResourceParameters="";this.AV10ApplicationId=0;this.AV22MenuId=0;this.AV18Id=0;this.Gx_mode="";this.AV6isOK=!1;this.Events={e122j2_client:["VTYPE.CLICK",!0],e132j2_client:["ENTER",!0],e142j2_client:["VRELRESID.CONTROLVALUECHANGED",!0],e162j1_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV10ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV22MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV18Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV10ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV22MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV18Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{ctrl:"vTYPE"},{av:"AV37Type",fld:"vTYPE",pic:""},{ctrl:"vRELRESID"},{av:"AV32RelResId",fld:"vRELRESID",pic:""},{ctrl:"vMENUSID"},{av:"AV24MenusId",fld:"vMENUSID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV18Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV25Name",fld:"vNAME",pic:""},{av:"AV13Dsc",fld:"vDSC",pic:""},{av:"AV17GUID",fld:"vGUID",pic:""},{ctrl:"vTYPE"},{av:"AV37Type",fld:"vTYPE",pic:""},{ctrl:"vMENUSID"},{av:"AV24MenusId",fld:"vMENUSID",pic:"ZZZZZZZZZZZ9"},{ctrl:"vRELRESID"},{av:"AV32RelResId",fld:"vRELRESID",pic:""},{av:"AV34Resource",fld:"vRESOURCE",pic:""},{av:"AV35ResourceParameters",fld:"vRESOURCEPARAMETERS",pic:""},{av:'gx.fn.getCtrlProperty("vGUID","Enabled")',ctrl:"vGUID",prop:"Enabled"},{ctrl:"BTNCONFIRM",prop:"Visible"},{av:'gx.fn.getCtrlProperty("vNAME","Enabled")',ctrl:"vNAME",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vDSC","Enabled")',ctrl:"vDSC",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vRESOURCE","Enabled")',ctrl:"vRESOURCE",prop:"Enabled"},{av:'gx.fn.getCtrlProperty("vRESOURCEPARAMETERS","Enabled")',ctrl:"vRESOURCEPARAMETERS",prop:"Enabled"},{ctrl:"BTNCONFIRM",prop:"Caption"},{av:'gx.fn.getCtrlProperty("MENUSCELL","Visible")',ctrl:"MENUSCELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("RESOURCECELL","Visible")',ctrl:"RESOURCECELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("RESOURCEPARAMETERSCELL","Visible")',ctrl:"RESOURCEPARAMETERSCELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("PERMISSIONCELL","Visible")',ctrl:"PERMISSIONCELL",prop:"Visible"}]];this.EvtParms["VTYPE.CLICK"]=[[{ctrl:"vTYPE"},{av:"AV37Type",fld:"vTYPE",pic:""},{ctrl:"vRELRESID"},{av:"AV32RelResId",fld:"vRELRESID",pic:""},{av:"AV10ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{ctrl:"vMENUSID"},{av:"AV24MenusId",fld:"vMENUSID",pic:"ZZZZZZZZZZZ9"},{av:"AV22MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9",hsh:!0}],[{ctrl:"vRELRESID"},{av:"AV32RelResId",fld:"vRELRESID",pic:""},{ctrl:"vMENUSID"},{av:"AV24MenusId",fld:"vMENUSID",pic:"ZZZZZZZZZZZ9"},{av:'gx.fn.getCtrlProperty("MENUSCELL","Visible")',ctrl:"MENUSCELL",prop:"Visible"},{av:'gx.fn.getCtrlProperty("RESOURCECELL","Visible")',ctrl:"RESOURCECELL",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"AV10ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV25Name",fld:"vNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV22MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV18Id",fld:"vID",pic:"ZZZZZZZZZZZ9",hsh:!0},{av:"AV6isOK",fld:"vISOK",pic:""},{av:"AV17GUID",fld:"vGUID",pic:""},{av:"AV13Dsc",fld:"vDSC",pic:""},{ctrl:"vTYPE"},{av:"AV37Type",fld:"vTYPE",pic:""},{ctrl:"vMENUSID"},{av:"AV24MenusId",fld:"vMENUSID",pic:"ZZZZZZZZZZZ9"},{ctrl:"vRELRESID"},{av:"AV32RelResId",fld:"vRELRESID",pic:""},{av:"AV34Resource",fld:"vRESOURCE",pic:""},{av:"AV35ResourceParameters",fld:"vRESOURCEPARAMETERS",pic:""}],[{av:"AV6isOK",fld:"vISOK",pic:""}]];this.EvtParms["VRELRESID.CONTROLVALUECHANGED"]=[[{av:"AV10ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9",hsh:!0},{ctrl:"vRELRESID"},{av:"AV32RelResId",fld:"vRELRESID",pic:""}],[{av:"AV34Resource",fld:"vRESOURCE",pic:""}]];this.EvtParms.VALIDV_TYPE=[[],[]];this.EnterCtrl=["BTNCONFIRM"];this.setVCMap("AV10ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV22MenuId","vMENUID",0,"int",12,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV18Id","vID",0,"int",12,0);this.setVCMap("AV6isOK","vISOK",0,"boolean",4,0);this.addBCProperty("Gamapplication",["Name"],this.GXValidFnc[20],"AV5GAMApplication");this.addBCProperty("Applicationmenu",["Name"],this.GXValidFnc[25],"AV11ApplicationMenu");this.Initialize()});gx.wi(function(){gx.createParentObj(gam_appmenuoptionentry)})