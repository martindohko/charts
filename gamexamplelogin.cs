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
   public class gamexamplelogin : GXHttpHandler
   {
      public gamexamplelogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gamexamplelogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
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
         cmbavLogonto = new GXCombobox();
         chkavKeepmeloggedin = new GXCheckbox();
         chkavRememberme = new GXCheckbox();
         cmbavTypeauthtype = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridauthtypes") == 0 )
            {
               nRC_GXsfl_63 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_63_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_63_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridauthtypes_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridauthtypes") == 0 )
            {
               AV6ApplicationClientId = GetNextPar( );
               AV18Language = GetNextPar( );
               AV34AuxUserName = GetNextPar( );
               AV28UserRememberMe = (short)(NumberUtil.Val( GetNextPar( ), "."));
               AV17KeepMeLoggedIn = StringUtil.StrToBool( GetNextPar( ));
               AV21RememberMe = StringUtil.StrToBool( GetNextPar( ));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGridauthtypes_refresh( AV6ApplicationClientId, AV18Language, AV34AuxUserName, AV28UserRememberMe, AV17KeepMeLoggedIn, AV21RememberMe) ;
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
            ValidateSpaRequest();
            PA1P2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               cmbavTypeauthtype.Enabled = 0;
               AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtavNameauthtype_Enabled = 0;
               AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               WS1P2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE1P2( ) ;
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
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Login") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202091115391098", false, true);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexamplelogin.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28UserRememberMe), "Z9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_63), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONCLIENTID", StringUtil.RTrim( AV6ApplicationClientId));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV18Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV34AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "BUTTONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divButtons_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BUTTONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divButtons_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1P2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "GAMExampleLogin" ;
      }

      public override String GetPgmdesc( )
      {
         return "Login" ;
      }

      protected void WB1P0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "LoginContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "TableLogin", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "LOGIN", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "BigTitle", 0, "", 1, 1, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentrepository_Internalname, lblCurrentrepository_Caption, "", "", lblCurrentrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "VersionText", 0, "", lblCurrentrepository_Visible, 1, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Log On To", "col-sm-5 LoginComboAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-7 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_63_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV20LogOnTo), 1, cmbavLogonto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "LoginComboAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "", true, "HLP_GAMExampleLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV20LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (String)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User Name", "col-sm-3 LoginAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_63_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV26UserName, StringUtil.RTrim( context.localUtil.Format( AV26UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "User Name", edtavUsername_Jsonclick, 0, "LoginAttribute", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "User Password", "col-sm-3 LoginAttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_63_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV27UserPassword), StringUtil.RTrim( context.localUtil.Format( AV27UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Password", edtavUserpassword_Jsonclick, 0, "LoginAttribute", "", "", "", "", 1, edtavUserpassword_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, -1, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "left", true, "", "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavKeepmeloggedin.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavKeepmeloggedin_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_63_idx + "',0)\"";
            ClassString = "CheckBox Label";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV17KeepMeLoggedIn), "", "", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "Keep me logged in", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-xs-offset-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_63_idx + "',0)\"";
            ClassString = "CheckBox Label";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV21RememberMe), "", "", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "Remember Me", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,41);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-7 col-xs-offset-3 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "BtnLogin";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(63), 2, 0)+","+"null"+");", "LOG IN", bttLogin_Jsonclick, 5, "LOG IN", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbrememberme2_Internalname, "FORGOT YOUR PASSWORD?", "", "", lblTbrememberme2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111p1_client"+"'", "", "PagingText TextLikeLink", 7, "", 1, 1, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            wb_table1_50_1P2( true) ;
         }
         else
         {
            wb_table1_50_1P2( false) ;
         }
         return  ;
      }

      protected void wb_table1_50_1P2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divButtons_Internalname, divButtons_Visible, 0, "px", 0, "px", "TableButtons", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-sm-offset-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, "OR USE", "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridauthtypesContainer.SetIsFreestyle(true);
            GridauthtypesContainer.SetWrapped(nGXWrapped);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"DivS\" data-gxgridid=\"63\">") ;
               sStyleString = "";
               if ( subGridauthtypes_Visible == 0 )
               {
                  sStyleString = sStyleString + "display:none;";
               }
               GxWebStd.gx_table_start( context, subGridauthtypes_Internalname, subGridauthtypes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
            }
            else
            {
               GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
               GridauthtypesContainer.AddObjectProperty("Header", subGridauthtypes_Header);
               GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
               GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("CmpContext", "");
               GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", context.convertURL( AV30ImageAuthType));
               GridauthtypesColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavImageauthtype_Tooltiptext));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV33TypeAuthType));
               GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavTypeauthtype.Enabled), 5, 0, ".", "")));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridauthtypesColumn.AddObjectProperty("Value", StringUtil.RTrim( AV32NameAuthType));
               GridauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNameauthtype_Enabled), 5, 0, ".", "")));
               GridauthtypesContainer.AddColumnProperties(GridauthtypesColumn);
               GridauthtypesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Selectedindex), 4, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowselection), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Selectioncolor), 9, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowhovering), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Hoveringcolor), 9, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Allowcollapsing), 1, 0, ".", "")));
               GridauthtypesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 63 )
         {
            wbEnd = 0;
            nRC_GXsfl_63 = (int)(nGXsfl_63_idx-1);
            if ( GridauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               if ( subGridauthtypes_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridauthtypes", GridauthtypesContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData", GridauthtypesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData"+"V", GridauthtypesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridauthtypesContainerData"+"V"+"\" value='"+GridauthtypesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 63 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridauthtypesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  if ( subGridauthtypes_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+"GridauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridauthtypes", GridauthtypesContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData", GridauthtypesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridauthtypesContainerData"+"V", GridauthtypesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridauthtypesContainerData"+"V"+"\" value='"+GridauthtypesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1P2( )
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
            Form.Meta.addItem("description", "Login", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1P0( ) ;
      }

      protected void WS1P2( )
      {
         START1P2( ) ;
         EVT1P2( ) ;
      }

      protected void EVT1P2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E121P2 ();
                              }
                              dynload_actions( ) ;
                           }
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "GRIDAUTHTYPES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) )
                        {
                           nGXsfl_63_idx = (int)(NumberUtil.Val( sEvtType, "."));
                           sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
                           SubsflControlProps_632( ) ;
                           AV30ImageAuthType = cgiGet( edtavImageauthtype_Internalname);
                           AssignProp("", false, edtavImageauthtype_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV30ImageAuthType)) ? AV40Imageauthtype_GXI : context.convertURL( context.PathToRelativeUrl( AV30ImageAuthType))), !bGXsfl_63_Refreshing);
                           AssignProp("", false, edtavImageauthtype_Internalname, "SrcSet", context.GetImageSrcSet( AV30ImageAuthType), true);
                           cmbavTypeauthtype.Name = cmbavTypeauthtype_Internalname;
                           cmbavTypeauthtype.CurrentValue = cgiGet( cmbavTypeauthtype_Internalname);
                           AV33TypeAuthType = cgiGet( cmbavTypeauthtype_Internalname);
                           AssignAttri("", false, cmbavTypeauthtype_Internalname, AV33TypeAuthType);
                           AV32NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                           AssignAttri("", false, edtavNameauthtype_Internalname, AV32NameAuthType);
                           GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_63_idx, GetSecureSignedToken( sGXsfl_63_idx, StringUtil.RTrim( context.localUtil.Format( AV32NameAuthType, "")), context));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E131P2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E141P2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "GRIDAUTHTYPES.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 E151P2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: 'SelectAuthenticationType' */
                                 E161P2 ();
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

      protected void WE1P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1P2( ) ;
            }
         }
      }

      protected void PA1P2( )
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
               GX_FocusControl = cmbavLogonto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridauthtypes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_632( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            sendrow_632( ) ;
            nGXsfl_63_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_63_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_632( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridauthtypesContainer)) ;
         /* End function gxnrGridauthtypes_newrow */
      }

      protected void gxgrGridauthtypes_refresh( String AV6ApplicationClientId ,
                                                String AV18Language ,
                                                String AV34AuxUserName ,
                                                short AV28UserRememberMe ,
                                                bool AV17KeepMeLoggedIn ,
                                                bool AV21RememberMe )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E141P2 ();
         GRIDAUTHTYPES_nCurrentRecord = 0;
         RF1P2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV32NameAuthType));
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
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV20LogOnTo = cmbavLogonto.getValidValue(AV20LogOnTo);
            AssignAttri("", false, "AV20LogOnTo", AV20LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV20LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV17KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV17KeepMeLoggedIn));
         AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
         AV21RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV21RememberMe));
         AssignAttri("", false, "AV21RememberMe", AV21RememberMe);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void RF1P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridauthtypesContainer.ClearRows();
         }
         wbStart = 63;
         /* Execute user event: Refresh */
         E141P2 ();
         nGXsfl_63_idx = 1;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_632( ) ;
         bGXsfl_63_Refreshing = true;
         GridauthtypesContainer.AddObjectProperty("GridName", "Gridauthtypes");
         GridauthtypesContainer.AddObjectProperty("CmpContext", "");
         GridauthtypesContainer.AddObjectProperty("InMasterPage", "false");
         GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Backcolorstyle), 1, 0, ".", "")));
         GridauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridauthtypes_Visible), 5, 0, ".", "")));
         GridauthtypesContainer.PageSize = subGridauthtypes_fnc_Recordsperpage( );
         if ( subGridauthtypes_Islastpage != 0 )
         {
            GRIDAUTHTYPES_nFirstRecordOnPage = (long)(subGridauthtypes_fnc_Recordcount( )-subGridauthtypes_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDAUTHTYPES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDAUTHTYPES_nFirstRecordOnPage), 15, 0, ".", "")));
            GridauthtypesContainer.AddObjectProperty("GRIDAUTHTYPES_nFirstRecordOnPage", GRIDAUTHTYPES_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_632( ) ;
            E151P2 ();
            wbEnd = 63;
            WB1P0( ) ;
         }
         bGXsfl_63_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1P2( )
      {
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV18Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Language, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV34AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28UserRememberMe), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV28UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_63_idx, GetSecureSignedToken( sGXsfl_63_idx, StringUtil.RTrim( context.localUtil.Format( AV32NameAuthType, "")), context));
      }

      protected int subGridauthtypes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridauthtypes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         cmbavTypeauthtype.Enabled = 0;
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavTypeauthtype.Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtavNameauthtype_Enabled = 0;
         AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void STRUP1P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E131P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_63 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ".", ","));
            AV6ApplicationClientId = cgiGet( "vAPPLICATIONCLIENTID");
            divButtons_Visible = (int)(context.localUtil.CToN( cgiGet( "BUTTONS_Visible"), ".", ","));
            /* Read variables values. */
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV20LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV20LogOnTo", AV20LogOnTo);
            AV26UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV26UserName", AV26UserName);
            AV27UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV27UserPassword", AV27UserPassword);
            AV17KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
            AV21RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV21RememberMe", AV21RememberMe);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E131P2 ();
         if (returnInSub) return;
      }

      protected void E131P2( )
      {
         /* Start Routine */
         lblCurrentrepository_Visible = 0;
         AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AV29GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV10ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
         if ( ! (0==AV29GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV15isOK = false;
         }
         if ( ! AV15isOK )
         {
            if ( AV10ConnectionInfoCollection.Count > 0 )
            {
               AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV10ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV12Errors);
            }
         }
         if ( AV10ConnectionInfoCollection.Count > 1 )
         {
            AV29GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            lblCurrentrepository_Caption = "Repository: "+AV29GAMRepository.gxTpr_Name;
            AssignProp("", false, lblCurrentrepository_Internalname, "Caption", lblCurrentrepository_Caption, true);
            lblCurrentrepository_Visible = 1;
            AssignProp("", false, lblCurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCurrentrepository_Visible), 5, 0), true);
         }
         divButtons_Visible = 0;
         AssignProp("", false, divButtons_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtons_Visible), 5, 0), true);
      }

      protected void E141P2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         subGridauthtypes_Visible = 0;
         AssignProp("", false, "GridauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridauthtypes_Visible), 5, 0), true);
         divTableauthtypeinfo_Visible = 0;
         AssignProp("", false, divTableauthtypeinfo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableauthtypeinfo_Visible), 5, 0), !bGXsfl_63_Refreshing);
         AV16isRedirect = false;
         AV13ErrorsLogin = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV13ErrorsLogin.Count > 0 )
         {
            if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13ErrorsLogin.Item(1)).gxTpr_Code == 1 )
            {
            }
            else if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13ErrorsLogin.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13ErrorsLogin.Item(1)).gxTpr_Code == 23 ) )
            {
               CallWebObject(formatLink("gamexamplechangepassword.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6ApplicationClientId)));
               context.wjLocDisableFrm = 1;
               AV16isRedirect = true;
            }
            else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13ErrorsLogin.Item(1)).gxTpr_Code == 161 )
            {
               CallWebObject(formatLink("gamexampleupdateregisteruser.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6ApplicationClientId)));
               context.wjLocDisableFrm = 1;
               AV16isRedirect = true;
            }
            else
            {
               AV27UserPassword = "";
               AssignAttri("", false, "AV27UserPassword", AV27UserPassword);
               AV12Errors = AV13ErrorsLogin;
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV16isRedirect )
         {
            AV24SessionValid = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV23Session, out  AV12Errors);
            if ( AV24SessionValid && ! AV23Session.gxTpr_Isanonymous )
            {
               AV25URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25URL)) )
               {
                  CallWebObject(formatLink("gamhome.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  CallWebObject(formatLink(AV25URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV9AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV18Language, out  AV12Errors);
               AV38GXV1 = 1;
               while ( AV38GXV1 <= AV9AuthenticationTypes.Count )
               {
                  AV8AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV9AuthenticationTypes.Item(AV38GXV1));
                  if ( AV8AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV8AuthenticationType.gxTpr_Name, AV8AuthenticationType.gxTpr_Description, 0);
                  }
                  else
                  {
                     subGridauthtypes_Visible = 1;
                     AssignProp("", false, "GridauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridauthtypes_Visible), 5, 0), true);
                  }
                  AV38GXV1 = (int)(AV38GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               else
               {
                  AV20LogOnTo = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV9AuthenticationTypes.Item(1)).gxTpr_Name;
                  AssignAttri("", false, "AV20LogOnTo", AV20LogOnTo);
               }
               AV15isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV20LogOnTo, out  AV34AuxUserName, out  AV28UserRememberMe, out  AV12Errors);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34AuxUserName)) )
               {
                  AV26UserName = AV34AuxUserName;
                  AssignAttri("", false, "AV26UserName", AV26UserName);
               }
               if ( AV28UserRememberMe == 2 )
               {
                  AV21RememberMe = true;
                  AssignAttri("", false, "AV21RememberMe", AV21RememberMe);
               }
               AV22Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV20LogOnTo = AV22Repository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV20LogOnTo", AV20LogOnTo);
               }
               if ( StringUtil.StrCmp(AV22Repository.gxTpr_Userremembermetype, "Login") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 0;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV22Repository.gxTpr_Userremembermetype, "Auth") == 0 )
               {
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
                  chkavRememberme.Visible = 0;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
               }
               else if ( StringUtil.StrCmp(AV22Repository.gxTpr_Userremembermetype, "Both") == 0 )
               {
                  chkavRememberme.Visible = 1;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 1;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
               else
               {
                  chkavRememberme.Visible = 0;
                  AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
                  chkavKeepmeloggedin.Visible = 0;
                  AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV20LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
      }

      private void E151P2( )
      {
         /* Gridauthtypes_Load Routine */
         AV39GXV2 = 1;
         while ( AV39GXV2 <= AV9AuthenticationTypes.Count )
         {
            AV8AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV9AuthenticationTypes.Item(AV39GXV2));
            if ( ! AV8AuthenticationType.gxTpr_Needusername )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8AuthenticationType.gxTpr_Smallimagename)) )
               {
                  AV30ImageAuthType = context.GetImagePath( AV8AuthenticationType.gxTpr_Smallimagename, "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV30ImageAuthType);
                  AV40Imageauthtype_GXI = GXDbFile.PathToUrl( AV8AuthenticationType.gxTpr_Smallimagename);
               }
               else
               {
                  AV30ImageAuthType = context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( ));
                  AssignAttri("", false, edtavImageauthtype_Internalname, AV30ImageAuthType);
                  AV40Imageauthtype_GXI = GXDbFile.PathToUrl( context.GetImagePath( "6cdd3e18-cc5b-44e0-bd22-3efaf48a6c40", "", context.GetTheme( )));
               }
               AV33TypeAuthType = AV8AuthenticationType.gxTpr_Type;
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV33TypeAuthType);
               AV32NameAuthType = StringUtil.Trim( AV8AuthenticationType.gxTpr_Name);
               AssignAttri("", false, edtavNameauthtype_Internalname, AV32NameAuthType);
               GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_63_idx, GetSecureSignedToken( sGXsfl_63_idx, StringUtil.RTrim( context.localUtil.Format( AV32NameAuthType, "")), context));
               edtavImageauthtype_Tooltiptext = StringUtil.Format( "Sign in with %1", StringUtil.Trim( AV8AuthenticationType.gxTpr_Description), "", "", "", "", "", "", "", "");
               if ( divButtons_Visible == 0 )
               {
                  divButtons_Visible = 1;
                  AssignProp("", false, divButtons_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtons_Visible), 5, 0), true);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 63;
               }
               sendrow_632( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_63_Refreshing )
               {
                  DoAjaxLoad(63, GridauthtypesRow);
               }
            }
            AV39GXV2 = (int)(AV39GXV2+1);
         }
         /*  Sending Event outputs  */
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV33TypeAuthType);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E121P2 ();
         if (returnInSub) return;
      }

      protected void E121P2( )
      {
         /* Enter Routine */
         if ( AV17KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV21RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV20LogOnTo;
         AV19LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV26UserName, AV27UserPassword, AV5AdditionalParameter, out  AV12Errors);
         if ( AV19LoginOK )
         {
            AV7ApplicationData = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).getapplicationdata();
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ApplicationData)) )
            {
               AV14GAMExampleSDTApplicationData.FromJSonString(AV7ApplicationData, null);
            }
            AV25URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25URL)) )
            {
               CallWebObject(formatLink("gamhome.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               CallWebObject(formatLink(AV25URL) );
               context.wjLocDisableFrm = 0;
            }
         }
         else
         {
            if ( AV12Errors.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("gamexamplechangepassword.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6ApplicationClientId)));
                  context.wjLocDisableFrm = 1;
               }
               else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(1)).gxTpr_Code == 161 )
               {
                  CallWebObject(formatLink("gamexampleupdateregisteruser.aspx") + "?" + UrlEncode(StringUtil.RTrim(AV6ApplicationClientId)));
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV27UserPassword = "";
                  AssignAttri("", false, "AV27UserPassword", AV27UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S112 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void S112( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         AV41GXV3 = 1;
         while ( AV41GXV3 <= AV12Errors.Count )
         {
            AV11Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV41GXV3));
            if ( AV11Error.gxTpr_Code != 13 )
            {
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV11Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV11Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            }
            AV41GXV3 = (int)(AV41GXV3+1);
         }
      }

      protected void E161P2( )
      {
         /* 'SelectAuthenticationType' Routine */
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV32NameAuthType;
         AV19LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV26UserName, AV27UserPassword, AV5AdditionalParameter, out  AV12Errors);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void wb_table1_50_1P2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Right\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Right;text-align:-moz-Right;text-align:-webkit-Right")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "or", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SpecialText", 0, "", 1, 1, 0, "HLP_GAMExampleLogin.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td data-align=\"Left\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Left;text-align:-moz-Left;text-align:-webkit-Left")+"\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbregister_Internalname, "create an account", "", "", lblTbregister_Jsonclick, "'"+""+"'"+",false,"+"'"+"e171p1_client"+"'", "", "ActionText TextLikeLink", 7, "", 1, 1, 0, "HLP_GAMExampleLogin.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_50_1P2e( true) ;
         }
         else
         {
            wb_table1_50_1P2e( false) ;
         }
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
         PA1P2( ) ;
         WS1P2( ) ;
         WE1P2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202091115392930", true, true);
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
         context.AddJavascriptSource("gamexamplelogin.js", "?202091115392933", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_632( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_63_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_63_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_632( )
      {
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE_"+sGXsfl_63_fel_idx;
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE_"+sGXsfl_63_fel_idx;
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_63_fel_idx;
      }

      protected void sendrow_632( )
      {
         SubsflControlProps_632( ) ;
         WB1P0( ) ;
         GridauthtypesRow = GXWebRow.GetNew(context,GridauthtypesContainer);
         if ( subGridauthtypes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridauthtypes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
            }
         }
         else if ( subGridauthtypes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridauthtypes_Backstyle = 0;
            subGridauthtypes_Backcolor = subGridauthtypes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Uniform";
            }
         }
         else if ( subGridauthtypes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridauthtypes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
            {
               subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
            }
            subGridauthtypes_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridauthtypes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridauthtypes_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridauthtypes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
               {
                  subGridauthtypes_Linesclass = subGridauthtypes_Class+"Even";
               }
            }
            else
            {
               subGridauthtypes_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridauthtypes_Class, "") != 0 )
               {
                  subGridauthtypes_Linesclass = subGridauthtypes_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridauthtypes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_63_idx+"\">") ;
         }
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divGrid1table_Internalname+"_"+sGXsfl_63_idx,(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)45,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)"",(String)"Image Auth Type",(String)"col-sm-3 Fixed30Label",(short)0,(bool)true,(String)""});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavImageauthtype_Enabled!=0)&&(edtavImageauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'',false,'',63)\"" : " ");
         ClassString = "Fixed30";
         StyleString = "";
         AV30ImageAuthType_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV30ImageAuthType))&&String.IsNullOrEmpty(StringUtil.RTrim( AV40Imageauthtype_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV30ImageAuthType)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30ImageAuthType)) ? AV40Imageauthtype_GXI : context.PathToRelativeUrl( AV30ImageAuthType));
         GridauthtypesRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavImageauthtype_Internalname,(String)sImgUrl,(String)"",(String)"",(String)"",context.GetTheme( ),(short)1,(short)1,(String)"",(String)edtavImageauthtype_Tooltiptext,(short)0,(short)-1,(short)0,(String)"",(short)0,(String)"",(short)0,(short)0,(short)5,(String)edtavImageauthtype_Jsonclick,"'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+sGXsfl_63_idx+"'",(String)StyleString,(String)ClassString,(String)"",(String)"",(String)"",(String)"",(String)""+TempTags,(String)"",(String)"",(short)1,(bool)AV30ImageAuthType_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)divTableauthtypeinfo_Internalname+"_"+sGXsfl_63_idx,(int)divTableauthtypeinfo_Visible,(short)0,(String)"px",(short)0,(String)"px",(String)"Table",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)cmbavTypeauthtype_Internalname,(String)"Type Auth Type",(String)"col-sm-3 AttributeLabel",(short)0,(bool)true,(String)""});
         TempTags = " " + ((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 75,'',false,'"+sGXsfl_63_idx+"',63)\"" : " ");
         if ( ( cmbavTypeauthtype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_63_idx;
            cmbavTypeauthtype.Name = GXCCtl;
            cmbavTypeauthtype.WebTags = "";
            cmbavTypeauthtype.addItem("AppleID", "Apple", 0);
            cmbavTypeauthtype.addItem("Custom", "Custom", 0);
            cmbavTypeauthtype.addItem("ExternalWebService", "External Web Service", 0);
            cmbavTypeauthtype.addItem("Facebook", "Facebook", 0);
            cmbavTypeauthtype.addItem("GAMLocal", "GAM Local", 0);
            cmbavTypeauthtype.addItem("GAMRemote", "GAM Remote", 0);
            cmbavTypeauthtype.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
            cmbavTypeauthtype.addItem("Google", "Google", 0);
            cmbavTypeauthtype.addItem("Twitter", "Twitter", 0);
            cmbavTypeauthtype.addItem("Oauth20", "Oauth 2.0", 0);
            cmbavTypeauthtype.addItem("Saml20", "Saml 2.0", 0);
            cmbavTypeauthtype.addItem("WeChat", "WeChat", 0);
            if ( cmbavTypeauthtype.ItemCount > 0 )
            {
               AV33TypeAuthType = cmbavTypeauthtype.getValidValue(AV33TypeAuthType);
               AssignAttri("", false, cmbavTypeauthtype_Internalname, AV33TypeAuthType);
            }
         }
         /* ComboBox */
         GridauthtypesRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavTypeauthtype,(String)cmbavTypeauthtype_Internalname,StringUtil.RTrim( AV33TypeAuthType),(short)1,(String)cmbavTypeauthtype_Jsonclick,(short)0,(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"char",(String)"",(short)1,cmbavTypeauthtype.Enabled,(short)0,(short)0,(short)0,(String)"em",(short)0,(String)"",(String)"",(String)"Attribute",(String)"",(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavTypeauthtype.Enabled!=0)&&(cmbavTypeauthtype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,75);\"" : " "),(String)"",(bool)true});
         cmbavTypeauthtype.CurrentValue = StringUtil.RTrim( AV33TypeAuthType);
         AssignProp("", false, cmbavTypeauthtype_Internalname, "Values", (String)(cmbavTypeauthtype.ToJavascriptSource()), !bGXsfl_63_Refreshing);
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"row",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)"col-xs-12",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Div Control */
         GridauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(String)"",(short)1,(short)0,(String)"px",(short)0,(String)"px",(String)" gx-attribute",(String)"left",(String)"top",(String)"",(String)"",(String)"div"});
         /* Attribute/Variable Label */
         GridauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(String)edtavNameauthtype_Internalname,(String)"Name Auth Type",(String)"col-sm-3 AttributeLabel",(short)0,(bool)true,(String)""});
         /* Single line edit */
         TempTags = " " + ((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 79,'',false,'"+sGXsfl_63_idx+"',63)\"" : " ");
         ROClassString = "Attribute";
         GridauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtavNameauthtype_Internalname,StringUtil.RTrim( AV32NameAuthType),(String)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNameauthtype_Enabled!=0)&&(edtavNameauthtype_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,79);\"" : " "),(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtavNameauthtype_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"",(String)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(String)"text",(String)"",(short)60,(String)"chr",(short)1,(String)"row",(short)60,(short)0,(short)0,(short)63,(short)1,(short)-1,(short)-1,(bool)true,(String)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(String)"left",(bool)true,(String)""});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         GridauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(String)"left",(String)"top",(String)"div"});
         send_integrity_lvl_hashes1P2( ) ;
         /* End of Columns property logic. */
         GridauthtypesContainer.AddRow(GridauthtypesRow);
         nGXsfl_63_idx = ((subGridauthtypes_Islastpage==1)&&(nGXsfl_63_idx+1>subGridauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_632( ) ;
         /* End function sendrow_632 */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV20LogOnTo = cmbavLogonto.getValidValue(AV20LogOnTo);
            AssignAttri("", false, "AV20LogOnTo", AV20LogOnTo);
         }
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "Keep me logged in";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV17KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV17KeepMeLoggedIn));
         AssignAttri("", false, "AV17KeepMeLoggedIn", AV17KeepMeLoggedIn);
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "Remember Me";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV21RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV21RememberMe));
         AssignAttri("", false, "AV21RememberMe", AV21RememberMe);
         GXCCtl = "vTYPEAUTHTYPE_" + sGXsfl_63_idx;
         cmbavTypeauthtype.Name = GXCCtl;
         cmbavTypeauthtype.WebTags = "";
         cmbavTypeauthtype.addItem("AppleID", "Apple", 0);
         cmbavTypeauthtype.addItem("Custom", "Custom", 0);
         cmbavTypeauthtype.addItem("ExternalWebService", "External Web Service", 0);
         cmbavTypeauthtype.addItem("Facebook", "Facebook", 0);
         cmbavTypeauthtype.addItem("GAMLocal", "GAM Local", 0);
         cmbavTypeauthtype.addItem("GAMRemote", "GAM Remote", 0);
         cmbavTypeauthtype.addItem("GAMRemoteRest", "GAM Remote Rest", 0);
         cmbavTypeauthtype.addItem("Google", "Google", 0);
         cmbavTypeauthtype.addItem("Twitter", "Twitter", 0);
         cmbavTypeauthtype.addItem("Oauth20", "Oauth 2.0", 0);
         cmbavTypeauthtype.addItem("Saml20", "Saml 2.0", 0);
         cmbavTypeauthtype.addItem("WeChat", "WeChat", 0);
         if ( cmbavTypeauthtype.ItemCount > 0 )
         {
            AV33TypeAuthType = cmbavTypeauthtype.getValidValue(AV33TypeAuthType);
            AssignAttri("", false, cmbavTypeauthtype_Internalname, AV33TypeAuthType);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblCurrentrepository_Internalname = "CURRENTREPOSITORY";
         cmbavLogonto_Internalname = "vLOGONTO";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         chkavRememberme_Internalname = "vREMEMBERME";
         bttLogin_Internalname = "LOGIN";
         lblTbrememberme2_Internalname = "TBREMEMBERME2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTbregister_Internalname = "TBREGISTER";
         tblTable2_Internalname = "TABLE2";
         lblTbexternalauthentication_Internalname = "TBEXTERNALAUTHENTICATION";
         edtavImageauthtype_Internalname = "vIMAGEAUTHTYPE";
         cmbavTypeauthtype_Internalname = "vTYPEAUTHTYPE";
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE";
         divTableauthtypeinfo_Internalname = "TABLEAUTHTYPEINFO";
         divGrid1table_Internalname = "GRID1TABLE";
         divButtons_Internalname = "BUTTONS";
         divTablelogin_Internalname = "TABLELOGIN";
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridauthtypes_Internalname = "GRIDAUTHTYPES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavRememberme.Caption = "";
         chkavKeepmeloggedin.Caption = "";
         edtavNameauthtype_Jsonclick = "";
         edtavNameauthtype_Visible = 1;
         cmbavTypeauthtype_Jsonclick = "";
         cmbavTypeauthtype.Visible = 1;
         divTableauthtypeinfo_Visible = 1;
         edtavImageauthtype_Jsonclick = "";
         edtavImageauthtype_Visible = 1;
         edtavImageauthtype_Enabled = 1;
         subGridauthtypes_Class = "FreeStyleGrid";
         subGridauthtypes_Allowcollapsing = 0;
         edtavNameauthtype_Enabled = 1;
         cmbavTypeauthtype.Enabled = 1;
         edtavImageauthtype_Tooltiptext = "";
         subGridauthtypes_Backcolorstyle = 0;
         subGridauthtypes_Visible = 1;
         divButtons_Visible = 1;
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         chkavKeepmeloggedin.Enabled = 1;
         chkavKeepmeloggedin.Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Enabled = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         lblCurrentrepository_Caption = "Text Block";
         lblCurrentrepository_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDAUTHTYPES_nFirstRecordOnPage'},{av:'GRIDAUTHTYPES_nEOF'},{av:'AV6ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV18Language',fld:'vLANGUAGE',pic:'',hsh:true},{av:'AV34AuxUserName',fld:'vAUXUSERNAME',pic:'',hsh:true},{av:'AV28UserRememberMe',fld:'vUSERREMEMBERME',pic:'Z9',hsh:true},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'subGridauthtypes_Visible',ctrl:'GRIDAUTHTYPES',prop:'Visible'},{av:'divTableauthtypeinfo_Visible',ctrl:'TABLEAUTHTYPEINFO',prop:'Visible'},{av:'AV6ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV27UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'cmbavLogonto'},{av:'AV20LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV26UserName',fld:'vUSERNAME',pic:''},{av:'chkavKeepmeloggedin.Visible',ctrl:'vKEEPMELOGGEDIN',prop:'Visible'},{av:'chkavRememberme.Visible',ctrl:'vREMEMBERME',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("GRIDAUTHTYPES.LOAD","{handler:'E151P2',iparms:[{av:'divButtons_Visible',ctrl:'BUTTONS',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("GRIDAUTHTYPES.LOAD",",oparms:[{av:'AV30ImageAuthType',fld:'vIMAGEAUTHTYPE',pic:''},{av:'cmbavTypeauthtype'},{av:'AV33TypeAuthType',fld:'vTYPEAUTHTYPE',pic:''},{av:'AV32NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'edtavImageauthtype_Tooltiptext',ctrl:'vIMAGEAUTHTYPE',prop:'Tooltiptext'},{av:'divButtons_Visible',ctrl:'BUTTONS',prop:'Visible'},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E121P2',iparms:[{av:'cmbavLogonto'},{av:'AV20LogOnTo',fld:'vLOGONTO',pic:''},{av:'AV26UserName',fld:'vUSERNAME',pic:''},{av:'AV27UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV6ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV6ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV27UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'FORGOTPASSWORD'","{handler:'E111P1',iparms:[{av:'AV6ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'FORGOTPASSWORD'",",oparms:[{av:'AV6ApplicationClientId',fld:'vAPPLICATIONCLIENTID',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'REGISTER'","{handler:'E171P1',iparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'REGISTER'",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","{handler:'E161P2',iparms:[{av:'AV32NameAuthType',fld:'vNAMEAUTHTYPE',pic:'',hsh:true},{av:'AV26UserName',fld:'vUSERNAME',pic:''},{av:'AV27UserPassword',fld:'vUSERPASSWORD',pic:''},{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("VALIDV_TYPEAUTHTYPE","{handler:'Validv_Typeauthtype',iparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("VALIDV_TYPEAUTHTYPE",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Nameauthtype',iparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV17KeepMeLoggedIn',fld:'vKEEPMELOGGEDIN',pic:''},{av:'AV21RememberMe',fld:'vREMEMBERME',pic:''}]}");
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
         AV6ApplicationClientId = "";
         AV18Language = "";
         AV34AuxUserName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         lblTextblock1_Jsonclick = "";
         lblCurrentrepository_Jsonclick = "";
         TempTags = "";
         AV20LogOnTo = "";
         AV26UserName = "";
         AV27UserPassword = "";
         bttLogin_Jsonclick = "";
         lblTbrememberme2_Jsonclick = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         subGridauthtypes_Header = "";
         GridauthtypesColumn = new GXWebColumn();
         AV30ImageAuthType = "";
         AV33TypeAuthType = "";
         AV32NameAuthType = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV40Imageauthtype_GXI = "";
         AV29GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV10ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV12Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13ErrorsLogin = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV23Session = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV25URL = "";
         AV9AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV8AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         AV22Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         GridauthtypesRow = new GXWebRow();
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV7ApplicationData = "";
         AV14GAMExampleSDTApplicationData = new SdtGAMExampleSDTApplicationData(context);
         AV11Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         lblTextblock3_Jsonclick = "";
         lblTbregister_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridauthtypes_Linesclass = "";
         sImgUrl = "";
         GXCCtl = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavTypeauthtype.Enabled = 0;
         edtavNameauthtype_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV28UserRememberMe ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short subGridauthtypes_Backcolorstyle ;
      private short subGridauthtypes_Allowselection ;
      private short subGridauthtypes_Allowhovering ;
      private short subGridauthtypes_Allowcollapsing ;
      private short subGridauthtypes_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short GRIDAUTHTYPES_nEOF ;
      private short nGXWrapped ;
      private short subGridauthtypes_Backstyle ;
      private int divButtons_Visible ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int edtavNameauthtype_Enabled ;
      private int lblCurrentrepository_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Enabled ;
      private int subGridauthtypes_Visible ;
      private int subGridauthtypes_Selectedindex ;
      private int subGridauthtypes_Selectioncolor ;
      private int subGridauthtypes_Hoveringcolor ;
      private int subGridauthtypes_Islastpage ;
      private int divTableauthtypeinfo_Visible ;
      private int AV38GXV1 ;
      private int AV39GXV2 ;
      private int AV41GXV3 ;
      private int idxLst ;
      private int subGridauthtypes_Backcolor ;
      private int subGridauthtypes_Allbackcolor ;
      private int edtavImageauthtype_Enabled ;
      private int edtavImageauthtype_Visible ;
      private int edtavNameauthtype_Visible ;
      private long GRIDAUTHTYPES_nCurrentRecord ;
      private long GRIDAUTHTYPES_nFirstRecordOnPage ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_63_idx="0001" ;
      private String AV6ApplicationClientId ;
      private String AV18Language ;
      private String cmbavTypeauthtype_Internalname ;
      private String edtavNameauthtype_Internalname ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divTable1_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String divTablelogin_Internalname ;
      private String lblTextblock1_Internalname ;
      private String lblTextblock1_Jsonclick ;
      private String lblCurrentrepository_Internalname ;
      private String lblCurrentrepository_Caption ;
      private String lblCurrentrepository_Jsonclick ;
      private String cmbavLogonto_Internalname ;
      private String TempTags ;
      private String AV20LogOnTo ;
      private String cmbavLogonto_Jsonclick ;
      private String edtavUsername_Internalname ;
      private String edtavUsername_Jsonclick ;
      private String edtavUserpassword_Internalname ;
      private String AV27UserPassword ;
      private String edtavUserpassword_Jsonclick ;
      private String chkavKeepmeloggedin_Internalname ;
      private String chkavRememberme_Internalname ;
      private String bttLogin_Internalname ;
      private String bttLogin_Jsonclick ;
      private String lblTbrememberme2_Internalname ;
      private String lblTbrememberme2_Jsonclick ;
      private String divButtons_Internalname ;
      private String lblTbexternalauthentication_Internalname ;
      private String lblTbexternalauthentication_Jsonclick ;
      private String sStyleString ;
      private String subGridauthtypes_Internalname ;
      private String subGridauthtypes_Header ;
      private String edtavImageauthtype_Tooltiptext ;
      private String AV33TypeAuthType ;
      private String AV32NameAuthType ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavImageauthtype_Internalname ;
      private String divTableauthtypeinfo_Internalname ;
      private String tblTable2_Internalname ;
      private String lblTextblock3_Internalname ;
      private String lblTextblock3_Jsonclick ;
      private String lblTbregister_Internalname ;
      private String lblTbregister_Jsonclick ;
      private String sGXsfl_63_fel_idx="0001" ;
      private String subGridauthtypes_Class ;
      private String subGridauthtypes_Linesclass ;
      private String divGrid1table_Internalname ;
      private String sImgUrl ;
      private String edtavImageauthtype_Jsonclick ;
      private String GXCCtl ;
      private String cmbavTypeauthtype_Jsonclick ;
      private String ROClassString ;
      private String edtavNameauthtype_Jsonclick ;
      private bool entryPointCalled ;
      private bool AV17KeepMeLoggedIn ;
      private bool AV21RememberMe ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV15isOK ;
      private bool gx_refresh_fired ;
      private bool AV16isRedirect ;
      private bool AV24SessionValid ;
      private bool AV19LoginOK ;
      private bool AV30ImageAuthType_IsBlob ;
      private String AV7ApplicationData ;
      private String AV34AuxUserName ;
      private String AV26UserName ;
      private String AV40Imageauthtype_GXI ;
      private String AV25URL ;
      private String AV30ImageAuthType ;
      private GXWebGrid GridauthtypesContainer ;
      private GXWebRow GridauthtypesRow ;
      private GXWebColumn GridauthtypesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXCheckbox chkavRememberme ;
      private GXCombobox cmbavTypeauthtype ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV9AuthenticationTypes ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV10ConnectionInfoCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13ErrorsLogin ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV8AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV11Error ;
      private SdtGAMExampleSDTApplicationData AV14GAMExampleSDTApplicationData ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV29GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV22Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV23Session ;
   }

}
