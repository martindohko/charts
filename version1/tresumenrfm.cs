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
   public class tresumenrfm : GXHttpHandler
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
               AV7Region = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV7Region", StringUtil.LTrimStr( (decimal)(AV7Region), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vREGION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Region), "ZZZ9"), context));
               AV8Sucursal = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "AV8Sucursal", StringUtil.LTrimStr( (decimal)(AV8Sucursal), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSUCURSAL", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8Sucursal), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "t Resumen RFM", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtRegion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tresumenrfm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tresumenrfm( IGxContext context )
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
                           short aP1_Region ,
                           short aP2_Sucursal )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Region = aP1_Region;
         this.AV8Sucursal = aP2_Sucursal;
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
            RenderHtmlCloseForm011( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "t Resumen RFM", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_Version1\\tResumenRFM.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Version1\\tResumenRFM.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRegion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegion_Internalname, "Region", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRegion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Region), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1Region), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegion_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSucursal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSucursal_Internalname, "Sucursal", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSucursal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2Sucursal), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2Sucursal), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSucursal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSucursal_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFMAnt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFMAnt_Internalname, "RFMAnt", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFMAnt_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3RFMAnt), 8, 0, ".", "")), ((edtRFMAnt_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A3RFMAnt), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A3RFMAnt), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFMAnt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFMAnt_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRFMAct_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRFMAct_Internalname, "RFMAct", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRFMAct_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4RFMAct), 8, 0, ".", "")), ((edtRFMAct_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A4RFMAct), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A4RFMAct), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFMAct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFMAct_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClientes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClientes_Internalname, "Clientes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClientes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5Clientes), 8, 0, ".", "")), ((edtClientes_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A5Clientes), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A5Clientes), "ZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientes_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Version1\\tResumenRFM.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Version1\\tResumenRFM.htm");
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1Region = (short)(context.localUtil.CToN( cgiGet( "Z1Region"), ".", ","));
               Z2Sucursal = (short)(context.localUtil.CToN( cgiGet( "Z2Sucursal"), ".", ","));
               Z3RFMAnt = (int)(context.localUtil.CToN( cgiGet( "Z3RFMAnt"), ".", ","));
               n3RFMAnt = ((0==A3RFMAnt) ? true : false);
               Z4RFMAct = (int)(context.localUtil.CToN( cgiGet( "Z4RFMAct"), ".", ","));
               n4RFMAct = ((0==A4RFMAct) ? true : false);
               Z5Clientes = (int)(context.localUtil.CToN( cgiGet( "Z5Clientes"), ".", ","));
               n5Clientes = ((0==A5Clientes) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7Region = (short)(context.localUtil.CToN( cgiGet( "vREGION"), ".", ","));
               AV8Sucursal = (short)(context.localUtil.CToN( cgiGet( "vSUCURSAL"), ".", ","));
               AV12Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtRegion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRegion_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REGION");
                  AnyError = 1;
                  GX_FocusControl = edtRegion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1Region = 0;
                  AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
               }
               else
               {
                  A1Region = (short)(context.localUtil.CToN( cgiGet( edtRegion_Internalname), ".", ","));
                  AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSucursal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSucursal_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUCURSAL");
                  AnyError = 1;
                  GX_FocusControl = edtSucursal_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2Sucursal = 0;
                  AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
               }
               else
               {
                  A2Sucursal = (short)(context.localUtil.CToN( cgiGet( edtSucursal_Internalname), ".", ","));
                  AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtRFMAnt_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFMAnt_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFMANT");
                  AnyError = 1;
                  GX_FocusControl = edtRFMAnt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3RFMAnt = 0;
                  n3RFMAnt = false;
                  AssignAttri("", false, "A3RFMAnt", StringUtil.LTrimStr( (decimal)(A3RFMAnt), 8, 0));
               }
               else
               {
                  A3RFMAnt = (int)(context.localUtil.CToN( cgiGet( edtRFMAnt_Internalname), ".", ","));
                  n3RFMAnt = false;
                  AssignAttri("", false, "A3RFMAnt", StringUtil.LTrimStr( (decimal)(A3RFMAnt), 8, 0));
               }
               n3RFMAnt = ((0==A3RFMAnt) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtRFMAct_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRFMAct_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RFMACT");
                  AnyError = 1;
                  GX_FocusControl = edtRFMAct_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4RFMAct = 0;
                  n4RFMAct = false;
                  AssignAttri("", false, "A4RFMAct", StringUtil.LTrimStr( (decimal)(A4RFMAct), 8, 0));
               }
               else
               {
                  A4RFMAct = (int)(context.localUtil.CToN( cgiGet( edtRFMAct_Internalname), ".", ","));
                  n4RFMAct = false;
                  AssignAttri("", false, "A4RFMAct", StringUtil.LTrimStr( (decimal)(A4RFMAct), 8, 0));
               }
               n4RFMAct = ((0==A4RFMAct) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClientes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClientes_Internalname), ".", ",") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTES");
                  AnyError = 1;
                  GX_FocusControl = edtClientes_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A5Clientes = 0;
                  n5Clientes = false;
                  AssignAttri("", false, "A5Clientes", StringUtil.LTrimStr( (decimal)(A5Clientes), 8, 0));
               }
               else
               {
                  A5Clientes = (int)(context.localUtil.CToN( cgiGet( edtClientes_Internalname), ".", ","));
                  n5Clientes = false;
                  AssignAttri("", false, "A5Clientes", StringUtil.LTrimStr( (decimal)(A5Clientes), 8, 0));
               }
               n5Clientes = ((0==A5Clientes) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"tResumenRFM");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("version1\\tresumenrfm:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1Region = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
                  A2Sucursal = (short)(NumberUtil.Val( GetNextPar( ), "."));
                  AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "REGION");
                        AnyError = 1;
                        GX_FocusControl = edtRegion_Internalname;
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
                        E11012 ();
                     }
                     else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                     {
                        context.wbHandled = 1;
                        dynload_actions( ) ;
                        /* Execute user event: After Trn */
                        E12012 ();
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         if ( ! new GeneXus.Programs.version1.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("version1.notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV12Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "TransactionContext", "RFM");
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("version1.wwtresumenrfm.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z3RFMAnt = T00013_A3RFMAnt[0];
               Z4RFMAct = T00013_A4RFMAct[0];
               Z5Clientes = T00013_A5Clientes[0];
            }
            else
            {
               Z3RFMAnt = A3RFMAnt;
               Z4RFMAct = A4RFMAct;
               Z5Clientes = A5Clientes;
            }
         }
         if ( GX_JID == -7 )
         {
            Z1Region = A1Region;
            Z2Sucursal = A2Sucursal;
            Z3RFMAnt = A3RFMAnt;
            Z4RFMAct = A4RFMAct;
            Z5Clientes = A5Clientes;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Region) )
         {
            A1Region = AV7Region;
            AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
         }
         if ( ! (0==AV7Region) )
         {
            edtRegion_Enabled = 0;
            AssignProp("", false, edtRegion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegion_Enabled), 5, 0), true);
         }
         else
         {
            edtRegion_Enabled = 1;
            AssignProp("", false, edtRegion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegion_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7Region) )
         {
            edtRegion_Enabled = 0;
            AssignProp("", false, edtRegion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegion_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8Sucursal) )
         {
            A2Sucursal = AV8Sucursal;
            AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
         }
         if ( ! (0==AV8Sucursal) )
         {
            edtSucursal_Enabled = 0;
            AssignProp("", false, edtSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSucursal_Enabled), 5, 0), true);
         }
         else
         {
            edtSucursal_Enabled = 1;
            AssignProp("", false, edtSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSucursal_Enabled), 5, 0), true);
         }
         if ( ! (0==AV8Sucursal) )
         {
            edtSucursal_Enabled = 0;
            AssignProp("", false, edtSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSucursal_Enabled), 5, 0), true);
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
            AV12Pgmname = "Version1.tResumenRFM";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A3RFMAnt = T00014_A3RFMAnt[0];
            n3RFMAnt = T00014_n3RFMAnt[0];
            AssignAttri("", false, "A3RFMAnt", StringUtil.LTrimStr( (decimal)(A3RFMAnt), 8, 0));
            A4RFMAct = T00014_A4RFMAct[0];
            n4RFMAct = T00014_n4RFMAct[0];
            AssignAttri("", false, "A4RFMAct", StringUtil.LTrimStr( (decimal)(A4RFMAct), 8, 0));
            A5Clientes = T00014_A5Clientes[0];
            n5Clientes = T00014_n5Clientes[0];
            AssignAttri("", false, "A5Clientes", StringUtil.LTrimStr( (decimal)(A5Clientes), 8, 0));
            ZM011( -7) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV12Pgmname = "Version1.tResumenRFM";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "Version1.tResumenRFM";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 7) ;
            RcdFound1 = 1;
            A1Region = T00013_A1Region[0];
            AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
            A2Sucursal = T00013_A2Sucursal[0];
            AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
            A3RFMAnt = T00013_A3RFMAnt[0];
            n3RFMAnt = T00013_n3RFMAnt[0];
            AssignAttri("", false, "A3RFMAnt", StringUtil.LTrimStr( (decimal)(A3RFMAnt), 8, 0));
            A4RFMAct = T00013_A4RFMAct[0];
            n4RFMAct = T00013_n4RFMAct[0];
            AssignAttri("", false, "A4RFMAct", StringUtil.LTrimStr( (decimal)(A4RFMAct), 8, 0));
            A5Clientes = T00013_A5Clientes[0];
            n5Clientes = T00013_n5Clientes[0];
            AssignAttri("", false, "A5Clientes", StringUtil.LTrimStr( (decimal)(A5Clientes), 8, 0));
            Z1Region = A1Region;
            Z2Sucursal = A2Sucursal;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1Region[0] < A1Region ) || ( T00016_A1Region[0] == A1Region ) && ( T00016_A2Sucursal[0] < A2Sucursal ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00016_A1Region[0] > A1Region ) || ( T00016_A1Region[0] == A1Region ) && ( T00016_A2Sucursal[0] > A2Sucursal ) ) )
            {
               A1Region = T00016_A1Region[0];
               AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
               A2Sucursal = T00016_A2Sucursal[0];
               AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1Region[0] > A1Region ) || ( T00017_A1Region[0] == A1Region ) && ( T00017_A2Sucursal[0] > A2Sucursal ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00017_A1Region[0] < A1Region ) || ( T00017_A1Region[0] == A1Region ) && ( T00017_A2Sucursal[0] < A2Sucursal ) ) )
            {
               A1Region = T00017_A1Region[0];
               AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
               A2Sucursal = T00017_A2Sucursal[0];
               AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRegion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
               {
                  A1Region = Z1Region;
                  AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
                  A2Sucursal = Z2Sucursal;
                  AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REGION");
                  AnyError = 1;
                  GX_FocusControl = edtRegion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRegion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtRegion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtRegion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REGION");
                     AnyError = 1;
                     GX_FocusControl = edtRegion_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRegion_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
         {
            A1Region = Z1Region;
            AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
            A2Sucursal = Z2Sucursal;
            AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REGION");
            AnyError = 1;
            GX_FocusControl = edtRegion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRegion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1Region, A2Sucursal});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tResumenRFM"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z3RFMAnt != T00012_A3RFMAnt[0] ) || ( Z4RFMAct != T00012_A4RFMAct[0] ) || ( Z5Clientes != T00012_A5Clientes[0] ) )
            {
               if ( Z3RFMAnt != T00012_A3RFMAnt[0] )
               {
                  GXUtil.WriteLog("version1.tresumenrfm:[seudo value changed for attri]"+"RFMAnt");
                  GXUtil.WriteLogRaw("Old: ",Z3RFMAnt);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3RFMAnt[0]);
               }
               if ( Z4RFMAct != T00012_A4RFMAct[0] )
               {
                  GXUtil.WriteLog("version1.tresumenrfm:[seudo value changed for attri]"+"RFMAct");
                  GXUtil.WriteLogRaw("Old: ",Z4RFMAct);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4RFMAct[0]);
               }
               if ( Z5Clientes != T00012_A5Clientes[0] )
               {
                  GXUtil.WriteLog("version1.tresumenrfm:[seudo value changed for attri]"+"Clientes");
                  GXUtil.WriteLogRaw("Old: ",Z5Clientes);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5Clientes[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tResumenRFM"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_default.execute(6, new Object[] {A1Region, A2Sucursal, n3RFMAnt, A3RFMAnt, n4RFMAct, A4RFMAct, n5Clientes, A5Clientes});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("tResumenRFM") ;
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
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_default.execute(7, new Object[] {n3RFMAnt, A3RFMAnt, n4RFMAct, A4RFMAct, n5Clientes, A5Clientes, A1Region, A2Sucursal});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("tResumenRFM") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tResumenRFM"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_default.execute(8, new Object[] {A1Region, A2Sucursal});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("tResumenRFM") ;
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Version1.tResumenRFM";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("version1.tresumenrfm",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("version1.tresumenrfm",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000111 */
         pr_default.execute(9);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1Region = T000111_A1Region[0];
            AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
            A2Sucursal = T000111_A2Sucursal[0];
            AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1Region = T000111_A1Region[0];
            AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
            A2Sucursal = T000111_A2Sucursal[0];
            AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtRegion_Enabled = 0;
         AssignProp("", false, edtRegion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegion_Enabled), 5, 0), true);
         edtSucursal_Enabled = 0;
         AssignProp("", false, edtSucursal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSucursal_Enabled), 5, 0), true);
         edtRFMAnt_Enabled = 0;
         AssignProp("", false, edtRFMAnt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFMAnt_Enabled), 5, 0), true);
         edtRFMAct_Enabled = 0;
         AssignProp("", false, edtRFMAct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRFMAct_Enabled), 5, 0), true);
         edtClientes_Enabled = 0;
         AssignProp("", false, edtClientes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClientes_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.SendWebValue( "t Resumen RFM") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202091115385683", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("version1.tresumenrfm.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode("" +AV7Region) + "," + UrlEncode("" +AV8Sucursal)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"tResumenRFM");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("version1\\tresumenrfm:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1Region", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1Region), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2Sucursal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2Sucursal), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z3RFMAnt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3RFMAnt), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4RFMAct", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4RFMAct), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5Clientes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5Clientes), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vREGION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Region), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREGION", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Region), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vSUCURSAL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Sucursal), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUCURSAL", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV8Sucursal), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
      }

      protected void RenderHtmlCloseForm011( )
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
         return "Version1.tResumenRFM" ;
      }

      public override String GetPgmdesc( )
      {
         return "t Resumen RFM" ;
      }

      protected void InitializeNonKey011( )
      {
         A3RFMAnt = 0;
         n3RFMAnt = false;
         AssignAttri("", false, "A3RFMAnt", StringUtil.LTrimStr( (decimal)(A3RFMAnt), 8, 0));
         n3RFMAnt = ((0==A3RFMAnt) ? true : false);
         A4RFMAct = 0;
         n4RFMAct = false;
         AssignAttri("", false, "A4RFMAct", StringUtil.LTrimStr( (decimal)(A4RFMAct), 8, 0));
         n4RFMAct = ((0==A4RFMAct) ? true : false);
         A5Clientes = 0;
         n5Clientes = false;
         AssignAttri("", false, "A5Clientes", StringUtil.LTrimStr( (decimal)(A5Clientes), 8, 0));
         n5Clientes = ((0==A5Clientes) ? true : false);
         Z3RFMAnt = 0;
         Z4RFMAct = 0;
         Z5Clientes = 0;
      }

      protected void InitAll011( )
      {
         A1Region = 0;
         AssignAttri("", false, "A1Region", StringUtil.LTrimStr( (decimal)(A1Region), 4, 0));
         A2Sucursal = 0;
         AssignAttri("", false, "A2Sucursal", StringUtil.LTrimStr( (decimal)(A2Sucursal), 4, 0));
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202091115385688", true, true);
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
         context.AddJavascriptSource("version1/tresumenrfm.js", "?202091115385689", false, true);
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
         edtRegion_Internalname = "REGION";
         edtSucursal_Internalname = "SUCURSAL";
         edtRFMAnt_Internalname = "RFMANT";
         edtRFMAct_Internalname = "RFMACT";
         edtClientes_Internalname = "CLIENTES";
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
         edtClientes_Jsonclick = "";
         edtClientes_Enabled = 1;
         edtRFMAct_Jsonclick = "";
         edtRFMAct_Enabled = 1;
         edtRFMAnt_Jsonclick = "";
         edtRFMAnt_Enabled = 1;
         edtSucursal_Jsonclick = "";
         edtSucursal_Enabled = 1;
         edtRegion_Jsonclick = "";
         edtRegion_Enabled = 1;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'AV8Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Region',fld:'vREGION',pic:'ZZZ9',hsh:true},{av:'AV8Sucursal',fld:'vSUCURSAL',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_REGION","{handler:'Valid_Region',iparms:[]");
         setEventMetadata("VALID_REGION",",oparms:[]}");
         setEventMetadata("VALID_SUCURSAL","{handler:'Valid_Sucursal',iparms:[]");
         setEventMetadata("VALID_SUCURSAL",",oparms:[]}");
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
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV10TrnContext = new GeneXus.Programs.version1.SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         T00014_A1Region = new short[1] ;
         T00014_A2Sucursal = new short[1] ;
         T00014_A3RFMAnt = new int[1] ;
         T00014_n3RFMAnt = new bool[] {false} ;
         T00014_A4RFMAct = new int[1] ;
         T00014_n4RFMAct = new bool[] {false} ;
         T00014_A5Clientes = new int[1] ;
         T00014_n5Clientes = new bool[] {false} ;
         T00015_A1Region = new short[1] ;
         T00015_A2Sucursal = new short[1] ;
         T00013_A1Region = new short[1] ;
         T00013_A2Sucursal = new short[1] ;
         T00013_A3RFMAnt = new int[1] ;
         T00013_n3RFMAnt = new bool[] {false} ;
         T00013_A4RFMAct = new int[1] ;
         T00013_n4RFMAct = new bool[] {false} ;
         T00013_A5Clientes = new int[1] ;
         T00013_n5Clientes = new bool[] {false} ;
         T00016_A1Region = new short[1] ;
         T00016_A2Sucursal = new short[1] ;
         T00017_A1Region = new short[1] ;
         T00017_A2Sucursal = new short[1] ;
         T00012_A1Region = new short[1] ;
         T00012_A2Sucursal = new short[1] ;
         T00012_A3RFMAnt = new int[1] ;
         T00012_n3RFMAnt = new bool[] {false} ;
         T00012_A4RFMAct = new int[1] ;
         T00012_n4RFMAct = new bool[] {false} ;
         T00012_A5Clientes = new int[1] ;
         T00012_n5Clientes = new bool[] {false} ;
         T000111_A1Region = new short[1] ;
         T000111_A2Sucursal = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.version1.tresumenrfm__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.version1.tresumenrfm__default(),
            new Object[][] {
                new Object[] {
               T00012_A1Region, T00012_A2Sucursal, T00012_A3RFMAnt, T00012_n3RFMAnt, T00012_A4RFMAct, T00012_n4RFMAct, T00012_A5Clientes, T00012_n5Clientes
               }
               , new Object[] {
               T00013_A1Region, T00013_A2Sucursal, T00013_A3RFMAnt, T00013_n3RFMAnt, T00013_A4RFMAct, T00013_n4RFMAct, T00013_A5Clientes, T00013_n5Clientes
               }
               , new Object[] {
               T00014_A1Region, T00014_A2Sucursal, T00014_A3RFMAnt, T00014_n3RFMAnt, T00014_A4RFMAct, T00014_n4RFMAct, T00014_A5Clientes, T00014_n5Clientes
               }
               , new Object[] {
               T00015_A1Region, T00015_A2Sucursal
               }
               , new Object[] {
               T00016_A1Region, T00016_A2Sucursal
               }
               , new Object[] {
               T00017_A1Region, T00017_A2Sucursal
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A1Region, T000111_A2Sucursal
               }
            }
         );
         AV12Pgmname = "Version1.tResumenRFM";
      }

      private short wcpOAV7Region ;
      private short wcpOAV8Sucursal ;
      private short Z1Region ;
      private short Z2Sucursal ;
      private short GxWebError ;
      private short AV7Region ;
      private short AV8Sucursal ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1Region ;
      private short A2Sucursal ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_1 ;
      private int Z3RFMAnt ;
      private int Z4RFMAct ;
      private int Z5Clientes ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtRegion_Enabled ;
      private int edtSucursal_Enabled ;
      private int A3RFMAnt ;
      private int edtRFMAnt_Enabled ;
      private int A4RFMAct ;
      private int edtRFMAct_Enabled ;
      private int A5Clientes ;
      private int edtClientes_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
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
      private String edtRegion_Internalname ;
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
      private String edtRegion_Jsonclick ;
      private String edtSucursal_Internalname ;
      private String edtSucursal_Jsonclick ;
      private String edtRFMAnt_Internalname ;
      private String edtRFMAnt_Jsonclick ;
      private String edtRFMAct_Internalname ;
      private String edtRFMAct_Jsonclick ;
      private String edtClientes_Internalname ;
      private String edtClientes_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String AV12Pgmname ;
      private String hsh ;
      private String sMode1 ;
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
      private bool n3RFMAnt ;
      private bool n4RFMAct ;
      private bool n5Clientes ;
      private bool returnInSub ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00014_A1Region ;
      private short[] T00014_A2Sucursal ;
      private int[] T00014_A3RFMAnt ;
      private bool[] T00014_n3RFMAnt ;
      private int[] T00014_A4RFMAct ;
      private bool[] T00014_n4RFMAct ;
      private int[] T00014_A5Clientes ;
      private bool[] T00014_n5Clientes ;
      private short[] T00015_A1Region ;
      private short[] T00015_A2Sucursal ;
      private short[] T00013_A1Region ;
      private short[] T00013_A2Sucursal ;
      private int[] T00013_A3RFMAnt ;
      private bool[] T00013_n3RFMAnt ;
      private int[] T00013_A4RFMAct ;
      private bool[] T00013_n4RFMAct ;
      private int[] T00013_A5Clientes ;
      private bool[] T00013_n5Clientes ;
      private short[] T00016_A1Region ;
      private short[] T00016_A2Sucursal ;
      private short[] T00017_A1Region ;
      private short[] T00017_A2Sucursal ;
      private short[] T00012_A1Region ;
      private short[] T00012_A2Sucursal ;
      private int[] T00012_A3RFMAnt ;
      private bool[] T00012_n3RFMAnt ;
      private int[] T00012_A4RFMAct ;
      private bool[] T00012_n4RFMAct ;
      private int[] T00012_A5Clientes ;
      private bool[] T00012_n5Clientes ;
      private short[] T000111_A1Region ;
      private short[] T000111_A2Sucursal ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.version1.SdtTransactionContext AV10TrnContext ;
   }

   public class tresumenrfm__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tresumenrfm__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00014 ;
        prmT00014 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT00015 ;
        prmT00015 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT00013 ;
        prmT00013 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT00016 ;
        prmT00016 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT00017 ;
        prmT00017 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT00012 ;
        prmT00012 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT00018 ;
        prmT00018 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@RFMAnt",SqlDbType.Int,8,0} ,
        new Object[] {"@RFMAct",SqlDbType.Int,8,0} ,
        new Object[] {"@Clientes",SqlDbType.Int,8,0}
        } ;
        Object[] prmT00019 ;
        prmT00019 = new Object[] {
        new Object[] {"@RFMAnt",SqlDbType.Int,8,0} ,
        new Object[] {"@RFMAct",SqlDbType.Int,8,0} ,
        new Object[] {"@Clientes",SqlDbType.Int,8,0} ,
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT000110 ;
        prmT000110 = new Object[] {
        new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
        new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
        } ;
        Object[] prmT000111 ;
        prmT000111 = new Object[] {
        } ;
        def= new CursorDef[] {
            new CursorDef("T00012", "SELECT [Region], [Sucursal], [RFMAnt], [RFMAct], [Clientes] FROM [tResumenRFM] WITH (UPDLOCK) WHERE [Region] = @Region AND [Sucursal] = @Sucursal ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00013", "SELECT [Region], [Sucursal], [RFMAnt], [RFMAct], [Clientes] FROM [tResumenRFM] WHERE [Region] = @Region AND [Sucursal] = @Sucursal ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00014", "SELECT TM1.[Region], TM1.[Sucursal], TM1.[RFMAnt], TM1.[RFMAct], TM1.[Clientes] FROM [tResumenRFM] TM1 WHERE TM1.[Region] = @Region and TM1.[Sucursal] = @Sucursal ORDER BY TM1.[Region], TM1.[Sucursal]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00015", "SELECT [Region], [Sucursal] FROM [tResumenRFM] WHERE [Region] = @Region AND [Sucursal] = @Sucursal  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00016", "SELECT TOP 1 [Region], [Sucursal] FROM [tResumenRFM] WHERE ( [Region] > @Region or [Region] = @Region and [Sucursal] > @Sucursal) ORDER BY [Region], [Sucursal]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00017", "SELECT TOP 1 [Region], [Sucursal] FROM [tResumenRFM] WHERE ( [Region] < @Region or [Region] = @Region and [Sucursal] < @Sucursal) ORDER BY [Region] DESC, [Sucursal] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00018", "INSERT INTO [tResumenRFM]([Region], [Sucursal], [RFMAnt], [RFMAct], [Clientes]) VALUES(@Region, @Sucursal, @RFMAnt, @RFMAct, @Clientes)", GxErrorMask.GX_NOMASK,prmT00018)
           ,new CursorDef("T00019", "UPDATE [tResumenRFM] SET [RFMAnt]=@RFMAnt, [RFMAct]=@RFMAct, [Clientes]=@Clientes  WHERE [Region] = @Region AND [Sucursal] = @Sucursal", GxErrorMask.GX_NOMASK,prmT00019)
           ,new CursorDef("T000110", "DELETE FROM [tResumenRFM]  WHERE [Region] = @Region AND [Sucursal] = @Sucursal", GxErrorMask.GX_NOMASK,prmT000110)
           ,new CursorDef("T000111", "SELECT [Region], [Sucursal] FROM [tResumenRFM] ORDER BY [Region], [Sucursal]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
              ((int[]) buf[2])[0] = rslt.getInt(3) ;
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4) ;
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((int[]) buf[6])[0] = rslt.getInt(5) ;
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
              ((int[]) buf[2])[0] = rslt.getInt(3) ;
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4) ;
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((int[]) buf[6])[0] = rslt.getInt(5) ;
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
              ((int[]) buf[2])[0] = rslt.getInt(3) ;
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4) ;
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((int[]) buf[6])[0] = rslt.getInt(5) ;
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1) ;
              ((short[]) buf[1])[0] = rslt.getShort(2) ;
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
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
           case 1 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
           case 2 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
           case 3 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
           case 4 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
           case 5 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
           case 6 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 3 , SqlDbType.Int );
              }
              else
              {
                 stmt.SetParameter(3, (int)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 4 , SqlDbType.Int );
              }
              else
              {
                 stmt.SetParameter(4, (int)parms[5]);
              }
              if ( (bool)parms[6] )
              {
                 stmt.setNull( 5 , SqlDbType.Int );
              }
              else
              {
                 stmt.SetParameter(5, (int)parms[7]);
              }
              return;
           case 7 :
              if ( (bool)parms[0] )
              {
                 stmt.setNull( 1 , SqlDbType.Int );
              }
              else
              {
                 stmt.SetParameter(1, (int)parms[1]);
              }
              if ( (bool)parms[2] )
              {
                 stmt.setNull( 2 , SqlDbType.Int );
              }
              else
              {
                 stmt.SetParameter(2, (int)parms[3]);
              }
              if ( (bool)parms[4] )
              {
                 stmt.setNull( 3 , SqlDbType.Int );
              }
              else
              {
                 stmt.SetParameter(3, (int)parms[5]);
              }
              stmt.SetParameter(4, (short)parms[6]);
              stmt.SetParameter(5, (short)parms[7]);
              return;
           case 8 :
              stmt.SetParameter(1, (short)parms[0]);
              stmt.SetParameter(2, (short)parms[1]);
              return;
     }
  }

}

}
