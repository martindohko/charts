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
namespace GeneXus.Programs.version1 {
   public class wccantcli : GXWebComponent
   {
      public wccantcli( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public wccantcli( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref int aP0_corte1 ,
                           ref int aP1_corte2 )
      {
         this.AV16corte1 = aP0_corte1;
         this.AV15corte2 = aP1_corte2;
         executePrivate();
         aP0_corte1=this.AV16corte1;
         aP1_corte2=this.AV15corte2;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( String sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (String)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetNextPar( );
                  sSFPrefix = GetNextPar( );
                  AV16corte1 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV16corte1", StringUtil.LTrimStr( (decimal)(AV16corte1), 8, 0));
                  AV15corte2 = (int)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri(sPrefix, false, "AV15corte2", StringUtil.LTrimStr( (decimal)(AV15corte2), 8, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(String)sCompPrefix,(String)sSFPrefix,(int)AV16corte1,(int)AV15corte2});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "WCCant Cli") ;
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1247300), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202091115385433", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("version1.wccantcli.aspx") + "?" + UrlEncode("" +AV16corte1) + "," + UrlEncode("" +AV15corte2)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( ) ;
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAXES", AV7Axes);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAXES", AV7Axes);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPARAMETERS", AV5Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPARAMETERS", AV5Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCLICKDATA", AV13ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCLICKDATA", AV13ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMDOUBLECLICKDATA", AV14ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMDOUBLECLICKDATA", AV14ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDRAGANDDROPDATA", AV9DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDRAGANDDROPDATA", AV9DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMEXPANDDATA", AV10ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMEXPANDDATA", AV10ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCOLLAPSEDATA", AV11ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCOLLAPSEDATA", AV11ItemCollapseData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16corte1", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV16corte1), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV15corte2", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV15corte2), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCORTE1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16corte1), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCORTE2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15corte2), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWER1_Objectname", StringUtil.RTrim( Queryviewer1_Objectname));
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            context.AddJavascriptSource("version1/wccantcli.js", "?202091115385441", false, true);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override String GetPgmname( )
      {
         return "Version1.WCCantCli" ;
      }

      public override String GetPgmdesc( )
      {
         return "WCCant Cli" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "version1.wccantcli.aspx");
               context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQueryviewer1.SetProperty("Axes", AV7Axes);
            ucQueryviewer1.SetProperty("Parameters", AV5Parameters);
            ucQueryviewer1.SetProperty("ObjectName", Queryviewer1_Objectname);
            ucQueryviewer1.SetProperty("Title", Queryviewer1_Title);
            ucQueryviewer1.SetProperty("ItemClickData", AV13ItemClickData);
            ucQueryviewer1.SetProperty("ItemDoubleClickData", AV14ItemDoubleClickData);
            ucQueryviewer1.SetProperty("DragAndDropData", AV9DragAndDropData);
            ucQueryviewer1.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucQueryviewer1.SetProperty("ItemExpandData", AV10ItemExpandData);
            ucQueryviewer1.SetProperty("ItemCollapseData", AV11ItemCollapseData);
            ucQueryviewer1.Render(context, "queryviewer", Queryviewer1_Internalname, sPrefix+"QUERYVIEWER1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Core 16_0_10-142546", 0) ;
               }
               Form.Meta.addItem("description", "WCCant Cli", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0X0( ) ;
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E110X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
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
         RF0X2( ) ;
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

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E110X2 ();
            WB0X0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vAXES"), AV7Axes);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPARAMETERS"), AV5Parameters);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCLICKDATA"), AV13ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMDOUBLECLICKDATA"), AV14ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDRAGANDDROPDATA"), AV9DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERCHANGEDDATA"), AV12FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMEXPANDDATA"), AV10ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCOLLAPSEDATA"), AV11ItemCollapseData);
            /* Read saved values. */
            wcpOAV16corte1 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16corte1"), ".", ","));
            wcpOAV15corte2 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15corte2"), ".", ","));
            Queryviewer1_Objectname = cgiGet( sPrefix+"QUERYVIEWER1_Objectname");
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

      protected void E110X2( )
      {
         /* Load Routine */
         AV6Parameter = new GeneXus.Programs.version1.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "Corte1";
         AV6Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV16corte1), 8, 0);
         AV5Parameters.Add(AV6Parameter, 0);
         AV6Parameter = new GeneXus.Programs.version1.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "Corte2";
         AV6Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV15corte2), 8, 0);
         AV5Parameters.Add(AV6Parameter, 0);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16corte1 = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV16corte1", StringUtil.LTrimStr( (decimal)(AV16corte1), 8, 0));
         AV15corte2 = Convert.ToInt32(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV15corte2", StringUtil.LTrimStr( (decimal)(AV15corte2), 8, 0));
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV16corte1 = (String)((String)getParm(obj,0));
         sCtrlAV15corte2 = (String)((String)getParm(obj,1));
      }

      public override void componentrestorestate( String sPPrefix ,
                                                  String sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (String)getParm(obj,0);
         sSFPrefix = (String)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "version1\\wccantcli", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0X2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16corte1 = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV16corte1", StringUtil.LTrimStr( (decimal)(AV16corte1), 8, 0));
            AV15corte2 = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV15corte2", StringUtil.LTrimStr( (decimal)(AV15corte2), 8, 0));
         }
         wcpOAV16corte1 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV16corte1"), ".", ","));
         wcpOAV15corte2 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV15corte2"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV16corte1 != wcpOAV16corte1 ) || ( AV15corte2 != wcpOAV15corte2 ) ) )
         {
            setjustcreated();
         }
         wcpOAV16corte1 = AV16corte1;
         wcpOAV15corte2 = AV15corte2;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV16corte1 = cgiGet( sPrefix+"AV16corte1_CTRL");
         if ( StringUtil.Len( sCtrlAV16corte1) > 0 )
         {
            AV16corte1 = (int)(context.localUtil.CToN( cgiGet( sCtrlAV16corte1), ".", ","));
            AssignAttri(sPrefix, false, "AV16corte1", StringUtil.LTrimStr( (decimal)(AV16corte1), 8, 0));
         }
         else
         {
            AV16corte1 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV16corte1_PARM"), ".", ","));
         }
         sCtrlAV15corte2 = cgiGet( sPrefix+"AV15corte2_CTRL");
         if ( StringUtil.Len( sCtrlAV15corte2) > 0 )
         {
            AV15corte2 = (int)(context.localUtil.CToN( cgiGet( sCtrlAV15corte2), ".", ","));
            AssignAttri(sPrefix, false, "AV15corte2", StringUtil.LTrimStr( (decimal)(AV15corte2), 8, 0));
         }
         else
         {
            AV15corte2 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV15corte2_PARM"), ".", ","));
         }
      }

      public override void componentprocess( String sPPrefix ,
                                             String sPSFPrefix ,
                                             String sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16corte1_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16corte1), 8, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16corte1)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16corte1_CTRL", StringUtil.RTrim( sCtrlAV16corte1));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV15corte2_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15corte2), 8, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV15corte2)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV15corte2_CTRL", StringUtil.RTrim( sCtrlAV15corte2));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override String getstring( String sGXControl )
      {
         String sCtrlName ;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202091115385471", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("version1/wccantcli.js", "?202091115385471", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-3d.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/highcharts-more.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/funnel.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/highcharts/modules/solid-gauge.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/oatPivot/gxpivotjs.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Queryviewer1_Internalname = sPrefix+"QUERYVIEWER1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         Queryviewer1_Objectname = "QKPIChart1";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV7Axes = new GXBaseCollection<GeneXus.Programs.version1.SdtQueryViewerAxes_Axis>( context, "Axis", "RFM");
         AV5Parameters = new GXBaseCollection<GeneXus.Programs.version1.SdtQueryViewerParameters_Parameter>( context, "Parameter", "RFM");
         AV13ItemClickData = new GeneXus.Programs.version1.SdtQueryViewerItemClickData(context);
         AV14ItemDoubleClickData = new GeneXus.Programs.version1.SdtQueryViewerItemDoubleClickData(context);
         AV9DragAndDropData = new GeneXus.Programs.version1.SdtQueryViewerDragAndDropData(context);
         AV12FilterChangedData = new GeneXus.Programs.version1.SdtQueryViewerFilterChangedData(context);
         AV10ItemExpandData = new GeneXus.Programs.version1.SdtQueryViewerItemExpandData(context);
         AV11ItemCollapseData = new GeneXus.Programs.version1.SdtQueryViewerItemCollapseData(context);
         GX_FocusControl = "";
         ucQueryviewer1 = new GXUserControl();
         Queryviewer1_Title = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6Parameter = new GeneXus.Programs.version1.SdtQueryViewerParameters_Parameter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16corte1 = "";
         sCtrlAV15corte2 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int AV16corte1 ;
      private int AV15corte2 ;
      private int wcpOAV16corte1 ;
      private int wcpOAV15corte2 ;
      private int idxLst ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sPrefix ;
      private String sCompPrefix ;
      private String sSFPrefix ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String Queryviewer1_Objectname ;
      private String GX_FocusControl ;
      private String divMaintable_Internalname ;
      private String Queryviewer1_Title ;
      private String Queryviewer1_Internalname ;
      private String sXEvt ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sCtrlAV16corte1 ;
      private String sCtrlAV15corte2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private GXUserControl ucQueryviewer1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_corte1 ;
      private int aP1_corte2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.version1.SdtQueryViewerParameters_Parameter> AV5Parameters ;
      private GXBaseCollection<GeneXus.Programs.version1.SdtQueryViewerAxes_Axis> AV7Axes ;
      private GeneXus.Programs.version1.SdtQueryViewerParameters_Parameter AV6Parameter ;
      private GeneXus.Programs.version1.SdtQueryViewerDragAndDropData AV9DragAndDropData ;
      private GeneXus.Programs.version1.SdtQueryViewerItemExpandData AV10ItemExpandData ;
      private GeneXus.Programs.version1.SdtQueryViewerItemCollapseData AV11ItemCollapseData ;
      private GeneXus.Programs.version1.SdtQueryViewerFilterChangedData AV12FilterChangedData ;
      private GeneXus.Programs.version1.SdtQueryViewerItemClickData AV13ItemClickData ;
      private GeneXus.Programs.version1.SdtQueryViewerItemDoubleClickData AV14ItemDoubleClickData ;
   }

}
