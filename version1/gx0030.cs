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
   public class gx0030 : GXDataArea
   {
      public gx0030( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0030( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out String aP0_pPeriodo )
      {
         this.AV13pPeriodo = "" ;
         executePrivate();
         aP0_pPeriodo=this.AV13pPeriodo;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_84_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV6cPeriodo = GetNextPar( );
               AV7cCorte1 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV8cCorte2 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV9cRFM = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV10cClientesDelAnio = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV11cClientesDelMes = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV12cMinRecencia = (long)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pPeriodo = gxfirstwebparm;
               AssignAttri("", false, "AV13pPeriodo", AV13pPeriodo);
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

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      protected override string IntegratedSecurityPermissionName
      {
         get {
            return "" ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("version1.rwdpromptmasterpage", "GeneXus.Programs.version1.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA102( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START102( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202091115392230", false, true);
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("version1.gx0030.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV13pPeriodo))+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPERIODO", AV6cPeriodo);
         GxWebStd.gx_hidden_field( context, "GXH_vCCORTE1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCorte1), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCORTE2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCorte2), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRFM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cRFM), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTESDELANIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cClientesDelAnio), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTESDELMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cClientesDelMes), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCMINRECENCIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cMinRecencia), 10, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPERIODO", AV13pPeriodo);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PERIODOFILTERCONTAINER_Class", StringUtil.RTrim( divPeriodofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORTE1FILTERCONTAINER_Class", StringUtil.RTrim( divCorte1filtercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORTE2FILTERCONTAINER_Class", StringUtil.RTrim( divCorte2filtercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFMFILTERCONTAINER_Class", StringUtil.RTrim( divRfmfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTESDELANIOFILTERCONTAINER_Class", StringUtil.RTrim( divClientesdelaniofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTESDELMESFILTERCONTAINER_Class", StringUtil.RTrim( divClientesdelmesfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "MINRECENCIAFILTERCONTAINER_Class", StringUtil.RTrim( divMinrecenciafiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE102( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT102( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("version1.gx0030.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV13pPeriodo)) ;
      }

      public override String GetPgmname( )
      {
         return "Version1.Gx0030" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List ResumenRFMGlobal" ;
      }

      protected void WB100( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPeriodofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPeriodofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblperiodofilter_Internalname, "Periodo", "", "", lblLblperiodofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCperiodo_Internalname, "Periodo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCperiodo_Internalname, AV6cPeriodo, StringUtil.RTrim( context.localUtil.Format( AV6cPeriodo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCperiodo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCperiodo_Visible, edtavCperiodo_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCorte1filtercontainer_Internalname, 1, 0, "px", 0, "px", divCorte1filtercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorte1filter_Internalname, "Corte1", "", "", lblLblcorte1filter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorte1_Internalname, "Corte1", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorte1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cCorte1), 8, 0, ".", "")), ((edtavCcorte1_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7cCorte1), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV7cCorte1), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorte1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorte1_Visible, edtavCcorte1_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCorte2filtercontainer_Internalname, 1, 0, "px", 0, "px", divCorte2filtercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorte2filter_Internalname, "Corte2", "", "", lblLblcorte2filter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorte2_Internalname, "Corte2", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorte2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cCorte2), 8, 0, ".", "")), ((edtavCcorte2_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8cCorte2), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV8cCorte2), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorte2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorte2_Visible, edtavCcorte2_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRfmfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRfmfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrfmfilter_Internalname, "RFM", "", "", lblLblrfmfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCrfm_Internalname, "RFM", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCrfm_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cRFM), 8, 0, ".", "")), ((edtavCrfm_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9cRFM), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV9cRFM), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCrfm_Jsonclick, 0, "Attribute", "", "", "", "", edtavCrfm_Visible, edtavCrfm_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientesdelaniofiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientesdelaniofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientesdelaniofilter_Internalname, "Clientes Del Anio", "", "", lblLblclientesdelaniofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientesdelanio_Internalname, "Clientes Del Anio", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientesdelanio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cClientesDelAnio), 10, 0, ".", "")), ((edtavCclientesdelanio_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10cClientesDelAnio), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV10cClientesDelAnio), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientesdelanio_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientesdelanio_Visible, edtavCclientesdelanio_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClientesdelmesfiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientesdelmesfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientesdelmesfilter_Internalname, "Clientes Del Mes", "", "", lblLblclientesdelmesfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientesdelmes_Internalname, "Clientes Del Mes", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientesdelmes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cClientesDelMes), 10, 0, ".", "")), ((edtavCclientesdelmes_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11cClientesDelMes), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV11cClientesDelMes), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientesdelmes_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientesdelmes_Visible, edtavCclientesdelmes_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMinrecenciafiltercontainer_Internalname, 1, 0, "px", 0, "px", divMinrecenciafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblminrecenciafilter_Internalname, "Min Recencia", "", "", lblLblminrecenciafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17101_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCminrecencia_Internalname, "Min Recencia", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCminrecencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cMinRecencia), 10, 0, ".", "")), ((edtavCminrecencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12cMinRecencia), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV12cMinRecencia), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCminrecencia_Jsonclick, 0, "Attribute", "", "", "", "", edtavCminrecencia_Visible, edtavCminrecencia_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18101_client"+"'", TempTags, "", 2, "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Periodo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Corte1") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Corte2") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RFM") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Del Anio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Del Mes") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Recencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Recencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Recencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Frecuencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A7Periodo);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8Corte1), 8, 0, ".", "")));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtCorte1_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9Corte2), 8, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10RFM), 8, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClientesDelAnio), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ClientesDelMes), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MinRecencia), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14MaxRecencia), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AvgRecencia), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A15MinFrecuencia, 10, 6, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\Gx0030.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START102( )
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
            Form.Meta.addItem("description", "Selection List ResumenRFMGlobal", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP100( ) ;
      }

      protected void WS102( )
      {
         START102( ) ;
         EVT102( ) ;
      }

      protected void EVT102( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A7Periodo = cgiGet( edtPeriodo_Internalname);
                              A8Corte1 = (int)(context.localUtil.CToN( cgiGet( edtCorte1_Internalname), ".", ","));
                              A9Corte2 = (int)(context.localUtil.CToN( cgiGet( edtCorte2_Internalname), ".", ","));
                              A10RFM = (int)(context.localUtil.CToN( cgiGet( edtRFM_Internalname), ".", ","));
                              A11ClientesDelAnio = (long)(context.localUtil.CToN( cgiGet( edtClientesDelAnio_Internalname), ".", ","));
                              n11ClientesDelAnio = false;
                              A12ClientesDelMes = (long)(context.localUtil.CToN( cgiGet( edtClientesDelMes_Internalname), ".", ","));
                              A13MinRecencia = (long)(context.localUtil.CToN( cgiGet( edtMinRecencia_Internalname), ".", ","));
                              A14MaxRecencia = (long)(context.localUtil.CToN( cgiGet( edtMaxRecencia_Internalname), ".", ","));
                              A24AvgRecencia = (long)(context.localUtil.CToN( cgiGet( edtAvgRecencia_Internalname), ".", ","));
                              A15MinFrecuencia = context.localUtil.CToN( cgiGet( edtMinFrecuencia_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20102 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cperiodo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPERIODO"), AV6cPeriodo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorte1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORTE1"), ".", ",") != Convert.ToDecimal( AV7cCorte1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccorte2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORTE2"), ".", ",") != Convert.ToDecimal( AV8cCorte2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Crfm Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRFM"), ".", ",") != Convert.ToDecimal( AV9cRFM )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientesdelanio Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTESDELANIO"), ".", ",") != Convert.ToDecimal( AV10cClientesDelAnio )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientesdelmes Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTESDELMES"), ".", ",") != Convert.ToDecimal( AV11cClientesDelMes )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cminrecencia Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMINRECENCIA"), ".", ",") != Convert.ToDecimal( AV12cMinRecencia )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21102 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE102( )
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

      protected void PA102( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        String AV6cPeriodo ,
                                        int AV7cCorte1 ,
                                        int AV8cCorte2 ,
                                        int AV9cRFM ,
                                        long AV10cClientesDelAnio ,
                                        long AV11cClientesDelMes ,
                                        long AV12cMinRecencia )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF102( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PERIODO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A7Periodo, "")), context));
         GxWebStd.gx_hidden_field( context, "PERIODO", A7Periodo);
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
         RF102( ) ;
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

      protected void RF102( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cCorte1 ,
                                                 AV8cCorte2 ,
                                                 AV9cRFM ,
                                                 AV10cClientesDelAnio ,
                                                 AV11cClientesDelMes ,
                                                 AV12cMinRecencia ,
                                                 A8Corte1 ,
                                                 A9Corte2 ,
                                                 A10RFM ,
                                                 A11ClientesDelAnio ,
                                                 A12ClientesDelMes ,
                                                 A13MinRecencia ,
                                                 A7Periodo ,
                                                 AV6cPeriodo } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.STRING, TypeConstants.STRING
                                                 }
            } ) ;
            lV6cPeriodo = StringUtil.Concat( StringUtil.RTrim( AV6cPeriodo), "%", "");
            /* Using cursor H00102 */
            pr_default.execute(0, new Object[] {lV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A15MinFrecuencia = H00102_A15MinFrecuencia[0];
               A24AvgRecencia = H00102_A24AvgRecencia[0];
               A14MaxRecencia = H00102_A14MaxRecencia[0];
               A13MinRecencia = H00102_A13MinRecencia[0];
               A12ClientesDelMes = H00102_A12ClientesDelMes[0];
               A11ClientesDelAnio = H00102_A11ClientesDelAnio[0];
               n11ClientesDelAnio = H00102_n11ClientesDelAnio[0];
               A10RFM = H00102_A10RFM[0];
               A9Corte2 = H00102_A9Corte2[0];
               A8Corte1 = H00102_A8Corte1[0];
               A7Periodo = H00102_A7Periodo[0];
               /* Execute user event: Load */
               E20102 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB100( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes102( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PERIODO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A7Periodo, "")), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cCorte1 ,
                                              AV8cCorte2 ,
                                              AV9cRFM ,
                                              AV10cClientesDelAnio ,
                                              AV11cClientesDelMes ,
                                              AV12cMinRecencia ,
                                              A8Corte1 ,
                                              A9Corte2 ,
                                              A10RFM ,
                                              A11ClientesDelAnio ,
                                              A12ClientesDelMes ,
                                              A13MinRecencia ,
                                              A7Periodo ,
                                              AV6cPeriodo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.STRING, TypeConstants.STRING
                                              }
         } ) ;
         lV6cPeriodo = StringUtil.Concat( StringUtil.RTrim( AV6cPeriodo), "%", "");
         /* Using cursor H00103 */
         pr_default.execute(1, new Object[] {lV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia});
         GRID1_nRecordCount = H00103_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPeriodo, AV7cCorte1, AV8cCorte2, AV9cRFM, AV10cClientesDelAnio, AV11cClientesDelMes, AV12cMinRecencia) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP100( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19102 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            AV6cPeriodo = cgiGet( edtavCperiodo_Internalname);
            AssignAttri("", false, "AV6cPeriodo", AV6cPeriodo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcorte1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcorte1_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCORTE1");
               GX_FocusControl = edtavCcorte1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cCorte1 = 0;
               AssignAttri("", false, "AV7cCorte1", StringUtil.LTrimStr( (decimal)(AV7cCorte1), 8, 0));
            }
            else
            {
               AV7cCorte1 = (int)(context.localUtil.CToN( cgiGet( edtavCcorte1_Internalname), ".", ","));
               AssignAttri("", false, "AV7cCorte1", StringUtil.LTrimStr( (decimal)(AV7cCorte1), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcorte2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcorte2_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCORTE2");
               GX_FocusControl = edtavCcorte2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cCorte2 = 0;
               AssignAttri("", false, "AV8cCorte2", StringUtil.LTrimStr( (decimal)(AV8cCorte2), 8, 0));
            }
            else
            {
               AV8cCorte2 = (int)(context.localUtil.CToN( cgiGet( edtavCcorte2_Internalname), ".", ","));
               AssignAttri("", false, "AV8cCorte2", StringUtil.LTrimStr( (decimal)(AV8cCorte2), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCrfm_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCrfm_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRFM");
               GX_FocusControl = edtavCrfm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cRFM = 0;
               AssignAttri("", false, "AV9cRFM", StringUtil.LTrimStr( (decimal)(AV9cRFM), 8, 0));
            }
            else
            {
               AV9cRFM = (int)(context.localUtil.CToN( cgiGet( edtavCrfm_Internalname), ".", ","));
               AssignAttri("", false, "AV9cRFM", StringUtil.LTrimStr( (decimal)(AV9cRFM), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCclientesdelanio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCclientesdelanio_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCLIENTESDELANIO");
               GX_FocusControl = edtavCclientesdelanio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cClientesDelAnio = 0;
               AssignAttri("", false, "AV10cClientesDelAnio", StringUtil.LTrimStr( (decimal)(AV10cClientesDelAnio), 10, 0));
            }
            else
            {
               AV10cClientesDelAnio = (long)(context.localUtil.CToN( cgiGet( edtavCclientesdelanio_Internalname), ".", ","));
               AssignAttri("", false, "AV10cClientesDelAnio", StringUtil.LTrimStr( (decimal)(AV10cClientesDelAnio), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCclientesdelmes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCclientesdelmes_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCLIENTESDELMES");
               GX_FocusControl = edtavCclientesdelmes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cClientesDelMes = 0;
               AssignAttri("", false, "AV11cClientesDelMes", StringUtil.LTrimStr( (decimal)(AV11cClientesDelMes), 10, 0));
            }
            else
            {
               AV11cClientesDelMes = (long)(context.localUtil.CToN( cgiGet( edtavCclientesdelmes_Internalname), ".", ","));
               AssignAttri("", false, "AV11cClientesDelMes", StringUtil.LTrimStr( (decimal)(AV11cClientesDelMes), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCminrecencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCminrecencia_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCMINRECENCIA");
               GX_FocusControl = edtavCminrecencia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cMinRecencia = 0;
               AssignAttri("", false, "AV12cMinRecencia", StringUtil.LTrimStr( (decimal)(AV12cMinRecencia), 10, 0));
            }
            else
            {
               AV12cMinRecencia = (long)(context.localUtil.CToN( cgiGet( edtavCminrecencia_Internalname), ".", ","));
               AssignAttri("", false, "AV12cMinRecencia", StringUtil.LTrimStr( (decimal)(AV12cMinRecencia), 10, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPERIODO"), AV6cPeriodo) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORTE1"), ".", ",") != Convert.ToDecimal( AV7cCorte1 )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORTE2"), ".", ",") != Convert.ToDecimal( AV8cCorte2 )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRFM"), ".", ",") != Convert.ToDecimal( AV9cRFM )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTESDELANIO"), ".", ",") != Convert.ToDecimal( AV10cClientesDelAnio )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTESDELMES"), ".", ",") != Convert.ToDecimal( AV11cClientesDelMes )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCMINRECENCIA"), ".", ",") != Convert.ToDecimal( AV12cMinRecencia )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E19102 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19102( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Selection List %1", "ResumenRFMGlobal", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20102( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21102 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21102( )
      {
         /* Enter Routine */
         AV13pPeriodo = A7Periodo;
         AssignAttri("", false, "AV13pPeriodo", AV13pPeriodo);
         context.setWebReturnParms(new Object[] {(String)AV13pPeriodo});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pPeriodo"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pPeriodo = (String)getParm(obj,0);
         AssignAttri("", false, "AV13pPeriodo", AV13pPeriodo);
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
         PA102( ) ;
         WS102( ) ;
         WE102( ) ;
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
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202091115392295", true, true);
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
         context.AddJavascriptSource("version1/gx0030.js", "?202091115392295", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtPeriodo_Internalname = "PERIODO_"+sGXsfl_84_idx;
         edtCorte1_Internalname = "CORTE1_"+sGXsfl_84_idx;
         edtCorte2_Internalname = "CORTE2_"+sGXsfl_84_idx;
         edtRFM_Internalname = "RFM_"+sGXsfl_84_idx;
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO_"+sGXsfl_84_idx;
         edtClientesDelMes_Internalname = "CLIENTESDELMES_"+sGXsfl_84_idx;
         edtMinRecencia_Internalname = "MINRECENCIA_"+sGXsfl_84_idx;
         edtMaxRecencia_Internalname = "MAXRECENCIA_"+sGXsfl_84_idx;
         edtAvgRecencia_Internalname = "AVGRECENCIA_"+sGXsfl_84_idx;
         edtMinFrecuencia_Internalname = "MINFRECUENCIA_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtPeriodo_Internalname = "PERIODO_"+sGXsfl_84_fel_idx;
         edtCorte1_Internalname = "CORTE1_"+sGXsfl_84_fel_idx;
         edtCorte2_Internalname = "CORTE2_"+sGXsfl_84_fel_idx;
         edtRFM_Internalname = "RFM_"+sGXsfl_84_fel_idx;
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO_"+sGXsfl_84_fel_idx;
         edtClientesDelMes_Internalname = "CLIENTESDELMES_"+sGXsfl_84_fel_idx;
         edtMinRecencia_Internalname = "MINRECENCIA_"+sGXsfl_84_fel_idx;
         edtMaxRecencia_Internalname = "MAXRECENCIA_"+sGXsfl_84_fel_idx;
         edtAvgRecencia_Internalname = "AVGRECENCIA_"+sGXsfl_84_fel_idx;
         edtMinFrecuencia_Internalname = "MINFRECUENCIA_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB100( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A7Periodo)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)1,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPeriodo_Internalname,(String)A7Periodo,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtPeriodo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtCorte1_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A7Periodo)+"'"+"]);";
            AssignProp("", false, edtCorte1_Internalname, "Link", edtCorte1_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCorte1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8Corte1), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A8Corte1), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)edtCorte1_Link,(String)"",(String)"",(String)"",(String)edtCorte1_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCorte2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9Corte2), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A9Corte2), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtCorte2_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRFM_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10RFM), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A10RFM), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRFM_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientesDelAnio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClientesDelAnio), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A11ClientesDelAnio), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientesDelAnio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientesDelMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ClientesDelMes), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A12ClientesDelMes), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientesDelMes_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinRecencia_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MinRecencia), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A13MinRecencia), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxRecencia_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14MaxRecencia), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A14MaxRecencia), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAvgRecencia_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AvgRecencia), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A24AvgRecencia), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtAvgRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinFrecuencia_Internalname,StringUtil.LTrim( StringUtil.NToC( A15MinFrecuencia, 10, 6, ".", "")),context.localUtil.Format( A15MinFrecuencia, "ZZ9.999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes102( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblperiodofilter_Internalname = "LBLPERIODOFILTER";
         edtavCperiodo_Internalname = "vCPERIODO";
         divPeriodofiltercontainer_Internalname = "PERIODOFILTERCONTAINER";
         lblLblcorte1filter_Internalname = "LBLCORTE1FILTER";
         edtavCcorte1_Internalname = "vCCORTE1";
         divCorte1filtercontainer_Internalname = "CORTE1FILTERCONTAINER";
         lblLblcorte2filter_Internalname = "LBLCORTE2FILTER";
         edtavCcorte2_Internalname = "vCCORTE2";
         divCorte2filtercontainer_Internalname = "CORTE2FILTERCONTAINER";
         lblLblrfmfilter_Internalname = "LBLRFMFILTER";
         edtavCrfm_Internalname = "vCRFM";
         divRfmfiltercontainer_Internalname = "RFMFILTERCONTAINER";
         lblLblclientesdelaniofilter_Internalname = "LBLCLIENTESDELANIOFILTER";
         edtavCclientesdelanio_Internalname = "vCCLIENTESDELANIO";
         divClientesdelaniofiltercontainer_Internalname = "CLIENTESDELANIOFILTERCONTAINER";
         lblLblclientesdelmesfilter_Internalname = "LBLCLIENTESDELMESFILTER";
         edtavCclientesdelmes_Internalname = "vCCLIENTESDELMES";
         divClientesdelmesfiltercontainer_Internalname = "CLIENTESDELMESFILTERCONTAINER";
         lblLblminrecenciafilter_Internalname = "LBLMINRECENCIAFILTER";
         edtavCminrecencia_Internalname = "vCMINRECENCIA";
         divMinrecenciafiltercontainer_Internalname = "MINRECENCIAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtPeriodo_Internalname = "PERIODO";
         edtCorte1_Internalname = "CORTE1";
         edtCorte2_Internalname = "CORTE2";
         edtRFM_Internalname = "RFM";
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO";
         edtClientesDelMes_Internalname = "CLIENTESDELMES";
         edtMinRecencia_Internalname = "MINRECENCIA";
         edtMaxRecencia_Internalname = "MAXRECENCIA";
         edtAvgRecencia_Internalname = "AVGRECENCIA";
         edtMinFrecuencia_Internalname = "MINFRECUENCIA";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtMinFrecuencia_Jsonclick = "";
         edtAvgRecencia_Jsonclick = "";
         edtMaxRecencia_Jsonclick = "";
         edtMinRecencia_Jsonclick = "";
         edtClientesDelMes_Jsonclick = "";
         edtClientesDelAnio_Jsonclick = "";
         edtRFM_Jsonclick = "";
         edtCorte2_Jsonclick = "";
         edtCorte1_Jsonclick = "";
         edtPeriodo_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtCorte1_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCminrecencia_Jsonclick = "";
         edtavCminrecencia_Enabled = 1;
         edtavCminrecencia_Visible = 1;
         edtavCclientesdelmes_Jsonclick = "";
         edtavCclientesdelmes_Enabled = 1;
         edtavCclientesdelmes_Visible = 1;
         edtavCclientesdelanio_Jsonclick = "";
         edtavCclientesdelanio_Enabled = 1;
         edtavCclientesdelanio_Visible = 1;
         edtavCrfm_Jsonclick = "";
         edtavCrfm_Enabled = 1;
         edtavCrfm_Visible = 1;
         edtavCcorte2_Jsonclick = "";
         edtavCcorte2_Enabled = 1;
         edtavCcorte2_Visible = 1;
         edtavCcorte1_Jsonclick = "";
         edtavCcorte1_Enabled = 1;
         edtavCcorte1_Visible = 1;
         edtavCperiodo_Jsonclick = "";
         edtavCperiodo_Enabled = 1;
         edtavCperiodo_Visible = 1;
         divMinrecenciafiltercontainer_Class = "AdvancedContainerItem";
         divClientesdelmesfiltercontainer_Class = "AdvancedContainerItem";
         divClientesdelaniofiltercontainer_Class = "AdvancedContainerItem";
         divRfmfiltercontainer_Class = "AdvancedContainerItem";
         divCorte2filtercontainer_Class = "AdvancedContainerItem";
         divCorte1filtercontainer_Class = "AdvancedContainerItem";
         divPeriodofiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List ResumenRFMGlobal";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18101',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPERIODOFILTER.CLICK","{handler:'E11101',iparms:[{av:'divPeriodofiltercontainer_Class',ctrl:'PERIODOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPERIODOFILTER.CLICK",",oparms:[{av:'divPeriodofiltercontainer_Class',ctrl:'PERIODOFILTERCONTAINER',prop:'Class'},{av:'edtavCperiodo_Visible',ctrl:'vCPERIODO',prop:'Visible'}]}");
         setEventMetadata("LBLCORTE1FILTER.CLICK","{handler:'E12101',iparms:[{av:'divCorte1filtercontainer_Class',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORTE1FILTER.CLICK",",oparms:[{av:'divCorte1filtercontainer_Class',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'edtavCcorte1_Visible',ctrl:'vCCORTE1',prop:'Visible'}]}");
         setEventMetadata("LBLCORTE2FILTER.CLICK","{handler:'E13101',iparms:[{av:'divCorte2filtercontainer_Class',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORTE2FILTER.CLICK",",oparms:[{av:'divCorte2filtercontainer_Class',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'edtavCcorte2_Visible',ctrl:'vCCORTE2',prop:'Visible'}]}");
         setEventMetadata("LBLRFMFILTER.CLICK","{handler:'E14101',iparms:[{av:'divRfmfiltercontainer_Class',ctrl:'RFMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFMFILTER.CLICK",",oparms:[{av:'divRfmfiltercontainer_Class',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'edtavCrfm_Visible',ctrl:'vCRFM',prop:'Visible'}]}");
         setEventMetadata("LBLCLIENTESDELANIOFILTER.CLICK","{handler:'E15101',iparms:[{av:'divClientesdelaniofiltercontainer_Class',ctrl:'CLIENTESDELANIOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTESDELANIOFILTER.CLICK",",oparms:[{av:'divClientesdelaniofiltercontainer_Class',ctrl:'CLIENTESDELANIOFILTERCONTAINER',prop:'Class'},{av:'edtavCclientesdelanio_Visible',ctrl:'vCCLIENTESDELANIO',prop:'Visible'}]}");
         setEventMetadata("LBLCLIENTESDELMESFILTER.CLICK","{handler:'E16101',iparms:[{av:'divClientesdelmesfiltercontainer_Class',ctrl:'CLIENTESDELMESFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTESDELMESFILTER.CLICK",",oparms:[{av:'divClientesdelmesfiltercontainer_Class',ctrl:'CLIENTESDELMESFILTERCONTAINER',prop:'Class'},{av:'edtavCclientesdelmes_Visible',ctrl:'vCCLIENTESDELMES',prop:'Visible'}]}");
         setEventMetadata("LBLMINRECENCIAFILTER.CLICK","{handler:'E17101',iparms:[{av:'divMinrecenciafiltercontainer_Class',ctrl:'MINRECENCIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLMINRECENCIAFILTER.CLICK",",oparms:[{av:'divMinrecenciafiltercontainer_Class',ctrl:'MINRECENCIAFILTERCONTAINER',prop:'Class'},{av:'edtavCminrecencia_Visible',ctrl:'vCMINRECENCIA',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21102',iparms:[{av:'A7Periodo',fld:'PERIODO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pPeriodo',fld:'vPPERIODO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPeriodo',fld:'vCPERIODO',pic:''},{av:'AV7cCorte1',fld:'vCCORTE1',pic:'ZZZZZZZ9'},{av:'AV8cCorte2',fld:'vCCORTE2',pic:'ZZZZZZZ9'},{av:'AV9cRFM',fld:'vCRFM',pic:'ZZZZZZZ9'},{av:'AV10cClientesDelAnio',fld:'vCCLIENTESDELANIO',pic:'ZZZZZZZZZ9'},{av:'AV11cClientesDelMes',fld:'vCCLIENTESDELMES',pic:'ZZZZZZZZZ9'},{av:'AV12cMinRecencia',fld:'vCMINRECENCIA',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Minfrecuencia',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV6cPeriodo = "";
         AV13pPeriodo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblperiodofilter_Jsonclick = "";
         TempTags = "";
         lblLblcorte1filter_Jsonclick = "";
         lblLblcorte2filter_Jsonclick = "";
         lblLblrfmfilter_Jsonclick = "";
         lblLblclientesdelaniofilter_Jsonclick = "";
         lblLblclientesdelmesfilter_Jsonclick = "";
         lblLblminrecenciafilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A7Periodo = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV6cPeriodo = "";
         H00102_A15MinFrecuencia = new decimal[1] ;
         H00102_A24AvgRecencia = new long[1] ;
         H00102_A14MaxRecencia = new long[1] ;
         H00102_A13MinRecencia = new long[1] ;
         H00102_A12ClientesDelMes = new long[1] ;
         H00102_A11ClientesDelAnio = new long[1] ;
         H00102_n11ClientesDelAnio = new bool[] {false} ;
         H00102_A10RFM = new int[1] ;
         H00102_A9Corte2 = new int[1] ;
         H00102_A8Corte1 = new int[1] ;
         H00102_A7Periodo = new String[] {""} ;
         H00103_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.version1.gx0030__default(),
            new Object[][] {
                new Object[] {
               H00102_A15MinFrecuencia, H00102_A24AvgRecencia, H00102_A14MaxRecencia, H00102_A13MinRecencia, H00102_A12ClientesDelMes, H00102_A11ClientesDelAnio, H00102_n11ClientesDelAnio, H00102_A10RFM, H00102_A9Corte2, H00102_A8Corte1,
               H00102_A7Periodo
               }
               , new Object[] {
               H00103_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV7cCorte1 ;
      private int AV8cCorte2 ;
      private int AV9cRFM ;
      private int edtavCperiodo_Visible ;
      private int edtavCperiodo_Enabled ;
      private int edtavCcorte1_Enabled ;
      private int edtavCcorte1_Visible ;
      private int edtavCcorte2_Enabled ;
      private int edtavCcorte2_Visible ;
      private int edtavCrfm_Enabled ;
      private int edtavCrfm_Visible ;
      private int edtavCclientesdelanio_Enabled ;
      private int edtavCclientesdelanio_Visible ;
      private int edtavCclientesdelmes_Enabled ;
      private int edtavCclientesdelmes_Visible ;
      private int edtavCminrecencia_Enabled ;
      private int edtavCminrecencia_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A8Corte1 ;
      private int A9Corte2 ;
      private int A10RFM ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV10cClientesDelAnio ;
      private long AV11cClientesDelMes ;
      private long AV12cMinRecencia ;
      private long A11ClientesDelAnio ;
      private long A12ClientesDelMes ;
      private long A13MinRecencia ;
      private long A14MaxRecencia ;
      private long A24AvgRecencia ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal A15MinFrecuencia ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divPeriodofiltercontainer_Class ;
      private String divCorte1filtercontainer_Class ;
      private String divCorte2filtercontainer_Class ;
      private String divRfmfiltercontainer_Class ;
      private String divClientesdelaniofiltercontainer_Class ;
      private String divClientesdelmesfiltercontainer_Class ;
      private String divMinrecenciafiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_84_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divPeriodofiltercontainer_Internalname ;
      private String lblLblperiodofilter_Internalname ;
      private String lblLblperiodofilter_Jsonclick ;
      private String edtavCperiodo_Internalname ;
      private String TempTags ;
      private String edtavCperiodo_Jsonclick ;
      private String divCorte1filtercontainer_Internalname ;
      private String lblLblcorte1filter_Internalname ;
      private String lblLblcorte1filter_Jsonclick ;
      private String edtavCcorte1_Internalname ;
      private String edtavCcorte1_Jsonclick ;
      private String divCorte2filtercontainer_Internalname ;
      private String lblLblcorte2filter_Internalname ;
      private String lblLblcorte2filter_Jsonclick ;
      private String edtavCcorte2_Internalname ;
      private String edtavCcorte2_Jsonclick ;
      private String divRfmfiltercontainer_Internalname ;
      private String lblLblrfmfilter_Internalname ;
      private String lblLblrfmfilter_Jsonclick ;
      private String edtavCrfm_Internalname ;
      private String edtavCrfm_Jsonclick ;
      private String divClientesdelaniofiltercontainer_Internalname ;
      private String lblLblclientesdelaniofilter_Internalname ;
      private String lblLblclientesdelaniofilter_Jsonclick ;
      private String edtavCclientesdelanio_Internalname ;
      private String edtavCclientesdelanio_Jsonclick ;
      private String divClientesdelmesfiltercontainer_Internalname ;
      private String lblLblclientesdelmesfilter_Internalname ;
      private String lblLblclientesdelmesfilter_Jsonclick ;
      private String edtavCclientesdelmes_Internalname ;
      private String edtavCclientesdelmes_Jsonclick ;
      private String divMinrecenciafiltercontainer_Internalname ;
      private String lblLblminrecenciafilter_Internalname ;
      private String lblLblminrecenciafilter_Jsonclick ;
      private String edtavCminrecencia_Internalname ;
      private String edtavCminrecencia_Jsonclick ;
      private String divGridtable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String edtavLinkselection_Link ;
      private String edtCorte1_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtPeriodo_Internalname ;
      private String edtCorte1_Internalname ;
      private String edtCorte2_Internalname ;
      private String edtRFM_Internalname ;
      private String edtClientesDelAnio_Internalname ;
      private String edtClientesDelMes_Internalname ;
      private String edtMinRecencia_Internalname ;
      private String edtMaxRecencia_Internalname ;
      private String edtAvgRecencia_Internalname ;
      private String edtMinFrecuencia_Internalname ;
      private String scmdbuf ;
      private String AV14ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_84_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtPeriodo_Jsonclick ;
      private String edtCorte1_Jsonclick ;
      private String edtCorte2_Jsonclick ;
      private String edtRFM_Jsonclick ;
      private String edtClientesDelAnio_Jsonclick ;
      private String edtClientesDelMes_Jsonclick ;
      private String edtMinRecencia_Jsonclick ;
      private String edtMaxRecencia_Jsonclick ;
      private String edtAvgRecencia_Jsonclick ;
      private String edtMinFrecuencia_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n11ClientesDelAnio ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV6cPeriodo ;
      private String AV13pPeriodo ;
      private String A7Periodo ;
      private String AV17Linkselection_GXI ;
      private String lV6cPeriodo ;
      private String AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00102_A15MinFrecuencia ;
      private long[] H00102_A24AvgRecencia ;
      private long[] H00102_A14MaxRecencia ;
      private long[] H00102_A13MinRecencia ;
      private long[] H00102_A12ClientesDelMes ;
      private long[] H00102_A11ClientesDelAnio ;
      private bool[] H00102_n11ClientesDelAnio ;
      private int[] H00102_A10RFM ;
      private int[] H00102_A9Corte2 ;
      private int[] H00102_A8Corte1 ;
      private String[] H00102_A7Periodo ;
      private long[] H00103_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private String aP0_pPeriodo ;
      private GXWebForm Form ;
   }

   public class gx0030__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00102( IGxContext context ,
                                             int AV7cCorte1 ,
                                             int AV8cCorte2 ,
                                             int AV9cRFM ,
                                             long AV10cClientesDelAnio ,
                                             long AV11cClientesDelMes ,
                                             long AV12cMinRecencia ,
                                             int A8Corte1 ,
                                             int A9Corte2 ,
                                             int A10RFM ,
                                             long A11ClientesDelAnio ,
                                             long A12ClientesDelMes ,
                                             long A13MinRecencia ,
                                             String A7Periodo ,
                                             String AV6cPeriodo )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [10] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [MinFrecuencia], [AvgRecencia], [MaxRecencia], [MinRecencia], [ClientesDelMes], [ClientesDelAnio], [RFM], [Corte2], [Corte1], [Periodo]";
         sFromString = " FROM [ResumenRFMGlobal]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([Periodo] like @lV6cPeriodo)";
         if ( ! (0==AV7cCorte1) )
         {
            sWhereString = sWhereString + " and ([Corte1] >= @AV7cCorte1)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cCorte2) )
         {
            sWhereString = sWhereString + " and ([Corte2] >= @AV8cCorte2)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cRFM) )
         {
            sWhereString = sWhereString + " and ([RFM] >= @AV9cRFM)";
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cClientesDelAnio) )
         {
            sWhereString = sWhereString + " and ([ClientesDelAnio] >= @AV10cClientesDelAnio)";
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cClientesDelMes) )
         {
            sWhereString = sWhereString + " and ([ClientesDelMes] >= @AV11cClientesDelMes)";
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cMinRecencia) )
         {
            sWhereString = sWhereString + " and ([MinRecencia] >= @AV12cMinRecencia)";
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [Periodo]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00103( IGxContext context ,
                                             int AV7cCorte1 ,
                                             int AV8cCorte2 ,
                                             int AV9cRFM ,
                                             long AV10cClientesDelAnio ,
                                             long AV11cClientesDelMes ,
                                             long AV12cMinRecencia ,
                                             int A8Corte1 ,
                                             int A9Corte2 ,
                                             int A10RFM ,
                                             long A11ClientesDelAnio ,
                                             long A12ClientesDelMes ,
                                             long A13MinRecencia ,
                                             String A7Periodo ,
                                             String AV6cPeriodo )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [7] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM [ResumenRFMGlobal]";
         scmdbuf = scmdbuf + " WHERE ([Periodo] like @lV6cPeriodo)";
         if ( ! (0==AV7cCorte1) )
         {
            sWhereString = sWhereString + " and ([Corte1] >= @AV7cCorte1)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cCorte2) )
         {
            sWhereString = sWhereString + " and ([Corte2] >= @AV8cCorte2)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cRFM) )
         {
            sWhereString = sWhereString + " and ([RFM] >= @AV9cRFM)";
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cClientesDelAnio) )
         {
            sWhereString = sWhereString + " and ([ClientesDelAnio] >= @AV10cClientesDelAnio)";
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cClientesDelMes) )
         {
            sWhereString = sWhereString + " and ([ClientesDelMes] >= @AV11cClientesDelMes)";
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cMinRecencia) )
         {
            sWhereString = sWhereString + " and ([MinRecencia] >= @AV12cMinRecencia)";
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00102(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (String)dynConstraints[12] , (String)dynConstraints[13] );
               case 1 :
                     return conditional_H00103(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (String)dynConstraints[12] , (String)dynConstraints[13] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00102 ;
          prmH00102 = new Object[] {
          new Object[] {"@lV6cPeriodo",SqlDbType.NVarChar,6,0} ,
          new Object[] {"@AV7cCorte1",SqlDbType.Int,8,0} ,
          new Object[] {"@AV8cCorte2",SqlDbType.Int,8,0} ,
          new Object[] {"@AV9cRFM",SqlDbType.Int,8,0} ,
          new Object[] {"@AV10cClientesDelAnio",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV11cClientesDelMes",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV12cMinRecencia",SqlDbType.Decimal,10,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00103 ;
          prmH00103 = new Object[] {
          new Object[] {"@lV6cPeriodo",SqlDbType.NVarChar,6,0} ,
          new Object[] {"@AV7cCorte1",SqlDbType.Int,8,0} ,
          new Object[] {"@AV8cCorte2",SqlDbType.Int,8,0} ,
          new Object[] {"@AV9cRFM",SqlDbType.Int,8,0} ,
          new Object[] {"@AV10cClientesDelAnio",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV11cClientesDelMes",SqlDbType.Decimal,10,0} ,
          new Object[] {"@AV12cMinRecencia",SqlDbType.Decimal,10,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00102", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00102,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00103", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00103,1, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1) ;
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((long[]) buf[2])[0] = rslt.getLong(3) ;
                ((long[]) buf[3])[0] = rslt.getLong(4) ;
                ((long[]) buf[4])[0] = rslt.getLong(5) ;
                ((long[]) buf[5])[0] = rslt.getLong(6) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7) ;
                ((int[]) buf[8])[0] = rslt.getInt(8) ;
                ((int[]) buf[9])[0] = rslt.getInt(9) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(10) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[10]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[11]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[12]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[13]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[14]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[15]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[16]);
                }
                if ( (short)parms[7] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[17]);
                }
                if ( (short)parms[8] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[18]);
                }
                if ( (short)parms[9] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[19]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[8]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[9]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[10]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[13]);
                }
                return;
       }
    }

 }

}
