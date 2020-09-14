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
   public class resumenrfmglobal : GXHttpHandler
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7Periodo = GetNextPar( );
               AssignAttri("", false, "AV7Periodo", AV7Periodo);
               GxWebStd.gx_hidden_field( context, "gxhash_vPERIODO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Periodo, "")), context));
            }
         }
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Core 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Resumen RFMGlobal", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtPeriodo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public resumenrfmglobal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public resumenrfmglobal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( String aP0_Gx_mode ,
                           String aP1_Periodo )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Periodo = aP1_Periodo;
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
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
            RenderHtmlCloseForm073( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Resumen RFMGlobal", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPeriodo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPeriodo_Internalname, "Periodo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPeriodo_Internalname, A7Periodo, StringUtil.RTrim( context.localUtil.Format( A7Periodo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPeriodo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPeriodo_Enabled, 1, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorte1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorte1_Internalname, "Corte1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorte1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8Corte1), 8, 0, ".", "")), ((edtCorte1_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A8Corte1), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A8Corte1), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorte1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorte1_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorte2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorte2_Internalname, "Corte2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorte2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9Corte2), 8, 0, ".", "")), ((edtCorte2_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A9Corte2), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A9Corte2), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorte2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorte2_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFM_Internalname, "RFM", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFM_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10RFM), 8, 0, ".", "")), ((edtRFM_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A10RFM), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A10RFM), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFM_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClientesDelAnio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesDelAnio_Internalname, "Del Anio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesDelAnio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11ClientesDelAnio), 10, 0, ".", "")), ((edtClientesDelAnio_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11ClientesDelAnio), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A11ClientesDelAnio), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesDelAnio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesDelAnio_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClientesDelMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientesDelMes_Internalname, "Del Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientesDelMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ClientesDelMes), 10, 0, ".", "")), ((edtClientesDelMes_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A12ClientesDelMes), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A12ClientesDelMes), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesDelMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesDelMes_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMinRecencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMinRecencia_Internalname, "Recencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMinRecencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MinRecencia), 10, 0, ".", "")), ((edtMinRecencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A13MinRecencia), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A13MinRecencia), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMinRecencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMinRecencia_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMaxRecencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMaxRecencia_Internalname, "Recencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMaxRecencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14MaxRecencia), 10, 0, ".", "")), ((edtMaxRecencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A14MaxRecencia), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A14MaxRecencia), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMaxRecencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMaxRecencia_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAvgRecencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAvgRecencia_Internalname, "Recencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAvgRecencia_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24AvgRecencia), 10, 0, ".", "")), ((edtAvgRecencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A24AvgRecencia), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A24AvgRecencia), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAvgRecencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAvgRecencia_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMinFrecuencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMinFrecuencia_Internalname, "Frecuencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMinFrecuencia_Internalname, StringUtil.LTrim( StringUtil.NToC( A15MinFrecuencia, 10, 6, ".", "")), ((edtMinFrecuencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A15MinFrecuencia, "ZZ9.999999")) : context.localUtil.Format( A15MinFrecuencia, "ZZ9.999999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMinFrecuencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMinFrecuencia_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMaxFrecuencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMaxFrecuencia_Internalname, "Frecuencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMaxFrecuencia_Internalname, StringUtil.LTrim( StringUtil.NToC( A16MaxFrecuencia, 10, 6, ".", "")), ((edtMaxFrecuencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A16MaxFrecuencia, "ZZ9.999999")) : context.localUtil.Format( A16MaxFrecuencia, "ZZ9.999999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMaxFrecuencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMaxFrecuencia_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAvgFrecuencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAvgFrecuencia_Internalname, "Frecuencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAvgFrecuencia_Internalname, StringUtil.LTrim( StringUtil.NToC( A17AvgFrecuencia, 10, 6, ".", "")), ((edtAvgFrecuencia_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A17AvgFrecuencia, "ZZ9.999999")) : context.localUtil.Format( A17AvgFrecuencia, "ZZ9.999999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAvgFrecuencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAvgFrecuencia_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMinValorMonetario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMinValorMonetario_Internalname, "Valor Monetario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMinValorMonetario_Internalname, StringUtil.LTrim( StringUtil.NToC( A18MinValorMonetario, 12, 8, ".", "")), ((edtMinValorMonetario_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A18MinValorMonetario, "ZZ9.99999999")) : context.localUtil.Format( A18MinValorMonetario, "ZZ9.99999999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMinValorMonetario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMinValorMonetario_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMaxValorMonetario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMaxValorMonetario_Internalname, "Valor Monetario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMaxValorMonetario_Internalname, StringUtil.LTrim( StringUtil.NToC( A19MaxValorMonetario, 12, 8, ".", "")), ((edtMaxValorMonetario_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A19MaxValorMonetario, "ZZ9.99999999")) : context.localUtil.Format( A19MaxValorMonetario, "ZZ9.99999999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMaxValorMonetario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMaxValorMonetario_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAvgValorMonetario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAvgValorMonetario_Internalname, "Valor Monetario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAvgValorMonetario_Internalname, StringUtil.LTrim( StringUtil.NToC( A20AvgValorMonetario, 12, 8, ".", "")), ((edtAvgValorMonetario_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A20AvgValorMonetario, "ZZ9.99999999")) : context.localUtil.Format( A20AvgValorMonetario, "ZZ9.99999999")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAvgValorMonetario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAvgValorMonetario_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComprasTickets_AnioMovil_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComprasTickets_AnioMovil_Internalname, "Tickets_Anio Movil", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComprasTickets_AnioMovil_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21ComprasTickets_AnioMovil), 12, 0, ".", "")), ((edtComprasTickets_AnioMovil_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A21ComprasTickets_AnioMovil), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A21ComprasTickets_AnioMovil), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComprasTickets_AnioMovil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComprasTickets_AnioMovil_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComprasImporte_AnioMovil_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComprasImporte_AnioMovil_Internalname, "Importe_Anio Movil", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComprasImporte_AnioMovil_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ComprasImporte_AnioMovil, 12, 2, ".", "")), ((edtComprasImporte_AnioMovil_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A22ComprasImporte_AnioMovil, "ZZZZZZZZ9.99")) : context.localUtil.Format( A22ComprasImporte_AnioMovil, "ZZZZZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComprasImporte_AnioMovil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComprasImporte_AnioMovil_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtComprasArticulos_AnioMovil_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtComprasArticulos_AnioMovil_Internalname, "Articulos_Anio Movil", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComprasArticulos_AnioMovil_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0, ".", "")), ((edtComprasArticulos_AnioMovil_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A23ComprasArticulos_AnioMovil), "ZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A23ComprasArticulos_AnioMovil), "ZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComprasArticulos_AnioMovil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComprasArticulos_AnioMovil_Enabled, 0, "number", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\ResumenRFMGlobal.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\ResumenRFMGlobal.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7Periodo = cgiGet( "Z7Periodo");
               Z8Corte1 = (int)(context.localUtil.CToN( cgiGet( "Z8Corte1"), ".", ","));
               Z9Corte2 = (int)(context.localUtil.CToN( cgiGet( "Z9Corte2"), ".", ","));
               Z10RFM = (int)(context.localUtil.CToN( cgiGet( "Z10RFM"), ".", ","));
               Z11ClientesDelAnio = (long)(context.localUtil.CToN( cgiGet( "Z11ClientesDelAnio"), ".", ","));
               n11ClientesDelAnio = ((0==A11ClientesDelAnio) ? true : false);
               Z12ClientesDelMes = (long)(context.localUtil.CToN( cgiGet( "Z12ClientesDelMes"), ".", ","));
               Z13MinRecencia = (long)(context.localUtil.CToN( cgiGet( "Z13MinRecencia"), ".", ","));
               Z14MaxRecencia = (long)(context.localUtil.CToN( cgiGet( "Z14MaxRecencia"), ".", ","));
               Z24AvgRecencia = (long)(context.localUtil.CToN( cgiGet( "Z24AvgRecencia"), ".", ","));
               Z15MinFrecuencia = context.localUtil.CToN( cgiGet( "Z15MinFrecuencia"), ".", ",");
               Z16MaxFrecuencia = context.localUtil.CToN( cgiGet( "Z16MaxFrecuencia"), ".", ",");
               Z17AvgFrecuencia = context.localUtil.CToN( cgiGet( "Z17AvgFrecuencia"), ".", ",");
               Z18MinValorMonetario = context.localUtil.CToN( cgiGet( "Z18MinValorMonetario"), ".", ",");
               Z19MaxValorMonetario = context.localUtil.CToN( cgiGet( "Z19MaxValorMonetario"), ".", ",");
               Z20AvgValorMonetario = context.localUtil.CToN( cgiGet( "Z20AvgValorMonetario"), ".", ",");
               Z21ComprasTickets_AnioMovil = (long)(context.localUtil.CToN( cgiGet( "Z21ComprasTickets_AnioMovil"), ".", ","));
               n21ComprasTickets_AnioMovil = ((0==A21ComprasTickets_AnioMovil) ? true : false);
               Z22ComprasImporte_AnioMovil = context.localUtil.CToN( cgiGet( "Z22ComprasImporte_AnioMovil"), ".", ",");
               n22ComprasImporte_AnioMovil = ((Convert.ToDecimal(0)==A22ComprasImporte_AnioMovil) ? true : false);
               Z23ComprasArticulos_AnioMovil = (long)(context.localUtil.CToN( cgiGet( "Z23ComprasArticulos_AnioMovil"), ".", ","));
               n23ComprasArticulos_AnioMovil = ((0==A23ComprasArticulos_AnioMovil) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7Periodo = cgiGet( "vPERIODO");
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7Periodo = cgiGet( edtPeriodo_Internalname);
               AssignAttri("", false, "A7Periodo", A7Periodo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCorte1_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCorte1_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORTE1");
                  AnyError = 1;
                  GX_FocusControl = edtCorte1_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8Corte1 = 0;
                  AssignAttri("", false, "A8Corte1", StringUtil.LTrimStr( (decimal)(A8Corte1), 8, 0));
               }
               else
               {
                  A8Corte1 = (int)(context.localUtil.CToN( cgiGet( edtCorte1_Internalname), ".", ","));
                  AssignAttri("", false, "A8Corte1", StringUtil.LTrimStr( (decimal)(A8Corte1), 8, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCorte2_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCorte2_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORTE2");
                  AnyError = 1;
                  GX_FocusControl = edtCorte2_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9Corte2 = 0;
                  AssignAttri("", false, "A9Corte2", StringUtil.LTrimStr( (decimal)(A9Corte2), 8, 0));
               }
               else
               {
                  A9Corte2 = (int)(context.localUtil.CToN( cgiGet( edtCorte2_Internalname), ".", ","));
                  AssignAttri("", false, "A9Corte2", StringUtil.LTrimStr( (decimal)(A9Corte2), 8, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRFM_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFM_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFM");
                  AnyError = 1;
                  GX_FocusControl = edtRFM_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10RFM = 0;
                  AssignAttri("", false, "A10RFM", StringUtil.LTrimStr( (decimal)(A10RFM), 8, 0));
               }
               else
               {
                  A10RFM = (int)(context.localUtil.CToN( cgiGet( edtRFM_Internalname), ".", ","));
                  AssignAttri("", false, "A10RFM", StringUtil.LTrimStr( (decimal)(A10RFM), 8, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtClientesDelAnio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClientesDelAnio_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTESDELANIO");
                  AnyError = 1;
                  GX_FocusControl = edtClientesDelAnio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A11ClientesDelAnio = 0;
                  n11ClientesDelAnio = false;
                  AssignAttri("", false, "A11ClientesDelAnio", StringUtil.LTrimStr( (decimal)(A11ClientesDelAnio), 10, 0));
               }
               else
               {
                  A11ClientesDelAnio = (long)(context.localUtil.CToN( cgiGet( edtClientesDelAnio_Internalname), ".", ","));
                  n11ClientesDelAnio = false;
                  AssignAttri("", false, "A11ClientesDelAnio", StringUtil.LTrimStr( (decimal)(A11ClientesDelAnio), 10, 0));
               }
               n11ClientesDelAnio = ((0==A11ClientesDelAnio) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClientesDelMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClientesDelMes_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTESDELMES");
                  AnyError = 1;
                  GX_FocusControl = edtClientesDelMes_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12ClientesDelMes = 0;
                  AssignAttri("", false, "A12ClientesDelMes", StringUtil.LTrimStr( (decimal)(A12ClientesDelMes), 10, 0));
               }
               else
               {
                  A12ClientesDelMes = (long)(context.localUtil.CToN( cgiGet( edtClientesDelMes_Internalname), ".", ","));
                  AssignAttri("", false, "A12ClientesDelMes", StringUtil.LTrimStr( (decimal)(A12ClientesDelMes), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMinRecencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMinRecencia_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MINRECENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtMinRecencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13MinRecencia = 0;
                  AssignAttri("", false, "A13MinRecencia", StringUtil.LTrimStr( (decimal)(A13MinRecencia), 10, 0));
               }
               else
               {
                  A13MinRecencia = (long)(context.localUtil.CToN( cgiGet( edtMinRecencia_Internalname), ".", ","));
                  AssignAttri("", false, "A13MinRecencia", StringUtil.LTrimStr( (decimal)(A13MinRecencia), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMaxRecencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMaxRecencia_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MAXRECENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtMaxRecencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A14MaxRecencia = 0;
                  AssignAttri("", false, "A14MaxRecencia", StringUtil.LTrimStr( (decimal)(A14MaxRecencia), 10, 0));
               }
               else
               {
                  A14MaxRecencia = (long)(context.localUtil.CToN( cgiGet( edtMaxRecencia_Internalname), ".", ","));
                  AssignAttri("", false, "A14MaxRecencia", StringUtil.LTrimStr( (decimal)(A14MaxRecencia), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtAvgRecencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAvgRecencia_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AVGRECENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtAvgRecencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A24AvgRecencia = 0;
                  AssignAttri("", false, "A24AvgRecencia", StringUtil.LTrimStr( (decimal)(A24AvgRecencia), 10, 0));
               }
               else
               {
                  A24AvgRecencia = (long)(context.localUtil.CToN( cgiGet( edtAvgRecencia_Internalname), ".", ","));
                  AssignAttri("", false, "A24AvgRecencia", StringUtil.LTrimStr( (decimal)(A24AvgRecencia), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMinFrecuencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMinFrecuencia_Internalname), ".", ",") > 999.999999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MINFRECUENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtMinFrecuencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15MinFrecuencia = 0;
                  AssignAttri("", false, "A15MinFrecuencia", StringUtil.LTrimStr( A15MinFrecuencia, 10, 6));
               }
               else
               {
                  A15MinFrecuencia = context.localUtil.CToN( cgiGet( edtMinFrecuencia_Internalname), ".", ",");
                  AssignAttri("", false, "A15MinFrecuencia", StringUtil.LTrimStr( A15MinFrecuencia, 10, 6));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMaxFrecuencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMaxFrecuencia_Internalname), ".", ",") > 999.999999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MAXFRECUENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtMaxFrecuencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16MaxFrecuencia = 0;
                  AssignAttri("", false, "A16MaxFrecuencia", StringUtil.LTrimStr( A16MaxFrecuencia, 10, 6));
               }
               else
               {
                  A16MaxFrecuencia = context.localUtil.CToN( cgiGet( edtMaxFrecuencia_Internalname), ".", ",");
                  AssignAttri("", false, "A16MaxFrecuencia", StringUtil.LTrimStr( A16MaxFrecuencia, 10, 6));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtAvgFrecuencia_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAvgFrecuencia_Internalname), ".", ",") > 999.999999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AVGFRECUENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtAvgFrecuencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17AvgFrecuencia = 0;
                  AssignAttri("", false, "A17AvgFrecuencia", StringUtil.LTrimStr( A17AvgFrecuencia, 10, 6));
               }
               else
               {
                  A17AvgFrecuencia = context.localUtil.CToN( cgiGet( edtAvgFrecuencia_Internalname), ".", ",");
                  AssignAttri("", false, "A17AvgFrecuencia", StringUtil.LTrimStr( A17AvgFrecuencia, 10, 6));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMinValorMonetario_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMinValorMonetario_Internalname), ".", ",") > 999.99999999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MINVALORMONETARIO");
                  AnyError = 1;
                  GX_FocusControl = edtMinValorMonetario_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A18MinValorMonetario = 0;
                  AssignAttri("", false, "A18MinValorMonetario", StringUtil.LTrimStr( A18MinValorMonetario, 12, 8));
               }
               else
               {
                  A18MinValorMonetario = context.localUtil.CToN( cgiGet( edtMinValorMonetario_Internalname), ".", ",");
                  AssignAttri("", false, "A18MinValorMonetario", StringUtil.LTrimStr( A18MinValorMonetario, 12, 8));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMaxValorMonetario_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMaxValorMonetario_Internalname), ".", ",") > 999.99999999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MAXVALORMONETARIO");
                  AnyError = 1;
                  GX_FocusControl = edtMaxValorMonetario_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A19MaxValorMonetario = 0;
                  AssignAttri("", false, "A19MaxValorMonetario", StringUtil.LTrimStr( A19MaxValorMonetario, 12, 8));
               }
               else
               {
                  A19MaxValorMonetario = context.localUtil.CToN( cgiGet( edtMaxValorMonetario_Internalname), ".", ",");
                  AssignAttri("", false, "A19MaxValorMonetario", StringUtil.LTrimStr( A19MaxValorMonetario, 12, 8));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtAvgValorMonetario_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAvgValorMonetario_Internalname), ".", ",") > 999.99999999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AVGVALORMONETARIO");
                  AnyError = 1;
                  GX_FocusControl = edtAvgValorMonetario_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A20AvgValorMonetario = 0;
                  AssignAttri("", false, "A20AvgValorMonetario", StringUtil.LTrimStr( A20AvgValorMonetario, 12, 8));
               }
               else
               {
                  A20AvgValorMonetario = context.localUtil.CToN( cgiGet( edtAvgValorMonetario_Internalname), ".", ",");
                  AssignAttri("", false, "A20AvgValorMonetario", StringUtil.LTrimStr( A20AvgValorMonetario, 12, 8));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtComprasTickets_AnioMovil_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComprasTickets_AnioMovil_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMPRASTICKETS_ANIOMOVIL");
                  AnyError = 1;
                  GX_FocusControl = edtComprasTickets_AnioMovil_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A21ComprasTickets_AnioMovil = 0;
                  n21ComprasTickets_AnioMovil = false;
                  AssignAttri("", false, "A21ComprasTickets_AnioMovil", StringUtil.LTrimStr( (decimal)(A21ComprasTickets_AnioMovil), 12, 0));
               }
               else
               {
                  A21ComprasTickets_AnioMovil = (long)(context.localUtil.CToN( cgiGet( edtComprasTickets_AnioMovil_Internalname), ".", ","));
                  n21ComprasTickets_AnioMovil = false;
                  AssignAttri("", false, "A21ComprasTickets_AnioMovil", StringUtil.LTrimStr( (decimal)(A21ComprasTickets_AnioMovil), 12, 0));
               }
               n21ComprasTickets_AnioMovil = ((0==A21ComprasTickets_AnioMovil) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtComprasImporte_AnioMovil_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComprasImporte_AnioMovil_Internalname), ".", ",") > 999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMPRASIMPORTE_ANIOMOVIL");
                  AnyError = 1;
                  GX_FocusControl = edtComprasImporte_AnioMovil_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A22ComprasImporte_AnioMovil = 0;
                  n22ComprasImporte_AnioMovil = false;
                  AssignAttri("", false, "A22ComprasImporte_AnioMovil", StringUtil.LTrimStr( A22ComprasImporte_AnioMovil, 12, 2));
               }
               else
               {
                  A22ComprasImporte_AnioMovil = context.localUtil.CToN( cgiGet( edtComprasImporte_AnioMovil_Internalname), ".", ",");
                  n22ComprasImporte_AnioMovil = false;
                  AssignAttri("", false, "A22ComprasImporte_AnioMovil", StringUtil.LTrimStr( A22ComprasImporte_AnioMovil, 12, 2));
               }
               n22ComprasImporte_AnioMovil = ((Convert.ToDecimal(0)==A22ComprasImporte_AnioMovil) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtComprasArticulos_AnioMovil_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComprasArticulos_AnioMovil_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMPRASARTICULOS_ANIOMOVIL");
                  AnyError = 1;
                  GX_FocusControl = edtComprasArticulos_AnioMovil_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A23ComprasArticulos_AnioMovil = 0;
                  n23ComprasArticulos_AnioMovil = false;
                  AssignAttri("", false, "A23ComprasArticulos_AnioMovil", StringUtil.LTrimStr( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0));
               }
               else
               {
                  A23ComprasArticulos_AnioMovil = (long)(context.localUtil.CToN( cgiGet( edtComprasArticulos_AnioMovil_Internalname), ".", ","));
                  n23ComprasArticulos_AnioMovil = false;
                  AssignAttri("", false, "A23ComprasArticulos_AnioMovil", StringUtil.LTrimStr( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0));
               }
               n23ComprasArticulos_AnioMovil = ((0==A23ComprasArticulos_AnioMovil) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ResumenRFMGlobal");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A7Periodo, Z7Periodo) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("version1\\resumenrfmglobal:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A7Periodo = GetNextPar( );
                  AssignAttri("", false, "A7Periodo", A7Periodo);
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PERIODO");
                        AnyError = 1;
                        GX_FocusControl = edtPeriodo_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
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
                     if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                     {
                        context.wbHandled = 1;
                        dynload_actions( ) ;
                        /* Execute user event: Start */
                        E11072 ();
                     }
                     else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                     {
                        context.wbHandled = 1;
                        dynload_actions( ) ;
                        /* Execute user event: After Trn */
                        E12072 ();
                     }
                     else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                     {
                        context.wbHandled = 1;
                        if ( ! IsDsp( ) )
                        {
                           btn_enter( ) ;
                        }
                        /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: After Trn */
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll073( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes073( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_070( )
      {
         BeforeValidate073( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls073( ) ;
            }
            else
            {
               CheckExtendedTable073( ) ;
               CloseExtendedTableCursors073( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         if ( ! new GeneXus.Programs.version1.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("version1.notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV11Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "RFM");
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("version1.wwresumenrfmglobal.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM073( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8Corte1 = T00073_A8Corte1[0];
               Z9Corte2 = T00073_A9Corte2[0];
               Z10RFM = T00073_A10RFM[0];
               Z11ClientesDelAnio = T00073_A11ClientesDelAnio[0];
               Z12ClientesDelMes = T00073_A12ClientesDelMes[0];
               Z13MinRecencia = T00073_A13MinRecencia[0];
               Z14MaxRecencia = T00073_A14MaxRecencia[0];
               Z24AvgRecencia = T00073_A24AvgRecencia[0];
               Z15MinFrecuencia = T00073_A15MinFrecuencia[0];
               Z16MaxFrecuencia = T00073_A16MaxFrecuencia[0];
               Z17AvgFrecuencia = T00073_A17AvgFrecuencia[0];
               Z18MinValorMonetario = T00073_A18MinValorMonetario[0];
               Z19MaxValorMonetario = T00073_A19MaxValorMonetario[0];
               Z20AvgValorMonetario = T00073_A20AvgValorMonetario[0];
               Z21ComprasTickets_AnioMovil = T00073_A21ComprasTickets_AnioMovil[0];
               Z22ComprasImporte_AnioMovil = T00073_A22ComprasImporte_AnioMovil[0];
               Z23ComprasArticulos_AnioMovil = T00073_A23ComprasArticulos_AnioMovil[0];
            }
            else
            {
               Z8Corte1 = A8Corte1;
               Z9Corte2 = A9Corte2;
               Z10RFM = A10RFM;
               Z11ClientesDelAnio = A11ClientesDelAnio;
               Z12ClientesDelMes = A12ClientesDelMes;
               Z13MinRecencia = A13MinRecencia;
               Z14MaxRecencia = A14MaxRecencia;
               Z24AvgRecencia = A24AvgRecencia;
               Z15MinFrecuencia = A15MinFrecuencia;
               Z16MaxFrecuencia = A16MaxFrecuencia;
               Z17AvgFrecuencia = A17AvgFrecuencia;
               Z18MinValorMonetario = A18MinValorMonetario;
               Z19MaxValorMonetario = A19MaxValorMonetario;
               Z20AvgValorMonetario = A20AvgValorMonetario;
               Z21ComprasTickets_AnioMovil = A21ComprasTickets_AnioMovil;
               Z22ComprasImporte_AnioMovil = A22ComprasImporte_AnioMovil;
               Z23ComprasArticulos_AnioMovil = A23ComprasArticulos_AnioMovil;
            }
         }
         if ( GX_JID == -4 )
         {
            Z7Periodo = A7Periodo;
            Z8Corte1 = A8Corte1;
            Z9Corte2 = A9Corte2;
            Z10RFM = A10RFM;
            Z11ClientesDelAnio = A11ClientesDelAnio;
            Z12ClientesDelMes = A12ClientesDelMes;
            Z13MinRecencia = A13MinRecencia;
            Z14MaxRecencia = A14MaxRecencia;
            Z24AvgRecencia = A24AvgRecencia;
            Z15MinFrecuencia = A15MinFrecuencia;
            Z16MaxFrecuencia = A16MaxFrecuencia;
            Z17AvgFrecuencia = A17AvgFrecuencia;
            Z18MinValorMonetario = A18MinValorMonetario;
            Z19MaxValorMonetario = A19MaxValorMonetario;
            Z20AvgValorMonetario = A20AvgValorMonetario;
            Z21ComprasTickets_AnioMovil = A21ComprasTickets_AnioMovil;
            Z22ComprasImporte_AnioMovil = A22ComprasImporte_AnioMovil;
            Z23ComprasArticulos_AnioMovil = A23ComprasArticulos_AnioMovil;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Periodo)) )
         {
            A7Periodo = AV7Periodo;
            AssignAttri("", false, "A7Periodo", A7Periodo);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Periodo)) )
         {
            edtPeriodo_Enabled = 0;
            AssignProp("", false, edtPeriodo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPeriodo_Enabled), 5, 0), true);
         }
         else
         {
            edtPeriodo_Enabled = 1;
            AssignProp("", false, edtPeriodo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPeriodo_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Periodo)) )
         {
            edtPeriodo_Enabled = 0;
            AssignProp("", false, edtPeriodo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPeriodo_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV11Pgmname = "Version1.ResumenRFMGlobal";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void Load073( )
      {
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A8Corte1 = T00074_A8Corte1[0];
            AssignAttri("", false, "A8Corte1", StringUtil.LTrimStr( (decimal)(A8Corte1), 8, 0));
            A9Corte2 = T00074_A9Corte2[0];
            AssignAttri("", false, "A9Corte2", StringUtil.LTrimStr( (decimal)(A9Corte2), 8, 0));
            A10RFM = T00074_A10RFM[0];
            AssignAttri("", false, "A10RFM", StringUtil.LTrimStr( (decimal)(A10RFM), 8, 0));
            A11ClientesDelAnio = T00074_A11ClientesDelAnio[0];
            n11ClientesDelAnio = T00074_n11ClientesDelAnio[0];
            AssignAttri("", false, "A11ClientesDelAnio", StringUtil.LTrimStr( (decimal)(A11ClientesDelAnio), 10, 0));
            A12ClientesDelMes = T00074_A12ClientesDelMes[0];
            AssignAttri("", false, "A12ClientesDelMes", StringUtil.LTrimStr( (decimal)(A12ClientesDelMes), 10, 0));
            A13MinRecencia = T00074_A13MinRecencia[0];
            AssignAttri("", false, "A13MinRecencia", StringUtil.LTrimStr( (decimal)(A13MinRecencia), 10, 0));
            A14MaxRecencia = T00074_A14MaxRecencia[0];
            AssignAttri("", false, "A14MaxRecencia", StringUtil.LTrimStr( (decimal)(A14MaxRecencia), 10, 0));
            A24AvgRecencia = T00074_A24AvgRecencia[0];
            AssignAttri("", false, "A24AvgRecencia", StringUtil.LTrimStr( (decimal)(A24AvgRecencia), 10, 0));
            A15MinFrecuencia = T00074_A15MinFrecuencia[0];
            AssignAttri("", false, "A15MinFrecuencia", StringUtil.LTrimStr( A15MinFrecuencia, 10, 6));
            A16MaxFrecuencia = T00074_A16MaxFrecuencia[0];
            AssignAttri("", false, "A16MaxFrecuencia", StringUtil.LTrimStr( A16MaxFrecuencia, 10, 6));
            A17AvgFrecuencia = T00074_A17AvgFrecuencia[0];
            AssignAttri("", false, "A17AvgFrecuencia", StringUtil.LTrimStr( A17AvgFrecuencia, 10, 6));
            A18MinValorMonetario = T00074_A18MinValorMonetario[0];
            AssignAttri("", false, "A18MinValorMonetario", StringUtil.LTrimStr( A18MinValorMonetario, 12, 8));
            A19MaxValorMonetario = T00074_A19MaxValorMonetario[0];
            AssignAttri("", false, "A19MaxValorMonetario", StringUtil.LTrimStr( A19MaxValorMonetario, 12, 8));
            A20AvgValorMonetario = T00074_A20AvgValorMonetario[0];
            AssignAttri("", false, "A20AvgValorMonetario", StringUtil.LTrimStr( A20AvgValorMonetario, 12, 8));
            A21ComprasTickets_AnioMovil = T00074_A21ComprasTickets_AnioMovil[0];
            n21ComprasTickets_AnioMovil = T00074_n21ComprasTickets_AnioMovil[0];
            AssignAttri("", false, "A21ComprasTickets_AnioMovil", StringUtil.LTrimStr( (decimal)(A21ComprasTickets_AnioMovil), 12, 0));
            A22ComprasImporte_AnioMovil = T00074_A22ComprasImporte_AnioMovil[0];
            n22ComprasImporte_AnioMovil = T00074_n22ComprasImporte_AnioMovil[0];
            AssignAttri("", false, "A22ComprasImporte_AnioMovil", StringUtil.LTrimStr( A22ComprasImporte_AnioMovil, 12, 2));
            A23ComprasArticulos_AnioMovil = T00074_A23ComprasArticulos_AnioMovil[0];
            n23ComprasArticulos_AnioMovil = T00074_n23ComprasArticulos_AnioMovil[0];
            AssignAttri("", false, "A23ComprasArticulos_AnioMovil", StringUtil.LTrimStr( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0));
            ZM073( -4) ;
         }
         pr_default.close(2);
         OnLoadActions073( ) ;
      }

      protected void OnLoadActions073( )
      {
         AV11Pgmname = "Version1.ResumenRFMGlobal";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable073( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Version1.ResumenRFMGlobal";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CloseExtendedTableCursors073( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey073( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM073( 4) ;
            RcdFound3 = 1;
            A7Periodo = T00073_A7Periodo[0];
            AssignAttri("", false, "A7Periodo", A7Periodo);
            A8Corte1 = T00073_A8Corte1[0];
            AssignAttri("", false, "A8Corte1", StringUtil.LTrimStr( (decimal)(A8Corte1), 8, 0));
            A9Corte2 = T00073_A9Corte2[0];
            AssignAttri("", false, "A9Corte2", StringUtil.LTrimStr( (decimal)(A9Corte2), 8, 0));
            A10RFM = T00073_A10RFM[0];
            AssignAttri("", false, "A10RFM", StringUtil.LTrimStr( (decimal)(A10RFM), 8, 0));
            A11ClientesDelAnio = T00073_A11ClientesDelAnio[0];
            n11ClientesDelAnio = T00073_n11ClientesDelAnio[0];
            AssignAttri("", false, "A11ClientesDelAnio", StringUtil.LTrimStr( (decimal)(A11ClientesDelAnio), 10, 0));
            A12ClientesDelMes = T00073_A12ClientesDelMes[0];
            AssignAttri("", false, "A12ClientesDelMes", StringUtil.LTrimStr( (decimal)(A12ClientesDelMes), 10, 0));
            A13MinRecencia = T00073_A13MinRecencia[0];
            AssignAttri("", false, "A13MinRecencia", StringUtil.LTrimStr( (decimal)(A13MinRecencia), 10, 0));
            A14MaxRecencia = T00073_A14MaxRecencia[0];
            AssignAttri("", false, "A14MaxRecencia", StringUtil.LTrimStr( (decimal)(A14MaxRecencia), 10, 0));
            A24AvgRecencia = T00073_A24AvgRecencia[0];
            AssignAttri("", false, "A24AvgRecencia", StringUtil.LTrimStr( (decimal)(A24AvgRecencia), 10, 0));
            A15MinFrecuencia = T00073_A15MinFrecuencia[0];
            AssignAttri("", false, "A15MinFrecuencia", StringUtil.LTrimStr( A15MinFrecuencia, 10, 6));
            A16MaxFrecuencia = T00073_A16MaxFrecuencia[0];
            AssignAttri("", false, "A16MaxFrecuencia", StringUtil.LTrimStr( A16MaxFrecuencia, 10, 6));
            A17AvgFrecuencia = T00073_A17AvgFrecuencia[0];
            AssignAttri("", false, "A17AvgFrecuencia", StringUtil.LTrimStr( A17AvgFrecuencia, 10, 6));
            A18MinValorMonetario = T00073_A18MinValorMonetario[0];
            AssignAttri("", false, "A18MinValorMonetario", StringUtil.LTrimStr( A18MinValorMonetario, 12, 8));
            A19MaxValorMonetario = T00073_A19MaxValorMonetario[0];
            AssignAttri("", false, "A19MaxValorMonetario", StringUtil.LTrimStr( A19MaxValorMonetario, 12, 8));
            A20AvgValorMonetario = T00073_A20AvgValorMonetario[0];
            AssignAttri("", false, "A20AvgValorMonetario", StringUtil.LTrimStr( A20AvgValorMonetario, 12, 8));
            A21ComprasTickets_AnioMovil = T00073_A21ComprasTickets_AnioMovil[0];
            n21ComprasTickets_AnioMovil = T00073_n21ComprasTickets_AnioMovil[0];
            AssignAttri("", false, "A21ComprasTickets_AnioMovil", StringUtil.LTrimStr( (decimal)(A21ComprasTickets_AnioMovil), 12, 0));
            A22ComprasImporte_AnioMovil = T00073_A22ComprasImporte_AnioMovil[0];
            n22ComprasImporte_AnioMovil = T00073_n22ComprasImporte_AnioMovil[0];
            AssignAttri("", false, "A22ComprasImporte_AnioMovil", StringUtil.LTrimStr( A22ComprasImporte_AnioMovil, 12, 2));
            A23ComprasArticulos_AnioMovil = T00073_A23ComprasArticulos_AnioMovil[0];
            n23ComprasArticulos_AnioMovil = T00073_n23ComprasArticulos_AnioMovil[0];
            AssignAttri("", false, "A23ComprasArticulos_AnioMovil", StringUtil.LTrimStr( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0));
            Z7Periodo = A7Periodo;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load073( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey073( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey073( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey073( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00076_A7Periodo[0], A7Periodo) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00076_A7Periodo[0], A7Periodo) > 0 ) ) )
            {
               A7Periodo = T00076_A7Periodo[0];
               AssignAttri("", false, "A7Periodo", A7Periodo);
               RcdFound3 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00077_A7Periodo[0], A7Periodo) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00077_A7Periodo[0], A7Periodo) < 0 ) ) )
            {
               A7Periodo = T00077_A7Periodo[0];
               AssignAttri("", false, "A7Periodo", A7Periodo);
               RcdFound3 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey073( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPeriodo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert073( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( StringUtil.StrCmp(A7Periodo, Z7Periodo) != 0 )
               {
                  A7Periodo = Z7Periodo;
                  AssignAttri("", false, "A7Periodo", A7Periodo);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PERIODO");
                  AnyError = 1;
                  GX_FocusControl = edtPeriodo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPeriodo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update073( ) ;
                  GX_FocusControl = edtPeriodo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A7Periodo, Z7Periodo) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtPeriodo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert073( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PERIODO");
                     AnyError = 1;
                     GX_FocusControl = edtPeriodo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPeriodo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert073( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A7Periodo, Z7Periodo) != 0 )
         {
            A7Periodo = Z7Periodo;
            AssignAttri("", false, "A7Periodo", A7Periodo);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PERIODO");
            AnyError = 1;
            GX_FocusControl = edtPeriodo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPeriodo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency073( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A7Periodo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResumenRFMGlobal"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z8Corte1 != T00072_A8Corte1[0] ) || ( Z9Corte2 != T00072_A9Corte2[0] ) || ( Z10RFM != T00072_A10RFM[0] ) || ( Z11ClientesDelAnio != T00072_A11ClientesDelAnio[0] ) || ( Z12ClientesDelMes != T00072_A12ClientesDelMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z13MinRecencia != T00072_A13MinRecencia[0] ) || ( Z14MaxRecencia != T00072_A14MaxRecencia[0] ) || ( Z24AvgRecencia != T00072_A24AvgRecencia[0] ) || ( Z15MinFrecuencia != T00072_A15MinFrecuencia[0] ) || ( Z16MaxFrecuencia != T00072_A16MaxFrecuencia[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z17AvgFrecuencia != T00072_A17AvgFrecuencia[0] ) || ( Z18MinValorMonetario != T00072_A18MinValorMonetario[0] ) || ( Z19MaxValorMonetario != T00072_A19MaxValorMonetario[0] ) || ( Z20AvgValorMonetario != T00072_A20AvgValorMonetario[0] ) || ( Z21ComprasTickets_AnioMovil != T00072_A21ComprasTickets_AnioMovil[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z22ComprasImporte_AnioMovil != T00072_A22ComprasImporte_AnioMovil[0] ) || ( Z23ComprasArticulos_AnioMovil != T00072_A23ComprasArticulos_AnioMovil[0] ) )
            {
               if ( Z8Corte1 != T00072_A8Corte1[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"Corte1");
                  GXUtil.WriteLogRaw("Old: ",Z8Corte1);
                  GXUtil.WriteLogRaw("Current: ",T00072_A8Corte1[0]);
               }
               if ( Z9Corte2 != T00072_A9Corte2[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"Corte2");
                  GXUtil.WriteLogRaw("Old: ",Z9Corte2);
                  GXUtil.WriteLogRaw("Current: ",T00072_A9Corte2[0]);
               }
               if ( Z10RFM != T00072_A10RFM[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"RFM");
                  GXUtil.WriteLogRaw("Old: ",Z10RFM);
                  GXUtil.WriteLogRaw("Current: ",T00072_A10RFM[0]);
               }
               if ( Z11ClientesDelAnio != T00072_A11ClientesDelAnio[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"ClientesDelAnio");
                  GXUtil.WriteLogRaw("Old: ",Z11ClientesDelAnio);
                  GXUtil.WriteLogRaw("Current: ",T00072_A11ClientesDelAnio[0]);
               }
               if ( Z12ClientesDelMes != T00072_A12ClientesDelMes[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"ClientesDelMes");
                  GXUtil.WriteLogRaw("Old: ",Z12ClientesDelMes);
                  GXUtil.WriteLogRaw("Current: ",T00072_A12ClientesDelMes[0]);
               }
               if ( Z13MinRecencia != T00072_A13MinRecencia[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"MinRecencia");
                  GXUtil.WriteLogRaw("Old: ",Z13MinRecencia);
                  GXUtil.WriteLogRaw("Current: ",T00072_A13MinRecencia[0]);
               }
               if ( Z14MaxRecencia != T00072_A14MaxRecencia[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"MaxRecencia");
                  GXUtil.WriteLogRaw("Old: ",Z14MaxRecencia);
                  GXUtil.WriteLogRaw("Current: ",T00072_A14MaxRecencia[0]);
               }
               if ( Z24AvgRecencia != T00072_A24AvgRecencia[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"AvgRecencia");
                  GXUtil.WriteLogRaw("Old: ",Z24AvgRecencia);
                  GXUtil.WriteLogRaw("Current: ",T00072_A24AvgRecencia[0]);
               }
               if ( Z15MinFrecuencia != T00072_A15MinFrecuencia[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"MinFrecuencia");
                  GXUtil.WriteLogRaw("Old: ",Z15MinFrecuencia);
                  GXUtil.WriteLogRaw("Current: ",T00072_A15MinFrecuencia[0]);
               }
               if ( Z16MaxFrecuencia != T00072_A16MaxFrecuencia[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"MaxFrecuencia");
                  GXUtil.WriteLogRaw("Old: ",Z16MaxFrecuencia);
                  GXUtil.WriteLogRaw("Current: ",T00072_A16MaxFrecuencia[0]);
               }
               if ( Z17AvgFrecuencia != T00072_A17AvgFrecuencia[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"AvgFrecuencia");
                  GXUtil.WriteLogRaw("Old: ",Z17AvgFrecuencia);
                  GXUtil.WriteLogRaw("Current: ",T00072_A17AvgFrecuencia[0]);
               }
               if ( Z18MinValorMonetario != T00072_A18MinValorMonetario[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"MinValorMonetario");
                  GXUtil.WriteLogRaw("Old: ",Z18MinValorMonetario);
                  GXUtil.WriteLogRaw("Current: ",T00072_A18MinValorMonetario[0]);
               }
               if ( Z19MaxValorMonetario != T00072_A19MaxValorMonetario[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"MaxValorMonetario");
                  GXUtil.WriteLogRaw("Old: ",Z19MaxValorMonetario);
                  GXUtil.WriteLogRaw("Current: ",T00072_A19MaxValorMonetario[0]);
               }
               if ( Z20AvgValorMonetario != T00072_A20AvgValorMonetario[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"AvgValorMonetario");
                  GXUtil.WriteLogRaw("Old: ",Z20AvgValorMonetario);
                  GXUtil.WriteLogRaw("Current: ",T00072_A20AvgValorMonetario[0]);
               }
               if ( Z21ComprasTickets_AnioMovil != T00072_A21ComprasTickets_AnioMovil[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"ComprasTickets_AnioMovil");
                  GXUtil.WriteLogRaw("Old: ",Z21ComprasTickets_AnioMovil);
                  GXUtil.WriteLogRaw("Current: ",T00072_A21ComprasTickets_AnioMovil[0]);
               }
               if ( Z22ComprasImporte_AnioMovil != T00072_A22ComprasImporte_AnioMovil[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"ComprasImporte_AnioMovil");
                  GXUtil.WriteLogRaw("Old: ",Z22ComprasImporte_AnioMovil);
                  GXUtil.WriteLogRaw("Current: ",T00072_A22ComprasImporte_AnioMovil[0]);
               }
               if ( Z23ComprasArticulos_AnioMovil != T00072_A23ComprasArticulos_AnioMovil[0] )
               {
                  GXUtil.WriteLog("version1.resumenrfmglobal:[seudo value changed for attri]"+"ComprasArticulos_AnioMovil");
                  GXUtil.WriteLogRaw("Old: ",Z23ComprasArticulos_AnioMovil);
                  GXUtil.WriteLogRaw("Current: ",T00072_A23ComprasArticulos_AnioMovil[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResumenRFMGlobal"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert073( )
      {
         BeforeValidate073( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable073( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM073( 0) ;
            CheckOptimisticConcurrency073( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm073( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert073( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00078 */
                     pr_default.execute(6, new Object[] {A7Periodo, A8Corte1, A9Corte2, A10RFM, n11ClientesDelAnio, A11ClientesDelAnio, A12ClientesDelMes, A13MinRecencia, A14MaxRecencia, A24AvgRecencia, A15MinFrecuencia, A16MaxFrecuencia, A17AvgFrecuencia, A18MinValorMonetario, A19MaxValorMonetario, A20AvgValorMonetario, n21ComprasTickets_AnioMovil, A21ComprasTickets_AnioMovil, n22ComprasImporte_AnioMovil, A22ComprasImporte_AnioMovil, n23ComprasArticulos_AnioMovil, A23ComprasArticulos_AnioMovil});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("ResumenRFMGlobal") ;
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption070( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load073( ) ;
            }
            EndLevel073( ) ;
         }
         CloseExtendedTableCursors073( ) ;
      }

      protected void Update073( )
      {
         BeforeValidate073( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable073( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency073( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm073( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate073( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00079 */
                     pr_default.execute(7, new Object[] {A8Corte1, A9Corte2, A10RFM, n11ClientesDelAnio, A11ClientesDelAnio, A12ClientesDelMes, A13MinRecencia, A14MaxRecencia, A24AvgRecencia, A15MinFrecuencia, A16MaxFrecuencia, A17AvgFrecuencia, A18MinValorMonetario, A19MaxValorMonetario, A20AvgValorMonetario, n21ComprasTickets_AnioMovil, A21ComprasTickets_AnioMovil, n22ComprasImporte_AnioMovil, A22ComprasImporte_AnioMovil, n23ComprasArticulos_AnioMovil, A23ComprasArticulos_AnioMovil, A7Periodo});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ResumenRFMGlobal") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResumenRFMGlobal"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate073( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel073( ) ;
         }
         CloseExtendedTableCursors073( ) ;
      }

      protected void DeferredUpdate073( )
      {
      }

      protected void delete( )
      {
         BeforeValidate073( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency073( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls073( ) ;
            AfterConfirm073( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete073( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000710 */
                  pr_default.execute(8, new Object[] {A7Periodo});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("ResumenRFMGlobal") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel073( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls073( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Version1.ResumenRFMGlobal";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void EndLevel073( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete073( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("version1.resumenrfmglobal",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("version1.resumenrfmglobal",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart073( )
      {
         /* Scan By routine */
         /* Using cursor T000711 */
         pr_default.execute(9);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A7Periodo = T000711_A7Periodo[0];
            AssignAttri("", false, "A7Periodo", A7Periodo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext073( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A7Periodo = T000711_A7Periodo[0];
            AssignAttri("", false, "A7Periodo", A7Periodo);
         }
      }

      protected void ScanEnd073( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm073( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert073( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate073( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete073( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete073( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate073( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes073( )
      {
         edtPeriodo_Enabled = 0;
         AssignProp("", false, edtPeriodo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPeriodo_Enabled), 5, 0), true);
         edtCorte1_Enabled = 0;
         AssignProp("", false, edtCorte1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorte1_Enabled), 5, 0), true);
         edtCorte2_Enabled = 0;
         AssignProp("", false, edtCorte2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorte2_Enabled), 5, 0), true);
         edtRFM_Enabled = 0;
         AssignProp("", false, edtRFM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFM_Enabled), 5, 0), true);
         edtClientesDelAnio_Enabled = 0;
         AssignProp("", false, edtClientesDelAnio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesDelAnio_Enabled), 5, 0), true);
         edtClientesDelMes_Enabled = 0;
         AssignProp("", false, edtClientesDelMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientesDelMes_Enabled), 5, 0), true);
         edtMinRecencia_Enabled = 0;
         AssignProp("", false, edtMinRecencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMinRecencia_Enabled), 5, 0), true);
         edtMaxRecencia_Enabled = 0;
         AssignProp("", false, edtMaxRecencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMaxRecencia_Enabled), 5, 0), true);
         edtAvgRecencia_Enabled = 0;
         AssignProp("", false, edtAvgRecencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAvgRecencia_Enabled), 5, 0), true);
         edtMinFrecuencia_Enabled = 0;
         AssignProp("", false, edtMinFrecuencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMinFrecuencia_Enabled), 5, 0), true);
         edtMaxFrecuencia_Enabled = 0;
         AssignProp("", false, edtMaxFrecuencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMaxFrecuencia_Enabled), 5, 0), true);
         edtAvgFrecuencia_Enabled = 0;
         AssignProp("", false, edtAvgFrecuencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAvgFrecuencia_Enabled), 5, 0), true);
         edtMinValorMonetario_Enabled = 0;
         AssignProp("", false, edtMinValorMonetario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMinValorMonetario_Enabled), 5, 0), true);
         edtMaxValorMonetario_Enabled = 0;
         AssignProp("", false, edtMaxValorMonetario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMaxValorMonetario_Enabled), 5, 0), true);
         edtAvgValorMonetario_Enabled = 0;
         AssignProp("", false, edtAvgValorMonetario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAvgValorMonetario_Enabled), 5, 0), true);
         edtComprasTickets_AnioMovil_Enabled = 0;
         AssignProp("", false, edtComprasTickets_AnioMovil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComprasTickets_AnioMovil_Enabled), 5, 0), true);
         edtComprasImporte_AnioMovil_Enabled = 0;
         AssignProp("", false, edtComprasImporte_AnioMovil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComprasImporte_AnioMovil_Enabled), 5, 0), true);
         edtComprasArticulos_AnioMovil_Enabled = 0;
         AssignProp("", false, edtComprasArticulos_AnioMovil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComprasArticulos_AnioMovil_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes073( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Resumen RFMGlobal") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1247300), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202091115385788", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("version1.resumenrfmglobal.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7Periodo))+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ResumenRFMGlobal");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("version1\\resumenrfmglobal:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7Periodo", Z7Periodo);
         GxWebStd.gx_hidden_field( context, "Z8Corte1", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8Corte1), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9Corte2", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9Corte2), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10RFM", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10RFM), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z11ClientesDelAnio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11ClientesDelAnio), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12ClientesDelMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ClientesDelMes), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z13MinRecencia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13MinRecencia), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14MaxRecencia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14MaxRecencia), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24AvgRecencia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24AvgRecencia), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15MinFrecuencia", StringUtil.LTrim( StringUtil.NToC( Z15MinFrecuencia, 10, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16MaxFrecuencia", StringUtil.LTrim( StringUtil.NToC( Z16MaxFrecuencia, 10, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17AvgFrecuencia", StringUtil.LTrim( StringUtil.NToC( Z17AvgFrecuencia, 10, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18MinValorMonetario", StringUtil.LTrim( StringUtil.NToC( Z18MinValorMonetario, 12, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19MaxValorMonetario", StringUtil.LTrim( StringUtil.NToC( Z19MaxValorMonetario, 12, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20AvgValorMonetario", StringUtil.LTrim( StringUtil.NToC( Z20AvgValorMonetario, 12, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21ComprasTickets_AnioMovil", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21ComprasTickets_AnioMovil), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22ComprasImporte_AnioMovil", StringUtil.LTrim( StringUtil.NToC( Z22ComprasImporte_AnioMovil, 12, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23ComprasArticulos_AnioMovil", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23ComprasArticulos_AnioMovil), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPERIODO", AV7Periodo);
         GxWebStd.gx_hidden_field( context, "gxhash_vPERIODO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Periodo, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
      }

      protected void RenderHtmlCloseForm073( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "Version1.ResumenRFMGlobal" ;
      }

      public override String GetPgmdesc( )
      {
         return "Resumen RFMGlobal" ;
      }

      protected void InitializeNonKey073( )
      {
         A8Corte1 = 0;
         AssignAttri("", false, "A8Corte1", StringUtil.LTrimStr( (decimal)(A8Corte1), 8, 0));
         A9Corte2 = 0;
         AssignAttri("", false, "A9Corte2", StringUtil.LTrimStr( (decimal)(A9Corte2), 8, 0));
         A10RFM = 0;
         AssignAttri("", false, "A10RFM", StringUtil.LTrimStr( (decimal)(A10RFM), 8, 0));
         A11ClientesDelAnio = 0;
         n11ClientesDelAnio = false;
         AssignAttri("", false, "A11ClientesDelAnio", StringUtil.LTrimStr( (decimal)(A11ClientesDelAnio), 10, 0));
         n11ClientesDelAnio = ((0==A11ClientesDelAnio) ? true : false);
         A12ClientesDelMes = 0;
         AssignAttri("", false, "A12ClientesDelMes", StringUtil.LTrimStr( (decimal)(A12ClientesDelMes), 10, 0));
         A13MinRecencia = 0;
         AssignAttri("", false, "A13MinRecencia", StringUtil.LTrimStr( (decimal)(A13MinRecencia), 10, 0));
         A14MaxRecencia = 0;
         AssignAttri("", false, "A14MaxRecencia", StringUtil.LTrimStr( (decimal)(A14MaxRecencia), 10, 0));
         A24AvgRecencia = 0;
         AssignAttri("", false, "A24AvgRecencia", StringUtil.LTrimStr( (decimal)(A24AvgRecencia), 10, 0));
         A15MinFrecuencia = 0;
         AssignAttri("", false, "A15MinFrecuencia", StringUtil.LTrimStr( A15MinFrecuencia, 10, 6));
         A16MaxFrecuencia = 0;
         AssignAttri("", false, "A16MaxFrecuencia", StringUtil.LTrimStr( A16MaxFrecuencia, 10, 6));
         A17AvgFrecuencia = 0;
         AssignAttri("", false, "A17AvgFrecuencia", StringUtil.LTrimStr( A17AvgFrecuencia, 10, 6));
         A18MinValorMonetario = 0;
         AssignAttri("", false, "A18MinValorMonetario", StringUtil.LTrimStr( A18MinValorMonetario, 12, 8));
         A19MaxValorMonetario = 0;
         AssignAttri("", false, "A19MaxValorMonetario", StringUtil.LTrimStr( A19MaxValorMonetario, 12, 8));
         A20AvgValorMonetario = 0;
         AssignAttri("", false, "A20AvgValorMonetario", StringUtil.LTrimStr( A20AvgValorMonetario, 12, 8));
         A21ComprasTickets_AnioMovil = 0;
         n21ComprasTickets_AnioMovil = false;
         AssignAttri("", false, "A21ComprasTickets_AnioMovil", StringUtil.LTrimStr( (decimal)(A21ComprasTickets_AnioMovil), 12, 0));
         n21ComprasTickets_AnioMovil = ((0==A21ComprasTickets_AnioMovil) ? true : false);
         A22ComprasImporte_AnioMovil = 0;
         n22ComprasImporte_AnioMovil = false;
         AssignAttri("", false, "A22ComprasImporte_AnioMovil", StringUtil.LTrimStr( A22ComprasImporte_AnioMovil, 12, 2));
         n22ComprasImporte_AnioMovil = ((Convert.ToDecimal(0)==A22ComprasImporte_AnioMovil) ? true : false);
         A23ComprasArticulos_AnioMovil = 0;
         n23ComprasArticulos_AnioMovil = false;
         AssignAttri("", false, "A23ComprasArticulos_AnioMovil", StringUtil.LTrimStr( (decimal)(A23ComprasArticulos_AnioMovil), 12, 0));
         n23ComprasArticulos_AnioMovil = ((0==A23ComprasArticulos_AnioMovil) ? true : false);
         Z8Corte1 = 0;
         Z9Corte2 = 0;
         Z10RFM = 0;
         Z11ClientesDelAnio = 0;
         Z12ClientesDelMes = 0;
         Z13MinRecencia = 0;
         Z14MaxRecencia = 0;
         Z24AvgRecencia = 0;
         Z15MinFrecuencia = 0;
         Z16MaxFrecuencia = 0;
         Z17AvgFrecuencia = 0;
         Z18MinValorMonetario = 0;
         Z19MaxValorMonetario = 0;
         Z20AvgValorMonetario = 0;
         Z21ComprasTickets_AnioMovil = 0;
         Z22ComprasImporte_AnioMovil = 0;
         Z23ComprasArticulos_AnioMovil = 0;
      }

      protected void InitAll073( )
      {
         A7Periodo = "";
         AssignAttri("", false, "A7Periodo", A7Periodo);
         InitializeNonKey073( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20209111538581", true, true);
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
         context.AddJavascriptSource("version1/resumenrfmglobal.js", "?20209111538581", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
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
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtComprasArticulos_AnioMovil_Jsonclick = "";
         edtComprasArticulos_AnioMovil_Enabled = 1;
         edtComprasImporte_AnioMovil_Jsonclick = "";
         edtComprasImporte_AnioMovil_Enabled = 1;
         edtComprasTickets_AnioMovil_Jsonclick = "";
         edtComprasTickets_AnioMovil_Enabled = 1;
         edtAvgValorMonetario_Jsonclick = "";
         edtAvgValorMonetario_Enabled = 1;
         edtMaxValorMonetario_Jsonclick = "";
         edtMaxValorMonetario_Enabled = 1;
         edtMinValorMonetario_Jsonclick = "";
         edtMinValorMonetario_Enabled = 1;
         edtAvgFrecuencia_Jsonclick = "";
         edtAvgFrecuencia_Enabled = 1;
         edtMaxFrecuencia_Jsonclick = "";
         edtMaxFrecuencia_Enabled = 1;
         edtMinFrecuencia_Jsonclick = "";
         edtMinFrecuencia_Enabled = 1;
         edtAvgRecencia_Jsonclick = "";
         edtAvgRecencia_Enabled = 1;
         edtMaxRecencia_Jsonclick = "";
         edtMaxRecencia_Enabled = 1;
         edtMinRecencia_Jsonclick = "";
         edtMinRecencia_Enabled = 1;
         edtClientesDelMes_Jsonclick = "";
         edtClientesDelMes_Enabled = 1;
         edtClientesDelAnio_Jsonclick = "";
         edtClientesDelAnio_Enabled = 1;
         edtRFM_Jsonclick = "";
         edtRFM_Enabled = 1;
         edtCorte2_Jsonclick = "";
         edtCorte2_Enabled = 1;
         edtCorte1_Jsonclick = "";
         edtCorte1_Enabled = 1;
         edtPeriodo_Jsonclick = "";
         edtPeriodo_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Periodo',fld:'vPERIODO',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Periodo',fld:'vPERIODO',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PERIODO","{handler:'Valid_Periodo',iparms:[]");
         setEventMetadata("VALID_PERIODO",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7Periodo = "";
         Z7Periodo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A7Periodo = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9TrnContext = new GeneXus.Programs.version1.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00074_A7Periodo = new String[] {""} ;
         T00074_A8Corte1 = new int[1] ;
         T00074_A9Corte2 = new int[1] ;
         T00074_A10RFM = new int[1] ;
         T00074_A11ClientesDelAnio = new long[1] ;
         T00074_n11ClientesDelAnio = new bool[] {false} ;
         T00074_A12ClientesDelMes = new long[1] ;
         T00074_A13MinRecencia = new long[1] ;
         T00074_A14MaxRecencia = new long[1] ;
         T00074_A24AvgRecencia = new long[1] ;
         T00074_A15MinFrecuencia = new decimal[1] ;
         T00074_A16MaxFrecuencia = new decimal[1] ;
         T00074_A17AvgFrecuencia = new decimal[1] ;
         T00074_A18MinValorMonetario = new decimal[1] ;
         T00074_A19MaxValorMonetario = new decimal[1] ;
         T00074_A20AvgValorMonetario = new decimal[1] ;
         T00074_A21ComprasTickets_AnioMovil = new long[1] ;
         T00074_n21ComprasTickets_AnioMovil = new bool[] {false} ;
         T00074_A22ComprasImporte_AnioMovil = new decimal[1] ;
         T00074_n22ComprasImporte_AnioMovil = new bool[] {false} ;
         T00074_A23ComprasArticulos_AnioMovil = new long[1] ;
         T00074_n23ComprasArticulos_AnioMovil = new bool[] {false} ;
         T00075_A7Periodo = new String[] {""} ;
         T00073_A7Periodo = new String[] {""} ;
         T00073_A8Corte1 = new int[1] ;
         T00073_A9Corte2 = new int[1] ;
         T00073_A10RFM = new int[1] ;
         T00073_A11ClientesDelAnio = new long[1] ;
         T00073_n11ClientesDelAnio = new bool[] {false} ;
         T00073_A12ClientesDelMes = new long[1] ;
         T00073_A13MinRecencia = new long[1] ;
         T00073_A14MaxRecencia = new long[1] ;
         T00073_A24AvgRecencia = new long[1] ;
         T00073_A15MinFrecuencia = new decimal[1] ;
         T00073_A16MaxFrecuencia = new decimal[1] ;
         T00073_A17AvgFrecuencia = new decimal[1] ;
         T00073_A18MinValorMonetario = new decimal[1] ;
         T00073_A19MaxValorMonetario = new decimal[1] ;
         T00073_A20AvgValorMonetario = new decimal[1] ;
         T00073_A21ComprasTickets_AnioMovil = new long[1] ;
         T00073_n21ComprasTickets_AnioMovil = new bool[] {false} ;
         T00073_A22ComprasImporte_AnioMovil = new decimal[1] ;
         T00073_n22ComprasImporte_AnioMovil = new bool[] {false} ;
         T00073_A23ComprasArticulos_AnioMovil = new long[1] ;
         T00073_n23ComprasArticulos_AnioMovil = new bool[] {false} ;
         T00076_A7Periodo = new String[] {""} ;
         T00077_A7Periodo = new String[] {""} ;
         T00072_A7Periodo = new String[] {""} ;
         T00072_A8Corte1 = new int[1] ;
         T00072_A9Corte2 = new int[1] ;
         T00072_A10RFM = new int[1] ;
         T00072_A11ClientesDelAnio = new long[1] ;
         T00072_n11ClientesDelAnio = new bool[] {false} ;
         T00072_A12ClientesDelMes = new long[1] ;
         T00072_A13MinRecencia = new long[1] ;
         T00072_A14MaxRecencia = new long[1] ;
         T00072_A24AvgRecencia = new long[1] ;
         T00072_A15MinFrecuencia = new decimal[1] ;
         T00072_A16MaxFrecuencia = new decimal[1] ;
         T00072_A17AvgFrecuencia = new decimal[1] ;
         T00072_A18MinValorMonetario = new decimal[1] ;
         T00072_A19MaxValorMonetario = new decimal[1] ;
         T00072_A20AvgValorMonetario = new decimal[1] ;
         T00072_A21ComprasTickets_AnioMovil = new long[1] ;
         T00072_n21ComprasTickets_AnioMovil = new bool[] {false} ;
         T00072_A22ComprasImporte_AnioMovil = new decimal[1] ;
         T00072_n22ComprasImporte_AnioMovil = new bool[] {false} ;
         T00072_A23ComprasArticulos_AnioMovil = new long[1] ;
         T00072_n23ComprasArticulos_AnioMovil = new bool[] {false} ;
         T000711_A7Periodo = new String[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.version1.resumenrfmglobal__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.version1.resumenrfmglobal__default(),
            new Object[][] {
                new Object[] {
               T00072_A7Periodo, T00072_A8Corte1, T00072_A9Corte2, T00072_A10RFM, T00072_A11ClientesDelAnio, T00072_n11ClientesDelAnio, T00072_A12ClientesDelMes, T00072_A13MinRecencia, T00072_A14MaxRecencia, T00072_A24AvgRecencia,
               T00072_A15MinFrecuencia, T00072_A16MaxFrecuencia, T00072_A17AvgFrecuencia, T00072_A18MinValorMonetario, T00072_A19MaxValorMonetario, T00072_A20AvgValorMonetario, T00072_A21ComprasTickets_AnioMovil, T00072_n21ComprasTickets_AnioMovil, T00072_A22ComprasImporte_AnioMovil, T00072_n22ComprasImporte_AnioMovil,
               T00072_A23ComprasArticulos_AnioMovil, T00072_n23ComprasArticulos_AnioMovil
               }
               , new Object[] {
               T00073_A7Periodo, T00073_A8Corte1, T00073_A9Corte2, T00073_A10RFM, T00073_A11ClientesDelAnio, T00073_n11ClientesDelAnio, T00073_A12ClientesDelMes, T00073_A13MinRecencia, T00073_A14MaxRecencia, T00073_A24AvgRecencia,
               T00073_A15MinFrecuencia, T00073_A16MaxFrecuencia, T00073_A17AvgFrecuencia, T00073_A18MinValorMonetario, T00073_A19MaxValorMonetario, T00073_A20AvgValorMonetario, T00073_A21ComprasTickets_AnioMovil, T00073_n21ComprasTickets_AnioMovil, T00073_A22ComprasImporte_AnioMovil, T00073_n22ComprasImporte_AnioMovil,
               T00073_A23ComprasArticulos_AnioMovil, T00073_n23ComprasArticulos_AnioMovil
               }
               , new Object[] {
               T00074_A7Periodo, T00074_A8Corte1, T00074_A9Corte2, T00074_A10RFM, T00074_A11ClientesDelAnio, T00074_n11ClientesDelAnio, T00074_A12ClientesDelMes, T00074_A13MinRecencia, T00074_A14MaxRecencia, T00074_A24AvgRecencia,
               T00074_A15MinFrecuencia, T00074_A16MaxFrecuencia, T00074_A17AvgFrecuencia, T00074_A18MinValorMonetario, T00074_A19MaxValorMonetario, T00074_A20AvgValorMonetario, T00074_A21ComprasTickets_AnioMovil, T00074_n21ComprasTickets_AnioMovil, T00074_A22ComprasImporte_AnioMovil, T00074_n22ComprasImporte_AnioMovil,
               T00074_A23ComprasArticulos_AnioMovil, T00074_n23ComprasArticulos_AnioMovil
               }
               , new Object[] {
               T00075_A7Periodo
               }
               , new Object[] {
               T00076_A7Periodo
               }
               , new Object[] {
               T00077_A7Periodo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000711_A7Periodo
               }
            }
         );
         AV11Pgmname = "Version1.ResumenRFMGlobal";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_3 ;
      private int Z8Corte1 ;
      private int Z9Corte2 ;
      private int Z10RFM ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPeriodo_Enabled ;
      private int A8Corte1 ;
      private int edtCorte1_Enabled ;
      private int A9Corte2 ;
      private int edtCorte2_Enabled ;
      private int A10RFM ;
      private int edtRFM_Enabled ;
      private int edtClientesDelAnio_Enabled ;
      private int edtClientesDelMes_Enabled ;
      private int edtMinRecencia_Enabled ;
      private int edtMaxRecencia_Enabled ;
      private int edtAvgRecencia_Enabled ;
      private int edtMinFrecuencia_Enabled ;
      private int edtMaxFrecuencia_Enabled ;
      private int edtAvgFrecuencia_Enabled ;
      private int edtMinValorMonetario_Enabled ;
      private int edtMaxValorMonetario_Enabled ;
      private int edtAvgValorMonetario_Enabled ;
      private int edtComprasTickets_AnioMovil_Enabled ;
      private int edtComprasImporte_AnioMovil_Enabled ;
      private int edtComprasArticulos_AnioMovil_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z11ClientesDelAnio ;
      private long Z12ClientesDelMes ;
      private long Z13MinRecencia ;
      private long Z14MaxRecencia ;
      private long Z24AvgRecencia ;
      private long Z21ComprasTickets_AnioMovil ;
      private long Z23ComprasArticulos_AnioMovil ;
      private long A11ClientesDelAnio ;
      private long A12ClientesDelMes ;
      private long A13MinRecencia ;
      private long A14MaxRecencia ;
      private long A24AvgRecencia ;
      private long A21ComprasTickets_AnioMovil ;
      private long A23ComprasArticulos_AnioMovil ;
      private decimal Z15MinFrecuencia ;
      private decimal Z16MaxFrecuencia ;
      private decimal Z17AvgFrecuencia ;
      private decimal Z18MinValorMonetario ;
      private decimal Z19MaxValorMonetario ;
      private decimal Z20AvgValorMonetario ;
      private decimal Z22ComprasImporte_AnioMovil ;
      private decimal A15MinFrecuencia ;
      private decimal A16MaxFrecuencia ;
      private decimal A17AvgFrecuencia ;
      private decimal A18MinValorMonetario ;
      private decimal A19MaxValorMonetario ;
      private decimal A20AvgValorMonetario ;
      private decimal A22ComprasImporte_AnioMovil ;
      private String sPrefix ;
      private String wcpOGx_mode ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String Gx_mode ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtPeriodo_Internalname ;
      private String divMaintable_Internalname ;
      private String divTitlecontainer_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String ClassString ;
      private String StyleString ;
      private String divFormcontainer_Internalname ;
      private String divToolbarcell_Internalname ;
      private String TempTags ;
      private String bttBtn_first_Internalname ;
      private String bttBtn_first_Jsonclick ;
      private String bttBtn_previous_Internalname ;
      private String bttBtn_previous_Jsonclick ;
      private String bttBtn_next_Internalname ;
      private String bttBtn_next_Jsonclick ;
      private String bttBtn_last_Internalname ;
      private String bttBtn_last_Jsonclick ;
      private String bttBtn_select_Internalname ;
      private String bttBtn_select_Jsonclick ;
      private String edtPeriodo_Jsonclick ;
      private String edtCorte1_Internalname ;
      private String edtCorte1_Jsonclick ;
      private String edtCorte2_Internalname ;
      private String edtCorte2_Jsonclick ;
      private String edtRFM_Internalname ;
      private String edtRFM_Jsonclick ;
      private String edtClientesDelAnio_Internalname ;
      private String edtClientesDelAnio_Jsonclick ;
      private String edtClientesDelMes_Internalname ;
      private String edtClientesDelMes_Jsonclick ;
      private String edtMinRecencia_Internalname ;
      private String edtMinRecencia_Jsonclick ;
      private String edtMaxRecencia_Internalname ;
      private String edtMaxRecencia_Jsonclick ;
      private String edtAvgRecencia_Internalname ;
      private String edtAvgRecencia_Jsonclick ;
      private String edtMinFrecuencia_Internalname ;
      private String edtMinFrecuencia_Jsonclick ;
      private String edtMaxFrecuencia_Internalname ;
      private String edtMaxFrecuencia_Jsonclick ;
      private String edtAvgFrecuencia_Internalname ;
      private String edtAvgFrecuencia_Jsonclick ;
      private String edtMinValorMonetario_Internalname ;
      private String edtMinValorMonetario_Jsonclick ;
      private String edtMaxValorMonetario_Internalname ;
      private String edtMaxValorMonetario_Jsonclick ;
      private String edtAvgValorMonetario_Internalname ;
      private String edtAvgValorMonetario_Jsonclick ;
      private String edtComprasTickets_AnioMovil_Internalname ;
      private String edtComprasTickets_AnioMovil_Jsonclick ;
      private String edtComprasImporte_AnioMovil_Internalname ;
      private String edtComprasImporte_AnioMovil_Jsonclick ;
      private String edtComprasArticulos_AnioMovil_Internalname ;
      private String edtComprasArticulos_AnioMovil_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String AV11Pgmname ;
      private String hsh ;
      private String sMode3 ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n11ClientesDelAnio ;
      private bool n21ComprasTickets_AnioMovil ;
      private bool n22ComprasImporte_AnioMovil ;
      private bool n23ComprasArticulos_AnioMovil ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private String wcpOAV7Periodo ;
      private String Z7Periodo ;
      private String AV7Periodo ;
      private String A7Periodo ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] T00074_A7Periodo ;
      private int[] T00074_A8Corte1 ;
      private int[] T00074_A9Corte2 ;
      private int[] T00074_A10RFM ;
      private long[] T00074_A11ClientesDelAnio ;
      private bool[] T00074_n11ClientesDelAnio ;
      private long[] T00074_A12ClientesDelMes ;
      private long[] T00074_A13MinRecencia ;
      private long[] T00074_A14MaxRecencia ;
      private long[] T00074_A24AvgRecencia ;
      private decimal[] T00074_A15MinFrecuencia ;
      private decimal[] T00074_A16MaxFrecuencia ;
      private decimal[] T00074_A17AvgFrecuencia ;
      private decimal[] T00074_A18MinValorMonetario ;
      private decimal[] T00074_A19MaxValorMonetario ;
      private decimal[] T00074_A20AvgValorMonetario ;
      private long[] T00074_A21ComprasTickets_AnioMovil ;
      private bool[] T00074_n21ComprasTickets_AnioMovil ;
      private decimal[] T00074_A22ComprasImporte_AnioMovil ;
      private bool[] T00074_n22ComprasImporte_AnioMovil ;
      private long[] T00074_A23ComprasArticulos_AnioMovil ;
      private bool[] T00074_n23ComprasArticulos_AnioMovil ;
      private String[] T00075_A7Periodo ;
      private String[] T00073_A7Periodo ;
      private int[] T00073_A8Corte1 ;
      private int[] T00073_A9Corte2 ;
      private int[] T00073_A10RFM ;
      private long[] T00073_A11ClientesDelAnio ;
      private bool[] T00073_n11ClientesDelAnio ;
      private long[] T00073_A12ClientesDelMes ;
      private long[] T00073_A13MinRecencia ;
      private long[] T00073_A14MaxRecencia ;
      private long[] T00073_A24AvgRecencia ;
      private decimal[] T00073_A15MinFrecuencia ;
      private decimal[] T00073_A16MaxFrecuencia ;
      private decimal[] T00073_A17AvgFrecuencia ;
      private decimal[] T00073_A18MinValorMonetario ;
      private decimal[] T00073_A19MaxValorMonetario ;
      private decimal[] T00073_A20AvgValorMonetario ;
      private long[] T00073_A21ComprasTickets_AnioMovil ;
      private bool[] T00073_n21ComprasTickets_AnioMovil ;
      private decimal[] T00073_A22ComprasImporte_AnioMovil ;
      private bool[] T00073_n22ComprasImporte_AnioMovil ;
      private long[] T00073_A23ComprasArticulos_AnioMovil ;
      private bool[] T00073_n23ComprasArticulos_AnioMovil ;
      private String[] T00076_A7Periodo ;
      private String[] T00077_A7Periodo ;
      private String[] T00072_A7Periodo ;
      private int[] T00072_A8Corte1 ;
      private int[] T00072_A9Corte2 ;
      private int[] T00072_A10RFM ;
      private long[] T00072_A11ClientesDelAnio ;
      private bool[] T00072_n11ClientesDelAnio ;
      private long[] T00072_A12ClientesDelMes ;
      private long[] T00072_A13MinRecencia ;
      private long[] T00072_A14MaxRecencia ;
      private long[] T00072_A24AvgRecencia ;
      private decimal[] T00072_A15MinFrecuencia ;
      private decimal[] T00072_A16MaxFrecuencia ;
      private decimal[] T00072_A17AvgFrecuencia ;
      private decimal[] T00072_A18MinValorMonetario ;
      private decimal[] T00072_A19MaxValorMonetario ;
      private decimal[] T00072_A20AvgValorMonetario ;
      private long[] T00072_A21ComprasTickets_AnioMovil ;
      private bool[] T00072_n21ComprasTickets_AnioMovil ;
      private decimal[] T00072_A22ComprasImporte_AnioMovil ;
      private bool[] T00072_n22ComprasImporte_AnioMovil ;
      private long[] T00072_A23ComprasArticulos_AnioMovil ;
      private bool[] T00072_n23ComprasArticulos_AnioMovil ;
      private String[] T000711_A7Periodo ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.version1.SdtTransactionContext AV9TrnContext ;
   }

   public class resumenrfmglobal__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
       }
    }

    public String getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class resumenrfmglobal__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00074 ;
        prmT00074 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT00075 ;
        prmT00075 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT00073 ;
        prmT00073 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT00076 ;
        prmT00076 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT00077 ;
        prmT00077 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT00072 ;
        prmT00072 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT00078 ;
        prmT00078 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0} ,
        new Object[] {"@Corte1",SqlDbType.Int,8,0} ,
        new Object[] {"@Corte2",SqlDbType.Int,8,0} ,
        new Object[] {"@RFM",SqlDbType.Int,8,0} ,
        new Object[] {"@ClientesDelAnio",SqlDbType.Decimal,10,0} ,
        new Object[] {"@ClientesDelMes",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MinRecencia",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MaxRecencia",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AvgRecencia",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MinFrecuencia",SqlDbType.Decimal,10,6} ,
        new Object[] {"@MaxFrecuencia",SqlDbType.Decimal,10,6} ,
        new Object[] {"@AvgFrecuencia",SqlDbType.Decimal,10,6} ,
        new Object[] {"@MinValorMonetario",SqlDbType.Decimal,12,8} ,
        new Object[] {"@MaxValorMonetario",SqlDbType.Decimal,12,8} ,
        new Object[] {"@AvgValorMonetario",SqlDbType.Decimal,12,8} ,
        new Object[] {"@ComprasTickets_AnioMovil",SqlDbType.Decimal,12,0} ,
        new Object[] {"@ComprasImporte_AnioMovil",SqlDbType.Decimal,12,2} ,
        new Object[] {"@ComprasArticulos_AnioMovil",SqlDbType.Decimal,12,0}
        } ;
        Object[] prmT00079 ;
        prmT00079 = new Object[] {
        new Object[] {"@Corte1",SqlDbType.Int,8,0} ,
        new Object[] {"@Corte2",SqlDbType.Int,8,0} ,
        new Object[] {"@RFM",SqlDbType.Int,8,0} ,
        new Object[] {"@ClientesDelAnio",SqlDbType.Decimal,10,0} ,
        new Object[] {"@ClientesDelMes",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MinRecencia",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MaxRecencia",SqlDbType.Decimal,10,0} ,
        new Object[] {"@AvgRecencia",SqlDbType.Decimal,10,0} ,
        new Object[] {"@MinFrecuencia",SqlDbType.Decimal,10,6} ,
        new Object[] {"@MaxFrecuencia",SqlDbType.Decimal,10,6} ,
        new Object[] {"@AvgFrecuencia",SqlDbType.Decimal,10,6} ,
        new Object[] {"@MinValorMonetario",SqlDbType.Decimal,12,8} ,
        new Object[] {"@MaxValorMonetario",SqlDbType.Decimal,12,8} ,
        new Object[] {"@AvgValorMonetario",SqlDbType.Decimal,12,8} ,
        new Object[] {"@ComprasTickets_AnioMovil",SqlDbType.Decimal,12,0} ,
        new Object[] {"@ComprasImporte_AnioMovil",SqlDbType.Decimal,12,2} ,
        new Object[] {"@ComprasArticulos_AnioMovil",SqlDbType.Decimal,12,0} ,
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT000710 ;
        prmT000710 = new Object[] {
        new Object[] {"@Periodo",SqlDbType.NVarChar,6,0}
        } ;
        Object[] prmT000711 ;
        prmT000711 = new Object[] {
        } ;
        def= new CursorDef[] {
            new CursorDef("T00072", "SELECT [Periodo], [Corte1], [Corte2], [RFM], [ClientesDelAnio], [ClientesDelMes], [MinRecencia], [MaxRecencia], [AvgRecencia], [MinFrecuencia], [MaxFrecuencia], [AvgFrecuencia], [MinValorMonetario], [MaxValorMonetario], [AvgValorMonetario], [ComprasTickets_AnioMovil], [ComprasImporte_AnioMovil], [ComprasArticulos_AnioMovil] FROM [ResumenRFMGlobal] WITH (UPDLOCK) WHERE [Periodo] = @Periodo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00073", "SELECT [Periodo], [Corte1], [Corte2], [RFM], [ClientesDelAnio], [ClientesDelMes], [MinRecencia], [MaxRecencia], [AvgRecencia], [MinFrecuencia], [MaxFrecuencia], [AvgFrecuencia], [MinValorMonetario], [MaxValorMonetario], [AvgValorMonetario], [ComprasTickets_AnioMovil], [ComprasImporte_AnioMovil], [ComprasArticulos_AnioMovil] FROM [ResumenRFMGlobal] WHERE [Periodo] = @Periodo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00074", "SELECT TM1.[Periodo], TM1.[Corte1], TM1.[Corte2], TM1.[RFM], TM1.[ClientesDelAnio], TM1.[ClientesDelMes], TM1.[MinRecencia], TM1.[MaxRecencia], TM1.[AvgRecencia], TM1.[MinFrecuencia], TM1.[MaxFrecuencia], TM1.[AvgFrecuencia], TM1.[MinValorMonetario], TM1.[MaxValorMonetario], TM1.[AvgValorMonetario], TM1.[ComprasTickets_AnioMovil], TM1.[ComprasImporte_AnioMovil], TM1.[ComprasArticulos_AnioMovil] FROM [ResumenRFMGlobal] TM1 WHERE TM1.[Periodo] = @Periodo ORDER BY TM1.[Periodo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00075", "SELECT [Periodo] FROM [ResumenRFMGlobal] WHERE [Periodo] = @Periodo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00076", "SELECT TOP 1 [Periodo] FROM [ResumenRFMGlobal] WHERE ( [Periodo] > @Periodo) ORDER BY [Periodo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00077", "SELECT TOP 1 [Periodo] FROM [ResumenRFMGlobal] WHERE ( [Periodo] < @Periodo) ORDER BY [Periodo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00078", "INSERT INTO [ResumenRFMGlobal]([Periodo], [Corte1], [Corte2], [RFM], [ClientesDelAnio], [ClientesDelMes], [MinRecencia], [MaxRecencia], [AvgRecencia], [MinFrecuencia], [MaxFrecuencia], [AvgFrecuencia], [MinValorMonetario], [MaxValorMonetario], [AvgValorMonetario], [ComprasTickets_AnioMovil], [ComprasImporte_AnioMovil], [ComprasArticulos_AnioMovil]) VALUES(@Periodo, @Corte1, @Corte2, @RFM, @ClientesDelAnio, @ClientesDelMes, @MinRecencia, @MaxRecencia, @AvgRecencia, @MinFrecuencia, @MaxFrecuencia, @AvgFrecuencia, @MinValorMonetario, @MaxValorMonetario, @AvgValorMonetario, @ComprasTickets_AnioMovil, @ComprasImporte_AnioMovil, @ComprasArticulos_AnioMovil)", GxErrorMask.GX_NOMASK,prmT00078)
           ,new CursorDef("T00079", "UPDATE [ResumenRFMGlobal] SET [Corte1]=@Corte1, [Corte2]=@Corte2, [RFM]=@RFM, [ClientesDelAnio]=@ClientesDelAnio, [ClientesDelMes]=@ClientesDelMes, [MinRecencia]=@MinRecencia, [MaxRecencia]=@MaxRecencia, [AvgRecencia]=@AvgRecencia, [MinFrecuencia]=@MinFrecuencia, [MaxFrecuencia]=@MaxFrecuencia, [AvgFrecuencia]=@AvgFrecuencia, [MinValorMonetario]=@MinValorMonetario, [MaxValorMonetario]=@MaxValorMonetario, [AvgValorMonetario]=@AvgValorMonetario, [ComprasTickets_AnioMovil]=@ComprasTickets_AnioMovil, [ComprasImporte_AnioMovil]=@ComprasImporte_AnioMovil, [ComprasArticulos_AnioMovil]=@ComprasArticulos_AnioMovil  WHERE [Periodo] = @Periodo", GxErrorMask.GX_NOMASK,prmT00079)
           ,new CursorDef("T000710", "DELETE FROM [ResumenRFMGlobal]  WHERE [Periodo] = @Periodo", GxErrorMask.GX_NOMASK,prmT000710)
           ,new CursorDef("T000711", "SELECT [Periodo] FROM [ResumenRFMGlobal] ORDER BY [Periodo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2) ;
              ((int[]) buf[2])[0] = rslt.getInt(3) ;
              ((int[]) buf[3])[0] = rslt.getInt(4) ;
              ((long[]) buf[4])[0] = rslt.getLong(5) ;
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6) ;
              ((long[]) buf[7])[0] = rslt.getLong(7) ;
              ((long[]) buf[8])[0] = rslt.getLong(8) ;
              ((long[]) buf[9])[0] = rslt.getLong(9) ;
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10) ;
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11) ;
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12) ;
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13) ;
              ((decimal[]) buf[14])[0] = rslt.getDecimal(14) ;
              ((decimal[]) buf[15])[0] = rslt.getDecimal(15) ;
              ((long[]) buf[16])[0] = rslt.getLong(16) ;
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(17) ;
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((long[]) buf[20])[0] = rslt.getLong(18) ;
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              return;
           case 1 :
              ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
              ((int[]) buf[1])[0] = rslt.getInt(2) ;
              ((int[]) buf[2])[0] = rslt.getInt(3) ;
              ((int[]) buf[3])[0] = rslt.getInt(4) ;
              ((long[]) buf[4])[0] = rslt.getLong(5) ;
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6) ;
              ((long[]) buf[7])[0] = rslt.getLong(7) ;
              ((long[]) buf[8])[0] = rslt.getLong(8) ;
              ((long[]) buf[9])[0] = rslt.getLong(9) ;
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10) ;
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11) ;
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12) ;
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13) ;
              ((decimal[]) buf[14])[0] = rslt.getDecimal(14) ;
              ((decimal[]) buf[15])[0] = rslt.getDecimal(15) ;
              ((long[]) buf[16])[0] = rslt.getLong(16) ;
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(17) ;
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((long[]) buf[20])[0] = rslt.getLong(18) ;
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              return;
           case 2 :
              ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
              ((int[]) buf[1])[0] = rslt.getInt(2) ;
              ((int[]) buf[2])[0] = rslt.getInt(3) ;
              ((int[]) buf[3])[0] = rslt.getInt(4) ;
              ((long[]) buf[4])[0] = rslt.getLong(5) ;
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((long[]) buf[6])[0] = rslt.getLong(6) ;
              ((long[]) buf[7])[0] = rslt.getLong(7) ;
              ((long[]) buf[8])[0] = rslt.getLong(8) ;
              ((long[]) buf[9])[0] = rslt.getLong(9) ;
              ((decimal[]) buf[10])[0] = rslt.getDecimal(10) ;
              ((decimal[]) buf[11])[0] = rslt.getDecimal(11) ;
              ((decimal[]) buf[12])[0] = rslt.getDecimal(12) ;
              ((decimal[]) buf[13])[0] = rslt.getDecimal(13) ;
              ((decimal[]) buf[14])[0] = rslt.getDecimal(14) ;
              ((decimal[]) buf[15])[0] = rslt.getDecimal(15) ;
              ((long[]) buf[16])[0] = rslt.getLong(16) ;
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(17) ;
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((long[]) buf[20])[0] = rslt.getLong(18) ;
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              return;
           case 3 :
              ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
              return;
           case 4 :
              ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
              return;
           case 5 :
              ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
              return;
           case 9 :
              ((String[]) buf[0])[0] = rslt.getVarchar(1) ;
              return;
     }
  }

  public void setParameters( int cursor ,
                             IFieldSetter stmt ,
                             Object[] parms )
  {
     switch ( cursor )
     {
           case 0 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
           case 1 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
           case 2 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
           case 3 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
           case 4 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
           case 5 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
           case 6 :
              stmt.SetParameter(1, (String)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              stmt.SetParameter(4, (int)parms[3]);
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 5 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(5, (long)parms[5]);
              }
              stmt.SetParameter(6, (long)parms[6]);
              stmt.SetParameter(7, (long)parms[7]);
              stmt.SetParameter(8, (long)parms[8]);
              stmt.SetParameter(9, (long)parms[9]);
              stmt.SetParameter(10, (decimal)parms[10]);
              stmt.SetParameter(11, (decimal)parms[11]);
              stmt.SetParameter(12, (decimal)parms[12]);
              stmt.SetParameter(13, (decimal)parms[13]);
              stmt.SetParameter(14, (decimal)parms[14]);
              stmt.SetParameter(15, (decimal)parms[15]);
              if ( (bool)parms[16] )
              {
                 stmt.setNull( 16 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(16, (long)parms[17]);
              }
              if ( (bool)parms[18] )
              {
                 stmt.setNull( 17 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(17, (decimal)parms[19]);
              }
              if ( (bool)parms[20] )
              {
                 stmt.setNull( 18 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(18, (long)parms[21]);
              }
              return;
           case 7 :
              stmt.SetParameter(1, (int)parms[0]);
              stmt.SetParameter(2, (int)parms[1]);
              stmt.SetParameter(3, (int)parms[2]);
              if ( (bool)parms[3] )
              {
                 stmt.setNull( 4 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(4, (long)parms[4]);
              }
              stmt.SetParameter(5, (long)parms[5]);
              stmt.SetParameter(6, (long)parms[6]);
              stmt.SetParameter(7, (long)parms[7]);
              stmt.SetParameter(8, (long)parms[8]);
              stmt.SetParameter(9, (decimal)parms[9]);
              stmt.SetParameter(10, (decimal)parms[10]);
              stmt.SetParameter(11, (decimal)parms[11]);
              stmt.SetParameter(12, (decimal)parms[12]);
              stmt.SetParameter(13, (decimal)parms[13]);
              stmt.SetParameter(14, (decimal)parms[14]);
              if ( (bool)parms[15] )
              {
                 stmt.setNull( 15 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(15, (long)parms[16]);
              }
              if ( (bool)parms[17] )
              {
                 stmt.setNull( 16 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(16, (decimal)parms[18]);
              }
              if ( (bool)parms[19] )
              {
                 stmt.setNull( 17 , SqlDbType.Decimal );
              }
              else
              {
                 stmt.SetParameter(17, (long)parms[20]);
              }
              stmt.SetParameter(18, (String)parms[21]);
              return;
           case 8 :
              stmt.SetParameter(1, (String)parms[0]);
              return;
     }
  }

}

}
