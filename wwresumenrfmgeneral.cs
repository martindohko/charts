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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwresumenrfmgeneral : GXDataArea
   {
      public wwresumenrfmgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwresumenrfmgeneral( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               nRC_GXsfl_55 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_55_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_55_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               subGrid_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV14Corte1 = GetNextPar( );
               AV17ADVANCED_LABEL_TEMPLATE = GetNextPar( );
               AV15Corte2 = GetNextPar( );
               AV16RFM = GetNextPar( );
               AV20Pgmname = GetNextPar( );
               AV13Periodo = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV14Corte1, AV17ADVANCED_LABEL_TEMPLATE, AV15Corte2, AV16RFM, AV20Pgmname, AV13Periodo) ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         PA0Z2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Z2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2020989371249", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwresumenrfmgeneral.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCORTE1", AV14Corte1);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_55", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_55), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV17ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORTE1FILTERCONTAINER_Class", StringUtil.RTrim( divCorte1filtercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CORTE2FILTERCONTAINER_Class", StringUtil.RTrim( divCorte2filtercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFMFILTERCONTAINER_Class", StringUtil.RTrim( divRfmfiltercontainer_Class));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0Z2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Z2( ) ;
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
         return formatLink("wwresumenrfmgeneral.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WWResumenRFMGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "Resumen RFMGenerals" ;
      }

      protected void WB0Z0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "TableTopSearch", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110z1_client"+"'", TempTags, "", 2, "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Resumen RFMGenerals", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-5 col-sm-push-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPeriodo_Internalname, "Periodo", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPeriodo_Internalname, AV13Periodo, StringUtil.RTrim( context.localUtil.Format( AV13Periodo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPeriodo_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavPeriodo_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 WWAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "left", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblLblcorte1filter_Internalname, lblLblcorte1filter_Caption, "", "", lblLblcorte1filter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120z1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorte1_Internalname, "Corte1", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorte1_Internalname, AV14Corte1, StringUtil.RTrim( context.localUtil.Format( AV14Corte1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorte1_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavCorte1_Visible, edtavCorte1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWResumenRFMGeneral.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcorte2filter_Internalname, lblLblcorte2filter_Caption, "", "", lblLblcorte2filter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130z1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorte2_Internalname, "Corte2", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorte2_Internalname, AV15Corte2, StringUtil.RTrim( context.localUtil.Format( AV15Corte2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorte2_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavCorte2_Visible, edtavCorte2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWResumenRFMGeneral.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblrfmfilter_Internalname, lblLblrfmfilter_Caption, "", "", lblLblrfmfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140z1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRfm_Internalname, "RFM", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRfm_Internalname, AV16RFM, StringUtil.RTrim( context.localUtil.Format( AV16RFM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRfm_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavRfm_Visible, edtavRfm_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWResumenRFMGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "ContainerFluid WWAdvancedContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"55\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Periodo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Corte1") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Corte2") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RFM") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Del Anio") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Del Mes") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Recencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Recencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Frecuencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Frecuencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Frecuencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Valor Monetario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Valor Monetario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Valor Monetario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tickets_Anio Movil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Importe_Anio Movil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Articulos_Anio Movil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  GridContainer = new GXWebGrid( context);
               }
               else
               {
                  GridContainer.Clear();
               }
               GridContainer.SetWrapped(nGXWrapped);
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", "");
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A7Periodo);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A8Corte1);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A9Corte2);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A10RFM);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A11ClientesDelAnio);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A12ClientesDelMes);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A13MinRecencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A14MaxRecencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A15MinFrecuencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A16MaxFrecuencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A17AvgFrecuencia);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A18MinValorMonetario);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A19MaxValorMonetario);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A20AvgValorMonetario);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A21ComprasTickets_AnioMovil);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A22ComprasImporte_AnioMovil);
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A23ComprasArticulos_AnioMovil);
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 55 )
         {
            wbEnd = 0;
            nRC_GXsfl_55 = (int)(nGXsfl_55_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 55 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Z2( )
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
            Form.Meta.addItem("description", "Resumen RFMGenerals", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Z0( ) ;
      }

      protected void WS0Z2( )
      {
         START0Z2( ) ;
         EVT0Z2( ) ;
      }

      protected void EVT0Z2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_55_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
                              SubsflControlProps_552( ) ;
                              A7Periodo = cgiGet( edtPeriodo_Internalname);
                              A8Corte1 = cgiGet( edtCorte1_Internalname);
                              A9Corte2 = cgiGet( edtCorte2_Internalname);
                              A10RFM = cgiGet( edtRFM_Internalname);
                              A11ClientesDelAnio = cgiGet( edtClientesDelAnio_Internalname);
                              A12ClientesDelMes = cgiGet( edtClientesDelMes_Internalname);
                              A13MinRecencia = cgiGet( edtMinRecencia_Internalname);
                              A14MaxRecencia = cgiGet( edtMaxRecencia_Internalname);
                              A15MinFrecuencia = cgiGet( edtMinFrecuencia_Internalname);
                              A16MaxFrecuencia = cgiGet( edtMaxFrecuencia_Internalname);
                              A17AvgFrecuencia = cgiGet( edtAvgFrecuencia_Internalname);
                              A18MinValorMonetario = cgiGet( edtMinValorMonetario_Internalname);
                              A19MaxValorMonetario = cgiGet( edtMaxValorMonetario_Internalname);
                              A20AvgValorMonetario = cgiGet( edtAvgValorMonetario_Internalname);
                              A21ComprasTickets_AnioMovil = cgiGet( edtComprasTickets_AnioMovil_Internalname);
                              A22ComprasImporte_AnioMovil = cgiGet( edtComprasImporte_AnioMovil_Internalname);
                              A23ComprasArticulos_AnioMovil = cgiGet( edtComprasArticulos_AnioMovil_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E150Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E160Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E170Z2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Corte1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCORTE1"), AV14Corte1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE0Z2( )
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

      protected void PA0Z2( )
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
               GX_FocusControl = edtavPeriodo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_552( ) ;
         while ( nGXsfl_55_idx <= nRC_GXsfl_55 )
         {
            sendrow_552( ) ;
            nGXsfl_55_idx = ((subGrid_Islastpage==1)&&(nGXsfl_55_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       String AV14Corte1 ,
                                       String AV17ADVANCED_LABEL_TEMPLATE ,
                                       String AV15Corte2 ,
                                       String AV16RFM ,
                                       String AV20Pgmname ,
                                       String AV13Periodo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E160Z2 ();
         GRID_nCurrentRecord = 0;
         RF0Z2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         RF0Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV20Pgmname = "WWResumenRFMGeneral";
         context.Gx_err = 0;
      }

      protected void RF0Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 55;
         /* Execute user event: Refresh */
         E160Z2 ();
         nGXsfl_55_idx = 1;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_552( ) ;
         bGXsfl_55_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_552( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14Corte1 ,
                                                 A8Corte1 } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.STRING
                                                 }
            } ) ;
            lV14Corte1 = StringUtil.Concat( StringUtil.RTrim( AV14Corte1), "%", "");
            /* Using cursor H000Z2 */
            pr_default.execute(0, new Object[] {lV14Corte1, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_55_idx = 1;
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A23ComprasArticulos_AnioMovil = H000Z2_A23ComprasArticulos_AnioMovil[0];
               A22ComprasImporte_AnioMovil = H000Z2_A22ComprasImporte_AnioMovil[0];
               A21ComprasTickets_AnioMovil = H000Z2_A21ComprasTickets_AnioMovil[0];
               A20AvgValorMonetario = H000Z2_A20AvgValorMonetario[0];
               A19MaxValorMonetario = H000Z2_A19MaxValorMonetario[0];
               A18MinValorMonetario = H000Z2_A18MinValorMonetario[0];
               A17AvgFrecuencia = H000Z2_A17AvgFrecuencia[0];
               A16MaxFrecuencia = H000Z2_A16MaxFrecuencia[0];
               A15MinFrecuencia = H000Z2_A15MinFrecuencia[0];
               A14MaxRecencia = H000Z2_A14MaxRecencia[0];
               A13MinRecencia = H000Z2_A13MinRecencia[0];
               A12ClientesDelMes = H000Z2_A12ClientesDelMes[0];
               A11ClientesDelAnio = H000Z2_A11ClientesDelAnio[0];
               A10RFM = H000Z2_A10RFM[0];
               A9Corte2 = H000Z2_A9Corte2[0];
               A8Corte1 = H000Z2_A8Corte1[0];
               A7Periodo = H000Z2_A7Periodo[0];
               E170Z2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 55;
            WB0Z0( ) ;
         }
         bGXsfl_55_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Z2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV17ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV20Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV14Corte1 ,
                                              A8Corte1 } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.STRING
                                              }
         } ) ;
         lV14Corte1 = StringUtil.Concat( StringUtil.RTrim( AV14Corte1), "%", "");
         /* Using cursor H000Z3 */
         pr_default.execute(1, new Object[] {lV14Corte1});
         GRID_nRecordCount = H000Z3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14Corte1, AV17ADVANCED_LABEL_TEMPLATE, AV15Corte2, AV16RFM, AV20Pgmname, AV13Periodo) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14Corte1, AV17ADVANCED_LABEL_TEMPLATE, AV15Corte2, AV16RFM, AV20Pgmname, AV13Periodo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14Corte1, AV17ADVANCED_LABEL_TEMPLATE, AV15Corte2, AV16RFM, AV20Pgmname, AV13Periodo) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14Corte1, AV17ADVANCED_LABEL_TEMPLATE, AV15Corte2, AV16RFM, AV20Pgmname, AV13Periodo) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14Corte1, AV17ADVANCED_LABEL_TEMPLATE, AV15Corte2, AV16RFM, AV20Pgmname, AV13Periodo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV20Pgmname = "WWResumenRFMGeneral";
         context.Gx_err = 0;
      }

      protected void STRUP0Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E150Z2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_55 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_55"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV13Periodo = cgiGet( edtavPeriodo_Internalname);
            AssignAttri("", false, "AV13Periodo", AV13Periodo);
            AV14Corte1 = cgiGet( edtavCorte1_Internalname);
            AssignAttri("", false, "AV14Corte1", AV14Corte1);
            AV15Corte2 = cgiGet( edtavCorte2_Internalname);
            AssignAttri("", false, "AV15Corte2", AV15Corte2);
            AV16RFM = cgiGet( edtavRfm_Internalname);
            AssignAttri("", false, "AV16RFM", AV16RFM);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCORTE1"), AV14Corte1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E150Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E150Z2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV20Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV20Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         edtavCorte1_Visible = 0;
         AssignProp("", false, edtavCorte1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorte1_Visible), 5, 0), true);
         edtavCorte2_Visible = 0;
         AssignProp("", false, edtavCorte2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorte2_Visible), 5, 0), true);
         edtavRfm_Visible = 0;
         AssignProp("", false, edtavRfm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRfm_Visible), 5, 0), true);
         Form.Caption = "Resumen RFMGenerals";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV17ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV17ADVANCED_LABEL_TEMPLATE", AV17ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E160Z2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14Corte1)) )
         {
            lblLblcorte1filter_Caption = "Corte1";
            AssignProp("", false, lblLblcorte1filter_Internalname, "Caption", lblLblcorte1filter_Caption, true);
         }
         else
         {
            lblLblcorte1filter_Caption = StringUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "Corte1", AV14Corte1, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblcorte1filter_Internalname, "Caption", lblLblcorte1filter_Caption, true);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15Corte2)) )
         {
            lblLblcorte2filter_Caption = "";
            AssignProp("", false, lblLblcorte2filter_Internalname, "Caption", lblLblcorte2filter_Caption, true);
         }
         else
         {
            lblLblcorte2filter_Caption = StringUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "", AV15Corte2, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblcorte2filter_Internalname, "Caption", lblLblcorte2filter_Caption, true);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16RFM)) )
         {
            lblLblrfmfilter_Caption = "";
            AssignProp("", false, lblLblrfmfilter_Internalname, "Caption", lblLblrfmfilter_Caption, true);
         }
         else
         {
            lblLblrfmfilter_Caption = StringUtil.Format( AV17ADVANCED_LABEL_TEMPLATE, "", AV16RFM, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblrfmfilter_Internalname, "Caption", lblLblrfmfilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E170Z2( )
      {
         /* Grid_Load Routine */
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 55;
         }
         sendrow_552( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_55_Refreshing )
         {
            DoAjaxLoad(55, GridRow);
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            AV8GridState.FromXml(AV6Session.Get(AV20Pgmname+"GridState"), null, "GridState", "RFM");
            if ( AV8GridState.gxTpr_Filtervalues.Count >= 4 )
            {
               AV13Periodo = ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(1)).gxTpr_Value;
               AssignAttri("", false, "AV13Periodo", AV13Periodo);
               AV14Corte1 = ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(2)).gxTpr_Value;
               AssignAttri("", false, "AV14Corte1", AV14Corte1);
               AV15Corte2 = ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(3)).gxTpr_Value;
               AssignAttri("", false, "AV15Corte2", AV15Corte2);
               AV16RFM = ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(4)).gxTpr_Value;
               AssignAttri("", false, "AV16RFM", AV16RFM);
            }
            if ( AV8GridState.gxTpr_Currentpage > 0 )
            {
               AV10GridPageCount = subGrid_fnc_Pagecount( );
               if ( ( AV10GridPageCount > 0 ) && ( AV10GridPageCount < AV8GridState.gxTpr_Currentpage ) )
               {
                  subgrid_gotopage( AV10GridPageCount) ;
               }
               else
               {
                  subgrid_gotopage( AV8GridState.gxTpr_Currentpage) ;
               }
            }
         }
      }

      protected void S132( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         AV8GridState.FromXml(AV6Session.Get(AV20Pgmname+"GridState"), null, "GridState", "RFM");
         AV8GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV8GridState.gxTpr_Filtervalues.Clear();
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = AV13Periodo;
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = AV14Corte1;
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = AV15Corte2;
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = AV16RFM;
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV6Session.Set(AV20Pgmname+"GridState", AV8GridState.ToXml(false, true, "GridState", "RFM"));
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context);
         AV11TrnContext.gxTpr_Callerobject = AV20Pgmname;
         AV11TrnContext.gxTpr_Callerondelete = true;
         AV11TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV11TrnContext.gxTpr_Transactionname = "ResumenRFMGeneral";
         AV6Session.Set("TrnContext", AV11TrnContext.ToXml(false, true, "TransactionContext", "RFM"));
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
         PA0Z2( ) ;
         WS0Z2( ) ;
         WE0Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202098937131", true, true);
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
         context.AddJavascriptSource("wwresumenrfmgeneral.js", "?202098937131", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_552( )
      {
         edtPeriodo_Internalname = "PERIODO_"+sGXsfl_55_idx;
         edtCorte1_Internalname = "CORTE1_"+sGXsfl_55_idx;
         edtCorte2_Internalname = "CORTE2_"+sGXsfl_55_idx;
         edtRFM_Internalname = "RFM_"+sGXsfl_55_idx;
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO_"+sGXsfl_55_idx;
         edtClientesDelMes_Internalname = "CLIENTESDELMES_"+sGXsfl_55_idx;
         edtMinRecencia_Internalname = "MINRECENCIA_"+sGXsfl_55_idx;
         edtMaxRecencia_Internalname = "MAXRECENCIA_"+sGXsfl_55_idx;
         edtMinFrecuencia_Internalname = "MINFRECUENCIA_"+sGXsfl_55_idx;
         edtMaxFrecuencia_Internalname = "MAXFRECUENCIA_"+sGXsfl_55_idx;
         edtAvgFrecuencia_Internalname = "AVGFRECUENCIA_"+sGXsfl_55_idx;
         edtMinValorMonetario_Internalname = "MINVALORMONETARIO_"+sGXsfl_55_idx;
         edtMaxValorMonetario_Internalname = "MAXVALORMONETARIO_"+sGXsfl_55_idx;
         edtAvgValorMonetario_Internalname = "AVGVALORMONETARIO_"+sGXsfl_55_idx;
         edtComprasTickets_AnioMovil_Internalname = "COMPRASTICKETS_ANIOMOVIL_"+sGXsfl_55_idx;
         edtComprasImporte_AnioMovil_Internalname = "COMPRASIMPORTE_ANIOMOVIL_"+sGXsfl_55_idx;
         edtComprasArticulos_AnioMovil_Internalname = "COMPRASARTICULOS_ANIOMOVIL_"+sGXsfl_55_idx;
      }

      protected void SubsflControlProps_fel_552( )
      {
         edtPeriodo_Internalname = "PERIODO_"+sGXsfl_55_fel_idx;
         edtCorte1_Internalname = "CORTE1_"+sGXsfl_55_fel_idx;
         edtCorte2_Internalname = "CORTE2_"+sGXsfl_55_fel_idx;
         edtRFM_Internalname = "RFM_"+sGXsfl_55_fel_idx;
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO_"+sGXsfl_55_fel_idx;
         edtClientesDelMes_Internalname = "CLIENTESDELMES_"+sGXsfl_55_fel_idx;
         edtMinRecencia_Internalname = "MINRECENCIA_"+sGXsfl_55_fel_idx;
         edtMaxRecencia_Internalname = "MAXRECENCIA_"+sGXsfl_55_fel_idx;
         edtMinFrecuencia_Internalname = "MINFRECUENCIA_"+sGXsfl_55_fel_idx;
         edtMaxFrecuencia_Internalname = "MAXFRECUENCIA_"+sGXsfl_55_fel_idx;
         edtAvgFrecuencia_Internalname = "AVGFRECUENCIA_"+sGXsfl_55_fel_idx;
         edtMinValorMonetario_Internalname = "MINVALORMONETARIO_"+sGXsfl_55_fel_idx;
         edtMaxValorMonetario_Internalname = "MAXVALORMONETARIO_"+sGXsfl_55_fel_idx;
         edtAvgValorMonetario_Internalname = "AVGVALORMONETARIO_"+sGXsfl_55_fel_idx;
         edtComprasTickets_AnioMovil_Internalname = "COMPRASTICKETS_ANIOMOVIL_"+sGXsfl_55_fel_idx;
         edtComprasImporte_AnioMovil_Internalname = "COMPRASIMPORTE_ANIOMOVIL_"+sGXsfl_55_fel_idx;
         edtComprasArticulos_AnioMovil_Internalname = "COMPRASARTICULOS_ANIOMOVIL_"+sGXsfl_55_fel_idx;
      }

      protected void sendrow_552( )
      {
         SubsflControlProps_552( ) ;
         WB0Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_55_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_55_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_55_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPeriodo_Internalname,(String)A7Periodo,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtPeriodo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCorte1_Internalname,(String)A8Corte1,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtCorte1_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCorte2_Internalname,(String)A9Corte2,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtCorte2_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRFM_Internalname,(String)A10RFM,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRFM_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientesDelAnio_Internalname,(String)A11ClientesDelAnio,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientesDelAnio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientesDelMes_Internalname,(String)A12ClientesDelMes,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientesDelMes_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinRecencia_Internalname,(String)A13MinRecencia,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxRecencia_Internalname,(String)A14MaxRecencia,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinFrecuencia_Internalname,(String)A15MinFrecuencia,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxFrecuencia_Internalname,(String)A16MaxFrecuencia,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAvgFrecuencia_Internalname,(String)A17AvgFrecuencia,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtAvgFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinValorMonetario_Internalname,(String)A18MinValorMonetario,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinValorMonetario_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxValorMonetario_Internalname,(String)A19MaxValorMonetario,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxValorMonetario_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAvgValorMonetario_Internalname,(String)A20AvgValorMonetario,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtAvgValorMonetario_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtComprasTickets_AnioMovil_Internalname,(String)A21ComprasTickets_AnioMovil,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtComprasTickets_AnioMovil_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtComprasImporte_AnioMovil_Internalname,(String)A22ComprasImporte_AnioMovil,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtComprasImporte_AnioMovil_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtComprasArticulos_AnioMovil_Internalname,(String)A23ComprasArticulos_AnioMovil,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtComprasArticulos_AnioMovil_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)50,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            send_integrity_lvl_hashes0Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_55_idx = ((subGrid_Islastpage==1)&&(nGXsfl_55_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
         }
         /* End function sendrow_552 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtntoggle_Internalname = "BTNTOGGLE";
         lblTitletext_Internalname = "TITLETEXT";
         edtavPeriodo_Internalname = "vPERIODO";
         divTabletop_Internalname = "TABLETOP";
         lblLblcorte1filter_Internalname = "LBLCORTE1FILTER";
         edtavCorte1_Internalname = "vCORTE1";
         divCorte1filtercontainer_Internalname = "CORTE1FILTERCONTAINER";
         lblLblcorte2filter_Internalname = "LBLCORTE2FILTER";
         edtavCorte2_Internalname = "vCORTE2";
         divCorte2filtercontainer_Internalname = "CORTE2FILTERCONTAINER";
         lblLblrfmfilter_Internalname = "LBLRFMFILTER";
         edtavRfm_Internalname = "vRFM";
         divRfmfiltercontainer_Internalname = "RFMFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         edtPeriodo_Internalname = "PERIODO";
         edtCorte1_Internalname = "CORTE1";
         edtCorte2_Internalname = "CORTE2";
         edtRFM_Internalname = "RFM";
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO";
         edtClientesDelMes_Internalname = "CLIENTESDELMES";
         edtMinRecencia_Internalname = "MINRECENCIA";
         edtMaxRecencia_Internalname = "MAXRECENCIA";
         edtMinFrecuencia_Internalname = "MINFRECUENCIA";
         edtMaxFrecuencia_Internalname = "MAXFRECUENCIA";
         edtAvgFrecuencia_Internalname = "AVGFRECUENCIA";
         edtMinValorMonetario_Internalname = "MINVALORMONETARIO";
         edtMaxValorMonetario_Internalname = "MAXVALORMONETARIO";
         edtAvgValorMonetario_Internalname = "AVGVALORMONETARIO";
         edtComprasTickets_AnioMovil_Internalname = "COMPRASTICKETS_ANIOMOVIL";
         edtComprasImporte_AnioMovil_Internalname = "COMPRASIMPORTE_ANIOMOVIL";
         edtComprasArticulos_AnioMovil_Internalname = "COMPRASARTICULOS_ANIOMOVIL";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtComprasArticulos_AnioMovil_Jsonclick = "";
         edtComprasImporte_AnioMovil_Jsonclick = "";
         edtComprasTickets_AnioMovil_Jsonclick = "";
         edtAvgValorMonetario_Jsonclick = "";
         edtMaxValorMonetario_Jsonclick = "";
         edtMinValorMonetario_Jsonclick = "";
         edtAvgFrecuencia_Jsonclick = "";
         edtMaxFrecuencia_Jsonclick = "";
         edtMinFrecuencia_Jsonclick = "";
         edtMaxRecencia_Jsonclick = "";
         edtMinRecencia_Jsonclick = "";
         edtClientesDelMes_Jsonclick = "";
         edtClientesDelAnio_Jsonclick = "";
         edtRFM_Jsonclick = "";
         edtCorte2_Jsonclick = "";
         edtCorte1_Jsonclick = "";
         edtPeriodo_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 WWGridCell";
         edtavRfm_Jsonclick = "";
         edtavRfm_Enabled = 1;
         edtavRfm_Visible = 1;
         lblLblrfmfilter_Caption = "";
         edtavCorte2_Jsonclick = "";
         edtavCorte2_Enabled = 1;
         edtavCorte2_Visible = 1;
         lblLblcorte2filter_Caption = "";
         edtavCorte1_Jsonclick = "";
         edtavCorte1_Enabled = 1;
         edtavCorte1_Visible = 1;
         lblLblcorte1filter_Caption = "Corte1";
         edtavPeriodo_Jsonclick = "";
         edtavPeriodo_Enabled = 1;
         bttBtntoggle_Class = "HideFiltersButton";
         bttBtntoggle_Caption = "Hide Filters";
         divRfmfiltercontainer_Class = "AdvancedContainerItem";
         divCorte2filtercontainer_Class = "AdvancedContainerItem";
         divCorte1filtercontainer_Class = "AdvancedContainerItem";
         divFilterscontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Resumen RFMGenerals";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Corte1',fld:'vCORTE1',pic:''},{av:'AV15Corte2',fld:'vCORTE2',pic:''},{av:'AV16RFM',fld:'vRFM',pic:''},{av:'AV17ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E110Z1',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'}]}");
         setEventMetadata("LBLCORTE1FILTER.CLICK","{handler:'E120Z1',iparms:[{av:'divCorte1filtercontainer_Class',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORTE1FILTER.CLICK",",oparms:[{av:'divCorte1filtercontainer_Class',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'edtavCorte1_Visible',ctrl:'vCORTE1',prop:'Visible'}]}");
         setEventMetadata("LBLCORTE2FILTER.CLICK","{handler:'E130Z1',iparms:[{av:'divCorte2filtercontainer_Class',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORTE2FILTER.CLICK",",oparms:[{av:'divCorte2filtercontainer_Class',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'edtavCorte2_Visible',ctrl:'vCORTE2',prop:'Visible'}]}");
         setEventMetadata("LBLRFMFILTER.CLICK","{handler:'E140Z1',iparms:[{av:'divRfmfiltercontainer_Class',ctrl:'RFMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFMFILTER.CLICK",",oparms:[{av:'divRfmfiltercontainer_Class',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'edtavRfm_Visible',ctrl:'vRFM',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E170Z2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Corte1',fld:'vCORTE1',pic:''},{av:'AV17ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte2',fld:'vCORTE2',pic:''},{av:'AV16RFM',fld:'vRFM',pic:''},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Corte1',fld:'vCORTE1',pic:''},{av:'AV17ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte2',fld:'vCORTE2',pic:''},{av:'AV16RFM',fld:'vRFM',pic:''},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Corte1',fld:'vCORTE1',pic:''},{av:'AV17ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte2',fld:'vCORTE2',pic:''},{av:'AV16RFM',fld:'vRFM',pic:''},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Corte1',fld:'vCORTE1',pic:''},{av:'AV17ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte2',fld:'vCORTE2',pic:''},{av:'AV16RFM',fld:'vRFM',pic:''},{av:'AV20Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("NULL","{handler:'Valid_Comprasarticulos_aniomovil',iparms:[]");
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
         AV14Corte1 = "";
         AV17ADVANCED_LABEL_TEMPLATE = "";
         AV15Corte2 = "";
         AV16RFM = "";
         AV20Pgmname = "";
         AV13Periodo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         lblTitletext_Jsonclick = "";
         lblLblcorte1filter_Jsonclick = "";
         lblLblcorte2filter_Jsonclick = "";
         lblLblrfmfilter_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A7Periodo = "";
         A8Corte1 = "";
         A9Corte2 = "";
         A10RFM = "";
         A11ClientesDelAnio = "";
         A12ClientesDelMes = "";
         A13MinRecencia = "";
         A14MaxRecencia = "";
         A15MinFrecuencia = "";
         A16MaxFrecuencia = "";
         A17AvgFrecuencia = "";
         A18MinValorMonetario = "";
         A19MaxValorMonetario = "";
         A20AvgValorMonetario = "";
         A21ComprasTickets_AnioMovil = "";
         A22ComprasImporte_AnioMovil = "";
         A23ComprasArticulos_AnioMovil = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         lV14Corte1 = "";
         H000Z2_A23ComprasArticulos_AnioMovil = new String[] {""} ;
         H000Z2_A22ComprasImporte_AnioMovil = new String[] {""} ;
         H000Z2_A21ComprasTickets_AnioMovil = new String[] {""} ;
         H000Z2_A20AvgValorMonetario = new String[] {""} ;
         H000Z2_A19MaxValorMonetario = new String[] {""} ;
         H000Z2_A18MinValorMonetario = new String[] {""} ;
         H000Z2_A17AvgFrecuencia = new String[] {""} ;
         H000Z2_A16MaxFrecuencia = new String[] {""} ;
         H000Z2_A15MinFrecuencia = new String[] {""} ;
         H000Z2_A14MaxRecencia = new String[] {""} ;
         H000Z2_A13MinRecencia = new String[] {""} ;
         H000Z2_A12ClientesDelMes = new String[] {""} ;
         H000Z2_A11ClientesDelAnio = new String[] {""} ;
         H000Z2_A10RFM = new String[] {""} ;
         H000Z2_A9Corte2 = new String[] {""} ;
         H000Z2_A8Corte1 = new String[] {""} ;
         H000Z2_A7Periodo = new String[] {""} ;
         H000Z3_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV7HTTPRequest = new GxHttpRequest( context);
         AV8GridState = new SdtGridState(context);
         AV6Session = context.GetSession();
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV11TrnContext = new SdtTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwresumenrfmgeneral__default(),
            new Object[][] {
                new Object[] {
               H000Z2_A23ComprasArticulos_AnioMovil, H000Z2_A22ComprasImporte_AnioMovil, H000Z2_A21ComprasTickets_AnioMovil, H000Z2_A20AvgValorMonetario, H000Z2_A19MaxValorMonetario, H000Z2_A18MinValorMonetario, H000Z2_A17AvgFrecuencia, H000Z2_A16MaxFrecuencia, H000Z2_A15MinFrecuencia, H000Z2_A14MaxRecencia,
               H000Z2_A13MinRecencia, H000Z2_A12ClientesDelMes, H000Z2_A11ClientesDelAnio, H000Z2_A10RFM, H000Z2_A9Corte2, H000Z2_A8Corte1, H000Z2_A7Periodo
               }
               , new Object[] {
               H000Z3_AGRID_nRecordCount
               }
            }
         );
         AV20Pgmname = "WWResumenRFMGeneral";
         /* GeneXus formulas. */
         AV20Pgmname = "WWResumenRFMGeneral";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private int nRC_GXsfl_55 ;
      private int nGXsfl_55_idx=1 ;
      private int subGrid_Rows ;
      private int edtavPeriodo_Enabled ;
      private int edtavCorte1_Visible ;
      private int edtavCorte1_Enabled ;
      private int edtavCorte2_Visible ;
      private int edtavCorte2_Enabled ;
      private int edtavRfm_Visible ;
      private int edtavRfm_Enabled ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV10GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private String divFilterscontainer_Class ;
      private String divCorte1filtercontainer_Class ;
      private String divCorte2filtercontainer_Class ;
      private String divRfmfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_55_idx="0001" ;
      private String AV17ADVANCED_LABEL_TEMPLATE ;
      private String AV20Pgmname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTabletop_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String bttBtntoggle_Class ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Caption ;
      private String bttBtntoggle_Jsonclick ;
      private String lblTitletext_Internalname ;
      private String lblTitletext_Jsonclick ;
      private String edtavPeriodo_Internalname ;
      private String edtavPeriodo_Jsonclick ;
      private String divFilterscontainer_Internalname ;
      private String divCorte1filtercontainer_Internalname ;
      private String lblLblcorte1filter_Internalname ;
      private String lblLblcorte1filter_Caption ;
      private String lblLblcorte1filter_Jsonclick ;
      private String edtavCorte1_Internalname ;
      private String edtavCorte1_Jsonclick ;
      private String divCorte2filtercontainer_Internalname ;
      private String lblLblcorte2filter_Internalname ;
      private String lblLblcorte2filter_Caption ;
      private String lblLblcorte2filter_Jsonclick ;
      private String edtavCorte2_Internalname ;
      private String edtavCorte2_Jsonclick ;
      private String divRfmfiltercontainer_Internalname ;
      private String lblLblrfmfilter_Internalname ;
      private String lblLblrfmfilter_Caption ;
      private String lblLblrfmfilter_Jsonclick ;
      private String edtavRfm_Internalname ;
      private String edtavRfm_Jsonclick ;
      private String divGridcell_Internalname ;
      private String divGridcell_Class ;
      private String divGridtable_Internalname ;
      private String sStyleString ;
      private String subGrid_Internalname ;
      private String subGrid_Class ;
      private String subGrid_Linesclass ;
      private String subGrid_Header ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtPeriodo_Internalname ;
      private String edtCorte1_Internalname ;
      private String edtCorte2_Internalname ;
      private String edtRFM_Internalname ;
      private String edtClientesDelAnio_Internalname ;
      private String edtClientesDelMes_Internalname ;
      private String edtMinRecencia_Internalname ;
      private String edtMaxRecencia_Internalname ;
      private String edtMinFrecuencia_Internalname ;
      private String edtMaxFrecuencia_Internalname ;
      private String edtAvgFrecuencia_Internalname ;
      private String edtMinValorMonetario_Internalname ;
      private String edtMaxValorMonetario_Internalname ;
      private String edtAvgValorMonetario_Internalname ;
      private String edtComprasTickets_AnioMovil_Internalname ;
      private String edtComprasImporte_AnioMovil_Internalname ;
      private String edtComprasArticulos_AnioMovil_Internalname ;
      private String scmdbuf ;
      private String sGXsfl_55_fel_idx="0001" ;
      private String ROClassString ;
      private String edtPeriodo_Jsonclick ;
      private String edtCorte1_Jsonclick ;
      private String edtCorte2_Jsonclick ;
      private String edtRFM_Jsonclick ;
      private String edtClientesDelAnio_Jsonclick ;
      private String edtClientesDelMes_Jsonclick ;
      private String edtMinRecencia_Jsonclick ;
      private String edtMaxRecencia_Jsonclick ;
      private String edtMinFrecuencia_Jsonclick ;
      private String edtMaxFrecuencia_Jsonclick ;
      private String edtAvgFrecuencia_Jsonclick ;
      private String edtMinValorMonetario_Jsonclick ;
      private String edtMaxValorMonetario_Jsonclick ;
      private String edtAvgValorMonetario_Jsonclick ;
      private String edtComprasTickets_AnioMovil_Jsonclick ;
      private String edtComprasImporte_AnioMovil_Jsonclick ;
      private String edtComprasArticulos_AnioMovil_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_55_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private String AV14Corte1 ;
      private String AV15Corte2 ;
      private String AV16RFM ;
      private String AV13Periodo ;
      private String A7Periodo ;
      private String A8Corte1 ;
      private String A9Corte2 ;
      private String A10RFM ;
      private String A11ClientesDelAnio ;
      private String A12ClientesDelMes ;
      private String A13MinRecencia ;
      private String A14MaxRecencia ;
      private String A15MinFrecuencia ;
      private String A16MaxFrecuencia ;
      private String A17AvgFrecuencia ;
      private String A18MinValorMonetario ;
      private String A19MaxValorMonetario ;
      private String A20AvgValorMonetario ;
      private String A21ComprasTickets_AnioMovil ;
      private String A22ComprasImporte_AnioMovil ;
      private String A23ComprasArticulos_AnioMovil ;
      private String lV14Corte1 ;
      private IGxSession AV6Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] H000Z2_A23ComprasArticulos_AnioMovil ;
      private String[] H000Z2_A22ComprasImporte_AnioMovil ;
      private String[] H000Z2_A21ComprasTickets_AnioMovil ;
      private String[] H000Z2_A20AvgValorMonetario ;
      private String[] H000Z2_A19MaxValorMonetario ;
      private String[] H000Z2_A18MinValorMonetario ;
      private String[] H000Z2_A17AvgFrecuencia ;
      private String[] H000Z2_A16MaxFrecuencia ;
      private String[] H000Z2_A15MinFrecuencia ;
      private String[] H000Z2_A14MaxRecencia ;
      private String[] H000Z2_A13MinRecencia ;
      private String[] H000Z2_A12ClientesDelMes ;
      private String[] H000Z2_A11ClientesDelAnio ;
      private String[] H000Z2_A10RFM ;
      private String[] H000Z2_A9Corte2 ;
      private String[] H000Z2_A8Corte1 ;
      private String[] H000Z2_A7Periodo ;
      private long[] H000Z3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private SdtGridState AV8GridState ;
      private SdtGridState_FilterValue AV9GridStateFilterValue ;
      private SdtTransactionContext AV11TrnContext ;
   }

   public class wwresumenrfmgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000Z2( IGxContext context ,
                                             String AV14Corte1 ,
                                             String A8Corte1 )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [4] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [ComprasArticulos_AnioMovil], [ComprasImporte_AnioMovil], [ComprasTickets_AnioMovil], [AvgValorMonetario], [MaxValorMonetario], [MinValorMonetario], [AvgFrecuencia], [MaxFrecuencia], [MinFrecuencia], [MaxRecencia], [MinRecencia], [ClientesDelMes], [ClientesDelAnio], [RFM], [Corte2], [Corte1], [Periodo]";
         sFromString = " FROM [ResumenRFMGeneral]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Corte1)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Corte1] like @lV14Corte1)";
            }
            else
            {
               sWhereString = sWhereString + " ([Corte1] like @lV14Corte1)";
            }
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            sWhereString = " WHERE" + sWhereString;
         }
         sOrderString = sOrderString + " ORDER BY [Corte1]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000Z3( IGxContext context ,
                                             String AV14Corte1 ,
                                             String A8Corte1 )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [1] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM [ResumenRFMGeneral]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Corte1)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Corte1] like @lV14Corte1)";
            }
            else
            {
               sWhereString = sWhereString + " ([Corte1] like @lV14Corte1)";
            }
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE" + sWhereString;
         }
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
                     return conditional_H000Z2(context, (String)dynConstraints[0] , (String)dynConstraints[1] );
               case 1 :
                     return conditional_H000Z3(context, (String)dynConstraints[0] , (String)dynConstraints[1] );
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
          Object[] prmH000Z2 ;
          prmH000Z2 = new Object[] {
          new Object[] {"@lV14Corte1",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH000Z3 ;
          prmH000Z3 = new Object[] {
          new Object[] {"@lV14Corte1",SqlDbType.NVarChar,50,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Z3,1, GxCacheFrequency.OFF ,true,false )
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
                ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
                ((String[]) buf[1])[0] = rslt.getVarchar(2) ;
                ((String[]) buf[2])[0] = rslt.getVarchar(3) ;
                ((String[]) buf[3])[0] = rslt.getVarchar(4) ;
                ((String[]) buf[4])[0] = rslt.getVarchar(5) ;
                ((String[]) buf[5])[0] = rslt.getVarchar(6) ;
                ((String[]) buf[6])[0] = rslt.getVarchar(7) ;
                ((String[]) buf[7])[0] = rslt.getVarchar(8) ;
                ((String[]) buf[8])[0] = rslt.getVarchar(9) ;
                ((String[]) buf[9])[0] = rslt.getVarchar(10) ;
                ((String[]) buf[10])[0] = rslt.getVarchar(11) ;
                ((String[]) buf[11])[0] = rslt.getVarchar(12) ;
                ((String[]) buf[12])[0] = rslt.getVarchar(13) ;
                ((String[]) buf[13])[0] = rslt.getVarchar(14) ;
                ((String[]) buf[14])[0] = rslt.getVarchar(15) ;
                ((String[]) buf[15])[0] = rslt.getVarchar(16) ;
                ((String[]) buf[16])[0] = rslt.getVarchar(17) ;
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
                   stmt.SetParameter(sIdx, (String)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[5]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[6]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[7]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (String)parms[1]);
                }
                return;
       }
    }

 }

}
