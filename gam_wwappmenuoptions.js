gx.evt.autoSkip=!1;gx.define("gam_wwappmenuoptions",!1,function(){var n,t;this.ServerClass="gam_wwappmenuoptions";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV24SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.AV19MenuId=gx.fn.getIntegerValue("vMENUID",gx.thousandSeparator);this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV24SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.AV19MenuId=gx.fn.getIntegerValue("vMENUID",gx.thousandSeparator);this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV19MenuId=gx.fn.getIntegerValue("vMENUID",gx.thousandSeparator)};this.Validv_Type=function(){var n=gx.fn.currentGridRowImpl(37);return this.validCliEvt("Validv_Type",37,function(){try{var n=gx.util.balloon.getNew("vTYPE");if(this.AnyError=0,!(this.AV25Type=="S"||this.AV25Type=="M"))try{n.setError(gx.text.format(gx.getMessage("GXSPC_OutOfRange"),gx.getMessage("Type"),"","","","","","","",""));this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e122i1_client=function(){return this.clearMessages(),this.call("gam_appmenuoptionentry.aspx",["INS",this.AV6ApplicationId,this.AV19MenuId,0]),this.refreshOutputs([{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e112i1_client=function(){return this.clearMessages(),this.call("gam_wwappmenus.aspx",[this.AV6ApplicationId]),this.refreshOutputs([{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e172i2_client=function(){return this.clearMessages(),this.call("gam_appmenuoptionentry.aspx",["DSP",this.AV6ApplicationId,this.AV19MenuId,this.AV17Id]),this.refreshOutputs([{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e182i2_client=function(){return this.clearMessages(),this.call("gam_appmenuoptionentry.aspx",["UPD",this.AV6ApplicationId,this.AV19MenuId,this.AV17Id]),this.refreshOutputs([{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e192i2_client=function(){return this.clearMessages(),this.call("gam_appmenuoptionentry.aspx",["DLT",this.AV6ApplicationId,this.AV19MenuId,this.AV17Id]),this.refreshOutputs([{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e152i2_client=function(){return this.executeServerEvent("VBTNUP.CLICK",!0,arguments[0],!1,!1)};this.e162i2_client=function(){return this.executeServerEvent("VBTNDOWN.CLICK",!0,arguments[0],!1,!1)};this.e202i2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e212i2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,38,39,40,41,42,43,44,45];this.GXLastCtrlId=45;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",37,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwappmenuoptions",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",38,"vNAME",gx.getMessage("Menu name"),"","Name","char",0,"px",120,80,"left","e172i2_client",[],"Name","Name",!0,0,!1,!1,"Attribute TextLikeLink SmallLink",1,"WWColumn");t.addSingleLineEdit("Dsc",39,"vDSC",gx.getMessage("Description"),"","Dsc","char",0,"px",254,80,"left",null,[],"Dsc","Dsc",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addComboBox("Type",40,"vTYPE",gx.getMessage("Type"),"Type","char",null,0,!0,!1,0,"px","WWColumn WWSecondaryColumn");t.addSingleLineEdit("Btnup",41,"vBTNUP","","","BtnUp","char",0,"px",20,20,"left","e152i2_client",[],"Btnup","BtnUp",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btndown",42,"vBTNDOWN","","","BtnDown","char",0,"px",20,20,"left","e162i2_client",[],"Btndown","BtnDown",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btnupd",43,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"left","e182i2_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btndlt",44,"vBTNDLT","","","BtnDlt","char",0,"px",20,20,"left","e192i2_client",[],"Btndlt","BtnDlt",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Id",45,"vID",gx.getMessage("Id"),"","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!1,0,!1,!1,"Attribute",1,"");this.GridwwContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TABLE1",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BACK",grid:0,evt:"e112i1_client"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"ADDNEW",grid:0,evt:"e122i1_client"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",gxz:"ZV15FilName",gxold:"OV15FilName",gxvar:"AV15FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV15FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV15FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV15FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV15FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(19,function(){});n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"GRIDCELL",grid:0};n[22]={id:22,fld:"TABLE7",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAME",gxz:"ZV28GXV1",gxold:"OV28GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28GXV1=n)},v2c:function(){gx.fn.setControlValue("CTLNAME",gx.O.GXV1,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=this.val())},val:function(){return gx.fn.getControlValue("CTLNAME")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAME1",gxz:"ZV29GXV2",gxold:"OV29GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV29GXV2=n)},v2c:function(){gx.fn.setControlValue("CTLNAME1",gx.O.GXV2,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV2=this.val())},val:function(){return gx.fn.getControlValue("CTLNAME1")},nac:gx.falseFn};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[38]={id:38,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV21Name",gxold:"OV21Name",gxvar:"AV21Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV21Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(37),gx.O.AV21Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV21Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn,evt:"e172i2_client"};n[39]={id:39,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",gxz:"ZV12Dsc",gxold:"OV12Dsc",gxvar:"AV12Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(37),gx.O.AV12Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"char",len:1,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:this.Validv_Type,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTYPE",gxz:"ZV25Type",gxold:"OV25Type",gxvar:"AV25Type",ucs:[],op:[40],ip:[40],nacdep:[],ctrltype:"combo",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV25Type=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25Type=n)},v2c:function(n){gx.fn.setGridComboBoxValue("vTYPE",n||gx.fn.currentGridRowImpl(37),gx.O.AV25Type);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV25Type=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vTYPE",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUP",gxz:"ZV10BtnUp",gxold:"OV10BtnUp",gxvar:"AV10BtnUp",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10BtnUp=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10BtnUp=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUP",n||gx.fn.currentGridRowImpl(37),gx.O.AV10BtnUp,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10BtnUp=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUP",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn,evt:"e152i2_client"};n[42]={id:42,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNDOWN",gxz:"ZV9BtnDown",gxold:"OV9BtnDown",gxvar:"AV9BtnDown",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV9BtnDown=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9BtnDown=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNDOWN",n||gx.fn.currentGridRowImpl(37),gx.O.AV9BtnDown,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9BtnDown=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNDOWN",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn,evt:"e162i2_client"};n[43]={id:43,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",gxz:"ZV11BtnUpd",gxold:"OV11BtnUpd",gxvar:"AV11BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(37),gx.O.AV11BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn,evt:"e182i2_client"};n[44]={id:44,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNDLT",gxz:"ZV8BtnDlt",gxold:"OV8BtnDlt",gxvar:"AV8BtnDlt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV8BtnDlt=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8BtnDlt=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(37),gx.O.AV8BtnDlt,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8BtnDlt=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(37))},nac:gx.falseFn,evt:"e192i2_client"};n[45]={id:45,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:37,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",gxz:"ZV17Id",gxold:"OV17Id",gxvar:"AV17Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV17Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV17Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(37),gx.O.AV17Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV17Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(37),gx.thousandSeparator)},nac:gx.falseFn};this.AV15FilName="";this.ZV15FilName="";this.OV15FilName="";this.GXV1="";this.ZV28GXV1="";this.OV28GXV1="";this.GXV2="";this.ZV29GXV2="";this.OV29GXV2="";this.ZV21Name="";this.OV21Name="";this.ZV12Dsc="";this.OV12Dsc="";this.ZV25Type="";this.OV25Type="";this.ZV10BtnUp="";this.OV10BtnUp="";this.ZV9BtnDown="";this.OV9BtnDown="";this.ZV11BtnUpd="";this.OV11BtnUpd="";this.ZV8BtnDlt="";this.OV8BtnDlt="";this.ZV17Id=0;this.OV17Id=0;this.AV15FilName="";this.GXV1="";this.GXV2="";this.AV6ApplicationId=0;this.AV19MenuId=0;this.AV21Name="";this.AV12Dsc="";this.AV25Type="";this.AV10BtnUp="";this.AV9BtnDown="";this.AV11BtnUpd="";this.AV8BtnDlt="";this.AV17Id=0;this.AV24SearchFilter="";this.Events={e152i2_client:["VBTNUP.CLICK",!0],e162i2_client:["VBTNDOWN.CLICK",!0],e202i2_client:["ENTER",!0],e212i2_client:["CANCEL",!0],e122i1_client:["'ADDNEW'",!1],e112i1_client:["'GOBACK'",!1],e172i2_client:["VNAME.CLICK",!1],e182i2_client:["VBTNUPD.CLICK",!1],e192i2_client:["VBTNDLT.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV24SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV24SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV11BtnUpd",fld:"vBTNUPD",pic:""},{av:"AV8BtnDlt",fld:"vBTNDLT",pic:""},{av:"AV10BtnUp",fld:"vBTNUP",pic:""},{av:"AV9BtnDown",fld:"vBTNDOWN",pic:""},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV21Name",fld:"vNAME",pic:""},{av:"AV12Dsc",fld:"vDSC",pic:""},{ctrl:"vTYPE"},{av:"AV25Type",fld:"vTYPE",pic:""}]];this.EvtParms["'ADDNEW'"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'GOBACK'"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNDLT.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUP.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV24SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms["VBTNDOWN.CLICK"]=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV15FilName",fld:"vFILNAME",pic:""},{av:"AV24SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0},{av:"AV19MenuId",fld:"vMENUID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV17Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[]];this.EvtParms.VALIDV_TYPE=[[{ctrl:"vTYPE"},{av:"AV25Type",fld:"vTYPE",pic:""}],[{ctrl:"vTYPE"},{av:"AV25Type",fld:"vTYPE",pic:""}]];this.setVCMap("AV24SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV19MenuId","vMENUID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV24SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV19MenuId","vMENUID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV19MenuId","vMENUID",0,"int",12,0);this.setVCMap("AV24SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV19MenuId","vMENUID",0,"int",12,0);t.addRefreshingVar(this.GXValidFnc[19]);t.addRefreshingVar({rfrVar:"AV24SearchFilter"});t.addRefreshingVar({rfrVar:"AV19MenuId"});t.addRefreshingParm(this.GXValidFnc[19]);t.addRefreshingParm({rfrVar:"AV24SearchFilter"});t.addRefreshingParm({rfrVar:"AV19MenuId"});this.addBCProperty("Application",["Name"],this.GXValidFnc[27],"AV5Application");this.addBCProperty("Menu",["Name"],this.GXValidFnc[31],"AV18Menu");this.Initialize()});gx.wi(function(){gx.createParentObj(gam_wwappmenuoptions)})