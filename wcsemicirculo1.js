gx.evt.autoSkip=!1;gx.define("wcsemicirculo1",!0,function(n){var i,t;this.ServerClass="wcsemicirculo1";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e131a2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e141a2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];i=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5];this.GXLastCtrlId=5;this.UCSEMICIRCLE1Container=gx.uc.getNew(this,6,0,"UCSemicircle",this.CmpContext+"UCSEMICIRCLE1Container","Ucsemicircle1","UCSEMICIRCLE1");t=this.UCSEMICIRCLE1Container;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setDynProp("value","Value","2.3","str");t.setDynProp("text2remzise","Text2remzise","4","str");t.setDynProp("colour","Colour","green","str");t.setDynProp("text1remzise","Text1remzise","2","str");t.setDynProp("deg","Deg","83","str");t.setDynProp("percentage","Percentage","46","str");t.setProp("Visible","Visible",!0,"bool");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);i[2]={id:2,fld:"",grid:0};i[3]={id:3,fld:"MAINTABLE",grid:0};i[4]={id:4,fld:"",grid:0};i[5]={id:5,fld:"",grid:0};this.Events={e131a2_client:["ENTER",!0],e141a2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms.START=[[],[{av:"this.UCSEMICIRCLE1Container.percentage",ctrl:"UCSEMICIRCLE1",prop:"percentage"},{av:"this.UCSEMICIRCLE1Container.value",ctrl:"UCSEMICIRCLE1",prop:"value"},{av:"this.UCSEMICIRCLE1Container.deg",ctrl:"UCSEMICIRCLE1",prop:"deg"},{av:"this.UCSEMICIRCLE1Container.colour",ctrl:"UCSEMICIRCLE1",prop:"colour"},{av:"this.UCSEMICIRCLE1Container.text1remzise",ctrl:"UCSEMICIRCLE1",prop:"text1remzise"},{av:"this.UCSEMICIRCLE1Container.text2remzise",ctrl:"UCSEMICIRCLE1",prop:"text2remzise"}]];this.Initialize()})