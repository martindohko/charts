gx.evt.autoSkip = false;
gx.define('version1.home', false, function () {
   this.ServerClass =  "version1.home" ;
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
   this.e12092_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e13092_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,8];
   this.GXLastCtrlId =8;
   this.Grid1Container = new gx.grid.grid(this, 2,"WbpLvl2",5,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"version1.home",[],true,1,false,true,0,false,false,false,"",100,"%",0,"px","New row",false,false,false,null,null,false,"",false,[1,1,1,1],false,0,false,false);
   var Grid1Container = this.Grid1Container;
   Grid1Container.startRow("","","","","","");
   Grid1Container.startCell("","","","","","","","","","");
   Grid1Container.addSingleLineEdit("Menuitem",8,"vMENUITEM","","","MenuItem","char",80,"chr",100,80,"left",null,[],"Menuitem","MenuItem",true,0,false,false,"Attribute",1,"");
   Grid1Container.endCell();
   Grid1Container.endRow();
   this.Grid1Container.emptyText = "";
   this.setGrid(Grid1Container);
   GXValidFnc[2]={ id: 2, fld:"TABLE1",grid:0};
   GXValidFnc[8]={ id:8 ,lvl:2,type:"char",len:100,dec:0,sign:false,ro:1,isacc:0,grid:5,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMENUITEM",gxz:"ZV5MenuItem",gxold:"OV5MenuItem",gxvar:"AV5MenuItem",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.AV5MenuItem=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5MenuItem=Value},v2c:function(row){gx.fn.setGridControlValue("vMENUITEM",row || gx.fn.currentGridRowImpl(5),gx.O.AV5MenuItem,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.AV5MenuItem=this.val(row)},val:function(row){return gx.fn.getGridControlValue("vMENUITEM",row || gx.fn.currentGridRowImpl(5))},nac:gx.falseFn};
   this.AV5MenuItem = "" ;
   this.Events = {"e12092_client": ["ENTER", true] ,"e13092_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'}],[]];
   this.EvtParms["LOAD"] = [[],[{av:'AV5MenuItem',fld:'vMENUITEM',pic:''},{av:'gx.fn.getCtrlProperty("vMENUITEM","Link")',ctrl:'vMENUITEM',prop:'Link'}]];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(version1.home);});
