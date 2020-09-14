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
   public class wwresumenrfmglobal : GXDataArea
   {
      public wwresumenrfmglobal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwresumenrfmglobal( IGxContext context )
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
               nRC_GXsfl_73 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_73_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_73_idx = GetNextPar( );
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
               AV14Periodo = GetNextPar( );
               AV15Corte1 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV16Corte2 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV17RFM = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV13OrderedBy = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV18ADVANCED_LABEL_TEMPLATE = GetNextPar( );
               AV21Pgmname = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
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
         PA122( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START122( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202099155228", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwresumenrfmglobal.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vPERIODO", AV14Periodo);
         GxWebStd.gx_hidden_field( context, "GXH_vCORTE1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Corte1), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORTE2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Corte2), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRFM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RFM), 8, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_73), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV18ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERBYCONTAINER_Class", StringUtil.RTrim( divOrderbycontainer_Class));
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
            WE122( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT122( ) ;
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
         return formatLink("wwresumenrfmglobal.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WWResumenRFMGlobal" ;
      }

      public override String GetPgmdesc( )
      {
         return "Resumen RFMGlobals" ;
      }

      protected void WB120( )
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(73), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11121_client"+"'", TempTags, "", 2, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Resumen RFMGlobals", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-5 col-sm-push-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPeriodo_Internalname, "Periodo", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPeriodo_Internalname, AV14Periodo, StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPeriodo_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavPeriodo_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWResumenRFMGlobal.htm");
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
            GxWebStd.gx_div_start( context, divOrderbycontainer_Internalname, 1, 0, "px", 0, "px", divOrderbycontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderby_Internalname, lblLblorderby_Caption, "", "", lblLblorderby_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12121_client"+"'", "", "WWAdvancedLabel WWOrderByLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divOrderbycontainer2_Internalname, 1, 0, "px", 0, "px", "OrdersTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-6 OrdersCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby1_Internalname, "Periodo", "", "", lblOrderby1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EORDERBY1.CLICK."+"'", "", lblOrderby1_Class, 5, "", 1, 1, 0, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-6 OrdersCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby2_Internalname, "Corte1", "", "", lblOrderby2_Jsonclick, "'"+""+"'"+",false,"+"'"+"EORDERBY2.CLICK."+"'", "", lblOrderby2_Class, 5, "", 1, 1, 0, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-6 OrdersCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby3_Internalname, "Corte2", "", "", lblOrderby3_Jsonclick, "'"+""+"'"+",false,"+"'"+"EORDERBY3.CLICK."+"'", "", lblOrderby3_Class, 5, "", 1, 1, 0, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-6 OrdersCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblOrderby4_Internalname, "RFM", "", "", lblOrderby4_Jsonclick, "'"+""+"'"+",false,"+"'"+"EORDERBY4.CLICK."+"'", "", lblOrderby4_Class, 5, "", 1, 1, 0, "HLP_WWResumenRFMGlobal.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblLblcorte1filter_Internalname, lblLblcorte1filter_Caption, "", "", lblLblcorte1filter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13121_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGlobal.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorte1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Corte1), 8, 0, ".", "")), ((edtavCorte1_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV15Corte1), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV15Corte1), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorte1_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavCorte1_Visible, edtavCorte1_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWResumenRFMGlobal.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblcorte2filter_Internalname, lblLblcorte2filter_Caption, "", "", lblLblcorte2filter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14121_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGlobal.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorte2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Corte2), 8, 0, ".", "")), ((edtavCorte2_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16Corte2), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV16Corte2), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorte2_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavCorte2_Visible, edtavCorte2_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWResumenRFMGlobal.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblrfmfilter_Internalname, lblLblrfmfilter_Caption, "", "", lblLblrfmfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15121_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWResumenRFMGlobal.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_73_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRfm_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RFM), 8, 0, ".", "")), ((edtavRfm_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17RFM), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV17RFM), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRfm_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavRfm_Visible, edtavRfm_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWResumenRFMGlobal.htm");
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"73\">") ;
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Frecuencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Frecuencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Valor Monetario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Valor Monetario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Valor Monetario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tickets_Anio Movil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Importe_Anio Movil") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8Corte1), 8, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9Corte2), 8, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10RFM), 8, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClientesDelAnio), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ClientesDelMes), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MinRecencia), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14MaxRecencia), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AvgRecencia), 10, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A15MinFrecuencia, 10, 6, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A16MaxFrecuencia, 10, 6, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A17AvgFrecuencia, 10, 6, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A18MinValorMonetario, 12, 8, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A19MaxValorMonetario, 12, 8, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A20AvgValorMonetario, 12, 8, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A21ComprasTickets_AnioMovil), 12, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A22ComprasImporte_AnioMovil, 12, 2, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0, ".", "")));
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
         if ( wbEnd == 73 )
         {
            wbEnd = 0;
            nRC_GXsfl_73 = (int)(nGXsfl_73_idx-1);
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
         if ( wbEnd == 73 )
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

      protected void START122( )
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
            Form.Meta.addItem("description", "Resumen RFMGlobals", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP120( ) ;
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
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
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBY1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBY2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBY3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ORDERBY4.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19122 ();
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
                              nGXsfl_73_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
                              SubsflControlProps_732( ) ;
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
                              A16MaxFrecuencia = context.localUtil.CToN( cgiGet( edtMaxFrecuencia_Internalname), ".", ",");
                              A17AvgFrecuencia = context.localUtil.CToN( cgiGet( edtAvgFrecuencia_Internalname), ".", ",");
                              A18MinValorMonetario = context.localUtil.CToN( cgiGet( edtMinValorMonetario_Internalname), ".", ",");
                              A19MaxValorMonetario = context.localUtil.CToN( cgiGet( edtMaxValorMonetario_Internalname), ".", ",");
                              A20AvgValorMonetario = context.localUtil.CToN( cgiGet( edtAvgValorMonetario_Internalname), ".", ",");
                              A21ComprasTickets_AnioMovil = (long)(context.localUtil.CToN( cgiGet( edtComprasTickets_AnioMovil_Internalname), ".", ","));
                              n21ComprasTickets_AnioMovil = false;
                              A22ComprasImporte_AnioMovil = context.localUtil.CToN( cgiGet( edtComprasImporte_AnioMovil_Internalname), ".", ",");
                              n22ComprasImporte_AnioMovil = false;
                              A23ComprasArticulos_AnioMovil = (long)(context.localUtil.CToN( cgiGet( edtComprasArticulos_AnioMovil_Internalname), ".", ","));
                              n23ComprasArticulos_AnioMovil = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E20122 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E21122 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22122 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Periodo Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPERIODO"), AV14Periodo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corte1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORTE1"), ".", ",") != Convert.ToDecimal( AV15Corte1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corte2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORTE2"), ".", ",") != Convert.ToDecimal( AV16Corte2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rfm Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vRFM"), ".", ",") != Convert.ToDecimal( AV17RFM )) )
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

      protected void WE122( )
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

      protected void PA122( )
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
         SubsflControlProps_732( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            sendrow_732( ) ;
            nGXsfl_73_idx = ((subGrid_Islastpage==1)&&(nGXsfl_73_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_732( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       String AV14Periodo ,
                                       int AV15Corte1 ,
                                       int AV16Corte2 ,
                                       int AV17RFM ,
                                       short AV13OrderedBy ,
                                       String AV18ADVANCED_LABEL_TEMPLATE ,
                                       String AV21Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E21122 ();
         GRID_nCurrentRecord = 0;
         RF122( ) ;
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
         RF122( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "WWResumenRFMGlobal";
         context.Gx_err = 0;
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 73;
         /* Execute user event: Refresh */
         E21122 ();
         nGXsfl_73_idx = 1;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_732( ) ;
         bGXsfl_73_Refreshing = true;
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
            SubsflControlProps_732( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14Periodo ,
                                                 AV15Corte1 ,
                                                 AV16Corte2 ,
                                                 AV17RFM ,
                                                 A7Periodo ,
                                                 A8Corte1 ,
                                                 A9Corte2 ,
                                                 A10RFM ,
                                                 AV13OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.STRING, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.STRING, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            } ) ;
            /* Using cursor H00122 */
            pr_default.execute(0, new Object[] {AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_73_idx = 1;
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_732( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A23ComprasArticulos_AnioMovil = H00122_A23ComprasArticulos_AnioMovil[0];
               n23ComprasArticulos_AnioMovil = H00122_n23ComprasArticulos_AnioMovil[0];
               A22ComprasImporte_AnioMovil = H00122_A22ComprasImporte_AnioMovil[0];
               n22ComprasImporte_AnioMovil = H00122_n22ComprasImporte_AnioMovil[0];
               A21ComprasTickets_AnioMovil = H00122_A21ComprasTickets_AnioMovil[0];
               n21ComprasTickets_AnioMovil = H00122_n21ComprasTickets_AnioMovil[0];
               A20AvgValorMonetario = H00122_A20AvgValorMonetario[0];
               A19MaxValorMonetario = H00122_A19MaxValorMonetario[0];
               A18MinValorMonetario = H00122_A18MinValorMonetario[0];
               A17AvgFrecuencia = H00122_A17AvgFrecuencia[0];
               A16MaxFrecuencia = H00122_A16MaxFrecuencia[0];
               A15MinFrecuencia = H00122_A15MinFrecuencia[0];
               A24AvgRecencia = H00122_A24AvgRecencia[0];
               A14MaxRecencia = H00122_A14MaxRecencia[0];
               A13MinRecencia = H00122_A13MinRecencia[0];
               A12ClientesDelMes = H00122_A12ClientesDelMes[0];
               A11ClientesDelAnio = H00122_A11ClientesDelAnio[0];
               n11ClientesDelAnio = H00122_n11ClientesDelAnio[0];
               A10RFM = H00122_A10RFM[0];
               A9Corte2 = H00122_A9Corte2[0];
               A8Corte1 = H00122_A8Corte1[0];
               A7Periodo = H00122_A7Periodo[0];
               E22122 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 73;
            WB120( ) ;
         }
         bGXsfl_73_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes122( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV18ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
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
                                              AV14Periodo ,
                                              AV15Corte1 ,
                                              AV16Corte2 ,
                                              AV17RFM ,
                                              A7Periodo ,
                                              A8Corte1 ,
                                              A9Corte2 ,
                                              A10RFM ,
                                              AV13OrderedBy } ,
                                              new int[]{
                                              TypeConstants.STRING, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.STRING, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         } ) ;
         /* Using cursor H00123 */
         pr_default.execute(1, new Object[] {AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM});
         GRID_nRecordCount = H00123_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "WWResumenRFMGlobal";
         context.Gx_err = 0;
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E20122 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_73 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV14Periodo = cgiGet( edtavPeriodo_Internalname);
            AssignAttri("", false, "AV14Periodo", AV14Periodo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCorte1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCorte1_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCORTE1");
               GX_FocusControl = edtavCorte1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15Corte1 = 0;
               AssignAttri("", false, "AV15Corte1", StringUtil.LTrimStr( (decimal)(AV15Corte1), 8, 0));
            }
            else
            {
               AV15Corte1 = (int)(context.localUtil.CToN( cgiGet( edtavCorte1_Internalname), ".", ","));
               AssignAttri("", false, "AV15Corte1", StringUtil.LTrimStr( (decimal)(AV15Corte1), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCorte2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCorte2_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCORTE2");
               GX_FocusControl = edtavCorte2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16Corte2 = 0;
               AssignAttri("", false, "AV16Corte2", StringUtil.LTrimStr( (decimal)(AV16Corte2), 8, 0));
            }
            else
            {
               AV16Corte2 = (int)(context.localUtil.CToN( cgiGet( edtavCorte2_Internalname), ".", ","));
               AssignAttri("", false, "AV16Corte2", StringUtil.LTrimStr( (decimal)(AV16Corte2), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRfm_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRfm_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRFM");
               GX_FocusControl = edtavRfm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17RFM = 0;
               AssignAttri("", false, "AV17RFM", StringUtil.LTrimStr( (decimal)(AV17RFM), 8, 0));
            }
            else
            {
               AV17RFM = (int)(context.localUtil.CToN( cgiGet( edtavRfm_Internalname), ".", ","));
               AssignAttri("", false, "AV17RFM", StringUtil.LTrimStr( (decimal)(AV17RFM), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPERIODO"), AV14Periodo) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORTE1"), ".", ",") != Convert.ToDecimal( AV15Corte1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORTE2"), ".", ",") != Convert.ToDecimal( AV16Corte2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vRFM"), ".", ",") != Convert.ToDecimal( AV17RFM )) )
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
         E20122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E20122( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV21Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV21Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV13OrderedBy = 1;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         edtavCorte1_Visible = 0;
         AssignProp("", false, edtavCorte1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorte1_Visible), 5, 0), true);
         edtavCorte2_Visible = 0;
         AssignProp("", false, edtavCorte2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCorte2_Visible), 5, 0), true);
         edtavRfm_Visible = 0;
         AssignProp("", false, edtavRfm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRfm_Visible), 5, 0), true);
         Form.Caption = "Resumen RFMGlobals";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV18ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV18ADVANCED_LABEL_TEMPLATE", AV18ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "")), context));
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

      protected void E16122( )
      {
         /* Orderby1_Click Routine */
         AV13OrderedBy = 1;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         lblOrderby1_Class = "WWOrderItem"+" "+"WWOrderItemSelected";
         AssignProp("", false, lblOrderby1_Internalname, "Class", lblOrderby1_Class, true);
         lblOrderby2_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby2_Internalname, "Class", lblOrderby2_Class, true);
         lblOrderby3_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby3_Internalname, "Class", lblOrderby3_Class, true);
         lblOrderby4_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby4_Internalname, "Class", lblOrderby4_Class, true);
         gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
         /*  Sending Event outputs  */
      }

      protected void E17122( )
      {
         /* Orderby2_Click Routine */
         AV13OrderedBy = 2;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         lblOrderby1_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby1_Internalname, "Class", lblOrderby1_Class, true);
         lblOrderby2_Class = "WWOrderItem"+" "+"WWOrderItemSelected";
         AssignProp("", false, lblOrderby2_Internalname, "Class", lblOrderby2_Class, true);
         lblOrderby3_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby3_Internalname, "Class", lblOrderby3_Class, true);
         lblOrderby4_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby4_Internalname, "Class", lblOrderby4_Class, true);
         gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
         /*  Sending Event outputs  */
      }

      protected void E18122( )
      {
         /* Orderby3_Click Routine */
         AV13OrderedBy = 3;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         lblOrderby1_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby1_Internalname, "Class", lblOrderby1_Class, true);
         lblOrderby2_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby2_Internalname, "Class", lblOrderby2_Class, true);
         lblOrderby3_Class = "WWOrderItem"+" "+"WWOrderItemSelected";
         AssignProp("", false, lblOrderby3_Internalname, "Class", lblOrderby3_Class, true);
         lblOrderby4_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby4_Internalname, "Class", lblOrderby4_Class, true);
         gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
         /*  Sending Event outputs  */
      }

      protected void E19122( )
      {
         /* Orderby4_Click Routine */
         AV13OrderedBy = 4;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         lblOrderby1_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby1_Internalname, "Class", lblOrderby1_Class, true);
         lblOrderby2_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby2_Internalname, "Class", lblOrderby2_Class, true);
         lblOrderby3_Class = "WWOrderItem";
         AssignProp("", false, lblOrderby3_Internalname, "Class", lblOrderby3_Class, true);
         lblOrderby4_Class = "WWOrderItem"+" "+"WWOrderItemSelected";
         AssignProp("", false, lblOrderby4_Internalname, "Class", lblOrderby4_Class, true);
         gxgrGrid_refresh( subGrid_Rows, AV14Periodo, AV15Corte1, AV16Corte2, AV17RFM, AV13OrderedBy, AV18ADVANCED_LABEL_TEMPLATE, AV21Pgmname) ;
         /*  Sending Event outputs  */
      }

      protected void E21122( )
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
         if ( AV13OrderedBy == 1 )
         {
            lblLblorderby_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "Ordered By", "Periodo", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblorderby_Internalname, "Caption", lblLblorderby_Caption, true);
         }
         else if ( AV13OrderedBy == 2 )
         {
            lblLblorderby_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "Ordered By", "Corte1", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblorderby_Internalname, "Caption", lblLblorderby_Caption, true);
         }
         else if ( AV13OrderedBy == 3 )
         {
            lblLblorderby_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "Ordered By", "Corte2", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblorderby_Internalname, "Caption", lblLblorderby_Caption, true);
         }
         else if ( AV13OrderedBy == 4 )
         {
            lblLblorderby_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "Ordered By", "RFM", "", "", "", "", "", "", "");
            AssignProp("", false, lblLblorderby_Internalname, "Caption", lblLblorderby_Caption, true);
         }
         if ( (0==AV15Corte1) )
         {
            lblLblcorte1filter_Caption = "Corte1";
            AssignProp("", false, lblLblcorte1filter_Internalname, "Caption", lblLblcorte1filter_Caption, true);
         }
         else
         {
            lblLblcorte1filter_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "Corte1", StringUtil.LTrimStr( (decimal)(AV15Corte1), 8, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblcorte1filter_Internalname, "Caption", lblLblcorte1filter_Caption, true);
         }
         if ( (0==AV16Corte2) )
         {
            lblLblcorte2filter_Caption = "";
            AssignProp("", false, lblLblcorte2filter_Internalname, "Caption", lblLblcorte2filter_Caption, true);
         }
         else
         {
            lblLblcorte2filter_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "", StringUtil.LTrimStr( (decimal)(AV16Corte2), 8, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblcorte2filter_Internalname, "Caption", lblLblcorte2filter_Caption, true);
         }
         if ( (0==AV17RFM) )
         {
            lblLblrfmfilter_Caption = "";
            AssignProp("", false, lblLblrfmfilter_Internalname, "Caption", lblLblrfmfilter_Caption, true);
         }
         else
         {
            lblLblrfmfilter_Caption = StringUtil.Format( AV18ADVANCED_LABEL_TEMPLATE, "", StringUtil.LTrimStr( (decimal)(AV17RFM), 8, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblrfmfilter_Internalname, "Caption", lblLblrfmfilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E22122( )
      {
         /* Grid_Load Routine */
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 73;
         }
         sendrow_732( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_73_Refreshing )
         {
            DoAjaxLoad(73, GridRow);
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         if ( StringUtil.StrCmp(AV7HTTPRequest.Method, "GET") == 0 )
         {
            AV8GridState.FromXml(AV6Session.Get(AV21Pgmname+"GridState"), null, "GridState", "RFM");
            if ( AV8GridState.gxTpr_Orderedby != 0 )
            {
               AV13OrderedBy = AV8GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            }
            if ( AV8GridState.gxTpr_Filtervalues.Count >= 4 )
            {
               AV14Periodo = ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(1)).gxTpr_Value;
               AssignAttri("", false, "AV14Periodo", AV14Periodo);
               AV15Corte1 = (int)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(2)).gxTpr_Value, "."));
               AssignAttri("", false, "AV15Corte1", StringUtil.LTrimStr( (decimal)(AV15Corte1), 8, 0));
               AV16Corte2 = (int)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(3)).gxTpr_Value, "."));
               AssignAttri("", false, "AV16Corte2", StringUtil.LTrimStr( (decimal)(AV16Corte2), 8, 0));
               AV17RFM = (int)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(4)).gxTpr_Value, "."));
               AssignAttri("", false, "AV17RFM", StringUtil.LTrimStr( (decimal)(AV17RFM), 8, 0));
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
         AV8GridState.FromXml(AV6Session.Get(AV21Pgmname+"GridState"), null, "GridState", "RFM");
         AV8GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV8GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV8GridState.gxTpr_Filtervalues.Clear();
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = AV14Periodo;
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV15Corte1), 8, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV16Corte2), 8, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV17RFM), 8, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV6Session.Set(AV21Pgmname+"GridState", AV8GridState.ToXml(false, true, "GridState", "RFM"));
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context);
         AV11TrnContext.gxTpr_Callerobject = AV21Pgmname;
         AV11TrnContext.gxTpr_Callerondelete = true;
         AV11TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV11TrnContext.gxTpr_Transactionname = "ResumenRFMGlobal";
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202099155310", true, true);
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
         context.AddJavascriptSource("wwresumenrfmglobal.js", "?202099155310", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_732( )
      {
         edtPeriodo_Internalname = "PERIODO_"+sGXsfl_73_idx;
         edtCorte1_Internalname = "CORTE1_"+sGXsfl_73_idx;
         edtCorte2_Internalname = "CORTE2_"+sGXsfl_73_idx;
         edtRFM_Internalname = "RFM_"+sGXsfl_73_idx;
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO_"+sGXsfl_73_idx;
         edtClientesDelMes_Internalname = "CLIENTESDELMES_"+sGXsfl_73_idx;
         edtMinRecencia_Internalname = "MINRECENCIA_"+sGXsfl_73_idx;
         edtMaxRecencia_Internalname = "MAXRECENCIA_"+sGXsfl_73_idx;
         edtAvgRecencia_Internalname = "AVGRECENCIA_"+sGXsfl_73_idx;
         edtMinFrecuencia_Internalname = "MINFRECUENCIA_"+sGXsfl_73_idx;
         edtMaxFrecuencia_Internalname = "MAXFRECUENCIA_"+sGXsfl_73_idx;
         edtAvgFrecuencia_Internalname = "AVGFRECUENCIA_"+sGXsfl_73_idx;
         edtMinValorMonetario_Internalname = "MINVALORMONETARIO_"+sGXsfl_73_idx;
         edtMaxValorMonetario_Internalname = "MAXVALORMONETARIO_"+sGXsfl_73_idx;
         edtAvgValorMonetario_Internalname = "AVGVALORMONETARIO_"+sGXsfl_73_idx;
         edtComprasTickets_AnioMovil_Internalname = "COMPRASTICKETS_ANIOMOVIL_"+sGXsfl_73_idx;
         edtComprasImporte_AnioMovil_Internalname = "COMPRASIMPORTE_ANIOMOVIL_"+sGXsfl_73_idx;
         edtComprasArticulos_AnioMovil_Internalname = "COMPRASARTICULOS_ANIOMOVIL_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_732( )
      {
         edtPeriodo_Internalname = "PERIODO_"+sGXsfl_73_fel_idx;
         edtCorte1_Internalname = "CORTE1_"+sGXsfl_73_fel_idx;
         edtCorte2_Internalname = "CORTE2_"+sGXsfl_73_fel_idx;
         edtRFM_Internalname = "RFM_"+sGXsfl_73_fel_idx;
         edtClientesDelAnio_Internalname = "CLIENTESDELANIO_"+sGXsfl_73_fel_idx;
         edtClientesDelMes_Internalname = "CLIENTESDELMES_"+sGXsfl_73_fel_idx;
         edtMinRecencia_Internalname = "MINRECENCIA_"+sGXsfl_73_fel_idx;
         edtMaxRecencia_Internalname = "MAXRECENCIA_"+sGXsfl_73_fel_idx;
         edtAvgRecencia_Internalname = "AVGRECENCIA_"+sGXsfl_73_fel_idx;
         edtMinFrecuencia_Internalname = "MINFRECUENCIA_"+sGXsfl_73_fel_idx;
         edtMaxFrecuencia_Internalname = "MAXFRECUENCIA_"+sGXsfl_73_fel_idx;
         edtAvgFrecuencia_Internalname = "AVGFRECUENCIA_"+sGXsfl_73_fel_idx;
         edtMinValorMonetario_Internalname = "MINVALORMONETARIO_"+sGXsfl_73_fel_idx;
         edtMaxValorMonetario_Internalname = "MAXVALORMONETARIO_"+sGXsfl_73_fel_idx;
         edtAvgValorMonetario_Internalname = "AVGVALORMONETARIO_"+sGXsfl_73_fel_idx;
         edtComprasTickets_AnioMovil_Internalname = "COMPRASTICKETS_ANIOMOVIL_"+sGXsfl_73_fel_idx;
         edtComprasImporte_AnioMovil_Internalname = "COMPRASIMPORTE_ANIOMOVIL_"+sGXsfl_73_fel_idx;
         edtComprasArticulos_AnioMovil_Internalname = "COMPRASARTICULOS_ANIOMOVIL_"+sGXsfl_73_fel_idx;
      }

      protected void sendrow_732( )
      {
         SubsflControlProps_732( ) ;
         WB120( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_73_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_73_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtPeriodo_Internalname,(String)A7Periodo,(String)"",(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtPeriodo_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)6,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)-1,(bool)true,(String)"",(String)"left",(bool)true,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCorte1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A8Corte1), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A8Corte1), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtCorte1_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtCorte2_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9Corte2), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A9Corte2), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtCorte2_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRFM_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10RFM), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A10RFM), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRFM_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientesDelAnio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClientesDelAnio), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A11ClientesDelAnio), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientesDelAnio_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientesDelMes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ClientesDelMes), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A12ClientesDelMes), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientesDelMes_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinRecencia_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MinRecencia), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A13MinRecencia), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxRecencia_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14MaxRecencia), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A14MaxRecencia), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAvgRecencia_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AvgRecencia), 10, 0, ".", "")),context.localUtil.Format( (decimal)(A24AvgRecencia), "ZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtAvgRecencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinFrecuencia_Internalname,StringUtil.LTrim( StringUtil.NToC( A15MinFrecuencia, 10, 6, ".", "")),context.localUtil.Format( A15MinFrecuencia, "ZZ9.999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxFrecuencia_Internalname,StringUtil.LTrim( StringUtil.NToC( A16MaxFrecuencia, 10, 6, ".", "")),context.localUtil.Format( A16MaxFrecuencia, "ZZ9.999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAvgFrecuencia_Internalname,StringUtil.LTrim( StringUtil.NToC( A17AvgFrecuencia, 10, 6, ".", "")),context.localUtil.Format( A17AvgFrecuencia, "ZZ9.999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtAvgFrecuencia_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)10,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMinValorMonetario_Internalname,StringUtil.LTrim( StringUtil.NToC( A18MinValorMonetario, 12, 8, ".", "")),context.localUtil.Format( A18MinValorMonetario, "ZZ9.99999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMinValorMonetario_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtMaxValorMonetario_Internalname,StringUtil.LTrim( StringUtil.NToC( A19MaxValorMonetario, 12, 8, ".", "")),context.localUtil.Format( A19MaxValorMonetario, "ZZ9.99999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtMaxValorMonetario_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtAvgValorMonetario_Internalname,StringUtil.LTrim( StringUtil.NToC( A20AvgValorMonetario, 12, 8, ".", "")),context.localUtil.Format( A20AvgValorMonetario, "ZZ9.99999999"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtAvgValorMonetario_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtComprasTickets_AnioMovil_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A21ComprasTickets_AnioMovil), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A21ComprasTickets_AnioMovil), "ZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtComprasTickets_AnioMovil_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtComprasImporte_AnioMovil_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ComprasImporte_AnioMovil, 12, 2, ".", "")),context.localUtil.Format( A22ComprasImporte_AnioMovil, "ZZZZZZZZ9.99"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtComprasImporte_AnioMovil_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"text",(String)"",(short)0,(String)"px",(short)17,(String)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtComprasArticulos_AnioMovil_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0, ".", "")),context.localUtil.Format( (decimal)(A23ComprasArticulos_AnioMovil), "ZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtComprasArticulos_AnioMovil_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)12,(short)0,(short)0,(short)73,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes122( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_73_idx = ((subGrid_Islastpage==1)&&(nGXsfl_73_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_732( ) ;
         }
         /* End function sendrow_732 */
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
         lblLblorderby_Internalname = "LBLORDERBY";
         lblOrderby1_Internalname = "ORDERBY1";
         lblOrderby2_Internalname = "ORDERBY2";
         lblOrderby3_Internalname = "ORDERBY3";
         lblOrderby4_Internalname = "ORDERBY4";
         divOrderbycontainer2_Internalname = "ORDERBYCONTAINER2";
         divOrderbycontainer_Internalname = "ORDERBYCONTAINER";
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
         edtAvgRecencia_Internalname = "AVGRECENCIA";
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
         edtAvgRecencia_Jsonclick = "";
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
         lblOrderby4_Class = "WWOrderItem";
         lblOrderby3_Class = "WWOrderItem";
         lblOrderby2_Class = "WWOrderItem";
         lblOrderby1_Class = "WWOrderItem WWOrderItemSelected";
         lblLblorderby_Caption = "Ordered By";
         edtavPeriodo_Jsonclick = "";
         edtavPeriodo_Enabled = 1;
         bttBtntoggle_Class = "HideFiltersButton";
         bttBtntoggle_Caption = "Hide Filters";
         divRfmfiltercontainer_Class = "AdvancedContainerItem";
         divCorte2filtercontainer_Class = "AdvancedContainerItem";
         divCorte1filtercontainer_Class = "AdvancedContainerItem";
         divOrderbycontainer_Class = "AdvancedContainerItem";
         divFilterscontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Resumen RFMGlobals";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E11121',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'}]}");
         setEventMetadata("LBLORDERBY.CLICK","{handler:'E12121',iparms:[{av:'divOrderbycontainer_Class',ctrl:'ORDERBYCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERBY.CLICK",",oparms:[{av:'divOrderbycontainer_Class',ctrl:'ORDERBYCONTAINER',prop:'Class'}]}");
         setEventMetadata("ORDERBY1.CLICK","{handler:'E16122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("ORDERBY1.CLICK",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblOrderby1_Class',ctrl:'ORDERBY1',prop:'Class'},{av:'lblOrderby2_Class',ctrl:'ORDERBY2',prop:'Class'},{av:'lblOrderby3_Class',ctrl:'ORDERBY3',prop:'Class'},{av:'lblOrderby4_Class',ctrl:'ORDERBY4',prop:'Class'},{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("ORDERBY2.CLICK","{handler:'E17122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("ORDERBY2.CLICK",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblOrderby1_Class',ctrl:'ORDERBY1',prop:'Class'},{av:'lblOrderby2_Class',ctrl:'ORDERBY2',prop:'Class'},{av:'lblOrderby3_Class',ctrl:'ORDERBY3',prop:'Class'},{av:'lblOrderby4_Class',ctrl:'ORDERBY4',prop:'Class'},{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("ORDERBY3.CLICK","{handler:'E18122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("ORDERBY3.CLICK",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblOrderby1_Class',ctrl:'ORDERBY1',prop:'Class'},{av:'lblOrderby2_Class',ctrl:'ORDERBY2',prop:'Class'},{av:'lblOrderby3_Class',ctrl:'ORDERBY3',prop:'Class'},{av:'lblOrderby4_Class',ctrl:'ORDERBY4',prop:'Class'},{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("ORDERBY4.CLICK","{handler:'E19122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14Periodo',fld:'vPERIODO',pic:''},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("ORDERBY4.CLICK",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblOrderby1_Class',ctrl:'ORDERBY1',prop:'Class'},{av:'lblOrderby2_Class',ctrl:'ORDERBY2',prop:'Class'},{av:'lblOrderby3_Class',ctrl:'ORDERBY3',prop:'Class'},{av:'lblOrderby4_Class',ctrl:'ORDERBY4',prop:'Class'},{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("LBLCORTE1FILTER.CLICK","{handler:'E13121',iparms:[{av:'divCorte1filtercontainer_Class',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORTE1FILTER.CLICK",",oparms:[{av:'divCorte1filtercontainer_Class',ctrl:'CORTE1FILTERCONTAINER',prop:'Class'},{av:'edtavCorte1_Visible',ctrl:'vCORTE1',prop:'Visible'}]}");
         setEventMetadata("LBLCORTE2FILTER.CLICK","{handler:'E14121',iparms:[{av:'divCorte2filtercontainer_Class',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORTE2FILTER.CLICK",",oparms:[{av:'divCorte2filtercontainer_Class',ctrl:'CORTE2FILTERCONTAINER',prop:'Class'},{av:'edtavCorte2_Visible',ctrl:'vCORTE2',prop:'Visible'}]}");
         setEventMetadata("LBLRFMFILTER.CLICK","{handler:'E15121',iparms:[{av:'divRfmfiltercontainer_Class',ctrl:'RFMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFMFILTER.CLICK",",oparms:[{av:'divRfmfiltercontainer_Class',ctrl:'RFMFILTERCONTAINER',prop:'Class'},{av:'edtavRfm_Visible',ctrl:'vRFM',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E22122',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV18ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV15Corte1',fld:'vCORTE1',pic:'ZZZZZZZ9'},{av:'AV16Corte2',fld:'vCORTE2',pic:'ZZZZZZZ9'},{av:'AV17RFM',fld:'vRFM',pic:'ZZZZZZZ9'},{av:'AV21Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14Periodo',fld:'vPERIODO',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblorderby_Caption',ctrl:'LBLORDERBY',prop:'Caption'},{av:'lblLblcorte1filter_Caption',ctrl:'LBLCORTE1FILTER',prop:'Caption'},{av:'lblLblcorte2filter_Caption',ctrl:'LBLCORTE2FILTER',prop:'Caption'},{av:'lblLblrfmfilter_Caption',ctrl:'LBLRFMFILTER',prop:'Caption'}]}");
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
         AV14Periodo = "";
         AV18ADVANCED_LABEL_TEMPLATE = "";
         AV21Pgmname = "";
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
         lblLblorderby_Jsonclick = "";
         lblOrderby1_Jsonclick = "";
         lblOrderby2_Jsonclick = "";
         lblOrderby3_Jsonclick = "";
         lblOrderby4_Jsonclick = "";
         lblLblcorte1filter_Jsonclick = "";
         lblLblcorte2filter_Jsonclick = "";
         lblLblrfmfilter_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         A7Periodo = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00122_A23ComprasArticulos_AnioMovil = new long[1] ;
         H00122_n23ComprasArticulos_AnioMovil = new bool[] {false} ;
         H00122_A22ComprasImporte_AnioMovil = new decimal[1] ;
         H00122_n22ComprasImporte_AnioMovil = new bool[] {false} ;
         H00122_A21ComprasTickets_AnioMovil = new long[1] ;
         H00122_n21ComprasTickets_AnioMovil = new bool[] {false} ;
         H00122_A20AvgValorMonetario = new decimal[1] ;
         H00122_A19MaxValorMonetario = new decimal[1] ;
         H00122_A18MinValorMonetario = new decimal[1] ;
         H00122_A17AvgFrecuencia = new decimal[1] ;
         H00122_A16MaxFrecuencia = new decimal[1] ;
         H00122_A15MinFrecuencia = new decimal[1] ;
         H00122_A24AvgRecencia = new long[1] ;
         H00122_A14MaxRecencia = new long[1] ;
         H00122_A13MinRecencia = new long[1] ;
         H00122_A12ClientesDelMes = new long[1] ;
         H00122_A11ClientesDelAnio = new long[1] ;
         H00122_n11ClientesDelAnio = new bool[] {false} ;
         H00122_A10RFM = new int[1] ;
         H00122_A9Corte2 = new int[1] ;
         H00122_A8Corte1 = new int[1] ;
         H00122_A7Periodo = new String[] {""} ;
         H00123_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV7HTTPRequest = new GxHttpRequest( context);
         AV8GridState = new SdtGridState(context);
         AV6Session = context.GetSession();
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV11TrnContext = new SdtTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwresumenrfmglobal__default(),
            new Object[][] {
                new Object[] {
               H00122_A23ComprasArticulos_AnioMovil, H00122_n23ComprasArticulos_AnioMovil, H00122_A22ComprasImporte_AnioMovil, H00122_n22ComprasImporte_AnioMovil, H00122_A21ComprasTickets_AnioMovil, H00122_n21ComprasTickets_AnioMovil, H00122_A20AvgValorMonetario, H00122_A19MaxValorMonetario, H00122_A18MinValorMonetario, H00122_A17AvgFrecuencia,
               H00122_A16MaxFrecuencia, H00122_A15MinFrecuencia, H00122_A24AvgRecencia, H00122_A14MaxRecencia, H00122_A13MinRecencia, H00122_A12ClientesDelMes, H00122_A11ClientesDelAnio, H00122_n11ClientesDelAnio, H00122_A10RFM, H00122_A9Corte2,
               H00122_A8Corte1, H00122_A7Periodo
               }
               , new Object[] {
               H00123_AGRID_nRecordCount
               }
            }
         );
         AV21Pgmname = "WWResumenRFMGlobal";
         /* GeneXus formulas. */
         AV21Pgmname = "WWResumenRFMGlobal";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV13OrderedBy ;
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
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int subGrid_Rows ;
      private int AV15Corte1 ;
      private int AV16Corte2 ;
      private int AV17RFM ;
      private int edtavPeriodo_Enabled ;
      private int edtavCorte1_Enabled ;
      private int edtavCorte1_Visible ;
      private int edtavCorte2_Enabled ;
      private int edtavCorte2_Visible ;
      private int edtavRfm_Enabled ;
      private int edtavRfm_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A8Corte1 ;
      private int A9Corte2 ;
      private int A10RFM ;
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
      private long A11ClientesDelAnio ;
      private long A12ClientesDelMes ;
      private long A13MinRecencia ;
      private long A14MaxRecencia ;
      private long A24AvgRecencia ;
      private long A21ComprasTickets_AnioMovil ;
      private long A23ComprasArticulos_AnioMovil ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A15MinFrecuencia ;
      private decimal A16MaxFrecuencia ;
      private decimal A17AvgFrecuencia ;
      private decimal A18MinValorMonetario ;
      private decimal A19MaxValorMonetario ;
      private decimal A20AvgValorMonetario ;
      private decimal A22ComprasImporte_AnioMovil ;
      private String divFilterscontainer_Class ;
      private String divOrderbycontainer_Class ;
      private String divCorte1filtercontainer_Class ;
      private String divCorte2filtercontainer_Class ;
      private String divRfmfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_73_idx="0001" ;
      private String AV18ADVANCED_LABEL_TEMPLATE ;
      private String AV21Pgmname ;
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
      private String divOrderbycontainer_Internalname ;
      private String lblLblorderby_Internalname ;
      private String lblLblorderby_Caption ;
      private String lblLblorderby_Jsonclick ;
      private String divOrderbycontainer2_Internalname ;
      private String lblOrderby1_Internalname ;
      private String lblOrderby1_Jsonclick ;
      private String lblOrderby1_Class ;
      private String lblOrderby2_Internalname ;
      private String lblOrderby2_Jsonclick ;
      private String lblOrderby2_Class ;
      private String lblOrderby3_Internalname ;
      private String lblOrderby3_Jsonclick ;
      private String lblOrderby3_Class ;
      private String lblOrderby4_Internalname ;
      private String lblOrderby4_Jsonclick ;
      private String lblOrderby4_Class ;
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
      private String edtAvgRecencia_Internalname ;
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
      private String sGXsfl_73_fel_idx="0001" ;
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
      private bool n11ClientesDelAnio ;
      private bool n21ComprasTickets_AnioMovil ;
      private bool n22ComprasImporte_AnioMovil ;
      private bool n23ComprasArticulos_AnioMovil ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private String AV14Periodo ;
      private String A7Periodo ;
      private IGxSession AV6Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H00122_A23ComprasArticulos_AnioMovil ;
      private bool[] H00122_n23ComprasArticulos_AnioMovil ;
      private decimal[] H00122_A22ComprasImporte_AnioMovil ;
      private bool[] H00122_n22ComprasImporte_AnioMovil ;
      private long[] H00122_A21ComprasTickets_AnioMovil ;
      private bool[] H00122_n21ComprasTickets_AnioMovil ;
      private decimal[] H00122_A20AvgValorMonetario ;
      private decimal[] H00122_A19MaxValorMonetario ;
      private decimal[] H00122_A18MinValorMonetario ;
      private decimal[] H00122_A17AvgFrecuencia ;
      private decimal[] H00122_A16MaxFrecuencia ;
      private decimal[] H00122_A15MinFrecuencia ;
      private long[] H00122_A24AvgRecencia ;
      private long[] H00122_A14MaxRecencia ;
      private long[] H00122_A13MinRecencia ;
      private long[] H00122_A12ClientesDelMes ;
      private long[] H00122_A11ClientesDelAnio ;
      private bool[] H00122_n11ClientesDelAnio ;
      private int[] H00122_A10RFM ;
      private int[] H00122_A9Corte2 ;
      private int[] H00122_A8Corte1 ;
      private String[] H00122_A7Periodo ;
      private long[] H00123_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private SdtGridState AV8GridState ;
      private SdtGridState_FilterValue AV9GridStateFilterValue ;
      private SdtTransactionContext AV11TrnContext ;
   }

   public class wwresumenrfmglobal__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00122( IGxContext context ,
                                             String AV14Periodo ,
                                             int AV15Corte1 ,
                                             int AV16Corte2 ,
                                             int AV17RFM ,
                                             String A7Periodo ,
                                             int A8Corte1 ,
                                             int A9Corte2 ,
                                             int A10RFM ,
                                             short AV13OrderedBy )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [7] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [ComprasArticulos_AnioMovil], [ComprasImporte_AnioMovil], [ComprasTickets_AnioMovil], [AvgValorMonetario], [MaxValorMonetario], [MinValorMonetario], [AvgFrecuencia], [MaxFrecuencia], [MinFrecuencia], [AvgRecencia], [MaxRecencia], [MinRecencia], [ClientesDelMes], [ClientesDelAnio], [RFM], [Corte2], [Corte1], [Periodo]";
         sFromString = " FROM [ResumenRFMGlobal]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Periodo)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Periodo] >= @AV14Periodo)";
            }
            else
            {
               sWhereString = sWhereString + " ([Periodo] >= @AV14Periodo)";
            }
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV15Corte1) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Corte1] >= @AV15Corte1)";
            }
            else
            {
               sWhereString = sWhereString + " ([Corte1] >= @AV15Corte1)";
            }
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV16Corte2) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Corte2] >= @AV16Corte2)";
            }
            else
            {
               sWhereString = sWhereString + " ([Corte2] >= @AV16Corte2)";
            }
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV17RFM) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([RFM] >= @AV17RFM)";
            }
            else
            {
               sWhereString = sWhereString + " ([RFM] >= @AV17RFM)";
            }
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            sWhereString = " WHERE" + sWhereString;
         }
         if ( AV13OrderedBy == 1 )
         {
            sOrderString = sOrderString + " ORDER BY [Periodo]";
         }
         else if ( AV13OrderedBy == 2 )
         {
            sOrderString = sOrderString + " ORDER BY [Corte1]";
         }
         else if ( AV13OrderedBy == 3 )
         {
            sOrderString = sOrderString + " ORDER BY [Corte2]";
         }
         else if ( AV13OrderedBy == 4 )
         {
            sOrderString = sOrderString + " ORDER BY [RFM]";
         }
         else if ( true )
         {
            sOrderString = sOrderString + " ORDER BY [Periodo]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00123( IGxContext context ,
                                             String AV14Periodo ,
                                             int AV15Corte1 ,
                                             int AV16Corte2 ,
                                             int AV17RFM ,
                                             String A7Periodo ,
                                             int A8Corte1 ,
                                             int A9Corte2 ,
                                             int A10RFM ,
                                             short AV13OrderedBy )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [4] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM [ResumenRFMGlobal]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14Periodo)) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Periodo] >= @AV14Periodo)";
            }
            else
            {
               sWhereString = sWhereString + " ([Periodo] >= @AV14Periodo)";
            }
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV15Corte1) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Corte1] >= @AV15Corte1)";
            }
            else
            {
               sWhereString = sWhereString + " ([Corte1] >= @AV15Corte1)";
            }
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV16Corte2) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Corte2] >= @AV16Corte2)";
            }
            else
            {
               sWhereString = sWhereString + " ([Corte2] >= @AV16Corte2)";
            }
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV17RFM) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([RFM] >= @AV17RFM)";
            }
            else
            {
               sWhereString = sWhereString + " ([RFM] >= @AV17RFM)";
            }
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp("", sWhereString) != 0 )
         {
            scmdbuf = scmdbuf + " WHERE" + sWhereString;
         }
         if ( AV13OrderedBy == 1 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV13OrderedBy == 2 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV13OrderedBy == 3 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( AV13OrderedBy == 4 )
         {
            scmdbuf = scmdbuf + "";
         }
         else if ( true )
         {
            scmdbuf = scmdbuf + "";
         }
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
                     return conditional_H00122(context, (String)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (String)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00123(context, (String)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (String)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmH00122 ;
          prmH00122 = new Object[] {
          new Object[] {"@AV14Periodo",SqlDbType.VarChar,6,0} ,
          new Object[] {"@AV15Corte1",SqlDbType.Int,8,0} ,
          new Object[] {"@AV16Corte2",SqlDbType.Int,8,0} ,
          new Object[] {"@AV17RFM",SqlDbType.Int,8,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00123 ;
          prmH00123 = new Object[] {
          new Object[] {"@AV14Periodo",SqlDbType.VarChar,6,0} ,
          new Object[] {"@AV15Corte1",SqlDbType.Int,8,0} ,
          new Object[] {"@AV16Corte2",SqlDbType.Int,8,0} ,
          new Object[] {"@AV17RFM",SqlDbType.Int,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00122", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00122,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00123", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00123,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4) ;
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5) ;
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6) ;
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7) ;
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8) ;
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9) ;
                ((long[]) buf[12])[0] = rslt.getLong(10) ;
                ((long[]) buf[13])[0] = rslt.getLong(11) ;
                ((long[]) buf[14])[0] = rslt.getLong(12) ;
                ((long[]) buf[15])[0] = rslt.getLong(13) ;
                ((long[]) buf[16])[0] = rslt.getLong(14) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(14);
                ((int[]) buf[18])[0] = rslt.getInt(15) ;
                ((int[]) buf[19])[0] = rslt.getInt(16) ;
                ((int[]) buf[20])[0] = rslt.getInt(17) ;
                ((String[]) buf[21])[0] = rslt.getVarchar(18) ;
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
                   stmt.SetParameter(sIdx, (int)parms[11]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[12]);
                }
                if ( (short)parms[6] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[13]);
                }
                return;
             case 1 :
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
       }
    }

 }

}
