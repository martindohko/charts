gx.evt.autoSkip=!1;gx.define("gam_wwappmenus",!1,function(){var n,t;this.ServerClass="gam_wwappmenus";this.PackageName="GeneXus.Security.Backend";this.setObjectType("web");this.setAjaxSecurity(!1);this.setOnAjaxSessionTimeout("Warn");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV17SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator);this.AV17SearchFilter=gx.fn.getControlValue("vSEARCHFILTER");this.AV6ApplicationId=gx.fn.getIntegerValue("vAPPLICATIONID",gx.thousandSeparator)};this.e122g1_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["INS",this.AV6ApplicationId,0]),this.refreshOutputs([{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e112g1_client=function(){return this.clearMessages(),this.call("gam_applicationentry.aspx",["DSP",this.AV6ApplicationId]),this.refreshOutputs([{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e142g2_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["DSP",this.AV6ApplicationId,this.AV15Id]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e162g2_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["UPD",this.AV6ApplicationId,this.AV15Id]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e172g2_client=function(){return this.clearMessages(),this.call("gam_appmenuentry.aspx",["DLT",this.AV6ApplicationId,this.AV15Id]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e152g2_client=function(){return this.clearMessages(),this.call("gam_wwappmenuoptions.aspx",[this.AV6ApplicationId,this.AV15Id]),this.refreshOutputs([{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]),gx.$.Deferred().resolve()};this.e182g2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e192g2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,31,32,34,35,36,37,38,39];this.GXLastCtrlId=39;this.GridwwContainer=new gx.grid.grid(this,2,"WbpLvl2",33,"Gridww","Gridww","GridwwContainer",this.CmpContext,this.IsMasterPage,"gam_wwappmenus",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px",gx.getMessage("GXM_newrow"),!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridwwContainer;t.addSingleLineEdit("Name",34,"vNAME",gx.getMessage("Menu name"),"","Name","char",0,"px",120,80,"left","e142g2_client",[],"Name","Name",!0,0,!1,!1,"Attribute TextLikeLink SmallLink",1,"WWColumn");t.addSingleLineEdit("Dsc",35,"vDSC",gx.getMessage("Description"),"","Dsc","char",0,"px",254,80,"left",null,[],"Dsc","Dsc",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Btnmenuoptions",36,"vBTNMENUOPTIONS","","","BtnMenuOptions","char",0,"px",20,20,"left","e152g2_client",[],"Btnmenuoptions","BtnMenuOptions",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btnupd",37,"vBTNUPD","","","BtnUpd","char",0,"px",20,20,"left","e162g2_client",[],"Btnupd","BtnUpd",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Btndlt",38,"vBTNDLT","","","BtnDlt","char",0,"px",20,20,"left","e172g2_client",[],"Btndlt","BtnDlt",!0,0,!1,!1,"TextActionAttribute TextLikeLink",1,"WWTextActionColumn");t.addSingleLineEdit("Id",39,"vID",gx.getMessage("Id"),"","Id","int",0,"px",12,12,"right",null,[],"Id","Id",!1,0,!1,!1,"Attribute",1,"");this.GridwwContainer.emptyText=gx.getMessage("");this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TABLE1",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"BACK",grid:0,evt:"e112g1_client"};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"ADDNEW",grid:0,evt:"e122g1_client"};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFILNAME",gxz:"ZV13FilName",gxold:"OV13FilName",gxvar:"AV13FilName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV13FilName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13FilName=n)},v2c:function(){gx.fn.setControlValue("vFILNAME",gx.O.AV13FilName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV13FilName=this.val())},val:function(){return gx.fn.getControlValue("vFILNAME")},nac:gx.falseFn};this.declareDomainHdlr(19,function(){});n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"GRIDCELL",grid:0};n[22]={id:22,fld:"TABLE7",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CTLNAME",gxz:"ZV20GXV1",gxold:"OV20GXV1",gxvar:"GXV1",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.GXV1=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20GXV1=n)},v2c:function(){gx.fn.setControlValue("CTLNAME",gx.O.GXV1,0)},c2v:function(){this.val()!==undefined&&(gx.O.GXV1=this.val())},val:function(){return gx.fn.getControlValue("CTLNAME")},nac:gx.falseFn};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[34]={id:34,lvl:2,type:"char",len:120,dec:0,sign:!1,ro:0,isacc:0,grid:33,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV16Name",gxold:"OV16Name",gxvar:"AV16Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV16Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV16Name=n)},v2c:function(n){gx.fn.setGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(33),gx.O.AV16Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV16Name=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNAME",n||gx.fn.currentGridRowImpl(33))},nac:gx.falseFn,evt:"e142g2_client"};n[35]={id:35,lvl:2,type:"char",len:254,dec:0,sign:!1,ro:0,isacc:0,grid:33,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDSC",gxz:"ZV11Dsc",gxold:"OV11Dsc",gxvar:"AV11Dsc",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11Dsc=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Dsc=n)},v2c:function(n){gx.fn.setGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(33),gx.O.AV11Dsc,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11Dsc=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDSC",n||gx.fn.currentGridRowImpl(33))},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:33,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNMENUOPTIONS",gxz:"ZV9BtnMenuOptions",gxold:"OV9BtnMenuOptions",gxvar:"AV9BtnMenuOptions",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV9BtnMenuOptions=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9BtnMenuOptions=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNMENUOPTIONS",n||gx.fn.currentGridRowImpl(33),gx.O.AV9BtnMenuOptions,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9BtnMenuOptions=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNMENUOPTIONS",n||gx.fn.currentGridRowImpl(33))},nac:gx.falseFn,evt:"e152g2_client"};n[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:33,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNUPD",gxz:"ZV10BtnUpd",gxold:"OV10BtnUpd",gxvar:"AV10BtnUpd",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10BtnUpd=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10BtnUpd=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(33),gx.O.AV10BtnUpd,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10BtnUpd=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNUPD",n||gx.fn.currentGridRowImpl(33))},nac:gx.falseFn,evt:"e162g2_client"};n[38]={id:38,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:0,isacc:0,grid:33,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBTNDLT",gxz:"ZV8BtnDlt",gxold:"OV8BtnDlt",gxvar:"AV8BtnDlt",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV8BtnDlt=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8BtnDlt=n)},v2c:function(n){gx.fn.setGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(33),gx.O.AV8BtnDlt,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8BtnDlt=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vBTNDLT",n||gx.fn.currentGridRowImpl(33))},nac:gx.falseFn,evt:"e172g2_client"};n[39]={id:39,lvl:2,type:"int",len:12,dec:0,sign:!1,pic:"ZZZZZZZZZZZ9",ro:0,isacc:0,grid:33,gxgrid:this.GridwwContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vID",gxz:"ZV15Id",gxold:"OV15Id",gxvar:"AV15Id",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.AV15Id=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV15Id=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vID",n||gx.fn.currentGridRowImpl(33),gx.O.AV15Id,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV15Id=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vID",n||gx.fn.currentGridRowImpl(33),gx.thousandSeparator)},nac:gx.falseFn};this.AV13FilName="";this.ZV13FilName="";this.OV13FilName="";this.GXV1="";this.ZV20GXV1="";this.OV20GXV1="";this.ZV16Name="";this.OV16Name="";this.ZV11Dsc="";this.OV11Dsc="";this.ZV9BtnMenuOptions="";this.OV9BtnMenuOptions="";this.ZV10BtnUpd="";this.OV10BtnUpd="";this.ZV8BtnDlt="";this.OV8BtnDlt="";this.ZV15Id=0;this.OV15Id=0;this.AV13FilName="";this.GXV1="";this.AV6ApplicationId=0;this.AV16Name="";this.AV11Dsc="";this.AV9BtnMenuOptions="";this.AV10BtnUpd="";this.AV8BtnDlt="";this.AV15Id=0;this.AV17SearchFilter="";this.Events={e182g2_client:["ENTER",!0],e192g2_client:["CANCEL",!0],e122g1_client:["'ADDNEW'",!1],e112g1_client:["'GOBACK'",!1],e142g2_client:["VNAME.CLICK",!1],e162g2_client:["VBTNUPD.CLICK",!1],e172g2_client:["VBTNDLT.CLICK",!1],e152g2_client:["VBTNMENUOPTIONS.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRIDWW_nFirstRecordOnPage"},{av:"GRIDWW_nEOF"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13FilName",fld:"vFILNAME",pic:""},{av:"AV17SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0}],[]];this.EvtParms["GRIDWW.LOAD"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV13FilName",fld:"vFILNAME",pic:""},{av:"AV17SearchFilter",fld:"vSEARCHFILTER",pic:"",hsh:!0}],[{av:"AV10BtnUpd",fld:"vBTNUPD",pic:""},{av:"AV8BtnDlt",fld:"vBTNDLT",pic:""},{av:"AV9BtnMenuOptions",fld:"vBTNMENUOPTIONS",pic:""},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV16Name",fld:"vNAME",pic:""},{av:"AV11Dsc",fld:"vDSC",pic:""}]];this.EvtParms["'ADDNEW'"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["'GOBACK'"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VNAME.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNUPD.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNDLT.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.EvtParms["VBTNMENUOPTIONS.CLICK"]=[[{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"},{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"}],[{av:"AV15Id",fld:"vID",pic:"ZZZZZZZZZZZ9"},{av:"AV6ApplicationId",fld:"vAPPLICATIONID",pic:"ZZZZZZZZZZZ9"}]];this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV17SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV17SearchFilter","vSEARCHFILTER",0,"char",254,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV6ApplicationId","vAPPLICATIONID",0,"int",12,0);this.setVCMap("AV17SearchFilter","vSEARCHFILTER",0,"char",254,0);t.addRefreshingVar({rfrVar:"AV6ApplicationId"});t.addRefreshingVar(this.GXValidFnc[19]);t.addRefreshingVar({rfrVar:"AV17SearchFilter"});t.addRefreshingParm({rfrVar:"AV6ApplicationId"});t.addRefreshingParm(this.GXValidFnc[19]);t.addRefreshingParm({rfrVar:"AV17SearchFilter"});this.addBCProperty("Application",["Name"],this.GXValidFnc[27],"AV5Application");this.Initialize()});gx.wi(function(){gx.createParentObj(gam_wwappmenus)})