gx.evt.autoSkip=!1;gx.define("wplinechart",!1,function(){this.ServerClass="wplinechart";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e120q2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130q2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};this.Events={e120q2_client:["ENTER",!0],e130q2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.Initialize();this.setComponent({id:"COMPONENT1",GXClass:"wclinechart",Prefix:"W0006",lvl:1})});gx.wi(function(){gx.createParentObj(wplinechart)})