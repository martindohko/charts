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
   public class wwtresumenrfm : GXDataArea
   {
      public wwtresumenrfm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwtresumenrfm( IGxContext context )
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
               AV17Region = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV18Sucursal = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV13RFMAnt = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV19RFMAct = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV16ADVANCED_LABEL_TEMPLATE = GetNextPar( );
               AV22Pgmname = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, AV16ADVANCED_LABEL_TEMPLATE, AV22Pgmname) ;
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
         PA0D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202099155133", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwtresumenrfm.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vREGION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Region), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSUCURSAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Sucursal), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRFMANT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13RFMAnt), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vRFMACT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RFMAct), 8, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_55", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_55), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV16ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUCURSALFILTERCONTAINER_Class", StringUtil.RTrim( divSucursalfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFMANTFILTERCONTAINER_Class", StringUtil.RTrim( divRfmantfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RFMACTFILTERCONTAINER_Class", StringUtil.RTrim( divRfmactfiltercontainer_Class));
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
            WE0D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0D2( ) ;
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
         return formatLink("wwtresumenrfm.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "WWtResumenRFM" ;
      }

      public override String GetPgmdesc( )
      {
         return "t Resumen RFMs" ;
      }

      protected void WB0D0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110d1_client"+"'", TempTags, "", 2, "HLP_WWtResumenRFM.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "t Resumen RFMs", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SubTitle", 0, "", 1, 1, 0, "HLP_WWtResumenRFM.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-5 col-sm-push-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRegion_Internalname, "Region", "col-sm-3 FilterSearchAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRegion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Region), 4, 0, ".", "")), ((edtavRegion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Region), "ZZZ9")) : context.localUtil.Format( (decimal)(AV17Region), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Region", edtavRegion_Jsonclick, 0, "FilterSearchAttribute", "", "", "", "", 1, edtavRegion_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWtResumenRFM.htm");
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
            GxWebStd.gx_div_start( context, divSucursalfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSucursalfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsucursalfilter_Internalname, lblLblsucursalfilter_Caption, "", "", lblLblsucursalfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWtResumenRFM.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSucursal_Internalname, "Sucursal", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Sucursal), 4, 0, ".", "")), ((edtavSucursal_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18Sucursal), "ZZZ9")) : context.localUtil.Format( (decimal)(AV18Sucursal), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSucursal_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavSucursal_Visible, edtavSucursal_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWtResumenRFM.htm");
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
            GxWebStd.gx_div_start( context, divRfmantfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRfmantfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrfmantfilter_Internalname, lblLblrfmantfilter_Caption, "", "", lblLblrfmantfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWtResumenRFM.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRfmant_Internalname, "RFMAnt", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRfmant_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13RFMAnt), 8, 0, ".", "")), ((edtavRfmant_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13RFMAnt), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV13RFMAnt), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRfmant_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavRfmant_Visible, edtavRfmant_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWtResumenRFM.htm");
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
            GxWebStd.gx_div_start( context, divRfmactfiltercontainer_Internalname, 1, 0, "px", 0, "px", divRfmactfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblrfmactfilter_Internalname, lblLblrfmactfilter_Caption, "", "", lblLblrfmactfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_WWtResumenRFM.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRfmact_Internalname, "RFMAct", "col-sm-3 FilterComboAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_55_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRfmact_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RFMAct), 8, 0, ".", "")), ((edtavRfmact_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19RFMAct), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV19RFMAct), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRfmact_Jsonclick, 0, "FilterComboAttribute", "", "", "", "", edtavRfmact_Visible, edtavRfmact_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWtResumenRFM.htm");
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
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Region") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Sucursal") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RFMAnt") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RFMAct") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Clientes") ;
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
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Region), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2Sucursal), 4, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3RFMAnt), 8, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4RFMAct), 8, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5Clientes), 8, 0, ".", "")));
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

      protected void START0D2( )
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
            Form.Meta.addItem("description", "t Resumen RFMs", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0D0( ) ;
      }

      protected void WS0D2( )
      {
         START0D2( ) ;
         EVT0D2( ) ;
      }

      protected void EVT0D2( )
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
                              A1Region = (short)(context.localUtil.CToN( cgiGet( edtRegion_Internalname), ".", ","));
                              A2Sucursal = (short)(context.localUtil.CToN( cgiGet( edtSucursal_Internalname), ".", ","));
                              A3RFMAnt = (int)(context.localUtil.CToN( cgiGet( edtRFMAnt_Internalname), ".", ","));
                              n3RFMAnt = false;
                              A4RFMAct = (int)(context.localUtil.CToN( cgiGet( edtRFMAct_Internalname), ".", ","));
                              n4RFMAct = false;
                              A5Clientes = (int)(context.localUtil.CToN( cgiGet( edtClientes_Internalname), ".", ","));
                              n5Clientes = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E150D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E160D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E170D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Region Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vREGION"), ".", ",") != Convert.ToDecimal( AV17Region )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sucursal Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUCURSAL"), ".", ",") != Convert.ToDecimal( AV18Sucursal )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rfmant Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vRFMANT"), ".", ",") != Convert.ToDecimal( AV13RFMAnt )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Rfmact Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vRFMACT"), ".", ",") != Convert.ToDecimal( AV19RFMAct )) )
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

      protected void WE0D2( )
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

      protected void PA0D2( )
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
               GX_FocusControl = edtavRegion_Internalname;
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
                                       short AV17Region ,
                                       short AV18Sucursal ,
                                       int AV13RFMAnt ,
                                       int AV19RFMAct ,
                                       String AV16ADVANCED_LABEL_TEMPLATE ,
                                       String AV22Pgmname )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E160D2 ();
         GRID_nCurrentRecord = 0;
         RF0D2( ) ;
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
         RF0D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV22Pgmname = "WWtResumenRFM";
         context.Gx_err = 0;
      }

      protected void RF0D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 55;
         /* Execute user event: Refresh */
         E160D2 ();
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
                                                 AV17Region ,
                                                 AV18Sucursal ,
                                                 AV13RFMAnt ,
                                                 AV19RFMAct ,
                                                 A1Region ,
                                                 A2Sucursal ,
                                                 A3RFMAnt ,
                                                 A4RFMAct } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            } ) ;
            /* Using cursor H000D2 */
            pr_default.execute(0, new Object[] {AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_55_idx = 1;
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_552( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A5Clientes = H000D2_A5Clientes[0];
               n5Clientes = H000D2_n5Clientes[0];
               A4RFMAct = H000D2_A4RFMAct[0];
               n4RFMAct = H000D2_n4RFMAct[0];
               A3RFMAnt = H000D2_A3RFMAnt[0];
               n3RFMAnt = H000D2_n3RFMAnt[0];
               A2Sucursal = H000D2_A2Sucursal[0];
               A1Region = H000D2_A1Region[0];
               E170D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 55;
            WB0D0( ) ;
         }
         bGXsfl_55_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0D2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV16ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22Pgmname, "")), context));
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
                                              AV17Region ,
                                              AV18Sucursal ,
                                              AV13RFMAnt ,
                                              AV19RFMAct ,
                                              A1Region ,
                                              A2Sucursal ,
                                              A3RFMAnt ,
                                              A4RFMAct } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         } ) ;
         /* Using cursor H000D3 */
         pr_default.execute(1, new Object[] {AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct});
         GRID_nRecordCount = H000D3_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, AV16ADVANCED_LABEL_TEMPLATE, AV22Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, AV16ADVANCED_LABEL_TEMPLATE, AV22Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, AV16ADVANCED_LABEL_TEMPLATE, AV22Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, AV16ADVANCED_LABEL_TEMPLATE, AV22Pgmname) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV17Region, AV18Sucursal, AV13RFMAnt, AV19RFMAct, AV16ADVANCED_LABEL_TEMPLATE, AV22Pgmname) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV22Pgmname = "WWtResumenRFM";
         context.Gx_err = 0;
      }

      protected void STRUP0D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E150D2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRegion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRegion_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREGION");
               GX_FocusControl = edtavRegion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17Region = 0;
               AssignAttri("", false, "AV17Region", StringUtil.LTrimStr( (decimal)(AV17Region), 4, 0));
            }
            else
            {
               AV17Region = (short)(context.localUtil.CToN( cgiGet( edtavRegion_Internalname), ".", ","));
               AssignAttri("", false, "AV17Region", StringUtil.LTrimStr( (decimal)(AV17Region), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSucursal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSucursal_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSUCURSAL");
               GX_FocusControl = edtavSucursal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18Sucursal = 0;
               AssignAttri("", false, "AV18Sucursal", StringUtil.LTrimStr( (decimal)(AV18Sucursal), 4, 0));
            }
            else
            {
               AV18Sucursal = (short)(context.localUtil.CToN( cgiGet( edtavSucursal_Internalname), ".", ","));
               AssignAttri("", false, "AV18Sucursal", StringUtil.LTrimStr( (decimal)(AV18Sucursal), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRfmant_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRfmant_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRFMANT");
               GX_FocusControl = edtavRfmant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13RFMAnt = 0;
               AssignAttri("", false, "AV13RFMAnt", StringUtil.LTrimStr( (decimal)(AV13RFMAnt), 8, 0));
            }
            else
            {
               AV13RFMAnt = (int)(context.localUtil.CToN( cgiGet( edtavRfmant_Internalname), ".", ","));
               AssignAttri("", false, "AV13RFMAnt", StringUtil.LTrimStr( (decimal)(AV13RFMAnt), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRfmact_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRfmact_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRFMACT");
               GX_FocusControl = edtavRfmact_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19RFMAct = 0;
               AssignAttri("", false, "AV19RFMAct", StringUtil.LTrimStr( (decimal)(AV19RFMAct), 8, 0));
            }
            else
            {
               AV19RFMAct = (int)(context.localUtil.CToN( cgiGet( edtavRfmact_Internalname), ".", ","));
               AssignAttri("", false, "AV19RFMAct", StringUtil.LTrimStr( (decimal)(AV19RFMAct), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vREGION"), ".", ",") != Convert.ToDecimal( AV17Region )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUCURSAL"), ".", ",") != Convert.ToDecimal( AV18Sucursal )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vRFMANT"), ".", ",") != Convert.ToDecimal( AV13RFMAnt )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vRFMACT"), ".", ",") != Convert.ToDecimal( AV19RFMAct )) )
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
         E150D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E150D2( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV22Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV22Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         edtavSucursal_Visible = 0;
         AssignProp("", false, edtavSucursal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSucursal_Visible), 5, 0), true);
         edtavRfmant_Visible = 0;
         AssignProp("", false, edtavRfmant_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRfmant_Visible), 5, 0), true);
         edtavRfmact_Visible = 0;
         AssignProp("", false, edtavRfmact_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavRfmact_Visible), 5, 0), true);
         Form.Caption = "t Resumen RFMs";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV16ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV16ADVANCED_LABEL_TEMPLATE", AV16ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
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

      protected void E160D2( )
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
         if ( (0==AV18Sucursal) )
         {
            lblLblsucursalfilter_Caption = "Sucursal";
            AssignProp("", false, lblLblsucursalfilter_Internalname, "Caption", lblLblsucursalfilter_Caption, true);
         }
         else
         {
            lblLblsucursalfilter_Caption = StringUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "Sucursal", StringUtil.LTrimStr( (decimal)(AV18Sucursal), 4, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblsucursalfilter_Internalname, "Caption", lblLblsucursalfilter_Caption, true);
         }
         if ( (0==AV13RFMAnt) )
         {
            lblLblrfmantfilter_Caption = "RFMAnt";
            AssignProp("", false, lblLblrfmantfilter_Internalname, "Caption", lblLblrfmantfilter_Caption, true);
         }
         else
         {
            lblLblrfmantfilter_Caption = StringUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "RFMAnt", StringUtil.LTrimStr( (decimal)(AV13RFMAnt), 8, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblrfmantfilter_Internalname, "Caption", lblLblrfmantfilter_Caption, true);
         }
         if ( (0==AV19RFMAct) )
         {
            lblLblrfmactfilter_Caption = "RFMAct";
            AssignProp("", false, lblLblrfmactfilter_Internalname, "Caption", lblLblrfmactfilter_Caption, true);
         }
         else
         {
            lblLblrfmactfilter_Caption = StringUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "RFMAct", StringUtil.LTrimStr( (decimal)(AV19RFMAct), 8, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblrfmactfilter_Internalname, "Caption", lblLblrfmactfilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E170D2( )
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
            AV8GridState.FromXml(AV6Session.Get(AV22Pgmname+"GridState"), null, "GridState", "RFM");
            if ( AV8GridState.gxTpr_Filtervalues.Count >= 4 )
            {
               AV17Region = (short)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(1)).gxTpr_Value, "."));
               AssignAttri("", false, "AV17Region", StringUtil.LTrimStr( (decimal)(AV17Region), 4, 0));
               AV18Sucursal = (short)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(2)).gxTpr_Value, "."));
               AssignAttri("", false, "AV18Sucursal", StringUtil.LTrimStr( (decimal)(AV18Sucursal), 4, 0));
               AV13RFMAnt = (int)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(3)).gxTpr_Value, "."));
               AssignAttri("", false, "AV13RFMAnt", StringUtil.LTrimStr( (decimal)(AV13RFMAnt), 8, 0));
               AV19RFMAct = (int)(NumberUtil.Val( ((SdtGridState_FilterValue)AV8GridState.gxTpr_Filtervalues.Item(4)).gxTpr_Value, "."));
               AssignAttri("", false, "AV19RFMAct", StringUtil.LTrimStr( (decimal)(AV19RFMAct), 8, 0));
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
         AV8GridState.FromXml(AV6Session.Get(AV22Pgmname+"GridState"), null, "GridState", "RFM");
         AV8GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         AV8GridState.gxTpr_Filtervalues.Clear();
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV17Region), 4, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV18Sucursal), 4, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV13RFMAnt), 8, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV9GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV19RFMAct), 8, 0);
         AV8GridState.gxTpr_Filtervalues.Add(AV9GridStateFilterValue, 0);
         AV6Session.Set(AV22Pgmname+"GridState", AV8GridState.ToXml(false, true, "GridState", "RFM"));
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         AV11TrnContext = new SdtTransactionContext(context);
         AV11TrnContext.gxTpr_Callerobject = AV22Pgmname;
         AV11TrnContext.gxTpr_Callerondelete = true;
         AV11TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV11TrnContext.gxTpr_Transactionname = "tResumenRFM";
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
         PA0D2( ) ;
         WS0D2( ) ;
         WE0D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202099155178", true, true);
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
         context.AddJavascriptSource("wwtresumenrfm.js", "?202099155178", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_552( )
      {
         edtRegion_Internalname = "REGION_"+sGXsfl_55_idx;
         edtSucursal_Internalname = "SUCURSAL_"+sGXsfl_55_idx;
         edtRFMAnt_Internalname = "RFMANT_"+sGXsfl_55_idx;
         edtRFMAct_Internalname = "RFMACT_"+sGXsfl_55_idx;
         edtClientes_Internalname = "CLIENTES_"+sGXsfl_55_idx;
      }

      protected void SubsflControlProps_fel_552( )
      {
         edtRegion_Internalname = "REGION_"+sGXsfl_55_fel_idx;
         edtSucursal_Internalname = "SUCURSAL_"+sGXsfl_55_fel_idx;
         edtRFMAnt_Internalname = "RFMANT_"+sGXsfl_55_fel_idx;
         edtRFMAct_Internalname = "RFMACT_"+sGXsfl_55_fel_idx;
         edtClientes_Internalname = "CLIENTES_"+sGXsfl_55_fel_idx;
      }

      protected void sendrow_552( )
      {
         SubsflControlProps_552( ) ;
         WB0D0( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRegion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Region), 4, 0, ".", "")),context.localUtil.Format( (decimal)(A1Region), "ZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRegion_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtSucursal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A2Sucursal), 4, 0, ".", "")),context.localUtil.Format( (decimal)(A2Sucursal), "ZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtSucursal_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)4,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRFMAnt_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A3RFMAnt), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A3RFMAnt), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRFMAnt_Jsonclick,(short)0,(String)"DescriptionAttribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtRFMAct_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4RFMAct), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A4RFMAct), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtRFMAct_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtClientes_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A5Clientes), 8, 0, ".", "")),context.localUtil.Format( (decimal)(A5Clientes), "ZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtClientes_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn WWOptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)8,(short)0,(short)0,(short)55,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes0D2( ) ;
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
         edtavRegion_Internalname = "vREGION";
         divTabletop_Internalname = "TABLETOP";
         lblLblsucursalfilter_Internalname = "LBLSUCURSALFILTER";
         edtavSucursal_Internalname = "vSUCURSAL";
         divSucursalfiltercontainer_Internalname = "SUCURSALFILTERCONTAINER";
         lblLblrfmantfilter_Internalname = "LBLRFMANTFILTER";
         edtavRfmant_Internalname = "vRFMANT";
         divRfmantfiltercontainer_Internalname = "RFMANTFILTERCONTAINER";
         lblLblrfmactfilter_Internalname = "LBLRFMACTFILTER";
         edtavRfmact_Internalname = "vRFMACT";
         divRfmactfiltercontainer_Internalname = "RFMACTFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         edtRegion_Internalname = "REGION";
         edtSucursal_Internalname = "SUCURSAL";
         edtRFMAnt_Internalname = "RFMANT";
         edtRFMAct_Internalname = "RFMACT";
         edtClientes_Internalname = "CLIENTES";
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
         edtClientes_Jsonclick = "";
         edtRFMAct_Jsonclick = "";
         edtRFMAnt_Jsonclick = "";
         edtSucursal_Jsonclick = "";
         edtRegion_Jsonclick = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 WWGridCell";
         edtavRfmact_Jsonclick = "";
         edtavRfmact_Enabled = 1;
         edtavRfmact_Visible = 1;
         lblLblrfmactfilter_Caption = "RFMAct";
         edtavRfmant_Jsonclick = "";
         edtavRfmant_Enabled = 1;
         edtavRfmant_Visible = 1;
         lblLblrfmantfilter_Caption = "RFMAnt";
         edtavSucursal_Jsonclick = "";
         edtavSucursal_Enabled = 1;
         edtavSucursal_Visible = 1;
         lblLblsucursalfilter_Caption = "Sucursal";
         edtavRegion_Jsonclick = "";
         edtavRegion_Enabled = 1;
         bttBtntoggle_Class = "HideFiltersButton";
         bttBtntoggle_Caption = "Hide Filters";
         divRfmactfiltercontainer_Class = "AdvancedContainerItem";
         divRfmantfiltercontainer_Class = "AdvancedContainerItem";
         divSucursalfiltercontainer_Class = "AdvancedContainerItem";
         divFilterscontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "t Resumen RFMs";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblsucursalfilter_Caption',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'lblLblrfmantfilter_Caption',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'lblLblrfmactfilter_Caption',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E110D1',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'}]}");
         setEventMetadata("LBLSUCURSALFILTER.CLICK","{handler:'E120D1',iparms:[{av:'divSucursalfiltercontainer_Class',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSUCURSALFILTER.CLICK",",oparms:[{av:'divSucursalfiltercontainer_Class',ctrl:'SUCURSALFILTERCONTAINER',prop:'Class'},{av:'edtavSucursal_Visible',ctrl:'vSUCURSAL',prop:'Visible'}]}");
         setEventMetadata("LBLRFMANTFILTER.CLICK","{handler:'E130D1',iparms:[{av:'divRfmantfiltercontainer_Class',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFMANTFILTER.CLICK",",oparms:[{av:'divRfmantfiltercontainer_Class',ctrl:'RFMANTFILTERCONTAINER',prop:'Class'},{av:'edtavRfmant_Visible',ctrl:'vRFMANT',prop:'Visible'}]}");
         setEventMetadata("LBLRFMACTFILTER.CLICK","{handler:'E140D1',iparms:[{av:'divRfmactfiltercontainer_Class',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLRFMACTFILTER.CLICK",",oparms:[{av:'divRfmactfiltercontainer_Class',ctrl:'RFMACTFILTERCONTAINER',prop:'Class'},{av:'edtavRfmact_Visible',ctrl:'vRFMACT',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E170D2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblsucursalfilter_Caption',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'lblLblrfmantfilter_Caption',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'lblLblrfmactfilter_Caption',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblsucursalfilter_Caption',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'lblLblrfmantfilter_Caption',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'lblLblrfmactfilter_Caption',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblsucursalfilter_Caption',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'lblLblrfmantfilter_Caption',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'lblLblrfmactfilter_Caption',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18Sucursal',fld:'vSUCURSAL',pic:'ZZZ9'},{av:'AV16ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV13RFMAnt',fld:'vRFMANT',pic:'ZZZZZZZ9'},{av:'AV19RFMAct',fld:'vRFMACT',pic:'ZZZZZZZ9'},{av:'AV22Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV17Region',fld:'vREGION',pic:'ZZZ9'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblsucursalfilter_Caption',ctrl:'LBLSUCURSALFILTER',prop:'Caption'},{av:'lblLblrfmantfilter_Caption',ctrl:'LBLRFMANTFILTER',prop:'Caption'},{av:'lblLblrfmactfilter_Caption',ctrl:'LBLRFMACTFILTER',prop:'Caption'}]}");
         setEventMetadata("NULL","{handler:'Valid_Clientes',iparms:[]");
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
         AV16ADVANCED_LABEL_TEMPLATE = "";
         AV22Pgmname = "";
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
         lblLblsucursalfilter_Jsonclick = "";
         lblLblrfmantfilter_Jsonclick = "";
         lblLblrfmactfilter_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000D2_A5Clientes = new int[1] ;
         H000D2_n5Clientes = new bool[] {false} ;
         H000D2_A4RFMAct = new int[1] ;
         H000D2_n4RFMAct = new bool[] {false} ;
         H000D2_A3RFMAnt = new int[1] ;
         H000D2_n3RFMAnt = new bool[] {false} ;
         H000D2_A2Sucursal = new short[1] ;
         H000D2_A1Region = new short[1] ;
         H000D3_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV7HTTPRequest = new GxHttpRequest( context);
         AV8GridState = new SdtGridState(context);
         AV6Session = context.GetSession();
         AV9GridStateFilterValue = new SdtGridState_FilterValue(context);
         AV11TrnContext = new SdtTransactionContext(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwtresumenrfm__default(),
            new Object[][] {
                new Object[] {
               H000D2_A5Clientes, H000D2_n5Clientes, H000D2_A4RFMAct, H000D2_n4RFMAct, H000D2_A3RFMAnt, H000D2_n3RFMAnt, H000D2_A2Sucursal, H000D2_A1Region
               }
               , new Object[] {
               H000D3_AGRID_nRecordCount
               }
            }
         );
         AV22Pgmname = "WWtResumenRFM";
         /* GeneXus formulas. */
         AV22Pgmname = "WWtResumenRFM";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV17Region ;
      private short AV18Sucursal ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Titlebackstyle ;
      private short A1Region ;
      private short A2Sucursal ;
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
      private int AV13RFMAnt ;
      private int AV19RFMAct ;
      private int edtavRegion_Enabled ;
      private int edtavSucursal_Enabled ;
      private int edtavSucursal_Visible ;
      private int edtavRfmant_Enabled ;
      private int edtavRfmant_Visible ;
      private int edtavRfmact_Enabled ;
      private int edtavRfmact_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int A3RFMAnt ;
      private int A4RFMAct ;
      private int A5Clientes ;
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
      private String divSucursalfiltercontainer_Class ;
      private String divRfmantfiltercontainer_Class ;
      private String divRfmactfiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_55_idx="0001" ;
      private String AV16ADVANCED_LABEL_TEMPLATE ;
      private String AV22Pgmname ;
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
      private String edtavRegion_Internalname ;
      private String edtavRegion_Jsonclick ;
      private String divFilterscontainer_Internalname ;
      private String divSucursalfiltercontainer_Internalname ;
      private String lblLblsucursalfilter_Internalname ;
      private String lblLblsucursalfilter_Caption ;
      private String lblLblsucursalfilter_Jsonclick ;
      private String edtavSucursal_Internalname ;
      private String edtavSucursal_Jsonclick ;
      private String divRfmantfiltercontainer_Internalname ;
      private String lblLblrfmantfilter_Internalname ;
      private String lblLblrfmantfilter_Caption ;
      private String lblLblrfmantfilter_Jsonclick ;
      private String edtavRfmant_Internalname ;
      private String edtavRfmant_Jsonclick ;
      private String divRfmactfiltercontainer_Internalname ;
      private String lblLblrfmactfilter_Internalname ;
      private String lblLblrfmactfilter_Caption ;
      private String lblLblrfmactfilter_Jsonclick ;
      private String edtavRfmact_Internalname ;
      private String edtavRfmact_Jsonclick ;
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
      private String edtRegion_Internalname ;
      private String edtSucursal_Internalname ;
      private String edtRFMAnt_Internalname ;
      private String edtRFMAct_Internalname ;
      private String edtClientes_Internalname ;
      private String scmdbuf ;
      private String sGXsfl_55_fel_idx="0001" ;
      private String ROClassString ;
      private String edtRegion_Jsonclick ;
      private String edtSucursal_Jsonclick ;
      private String edtRFMAnt_Jsonclick ;
      private String edtRFMAct_Jsonclick ;
      private String edtClientes_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n3RFMAnt ;
      private bool n4RFMAct ;
      private bool n5Clientes ;
      private bool bGXsfl_55_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private IGxSession AV6Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H000D2_A5Clientes ;
      private bool[] H000D2_n5Clientes ;
      private int[] H000D2_A4RFMAct ;
      private bool[] H000D2_n4RFMAct ;
      private int[] H000D2_A3RFMAnt ;
      private bool[] H000D2_n3RFMAnt ;
      private short[] H000D2_A2Sucursal ;
      private short[] H000D2_A1Region ;
      private long[] H000D3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GXWebForm Form ;
      private SdtGridState AV8GridState ;
      private SdtGridState_FilterValue AV9GridStateFilterValue ;
      private SdtTransactionContext AV11TrnContext ;
   }

   public class wwtresumenrfm__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000D2( IGxContext context ,
                                             short AV17Region ,
                                             short AV18Sucursal ,
                                             int AV13RFMAnt ,
                                             int AV19RFMAct ,
                                             short A1Region ,
                                             short A2Sucursal ,
                                             int A3RFMAnt ,
                                             int A4RFMAct )
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
         sSelectString = " [Clientes], [RFMAct], [RFMAnt], [Sucursal], [Region]";
         sFromString = " FROM [tResumenRFM]";
         sOrderString = "";
         if ( ! (0==AV17Region) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Region] = @AV17Region)";
            }
            else
            {
               sWhereString = sWhereString + " ([Region] = @AV17Region)";
            }
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV18Sucursal) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Sucursal] = @AV18Sucursal)";
            }
            else
            {
               sWhereString = sWhereString + " ([Sucursal] = @AV18Sucursal)";
            }
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV13RFMAnt) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([RFMAnt] = @AV13RFMAnt)";
            }
            else
            {
               sWhereString = sWhereString + " ([RFMAnt] = @AV13RFMAnt)";
            }
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV19RFMAct) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([RFMAct] = @AV19RFMAct)";
            }
            else
            {
               sWhereString = sWhereString + " ([RFMAct] = @AV19RFMAct)";
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
         sOrderString = sOrderString + " ORDER BY [RFMAnt]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000D3( IGxContext context ,
                                             short AV17Region ,
                                             short AV18Sucursal ,
                                             int AV13RFMAnt ,
                                             int AV19RFMAct ,
                                             short A1Region ,
                                             short A2Sucursal ,
                                             int A3RFMAnt ,
                                             int A4RFMAct )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [4] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM [tResumenRFM]";
         if ( ! (0==AV17Region) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Region] = @AV17Region)";
            }
            else
            {
               sWhereString = sWhereString + " ([Region] = @AV17Region)";
            }
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV18Sucursal) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([Sucursal] = @AV18Sucursal)";
            }
            else
            {
               sWhereString = sWhereString + " ([Sucursal] = @AV18Sucursal)";
            }
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV13RFMAnt) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([RFMAnt] = @AV13RFMAnt)";
            }
            else
            {
               sWhereString = sWhereString + " ([RFMAnt] = @AV13RFMAnt)";
            }
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV19RFMAct) )
         {
            if ( StringUtil.StrCmp("", sWhereString) != 0 )
            {
               sWhereString = sWhereString + " and ([RFMAct] = @AV19RFMAct)";
            }
            else
            {
               sWhereString = sWhereString + " ([RFMAct] = @AV19RFMAct)";
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
                     return conditional_H000D2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
               case 1 :
                     return conditional_H000D3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
          Object[] prmH000D2 ;
          prmH000D2 = new Object[] {
          new Object[] {"@AV17Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@AV18Sucursal",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@AV13RFMAnt",SqlDbType.Int,8,0} ,
          new Object[] {"@AV19RFMAct",SqlDbType.Int,8,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH000D3 ;
          prmH000D3 = new Object[] {
          new Object[] {"@AV17Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@AV18Sucursal",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@AV13RFMAnt",SqlDbType.Int,8,0} ,
          new Object[] {"@AV19RFMAct",SqlDbType.Int,8,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H000D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4) ;
                ((short[]) buf[7])[0] = rslt.getShort(5) ;
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
                   stmt.SetParameter(sIdx, (short)parms[7]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[8]);
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
                   stmt.SetParameter(sIdx, (short)parms[4]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (short)parms[5]);
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
