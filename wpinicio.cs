using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpinicio : GXDataArea
   {
      public wpinicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wpinicio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpagerfm", "GeneXus.Programs.rwdmasterpagerfm", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0W2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1247300), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20209109462528", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpinicio.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Component6 == null ) )
         {
            WebComp_Component6.componentjscripts();
         }
         if ( ! ( WebComp_Component1 == null ) )
         {
            WebComp_Component1.componentjscripts();
         }
         if ( ! ( WebComp_Component4 == null ) )
         {
            WebComp_Component4.componentjscripts();
         }
         if ( ! ( WebComp_Component5 == null ) )
         {
            WebComp_Component5.componentjscripts();
         }
         if ( ! ( WebComp_Component2 == null ) )
         {
            WebComp_Component2.componentjscripts();
         }
         if ( ! ( WebComp_Component8 == null ) )
         {
            WebComp_Component8.componentjscripts();
         }
         if ( ! ( WebComp_Component10 == null ) )
         {
            WebComp_Component10.componentjscripts();
         }
         if ( ! ( WebComp_Component9 == null ) )
         {
            WebComp_Component9.componentjscripts();
         }
         if ( ! ( WebComp_Component3 == null ) )
         {
            WebComp_Component3.componentjscripts();
         }
         if ( ! ( WebComp_Component7 == null ) )
         {
            WebComp_Component7.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0W2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("wpinicio.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WPInicio" ;
      }

      public override String GetPgmdesc( )
      {
         return "WPInicio" ;
      }

      protected void WB0W0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0006"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0006"+"");
               }
               WebComp_Component6.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0009"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0009"+"");
               }
               WebComp_Component1.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0011"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0011"+"");
               }
               WebComp_Component4.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0013"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0013"+"");
               }
               WebComp_Component5.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-8", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0019"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
               }
               WebComp_Component2.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 col-md-4", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0021"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0021"+"");
               }
               WebComp_Component8.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0024"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0024"+"");
               }
               WebComp_Component10.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0026"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
               }
               WebComp_Component9.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0029"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
               }
               WebComp_Component3.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0032"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0032"+"");
               }
               WebComp_Component7.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0W2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Core 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "WPInicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0W0( ) ;
      }

      protected void WS0W2( )
      {
         START0W2( ) ;
         EVT0W2( ) ;
      }

      protected void EVT0W2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E110W2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 6 )
                        {
                           WebComp_Component6 = getWebComponent(GetType(), "GeneXus.Programs", "wccantcli", new Object[] {context} );
                           WebComp_Component6.ComponentInit();
                           WebComp_Component6.Name = "WCCantCli";
                           WebComp_Component6_Component = "WCCantCli";
                           WebComp_Component6.componentprocess("W0006", "", sEvt);
                        }
                        else if ( nCmpId == 9 )
                        {
                           WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiechartcli", new Object[] {context} );
                           WebComp_Component1.ComponentInit();
                           WebComp_Component1.Name = "WCPieChartCli";
                           WebComp_Component1_Component = "WCPieChartCli";
                           WebComp_Component1.componentprocess("W0009", "", sEvt);
                        }
                        else if ( nCmpId == 11 )
                        {
                           WebComp_Component4 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiechartfac", new Object[] {context} );
                           WebComp_Component4.ComponentInit();
                           WebComp_Component4.Name = "WCPieChartFac";
                           WebComp_Component4_Component = "WCPieChartFac";
                           WebComp_Component4.componentprocess("W0011", "", sEvt);
                        }
                        else if ( nCmpId == 13 )
                        {
                           WebComp_Component5 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiecharttks", new Object[] {context} );
                           WebComp_Component5.ComponentInit();
                           WebComp_Component5.Name = "WCPieChartTks";
                           WebComp_Component5_Component = "WCPieChartTks";
                           WebComp_Component5.componentprocess("W0013", "", sEvt);
                        }
                        else if ( nCmpId == 19 )
                        {
                           WebComp_Component2 = getWebComponent(GetType(), "GeneXus.Programs", "wccolumnchart", new Object[] {context} );
                           WebComp_Component2.ComponentInit();
                           WebComp_Component2.Name = "WCColumnChart";
                           WebComp_Component2_Component = "WCColumnChart";
                           WebComp_Component2.componentprocess("W0019", "", sEvt);
                        }
                        else if ( nCmpId == 21 )
                        {
                           WebComp_Component8 = getWebComponent(GetType(), "GeneXus.Programs", "wctable", new Object[] {context} );
                           WebComp_Component8.ComponentInit();
                           WebComp_Component8.Name = "WCTable";
                           WebComp_Component8_Component = "WCTable";
                           WebComp_Component8.componentprocess("W0021", "", sEvt);
                        }
                        else if ( nCmpId == 24 )
                        {
                           WebComp_Component10 = getWebComponent(GetType(), "GeneXus.Programs", "wctable", new Object[] {context} );
                           WebComp_Component10.ComponentInit();
                           WebComp_Component10.Name = "WCTable";
                           WebComp_Component10_Component = "WCTable";
                           WebComp_Component10.componentprocess("W0024", "", sEvt);
                        }
                        else if ( nCmpId == 26 )
                        {
                           WebComp_Component9 = getWebComponent(GetType(), "GeneXus.Programs", "wctable2", new Object[] {context} );
                           WebComp_Component9.ComponentInit();
                           WebComp_Component9.Name = "WCTable2";
                           WebComp_Component9_Component = "WCTable2";
                           WebComp_Component9.componentprocess("W0026", "", sEvt);
                        }
                        else if ( nCmpId == 29 )
                        {
                           WebComp_Component3 = getWebComponent(GetType(), "GeneXus.Programs", "wcsankey", new Object[] {context} );
                           WebComp_Component3.ComponentInit();
                           WebComp_Component3.Name = "WCSankey";
                           WebComp_Component3_Component = "WCSankey";
                           WebComp_Component3.componentprocess("W0029", "", sEvt);
                        }
                        else if ( nCmpId == 32 )
                        {
                           WebComp_Component7 = getWebComponent(GetType(), "GeneXus.Programs", "wclinechartfac", new Object[] {context} );
                           WebComp_Component7.ComponentInit();
                           WebComp_Component7.Name = "WCLineChartFac";
                           WebComp_Component7_Component = "WCLineChartFac";
                           WebComp_Component7.componentprocess("W0032", "", sEvt);
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0W2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0W2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0W2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component6_Component, "") == 0 )
            {
               WebComp_Component6 = getWebComponent(GetType(), "GeneXus.Programs", "wccantcli", new Object[] {context} );
               WebComp_Component6.ComponentInit();
               WebComp_Component6.Name = "WCCantCli";
               WebComp_Component6_Component = "WCCantCli";
            }
            WebComp_Component6.setjustcreated();
            WebComp_Component6.componentprepare(new Object[] {(String)"W0006",(String)""});
            WebComp_Component6.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0006"+"");
               WebComp_Component6.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component6.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
            {
               WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiechartcli", new Object[] {context} );
               WebComp_Component1.ComponentInit();
               WebComp_Component1.Name = "WCPieChartCli";
               WebComp_Component1_Component = "WCPieChartCli";
            }
            WebComp_Component1.setjustcreated();
            WebComp_Component1.componentprepare(new Object[] {(String)"W0009",(String)""});
            WebComp_Component1.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0009"+"");
               WebComp_Component1.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component1.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component4_Component, "") == 0 )
            {
               WebComp_Component4 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiechartfac", new Object[] {context} );
               WebComp_Component4.ComponentInit();
               WebComp_Component4.Name = "WCPieChartFac";
               WebComp_Component4_Component = "WCPieChartFac";
            }
            WebComp_Component4.setjustcreated();
            WebComp_Component4.componentprepare(new Object[] {(String)"W0011",(String)""});
            WebComp_Component4.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0011"+"");
               WebComp_Component4.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component4.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component5_Component, "") == 0 )
            {
               WebComp_Component5 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiecharttks", new Object[] {context} );
               WebComp_Component5.ComponentInit();
               WebComp_Component5.Name = "WCPieChartTks";
               WebComp_Component5_Component = "WCPieChartTks";
            }
            WebComp_Component5.setjustcreated();
            WebComp_Component5.componentprepare(new Object[] {(String)"W0013",(String)""});
            WebComp_Component5.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0013"+"");
               WebComp_Component5.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component5.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component2_Component, "") == 0 )
            {
               WebComp_Component2 = getWebComponent(GetType(), "GeneXus.Programs", "wccolumnchart", new Object[] {context} );
               WebComp_Component2.ComponentInit();
               WebComp_Component2.Name = "WCColumnChart";
               WebComp_Component2_Component = "WCColumnChart";
            }
            WebComp_Component2.setjustcreated();
            WebComp_Component2.componentprepare(new Object[] {(String)"W0019",(String)""});
            WebComp_Component2.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0019"+"");
               WebComp_Component2.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component2.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component8_Component, "") == 0 )
            {
               WebComp_Component8 = getWebComponent(GetType(), "GeneXus.Programs", "wctable", new Object[] {context} );
               WebComp_Component8.ComponentInit();
               WebComp_Component8.Name = "WCTable";
               WebComp_Component8_Component = "WCTable";
            }
            WebComp_Component8.setjustcreated();
            WebComp_Component8.componentprepare(new Object[] {(String)"W0021",(String)""});
            WebComp_Component8.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0021"+"");
               WebComp_Component8.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component8.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component10_Component, "") == 0 )
            {
               WebComp_Component10 = getWebComponent(GetType(), "GeneXus.Programs", "wctable", new Object[] {context} );
               WebComp_Component10.ComponentInit();
               WebComp_Component10.Name = "WCTable";
               WebComp_Component10_Component = "WCTable";
            }
            WebComp_Component10.setjustcreated();
            WebComp_Component10.componentprepare(new Object[] {(String)"W0024",(String)""});
            WebComp_Component10.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0024"+"");
               WebComp_Component10.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component10.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component9_Component, "") == 0 )
            {
               WebComp_Component9 = getWebComponent(GetType(), "GeneXus.Programs", "wctable2", new Object[] {context} );
               WebComp_Component9.ComponentInit();
               WebComp_Component9.Name = "WCTable2";
               WebComp_Component9_Component = "WCTable2";
            }
            WebComp_Component9.setjustcreated();
            WebComp_Component9.componentprepare(new Object[] {(String)"W0026",(String)""});
            WebComp_Component9.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
               WebComp_Component9.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component9.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component3_Component, "") == 0 )
            {
               WebComp_Component3 = getWebComponent(GetType(), "GeneXus.Programs", "wcsankey", new Object[] {context} );
               WebComp_Component3.ComponentInit();
               WebComp_Component3.Name = "WCSankey";
               WebComp_Component3_Component = "WCSankey";
            }
            WebComp_Component3.setjustcreated();
            WebComp_Component3.componentprepare(new Object[] {(String)"W0029",(String)""});
            WebComp_Component3.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
               WebComp_Component3.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component3.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Component7_Component, "") == 0 )
            {
               WebComp_Component7 = getWebComponent(GetType(), "GeneXus.Programs", "wclinechartfac", new Object[] {context} );
               WebComp_Component7.ComponentInit();
               WebComp_Component7.Name = "WCLineChartFac";
               WebComp_Component7_Component = "WCLineChartFac";
            }
            WebComp_Component7.setjustcreated();
            WebComp_Component7.componentprepare(new Object[] {(String)"W0032",(String)""});
            WebComp_Component7.componentbind(new Object[] {});
            if ( isFullAjaxMode( ) )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0032"+"");
               WebComp_Component7.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( 1 != 0 )
            {
               WebComp_Component7.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E110W2 ();
            WB0W0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0W2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E110W2( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0W2( ) ;
         WS0W2( ) ;
         WE0W2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( StringUtil.StrCmp(WebComp_Component6_Component, "") == 0 )
         {
            WebComp_Component6 = getWebComponent(GetType(), "GeneXus.Programs", "wccantcli", new Object[] {context} );
            WebComp_Component6.ComponentInit();
            WebComp_Component6.Name = "WCCantCli";
            WebComp_Component6_Component = "WCCantCli";
         }
         if ( ! ( WebComp_Component6 == null ) )
         {
            WebComp_Component6.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component1_Component, "") == 0 )
         {
            WebComp_Component1 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiechartcli", new Object[] {context} );
            WebComp_Component1.ComponentInit();
            WebComp_Component1.Name = "WCPieChartCli";
            WebComp_Component1_Component = "WCPieChartCli";
         }
         if ( ! ( WebComp_Component1 == null ) )
         {
            WebComp_Component1.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component4_Component, "") == 0 )
         {
            WebComp_Component4 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiechartfac", new Object[] {context} );
            WebComp_Component4.ComponentInit();
            WebComp_Component4.Name = "WCPieChartFac";
            WebComp_Component4_Component = "WCPieChartFac";
         }
         if ( ! ( WebComp_Component4 == null ) )
         {
            WebComp_Component4.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component5_Component, "") == 0 )
         {
            WebComp_Component5 = getWebComponent(GetType(), "GeneXus.Programs", "wcpiecharttks", new Object[] {context} );
            WebComp_Component5.ComponentInit();
            WebComp_Component5.Name = "WCPieChartTks";
            WebComp_Component5_Component = "WCPieChartTks";
         }
         if ( ! ( WebComp_Component5 == null ) )
         {
            WebComp_Component5.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component2_Component, "") == 0 )
         {
            WebComp_Component2 = getWebComponent(GetType(), "GeneXus.Programs", "wccolumnchart", new Object[] {context} );
            WebComp_Component2.ComponentInit();
            WebComp_Component2.Name = "WCColumnChart";
            WebComp_Component2_Component = "WCColumnChart";
         }
         if ( ! ( WebComp_Component2 == null ) )
         {
            WebComp_Component2.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component8_Component, "") == 0 )
         {
            WebComp_Component8 = getWebComponent(GetType(), "GeneXus.Programs", "wctable", new Object[] {context} );
            WebComp_Component8.ComponentInit();
            WebComp_Component8.Name = "WCTable";
            WebComp_Component8_Component = "WCTable";
         }
         if ( ! ( WebComp_Component8 == null ) )
         {
            WebComp_Component8.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component10_Component, "") == 0 )
         {
            WebComp_Component10 = getWebComponent(GetType(), "GeneXus.Programs", "wctable", new Object[] {context} );
            WebComp_Component10.ComponentInit();
            WebComp_Component10.Name = "WCTable";
            WebComp_Component10_Component = "WCTable";
         }
         if ( ! ( WebComp_Component10 == null ) )
         {
            WebComp_Component10.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component9_Component, "") == 0 )
         {
            WebComp_Component9 = getWebComponent(GetType(), "GeneXus.Programs", "wctable2", new Object[] {context} );
            WebComp_Component9.ComponentInit();
            WebComp_Component9.Name = "WCTable2";
            WebComp_Component9_Component = "WCTable2";
         }
         if ( ! ( WebComp_Component9 == null ) )
         {
            WebComp_Component9.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component3_Component, "") == 0 )
         {
            WebComp_Component3 = getWebComponent(GetType(), "GeneXus.Programs", "wcsankey", new Object[] {context} );
            WebComp_Component3.ComponentInit();
            WebComp_Component3.Name = "WCSankey";
            WebComp_Component3_Component = "WCSankey";
         }
         if ( ! ( WebComp_Component3 == null ) )
         {
            WebComp_Component3.componentthemes();
         }
         if ( StringUtil.StrCmp(WebComp_Component7_Component, "") == 0 )
         {
            WebComp_Component7 = getWebComponent(GetType(), "GeneXus.Programs", "wclinechartfac", new Object[] {context} );
            WebComp_Component7.ComponentInit();
            WebComp_Component7.Name = "WCLineChartFac";
            WebComp_Component7_Component = "WCLineChartFac";
         }
         if ( ! ( WebComp_Component7 == null ) )
         {
            WebComp_Component7.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20209109462557", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wpinicio.js", "?20209109462558", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPInicio";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         WebComp_Component6_Component = "";
         WebComp_Component1_Component = "";
         WebComp_Component4_Component = "";
         WebComp_Component5_Component = "";
         WebComp_Component2_Component = "";
         WebComp_Component8_Component = "";
         WebComp_Component10_Component = "";
         WebComp_Component9_Component = "";
         WebComp_Component3_Component = "";
         WebComp_Component7_Component = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         WebComp_Component6 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component1 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component4 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component5 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component2 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component8 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component10 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component9 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component3 = new GeneXus.Http.GXNullWebComponent();
         WebComp_Component7 = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String WebComp_Component6_Component ;
      private String WebComp_Component1_Component ;
      private String WebComp_Component4_Component ;
      private String WebComp_Component5_Component ;
      private String WebComp_Component2_Component ;
      private String WebComp_Component8_Component ;
      private String WebComp_Component10_Component ;
      private String WebComp_Component9_Component ;
      private String WebComp_Component3_Component ;
      private String WebComp_Component7_Component ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private GXWebComponent WebComp_Component6 ;
      private GXWebComponent WebComp_Component1 ;
      private GXWebComponent WebComp_Component4 ;
      private GXWebComponent WebComp_Component5 ;
      private GXWebComponent WebComp_Component2 ;
      private GXWebComponent WebComp_Component8 ;
      private GXWebComponent WebComp_Component10 ;
      private GXWebComponent WebComp_Component9 ;
      private GXWebComponent WebComp_Component3 ;
      private GXWebComponent WebComp_Component7 ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

}
