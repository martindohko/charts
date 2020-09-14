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
   public class resumenrfmgeneral : GXDataArea
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
            Form.Meta.addItem("description", "Resumen RFMGeneral", 0) ;
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

      public resumenrfmgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public resumenrfmgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
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
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Resumen RFMGeneral", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPeriodo_Internalname, A7Periodo, StringUtil.RTrim( context.localUtil.Format( A7Periodo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPeriodo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPeriodo_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCorte1_Internalname, A8Corte1, StringUtil.RTrim( context.localUtil.Format( A8Corte1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorte1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorte1_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCorte2_Internalname, A9Corte2, StringUtil.RTrim( context.localUtil.Format( A9Corte2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorte2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorte2_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtRFM_Internalname, A10RFM, StringUtil.RTrim( context.localUtil.Format( A10RFM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRFM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRFM_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtClientesDelAnio_Internalname, A11ClientesDelAnio, StringUtil.RTrim( context.localUtil.Format( A11ClientesDelAnio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesDelAnio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesDelAnio_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtClientesDelMes_Internalname, A12ClientesDelMes, StringUtil.RTrim( context.localUtil.Format( A12ClientesDelMes, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClientesDelMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClientesDelMes_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtMinRecencia_Internalname, A13MinRecencia, StringUtil.RTrim( context.localUtil.Format( A13MinRecencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMinRecencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMinRecencia_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         GxWebStd.gx_single_line_edit( context, edtMaxRecencia_Internalname, A14MaxRecencia, StringUtil.RTrim( context.localUtil.Format( A14MaxRecencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMaxRecencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMaxRecencia_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMinFrecuencia_Internalname, A15MinFrecuencia, StringUtil.RTrim( context.localUtil.Format( A15MinFrecuencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMinFrecuencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMinFrecuencia_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMaxFrecuencia_Internalname, A16MaxFrecuencia, StringUtil.RTrim( context.localUtil.Format( A16MaxFrecuencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMaxFrecuencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMaxFrecuencia_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAvgFrecuencia_Internalname, A17AvgFrecuencia, StringUtil.RTrim( context.localUtil.Format( A17AvgFrecuencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAvgFrecuencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAvgFrecuencia_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMinValorMonetario_Internalname, A18MinValorMonetario, StringUtil.RTrim( context.localUtil.Format( A18MinValorMonetario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMinValorMonetario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMinValorMonetario_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMaxValorMonetario_Internalname, A19MaxValorMonetario, StringUtil.RTrim( context.localUtil.Format( A19MaxValorMonetario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMaxValorMonetario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMaxValorMonetario_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAvgValorMonetario_Internalname, A20AvgValorMonetario, StringUtil.RTrim( context.localUtil.Format( A20AvgValorMonetario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAvgValorMonetario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAvgValorMonetario_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComprasTickets_AnioMovil_Internalname, A21ComprasTickets_AnioMovil, StringUtil.RTrim( context.localUtil.Format( A21ComprasTickets_AnioMovil, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComprasTickets_AnioMovil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComprasTickets_AnioMovil_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComprasImporte_AnioMovil_Internalname, A22ComprasImporte_AnioMovil, StringUtil.RTrim( context.localUtil.Format( A22ComprasImporte_AnioMovil, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComprasImporte_AnioMovil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComprasImporte_AnioMovil_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComprasArticulos_AnioMovil_Internalname, A23ComprasArticulos_AnioMovil, StringUtil.RTrim( context.localUtil.Format( A23ComprasArticulos_AnioMovil, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComprasArticulos_AnioMovil_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComprasArticulos_AnioMovil_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ResumenRFMGeneral.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ResumenRFMGeneral.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7Periodo = cgiGet( "Z7Periodo");
               Z8Corte1 = cgiGet( "Z8Corte1");
               Z9Corte2 = cgiGet( "Z9Corte2");
               Z10RFM = cgiGet( "Z10RFM");
               Z11ClientesDelAnio = cgiGet( "Z11ClientesDelAnio");
               Z12ClientesDelMes = cgiGet( "Z12ClientesDelMes");
               Z13MinRecencia = cgiGet( "Z13MinRecencia");
               Z14MaxRecencia = cgiGet( "Z14MaxRecencia");
               Z15MinFrecuencia = cgiGet( "Z15MinFrecuencia");
               Z16MaxFrecuencia = cgiGet( "Z16MaxFrecuencia");
               Z17AvgFrecuencia = cgiGet( "Z17AvgFrecuencia");
               Z18MinValorMonetario = cgiGet( "Z18MinValorMonetario");
               Z19MaxValorMonetario = cgiGet( "Z19MaxValorMonetario");
               Z20AvgValorMonetario = cgiGet( "Z20AvgValorMonetario");
               Z21ComprasTickets_AnioMovil = cgiGet( "Z21ComprasTickets_AnioMovil");
               Z22ComprasImporte_AnioMovil = cgiGet( "Z22ComprasImporte_AnioMovil");
               Z23ComprasArticulos_AnioMovil = cgiGet( "Z23ComprasArticulos_AnioMovil");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7Periodo = cgiGet( "vPERIODO");
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7Periodo = cgiGet( edtPeriodo_Internalname);
               AssignAttri("", false, "A7Periodo", A7Periodo);
               A8Corte1 = cgiGet( edtCorte1_Internalname);
               AssignAttri("", false, "A8Corte1", A8Corte1);
               A9Corte2 = cgiGet( edtCorte2_Internalname);
               AssignAttri("", false, "A9Corte2", A9Corte2);
               A10RFM = cgiGet( edtRFM_Internalname);
               AssignAttri("", false, "A10RFM", A10RFM);
               A11ClientesDelAnio = cgiGet( edtClientesDelAnio_Internalname);
               AssignAttri("", false, "A11ClientesDelAnio", A11ClientesDelAnio);
               A12ClientesDelMes = cgiGet( edtClientesDelMes_Internalname);
               AssignAttri("", false, "A12ClientesDelMes", A12ClientesDelMes);
               A13MinRecencia = cgiGet( edtMinRecencia_Internalname);
               AssignAttri("", false, "A13MinRecencia", A13MinRecencia);
               A14MaxRecencia = cgiGet( edtMaxRecencia_Internalname);
               AssignAttri("", false, "A14MaxRecencia", A14MaxRecencia);
               A15MinFrecuencia = cgiGet( edtMinFrecuencia_Internalname);
               AssignAttri("", false, "A15MinFrecuencia", A15MinFrecuencia);
               A16MaxFrecuencia = cgiGet( edtMaxFrecuencia_Internalname);
               AssignAttri("", false, "A16MaxFrecuencia", A16MaxFrecuencia);
               A17AvgFrecuencia = cgiGet( edtAvgFrecuencia_Internalname);
               AssignAttri("", false, "A17AvgFrecuencia", A17AvgFrecuencia);
               A18MinValorMonetario = cgiGet( edtMinValorMonetario_Internalname);
               AssignAttri("", false, "A18MinValorMonetario", A18MinValorMonetario);
               A19MaxValorMonetario = cgiGet( edtMaxValorMonetario_Internalname);
               AssignAttri("", false, "A19MaxValorMonetario", A19MaxValorMonetario);
               A20AvgValorMonetario = cgiGet( edtAvgValorMonetario_Internalname);
               AssignAttri("", false, "A20AvgValorMonetario", A20AvgValorMonetario);
               A21ComprasTickets_AnioMovil = cgiGet( edtComprasTickets_AnioMovil_Internalname);
               AssignAttri("", false, "A21ComprasTickets_AnioMovil", A21ComprasTickets_AnioMovil);
               A22ComprasImporte_AnioMovil = cgiGet( edtComprasImporte_AnioMovil_Internalname);
               AssignAttri("", false, "A22ComprasImporte_AnioMovil", A22ComprasImporte_AnioMovil);
               A23ComprasArticulos_AnioMovil = cgiGet( edtComprasArticulos_AnioMovil_Internalname);
               AssignAttri("", false, "A23ComprasArticulos_AnioMovil", A23ComprasArticulos_AnioMovil);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ResumenRFMGeneral");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A7Periodo, Z7Periodo) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("resumenrfmgeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
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
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: After Trn */
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         if ( ! new isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV11Pgmname)));
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "RFM");
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwresumenrfmgeneral.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z8Corte1 = T00023_A8Corte1[0];
               Z9Corte2 = T00023_A9Corte2[0];
               Z10RFM = T00023_A10RFM[0];
               Z11ClientesDelAnio = T00023_A11ClientesDelAnio[0];
               Z12ClientesDelMes = T00023_A12ClientesDelMes[0];
               Z13MinRecencia = T00023_A13MinRecencia[0];
               Z14MaxRecencia = T00023_A14MaxRecencia[0];
               Z15MinFrecuencia = T00023_A15MinFrecuencia[0];
               Z16MaxFrecuencia = T00023_A16MaxFrecuencia[0];
               Z17AvgFrecuencia = T00023_A17AvgFrecuencia[0];
               Z18MinValorMonetario = T00023_A18MinValorMonetario[0];
               Z19MaxValorMonetario = T00023_A19MaxValorMonetario[0];
               Z20AvgValorMonetario = T00023_A20AvgValorMonetario[0];
               Z21ComprasTickets_AnioMovil = T00023_A21ComprasTickets_AnioMovil[0];
               Z22ComprasImporte_AnioMovil = T00023_A22ComprasImporte_AnioMovil[0];
               Z23ComprasArticulos_AnioMovil = T00023_A23ComprasArticulos_AnioMovil[0];
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
            AV11Pgmname = "ResumenRFMGeneral";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A8Corte1 = T00024_A8Corte1[0];
            AssignAttri("", false, "A8Corte1", A8Corte1);
            A9Corte2 = T00024_A9Corte2[0];
            AssignAttri("", false, "A9Corte2", A9Corte2);
            A10RFM = T00024_A10RFM[0];
            AssignAttri("", false, "A10RFM", A10RFM);
            A11ClientesDelAnio = T00024_A11ClientesDelAnio[0];
            AssignAttri("", false, "A11ClientesDelAnio", A11ClientesDelAnio);
            A12ClientesDelMes = T00024_A12ClientesDelMes[0];
            AssignAttri("", false, "A12ClientesDelMes", A12ClientesDelMes);
            A13MinRecencia = T00024_A13MinRecencia[0];
            AssignAttri("", false, "A13MinRecencia", A13MinRecencia);
            A14MaxRecencia = T00024_A14MaxRecencia[0];
            AssignAttri("", false, "A14MaxRecencia", A14MaxRecencia);
            A15MinFrecuencia = T00024_A15MinFrecuencia[0];
            AssignAttri("", false, "A15MinFrecuencia", A15MinFrecuencia);
            A16MaxFrecuencia = T00024_A16MaxFrecuencia[0];
            AssignAttri("", false, "A16MaxFrecuencia", A16MaxFrecuencia);
            A17AvgFrecuencia = T00024_A17AvgFrecuencia[0];
            AssignAttri("", false, "A17AvgFrecuencia", A17AvgFrecuencia);
            A18MinValorMonetario = T00024_A18MinValorMonetario[0];
            AssignAttri("", false, "A18MinValorMonetario", A18MinValorMonetario);
            A19MaxValorMonetario = T00024_A19MaxValorMonetario[0];
            AssignAttri("", false, "A19MaxValorMonetario", A19MaxValorMonetario);
            A20AvgValorMonetario = T00024_A20AvgValorMonetario[0];
            AssignAttri("", false, "A20AvgValorMonetario", A20AvgValorMonetario);
            A21ComprasTickets_AnioMovil = T00024_A21ComprasTickets_AnioMovil[0];
            AssignAttri("", false, "A21ComprasTickets_AnioMovil", A21ComprasTickets_AnioMovil);
            A22ComprasImporte_AnioMovil = T00024_A22ComprasImporte_AnioMovil[0];
            AssignAttri("", false, "A22ComprasImporte_AnioMovil", A22ComprasImporte_AnioMovil);
            A23ComprasArticulos_AnioMovil = T00024_A23ComprasArticulos_AnioMovil[0];
            AssignAttri("", false, "A23ComprasArticulos_AnioMovil", A23ComprasArticulos_AnioMovil);
            ZM022( -4) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV11Pgmname = "ResumenRFMGeneral";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "ResumenRFMGeneral";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 4) ;
            RcdFound2 = 1;
            A7Periodo = T00023_A7Periodo[0];
            AssignAttri("", false, "A7Periodo", A7Periodo);
            A8Corte1 = T00023_A8Corte1[0];
            AssignAttri("", false, "A8Corte1", A8Corte1);
            A9Corte2 = T00023_A9Corte2[0];
            AssignAttri("", false, "A9Corte2", A9Corte2);
            A10RFM = T00023_A10RFM[0];
            AssignAttri("", false, "A10RFM", A10RFM);
            A11ClientesDelAnio = T00023_A11ClientesDelAnio[0];
            AssignAttri("", false, "A11ClientesDelAnio", A11ClientesDelAnio);
            A12ClientesDelMes = T00023_A12ClientesDelMes[0];
            AssignAttri("", false, "A12ClientesDelMes", A12ClientesDelMes);
            A13MinRecencia = T00023_A13MinRecencia[0];
            AssignAttri("", false, "A13MinRecencia", A13MinRecencia);
            A14MaxRecencia = T00023_A14MaxRecencia[0];
            AssignAttri("", false, "A14MaxRecencia", A14MaxRecencia);
            A15MinFrecuencia = T00023_A15MinFrecuencia[0];
            AssignAttri("", false, "A15MinFrecuencia", A15MinFrecuencia);
            A16MaxFrecuencia = T00023_A16MaxFrecuencia[0];
            AssignAttri("", false, "A16MaxFrecuencia", A16MaxFrecuencia);
            A17AvgFrecuencia = T00023_A17AvgFrecuencia[0];
            AssignAttri("", false, "A17AvgFrecuencia", A17AvgFrecuencia);
            A18MinValorMonetario = T00023_A18MinValorMonetario[0];
            AssignAttri("", false, "A18MinValorMonetario", A18MinValorMonetario);
            A19MaxValorMonetario = T00023_A19MaxValorMonetario[0];
            AssignAttri("", false, "A19MaxValorMonetario", A19MaxValorMonetario);
            A20AvgValorMonetario = T00023_A20AvgValorMonetario[0];
            AssignAttri("", false, "A20AvgValorMonetario", A20AvgValorMonetario);
            A21ComprasTickets_AnioMovil = T00023_A21ComprasTickets_AnioMovil[0];
            AssignAttri("", false, "A21ComprasTickets_AnioMovil", A21ComprasTickets_AnioMovil);
            A22ComprasImporte_AnioMovil = T00023_A22ComprasImporte_AnioMovil[0];
            AssignAttri("", false, "A22ComprasImporte_AnioMovil", A22ComprasImporte_AnioMovil);
            A23ComprasArticulos_AnioMovil = T00023_A23ComprasArticulos_AnioMovil[0];
            AssignAttri("", false, "A23ComprasArticulos_AnioMovil", A23ComprasArticulos_AnioMovil);
            Z7Periodo = A7Periodo;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A7Periodo[0], A7Periodo) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A7Periodo[0], A7Periodo) > 0 ) ) )
            {
               A7Periodo = T00026_A7Periodo[0];
               AssignAttri("", false, "A7Periodo", A7Periodo);
               RcdFound2 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A7Periodo});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A7Periodo[0], A7Periodo) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A7Periodo[0], A7Periodo) < 0 ) ) )
            {
               A7Periodo = T00027_A7Periodo[0];
               AssignAttri("", false, "A7Periodo", A7Periodo);
               RcdFound2 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPeriodo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
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
                  Update022( ) ;
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
                  Insert022( ) ;
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
                     Insert022( ) ;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A7Periodo});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResumenRFMGeneral"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8Corte1, T00022_A8Corte1[0]) != 0 ) || ( StringUtil.StrCmp(Z9Corte2, T00022_A9Corte2[0]) != 0 ) || ( StringUtil.StrCmp(Z10RFM, T00022_A10RFM[0]) != 0 ) || ( StringUtil.StrCmp(Z11ClientesDelAnio, T00022_A11ClientesDelAnio[0]) != 0 ) || ( StringUtil.StrCmp(Z12ClientesDelMes, T00022_A12ClientesDelMes[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z13MinRecencia, T00022_A13MinRecencia[0]) != 0 ) || ( StringUtil.StrCmp(Z14MaxRecencia, T00022_A14MaxRecencia[0]) != 0 ) || ( StringUtil.StrCmp(Z15MinFrecuencia, T00022_A15MinFrecuencia[0]) != 0 ) || ( StringUtil.StrCmp(Z16MaxFrecuencia, T00022_A16MaxFrecuencia[0]) != 0 ) || ( StringUtil.StrCmp(Z17AvgFrecuencia, T00022_A17AvgFrecuencia[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z18MinValorMonetario, T00022_A18MinValorMonetario[0]) != 0 ) || ( StringUtil.StrCmp(Z19MaxValorMonetario, T00022_A19MaxValorMonetario[0]) != 0 ) || ( StringUtil.StrCmp(Z20AvgValorMonetario, T00022_A20AvgValorMonetario[0]) != 0 ) || ( StringUtil.StrCmp(Z21ComprasTickets_AnioMovil, T00022_A21ComprasTickets_AnioMovil[0]) != 0 ) || ( StringUtil.StrCmp(Z22ComprasImporte_AnioMovil, T00022_A22ComprasImporte_AnioMovil[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z23ComprasArticulos_AnioMovil, T00022_A23ComprasArticulos_AnioMovil[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z8Corte1, T00022_A8Corte1[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"Corte1");
                  GXUtil.WriteLogRaw("Old: ",Z8Corte1);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8Corte1[0]);
               }
               if ( StringUtil.StrCmp(Z9Corte2, T00022_A9Corte2[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"Corte2");
                  GXUtil.WriteLogRaw("Old: ",Z9Corte2);
                  GXUtil.WriteLogRaw("Current: ",T00022_A9Corte2[0]);
               }
               if ( StringUtil.StrCmp(Z10RFM, T00022_A10RFM[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"RFM");
                  GXUtil.WriteLogRaw("Old: ",Z10RFM);
                  GXUtil.WriteLogRaw("Current: ",T00022_A10RFM[0]);
               }
               if ( StringUtil.StrCmp(Z11ClientesDelAnio, T00022_A11ClientesDelAnio[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"ClientesDelAnio");
                  GXUtil.WriteLogRaw("Old: ",Z11ClientesDelAnio);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11ClientesDelAnio[0]);
               }
               if ( StringUtil.StrCmp(Z12ClientesDelMes, T00022_A12ClientesDelMes[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"ClientesDelMes");
                  GXUtil.WriteLogRaw("Old: ",Z12ClientesDelMes);
                  GXUtil.WriteLogRaw("Current: ",T00022_A12ClientesDelMes[0]);
               }
               if ( StringUtil.StrCmp(Z13MinRecencia, T00022_A13MinRecencia[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"MinRecencia");
                  GXUtil.WriteLogRaw("Old: ",Z13MinRecencia);
                  GXUtil.WriteLogRaw("Current: ",T00022_A13MinRecencia[0]);
               }
               if ( StringUtil.StrCmp(Z14MaxRecencia, T00022_A14MaxRecencia[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"MaxRecencia");
                  GXUtil.WriteLogRaw("Old: ",Z14MaxRecencia);
                  GXUtil.WriteLogRaw("Current: ",T00022_A14MaxRecencia[0]);
               }
               if ( StringUtil.StrCmp(Z15MinFrecuencia, T00022_A15MinFrecuencia[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"MinFrecuencia");
                  GXUtil.WriteLogRaw("Old: ",Z15MinFrecuencia);
                  GXUtil.WriteLogRaw("Current: ",T00022_A15MinFrecuencia[0]);
               }
               if ( StringUtil.StrCmp(Z16MaxFrecuencia, T00022_A16MaxFrecuencia[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"MaxFrecuencia");
                  GXUtil.WriteLogRaw("Old: ",Z16MaxFrecuencia);
                  GXUtil.WriteLogRaw("Current: ",T00022_A16MaxFrecuencia[0]);
               }
               if ( StringUtil.StrCmp(Z17AvgFrecuencia, T00022_A17AvgFrecuencia[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"AvgFrecuencia");
                  GXUtil.WriteLogRaw("Old: ",Z17AvgFrecuencia);
                  GXUtil.WriteLogRaw("Current: ",T00022_A17AvgFrecuencia[0]);
               }
               if ( StringUtil.StrCmp(Z18MinValorMonetario, T00022_A18MinValorMonetario[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"MinValorMonetario");
                  GXUtil.WriteLogRaw("Old: ",Z18MinValorMonetario);
                  GXUtil.WriteLogRaw("Current: ",T00022_A18MinValorMonetario[0]);
               }
               if ( StringUtil.StrCmp(Z19MaxValorMonetario, T00022_A19MaxValorMonetario[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"MaxValorMonetario");
                  GXUtil.WriteLogRaw("Old: ",Z19MaxValorMonetario);
                  GXUtil.WriteLogRaw("Current: ",T00022_A19MaxValorMonetario[0]);
               }
               if ( StringUtil.StrCmp(Z20AvgValorMonetario, T00022_A20AvgValorMonetario[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"AvgValorMonetario");
                  GXUtil.WriteLogRaw("Old: ",Z20AvgValorMonetario);
                  GXUtil.WriteLogRaw("Current: ",T00022_A20AvgValorMonetario[0]);
               }
               if ( StringUtil.StrCmp(Z21ComprasTickets_AnioMovil, T00022_A21ComprasTickets_AnioMovil[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"ComprasTickets_AnioMovil");
                  GXUtil.WriteLogRaw("Old: ",Z21ComprasTickets_AnioMovil);
                  GXUtil.WriteLogRaw("Current: ",T00022_A21ComprasTickets_AnioMovil[0]);
               }
               if ( StringUtil.StrCmp(Z22ComprasImporte_AnioMovil, T00022_A22ComprasImporte_AnioMovil[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"ComprasImporte_AnioMovil");
                  GXUtil.WriteLogRaw("Old: ",Z22ComprasImporte_AnioMovil);
                  GXUtil.WriteLogRaw("Current: ",T00022_A22ComprasImporte_AnioMovil[0]);
               }
               if ( StringUtil.StrCmp(Z23ComprasArticulos_AnioMovil, T00022_A23ComprasArticulos_AnioMovil[0]) != 0 )
               {
                  GXUtil.WriteLog("resumenrfmgeneral:[seudo value changed for attri]"+"ComprasArticulos_AnioMovil");
                  GXUtil.WriteLogRaw("Old: ",Z23ComprasArticulos_AnioMovil);
                  GXUtil.WriteLogRaw("Current: ",T00022_A23ComprasArticulos_AnioMovil[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ResumenRFMGeneral"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00028 */
                     pr_default.execute(6, new Object[] {A7Periodo, A8Corte1, A9Corte2, A10RFM, A11ClientesDelAnio, A12ClientesDelMes, A13MinRecencia, A14MaxRecencia, A15MinFrecuencia, A16MaxFrecuencia, A17AvgFrecuencia, A18MinValorMonetario, A19MaxValorMonetario, A20AvgValorMonetario, A21ComprasTickets_AnioMovil, A22ComprasImporte_AnioMovil, A23ComprasArticulos_AnioMovil});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("ResumenRFMGeneral") ;
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
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00029 */
                     pr_default.execute(7, new Object[] {A8Corte1, A9Corte2, A10RFM, A11ClientesDelAnio, A12ClientesDelMes, A13MinRecencia, A14MaxRecencia, A15MinFrecuencia, A16MaxFrecuencia, A17AvgFrecuencia, A18MinValorMonetario, A19MaxValorMonetario, A20AvgValorMonetario, A21ComprasTickets_AnioMovil, A22ComprasImporte_AnioMovil, A23ComprasArticulos_AnioMovil, A7Periodo});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ResumenRFMGeneral") ;
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ResumenRFMGeneral"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000210 */
                  pr_default.execute(8, new Object[] {A7Periodo});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("ResumenRFMGeneral") ;
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "ResumenRFMGeneral";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("resumenrfmgeneral",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("resumenrfmgeneral",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000211 */
         pr_default.execute(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A7Periodo = T000211_A7Periodo[0];
            AssignAttri("", false, "A7Periodo", A7Periodo);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A7Periodo = T000211_A7Periodo[0];
            AssignAttri("", false, "A7Periodo", A7Periodo);
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
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

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
      {
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1247300), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1247300), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2020989371575", false, true);
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
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("resumenrfmgeneral.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7Periodo))+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ResumenRFMGeneral");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("resumenrfmgeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7Periodo", Z7Periodo);
         GxWebStd.gx_hidden_field( context, "Z8Corte1", Z8Corte1);
         GxWebStd.gx_hidden_field( context, "Z9Corte2", Z9Corte2);
         GxWebStd.gx_hidden_field( context, "Z10RFM", Z10RFM);
         GxWebStd.gx_hidden_field( context, "Z11ClientesDelAnio", Z11ClientesDelAnio);
         GxWebStd.gx_hidden_field( context, "Z12ClientesDelMes", Z12ClientesDelMes);
         GxWebStd.gx_hidden_field( context, "Z13MinRecencia", Z13MinRecencia);
         GxWebStd.gx_hidden_field( context, "Z14MaxRecencia", Z14MaxRecencia);
         GxWebStd.gx_hidden_field( context, "Z15MinFrecuencia", Z15MinFrecuencia);
         GxWebStd.gx_hidden_field( context, "Z16MaxFrecuencia", Z16MaxFrecuencia);
         GxWebStd.gx_hidden_field( context, "Z17AvgFrecuencia", Z17AvgFrecuencia);
         GxWebStd.gx_hidden_field( context, "Z18MinValorMonetario", Z18MinValorMonetario);
         GxWebStd.gx_hidden_field( context, "Z19MaxValorMonetario", Z19MaxValorMonetario);
         GxWebStd.gx_hidden_field( context, "Z20AvgValorMonetario", Z20AvgValorMonetario);
         GxWebStd.gx_hidden_field( context, "Z21ComprasTickets_AnioMovil", Z21ComprasTickets_AnioMovil);
         GxWebStd.gx_hidden_field( context, "Z22ComprasImporte_AnioMovil", Z22ComprasImporte_AnioMovil);
         GxWebStd.gx_hidden_field( context, "Z23ComprasArticulos_AnioMovil", Z23ComprasArticulos_AnioMovil);
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

      public override void RenderHtmlCloseForm( )
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
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("resumenrfmgeneral.aspx") + "?" + UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7Periodo)) ;
      }

      public override String GetPgmname( )
      {
         return "ResumenRFMGeneral" ;
      }

      public override String GetPgmdesc( )
      {
         return "Resumen RFMGeneral" ;
      }

      protected void InitializeNonKey022( )
      {
         A8Corte1 = "";
         AssignAttri("", false, "A8Corte1", A8Corte1);
         A9Corte2 = "";
         AssignAttri("", false, "A9Corte2", A9Corte2);
         A10RFM = "";
         AssignAttri("", false, "A10RFM", A10RFM);
         A11ClientesDelAnio = "";
         AssignAttri("", false, "A11ClientesDelAnio", A11ClientesDelAnio);
         A12ClientesDelMes = "";
         AssignAttri("", false, "A12ClientesDelMes", A12ClientesDelMes);
         A13MinRecencia = "";
         AssignAttri("", false, "A13MinRecencia", A13MinRecencia);
         A14MaxRecencia = "";
         AssignAttri("", false, "A14MaxRecencia", A14MaxRecencia);
         A15MinFrecuencia = "";
         AssignAttri("", false, "A15MinFrecuencia", A15MinFrecuencia);
         A16MaxFrecuencia = "";
         AssignAttri("", false, "A16MaxFrecuencia", A16MaxFrecuencia);
         A17AvgFrecuencia = "";
         AssignAttri("", false, "A17AvgFrecuencia", A17AvgFrecuencia);
         A18MinValorMonetario = "";
         AssignAttri("", false, "A18MinValorMonetario", A18MinValorMonetario);
         A19MaxValorMonetario = "";
         AssignAttri("", false, "A19MaxValorMonetario", A19MaxValorMonetario);
         A20AvgValorMonetario = "";
         AssignAttri("", false, "A20AvgValorMonetario", A20AvgValorMonetario);
         A21ComprasTickets_AnioMovil = "";
         AssignAttri("", false, "A21ComprasTickets_AnioMovil", A21ComprasTickets_AnioMovil);
         A22ComprasImporte_AnioMovil = "";
         AssignAttri("", false, "A22ComprasImporte_AnioMovil", A22ComprasImporte_AnioMovil);
         A23ComprasArticulos_AnioMovil = "";
         AssignAttri("", false, "A23ComprasArticulos_AnioMovil", A23ComprasArticulos_AnioMovil);
         Z8Corte1 = "";
         Z9Corte2 = "";
         Z10RFM = "";
         Z11ClientesDelAnio = "";
         Z12ClientesDelMes = "";
         Z13MinRecencia = "";
         Z14MaxRecencia = "";
         Z15MinFrecuencia = "";
         Z16MaxFrecuencia = "";
         Z17AvgFrecuencia = "";
         Z18MinValorMonetario = "";
         Z19MaxValorMonetario = "";
         Z20AvgValorMonetario = "";
         Z21ComprasTickets_AnioMovil = "";
         Z22ComprasImporte_AnioMovil = "";
         Z23ComprasArticulos_AnioMovil = "";
      }

      protected void InitAll022( )
      {
         A7Periodo = "";
         AssignAttri("", false, "A7Periodo", A7Periodo);
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?2020989371581", true, true);
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
         context.AddJavascriptSource("resumenrfmgeneral.js", "?2020989371582", false, true);
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Resumen RFMGeneral";
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
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
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
         Z8Corte1 = "";
         Z9Corte2 = "";
         Z10RFM = "";
         Z11ClientesDelAnio = "";
         Z12ClientesDelMes = "";
         Z13MinRecencia = "";
         Z14MaxRecencia = "";
         Z15MinFrecuencia = "";
         Z16MaxFrecuencia = "";
         Z17AvgFrecuencia = "";
         Z18MinValorMonetario = "";
         Z19MaxValorMonetario = "";
         Z20AvgValorMonetario = "";
         Z21ComprasTickets_AnioMovil = "";
         Z22ComprasImporte_AnioMovil = "";
         Z23ComprasArticulos_AnioMovil = "";
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
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00024_A7Periodo = new String[] {""} ;
         T00024_A8Corte1 = new String[] {""} ;
         T00024_A9Corte2 = new String[] {""} ;
         T00024_A10RFM = new String[] {""} ;
         T00024_A11ClientesDelAnio = new String[] {""} ;
         T00024_A12ClientesDelMes = new String[] {""} ;
         T00024_A13MinRecencia = new String[] {""} ;
         T00024_A14MaxRecencia = new String[] {""} ;
         T00024_A15MinFrecuencia = new String[] {""} ;
         T00024_A16MaxFrecuencia = new String[] {""} ;
         T00024_A17AvgFrecuencia = new String[] {""} ;
         T00024_A18MinValorMonetario = new String[] {""} ;
         T00024_A19MaxValorMonetario = new String[] {""} ;
         T00024_A20AvgValorMonetario = new String[] {""} ;
         T00024_A21ComprasTickets_AnioMovil = new String[] {""} ;
         T00024_A22ComprasImporte_AnioMovil = new String[] {""} ;
         T00024_A23ComprasArticulos_AnioMovil = new String[] {""} ;
         T00025_A7Periodo = new String[] {""} ;
         T00023_A7Periodo = new String[] {""} ;
         T00023_A8Corte1 = new String[] {""} ;
         T00023_A9Corte2 = new String[] {""} ;
         T00023_A10RFM = new String[] {""} ;
         T00023_A11ClientesDelAnio = new String[] {""} ;
         T00023_A12ClientesDelMes = new String[] {""} ;
         T00023_A13MinRecencia = new String[] {""} ;
         T00023_A14MaxRecencia = new String[] {""} ;
         T00023_A15MinFrecuencia = new String[] {""} ;
         T00023_A16MaxFrecuencia = new String[] {""} ;
         T00023_A17AvgFrecuencia = new String[] {""} ;
         T00023_A18MinValorMonetario = new String[] {""} ;
         T00023_A19MaxValorMonetario = new String[] {""} ;
         T00023_A20AvgValorMonetario = new String[] {""} ;
         T00023_A21ComprasTickets_AnioMovil = new String[] {""} ;
         T00023_A22ComprasImporte_AnioMovil = new String[] {""} ;
         T00023_A23ComprasArticulos_AnioMovil = new String[] {""} ;
         T00026_A7Periodo = new String[] {""} ;
         T00027_A7Periodo = new String[] {""} ;
         T00022_A7Periodo = new String[] {""} ;
         T00022_A8Corte1 = new String[] {""} ;
         T00022_A9Corte2 = new String[] {""} ;
         T00022_A10RFM = new String[] {""} ;
         T00022_A11ClientesDelAnio = new String[] {""} ;
         T00022_A12ClientesDelMes = new String[] {""} ;
         T00022_A13MinRecencia = new String[] {""} ;
         T00022_A14MaxRecencia = new String[] {""} ;
         T00022_A15MinFrecuencia = new String[] {""} ;
         T00022_A16MaxFrecuencia = new String[] {""} ;
         T00022_A17AvgFrecuencia = new String[] {""} ;
         T00022_A18MinValorMonetario = new String[] {""} ;
         T00022_A19MaxValorMonetario = new String[] {""} ;
         T00022_A20AvgValorMonetario = new String[] {""} ;
         T00022_A21ComprasTickets_AnioMovil = new String[] {""} ;
         T00022_A22ComprasImporte_AnioMovil = new String[] {""} ;
         T00022_A23ComprasArticulos_AnioMovil = new String[] {""} ;
         T000211_A7Periodo = new String[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.resumenrfmgeneral__default(),
            new Object[][] {
                new Object[] {
               T00022_A7Periodo, T00022_A8Corte1, T00022_A9Corte2, T00022_A10RFM, T00022_A11ClientesDelAnio, T00022_A12ClientesDelMes, T00022_A13MinRecencia, T00022_A14MaxRecencia, T00022_A15MinFrecuencia, T00022_A16MaxFrecuencia,
               T00022_A17AvgFrecuencia, T00022_A18MinValorMonetario, T00022_A19MaxValorMonetario, T00022_A20AvgValorMonetario, T00022_A21ComprasTickets_AnioMovil, T00022_A22ComprasImporte_AnioMovil, T00022_A23ComprasArticulos_AnioMovil
               }
               , new Object[] {
               T00023_A7Periodo, T00023_A8Corte1, T00023_A9Corte2, T00023_A10RFM, T00023_A11ClientesDelAnio, T00023_A12ClientesDelMes, T00023_A13MinRecencia, T00023_A14MaxRecencia, T00023_A15MinFrecuencia, T00023_A16MaxFrecuencia,
               T00023_A17AvgFrecuencia, T00023_A18MinValorMonetario, T00023_A19MaxValorMonetario, T00023_A20AvgValorMonetario, T00023_A21ComprasTickets_AnioMovil, T00023_A22ComprasImporte_AnioMovil, T00023_A23ComprasArticulos_AnioMovil
               }
               , new Object[] {
               T00024_A7Periodo, T00024_A8Corte1, T00024_A9Corte2, T00024_A10RFM, T00024_A11ClientesDelAnio, T00024_A12ClientesDelMes, T00024_A13MinRecencia, T00024_A14MaxRecencia, T00024_A15MinFrecuencia, T00024_A16MaxFrecuencia,
               T00024_A17AvgFrecuencia, T00024_A18MinValorMonetario, T00024_A19MaxValorMonetario, T00024_A20AvgValorMonetario, T00024_A21ComprasTickets_AnioMovil, T00024_A22ComprasImporte_AnioMovil, T00024_A23ComprasArticulos_AnioMovil
               }
               , new Object[] {
               T00025_A7Periodo
               }
               , new Object[] {
               T00026_A7Periodo
               }
               , new Object[] {
               T00027_A7Periodo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000211_A7Periodo
               }
            }
         );
         AV11Pgmname = "ResumenRFMGeneral";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPeriodo_Enabled ;
      private int edtCorte1_Enabled ;
      private int edtCorte2_Enabled ;
      private int edtRFM_Enabled ;
      private int edtClientesDelAnio_Enabled ;
      private int edtClientesDelMes_Enabled ;
      private int edtMinRecencia_Enabled ;
      private int edtMaxRecencia_Enabled ;
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
      private String sMode2 ;
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
      private bool returnInSub ;
      private bool Gx_longc ;
      private String wcpOAV7Periodo ;
      private String Z7Periodo ;
      private String Z8Corte1 ;
      private String Z9Corte2 ;
      private String Z10RFM ;
      private String Z11ClientesDelAnio ;
      private String Z12ClientesDelMes ;
      private String Z13MinRecencia ;
      private String Z14MaxRecencia ;
      private String Z15MinFrecuencia ;
      private String Z16MaxFrecuencia ;
      private String Z17AvgFrecuencia ;
      private String Z18MinValorMonetario ;
      private String Z19MaxValorMonetario ;
      private String Z20AvgValorMonetario ;
      private String Z21ComprasTickets_AnioMovil ;
      private String Z22ComprasImporte_AnioMovil ;
      private String Z23ComprasArticulos_AnioMovil ;
      private String AV7Periodo ;
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
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] T00024_A7Periodo ;
      private String[] T00024_A8Corte1 ;
      private String[] T00024_A9Corte2 ;
      private String[] T00024_A10RFM ;
      private String[] T00024_A11ClientesDelAnio ;
      private String[] T00024_A12ClientesDelMes ;
      private String[] T00024_A13MinRecencia ;
      private String[] T00024_A14MaxRecencia ;
      private String[] T00024_A15MinFrecuencia ;
      private String[] T00024_A16MaxFrecuencia ;
      private String[] T00024_A17AvgFrecuencia ;
      private String[] T00024_A18MinValorMonetario ;
      private String[] T00024_A19MaxValorMonetario ;
      private String[] T00024_A20AvgValorMonetario ;
      private String[] T00024_A21ComprasTickets_AnioMovil ;
      private String[] T00024_A22ComprasImporte_AnioMovil ;
      private String[] T00024_A23ComprasArticulos_AnioMovil ;
      private String[] T00025_A7Periodo ;
      private String[] T00023_A7Periodo ;
      private String[] T00023_A8Corte1 ;
      private String[] T00023_A9Corte2 ;
      private String[] T00023_A10RFM ;
      private String[] T00023_A11ClientesDelAnio ;
      private String[] T00023_A12ClientesDelMes ;
      private String[] T00023_A13MinRecencia ;
      private String[] T00023_A14MaxRecencia ;
      private String[] T00023_A15MinFrecuencia ;
      private String[] T00023_A16MaxFrecuencia ;
      private String[] T00023_A17AvgFrecuencia ;
      private String[] T00023_A18MinValorMonetario ;
      private String[] T00023_A19MaxValorMonetario ;
      private String[] T00023_A20AvgValorMonetario ;
      private String[] T00023_A21ComprasTickets_AnioMovil ;
      private String[] T00023_A22ComprasImporte_AnioMovil ;
      private String[] T00023_A23ComprasArticulos_AnioMovil ;
      private String[] T00026_A7Periodo ;
      private String[] T00027_A7Periodo ;
      private String[] T00022_A7Periodo ;
      private String[] T00022_A8Corte1 ;
      private String[] T00022_A9Corte2 ;
      private String[] T00022_A10RFM ;
      private String[] T00022_A11ClientesDelAnio ;
      private String[] T00022_A12ClientesDelMes ;
      private String[] T00022_A13MinRecencia ;
      private String[] T00022_A14MaxRecencia ;
      private String[] T00022_A15MinFrecuencia ;
      private String[] T00022_A16MaxFrecuencia ;
      private String[] T00022_A17AvgFrecuencia ;
      private String[] T00022_A18MinValorMonetario ;
      private String[] T00022_A19MaxValorMonetario ;
      private String[] T00022_A20AvgValorMonetario ;
      private String[] T00022_A21ComprasTickets_AnioMovil ;
      private String[] T00022_A22ComprasImporte_AnioMovil ;
      private String[] T00022_A23ComprasArticulos_AnioMovil ;
      private String[] T000211_A7Periodo ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class resumenrfmgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00024 ;
          prmT00024 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00025 ;
          prmT00025 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00023 ;
          prmT00023 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00026 ;
          prmT00026 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00027 ;
          prmT00027 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00022 ;
          prmT00022 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00028 ;
          prmT00028 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@Corte1",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@Corte2",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@RFM",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ClientesDelAnio",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ClientesDelMes",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MinRecencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MaxRecencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MinFrecuencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MaxFrecuencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@AvgFrecuencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MinValorMonetario",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MaxValorMonetario",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@AvgValorMonetario",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ComprasTickets_AnioMovil",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ComprasImporte_AnioMovil",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ComprasArticulos_AnioMovil",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT00029 ;
          prmT00029 = new Object[] {
          new Object[] {"@Corte1",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@Corte2",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@RFM",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ClientesDelAnio",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ClientesDelMes",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MinRecencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MaxRecencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MinFrecuencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MaxFrecuencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@AvgFrecuencia",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MinValorMonetario",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@MaxValorMonetario",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@AvgValorMonetario",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ComprasTickets_AnioMovil",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ComprasImporte_AnioMovil",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@ComprasArticulos_AnioMovil",SqlDbType.NVarChar,50,0} ,
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT000210 ;
          prmT000210 = new Object[] {
          new Object[] {"@Periodo",SqlDbType.NVarChar,50,0}
          } ;
          Object[] prmT000211 ;
          prmT000211 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [Periodo], [Corte1], [Corte2], [RFM], [ClientesDelAnio], [ClientesDelMes], [MinRecencia], [MaxRecencia], [MinFrecuencia], [MaxFrecuencia], [AvgFrecuencia], [MinValorMonetario], [MaxValorMonetario], [AvgValorMonetario], [ComprasTickets_AnioMovil], [ComprasImporte_AnioMovil], [ComprasArticulos_AnioMovil] FROM [ResumenRFMGeneral] WITH (UPDLOCK) WHERE [Periodo] = @Periodo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [Periodo], [Corte1], [Corte2], [RFM], [ClientesDelAnio], [ClientesDelMes], [MinRecencia], [MaxRecencia], [MinFrecuencia], [MaxFrecuencia], [AvgFrecuencia], [MinValorMonetario], [MaxValorMonetario], [AvgValorMonetario], [ComprasTickets_AnioMovil], [ComprasImporte_AnioMovil], [ComprasArticulos_AnioMovil] FROM [ResumenRFMGeneral] WHERE [Periodo] = @Periodo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT TM1.[Periodo], TM1.[Corte1], TM1.[Corte2], TM1.[RFM], TM1.[ClientesDelAnio], TM1.[ClientesDelMes], TM1.[MinRecencia], TM1.[MaxRecencia], TM1.[MinFrecuencia], TM1.[MaxFrecuencia], TM1.[AvgFrecuencia], TM1.[MinValorMonetario], TM1.[MaxValorMonetario], TM1.[AvgValorMonetario], TM1.[ComprasTickets_AnioMovil], TM1.[ComprasImporte_AnioMovil], TM1.[ComprasArticulos_AnioMovil] FROM [ResumenRFMGeneral] TM1 WHERE TM1.[Periodo] = @Periodo ORDER BY TM1.[Periodo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [Periodo] FROM [ResumenRFMGeneral] WHERE [Periodo] = @Periodo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT TOP 1 [Periodo] FROM [ResumenRFMGeneral] WHERE ( [Periodo] > @Periodo) ORDER BY [Periodo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00027", "SELECT TOP 1 [Periodo] FROM [ResumenRFMGeneral] WHERE ( [Periodo] < @Periodo) ORDER BY [Periodo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00028", "INSERT INTO [ResumenRFMGeneral]([Periodo], [Corte1], [Corte2], [RFM], [ClientesDelAnio], [ClientesDelMes], [MinRecencia], [MaxRecencia], [MinFrecuencia], [MaxFrecuencia], [AvgFrecuencia], [MinValorMonetario], [MaxValorMonetario], [AvgValorMonetario], [ComprasTickets_AnioMovil], [ComprasImporte_AnioMovil], [ComprasArticulos_AnioMovil]) VALUES(@Periodo, @Corte1, @Corte2, @RFM, @ClientesDelAnio, @ClientesDelMes, @MinRecencia, @MaxRecencia, @MinFrecuencia, @MaxFrecuencia, @AvgFrecuencia, @MinValorMonetario, @MaxValorMonetario, @AvgValorMonetario, @ComprasTickets_AnioMovil, @ComprasImporte_AnioMovil, @ComprasArticulos_AnioMovil)", GxErrorMask.GX_NOMASK,prmT00028)
             ,new CursorDef("T00029", "UPDATE [ResumenRFMGeneral] SET [Corte1]=@Corte1, [Corte2]=@Corte2, [RFM]=@RFM, [ClientesDelAnio]=@ClientesDelAnio, [ClientesDelMes]=@ClientesDelMes, [MinRecencia]=@MinRecencia, [MaxRecencia]=@MaxRecencia, [MinFrecuencia]=@MinFrecuencia, [MaxFrecuencia]=@MaxFrecuencia, [AvgFrecuencia]=@AvgFrecuencia, [MinValorMonetario]=@MinValorMonetario, [MaxValorMonetario]=@MaxValorMonetario, [AvgValorMonetario]=@AvgValorMonetario, [ComprasTickets_AnioMovil]=@ComprasTickets_AnioMovil, [ComprasImporte_AnioMovil]=@ComprasImporte_AnioMovil, [ComprasArticulos_AnioMovil]=@ComprasArticulos_AnioMovil  WHERE [Periodo] = @Periodo", GxErrorMask.GX_NOMASK,prmT00029)
             ,new CursorDef("T000210", "DELETE FROM [ResumenRFMGeneral]  WHERE [Periodo] = @Periodo", GxErrorMask.GX_NOMASK,prmT000210)
             ,new CursorDef("T000211", "SELECT [Periodo] FROM [ResumenRFMGeneral] ORDER BY [Periodo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100, GxCacheFrequency.OFF ,true,false )
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
             case 2 :
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
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (String)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                stmt.SetParameter(8, (String)parms[7]);
                stmt.SetParameter(9, (String)parms[8]);
                stmt.SetParameter(10, (String)parms[9]);
                stmt.SetParameter(11, (String)parms[10]);
                stmt.SetParameter(12, (String)parms[11]);
                stmt.SetParameter(13, (String)parms[12]);
                stmt.SetParameter(14, (String)parms[13]);
                stmt.SetParameter(15, (String)parms[14]);
                stmt.SetParameter(16, (String)parms[15]);
                stmt.SetParameter(17, (String)parms[16]);
                return;
             case 7 :
                stmt.SetParameter(1, (String)parms[0]);
                stmt.SetParameter(2, (String)parms[1]);
                stmt.SetParameter(3, (String)parms[2]);
                stmt.SetParameter(4, (String)parms[3]);
                stmt.SetParameter(5, (String)parms[4]);
                stmt.SetParameter(6, (String)parms[5]);
                stmt.SetParameter(7, (String)parms[6]);
                stmt.SetParameter(8, (String)parms[7]);
                stmt.SetParameter(9, (String)parms[8]);
                stmt.SetParameter(10, (String)parms[9]);
                stmt.SetParameter(11, (String)parms[10]);
                stmt.SetParameter(12, (String)parms[11]);
                stmt.SetParameter(13, (String)parms[12]);
                stmt.SetParameter(14, (String)parms[13]);
                stmt.SetParameter(15, (String)parms[14]);
                stmt.SetParameter(16, (String)parms[15]);
                stmt.SetParameter(17, (String)parms[16]);
                return;
             case 8 :
                stmt.SetParameter(1, (String)parms[0]);
                return;
       }
    }

 }

}
