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
   public class tresumenrfm_bc : GxSilentTrn, IGxSilentTrn
   {
      public tresumenrfm_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public tresumenrfm_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            /* Execute user event: After Trn */
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1Region = A1Region;
               Z2Sucursal = A2Sucursal;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
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
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
      }

      protected void E11012( )
      {
         /* After Trn Routine */
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z3RFMAnt = A3RFMAnt;
            Z4RFMAct = A4RFMAct;
            Z5Clientes = A5Clientes;
         }
         if ( GX_JID == -1 )
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
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A3RFMAnt = BC00014_A3RFMAnt[0];
            n3RFMAnt = BC00014_n3RFMAnt[0];
            A4RFMAct = BC00014_A4RFMAct[0];
            n4RFMAct = BC00014_n4RFMAct[0];
            A5Clientes = BC00014_A5Clientes[0];
            n5Clientes = BC00014_n5Clientes[0];
            ZM011( -1) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00015 */
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
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1Region, A2Sucursal});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 1) ;
            RcdFound1 = 1;
            A1Region = BC00013_A1Region[0];
            A2Sucursal = BC00013_A2Sucursal[0];
            A3RFMAnt = BC00013_A3RFMAnt[0];
            n3RFMAnt = BC00013_n3RFMAnt[0];
            A4RFMAct = BC00013_A4RFMAct[0];
            n4RFMAct = BC00013_n4RFMAct[0];
            A5Clientes = BC00013_A5Clientes[0];
            n5Clientes = BC00013_n5Clientes[0];
            Z1Region = A1Region;
            Z2Sucursal = A2Sucursal;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1Region, A2Sucursal});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tResumenRFM"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z3RFMAnt != BC00012_A3RFMAnt[0] ) || ( Z4RFMAct != BC00012_A4RFMAct[0] ) || ( Z5Clientes != BC00012_A5Clientes[0] ) )
            {
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
                     /* Using cursor BC00016 */
                     pr_default.execute(4, new Object[] {A1Region, A2Sucursal, n3RFMAnt, A3RFMAnt, n4RFMAct, A4RFMAct, n5Clientes, A5Clientes});
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("tResumenRFM") ;
                     if ( (pr_default.getStatus(4) == 1) )
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
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {n3RFMAnt, A3RFMAnt, n4RFMAct, A4RFMAct, n5Clientes, A5Clientes, A1Region, A2Sucursal});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("tResumenRFM") ;
                     if ( (pr_default.getStatus(5) == 103) )
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
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
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
         Gx_mode = "DLT";
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
                  /* Using cursor BC00018 */
                  pr_default.execute(6, new Object[] {A1Region, A2Sucursal});
                  pr_default.close(6);
                  dsDefault.SmartCacheProvider.SetUpdated("tResumenRFM") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
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
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
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
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC00019 */
         pr_default.execute(7, new Object[] {A1Region, A2Sucursal});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A1Region = BC00019_A1Region[0];
            A2Sucursal = BC00019_A2Sucursal[0];
            A3RFMAnt = BC00019_A3RFMAnt[0];
            n3RFMAnt = BC00019_n3RFMAnt[0];
            A4RFMAct = BC00019_A4RFMAct[0];
            n4RFMAct = BC00019_n4RFMAct[0];
            A5Clientes = BC00019_A5Clientes[0];
            n5Clientes = BC00019_n5Clientes[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound1 = 1;
            A1Region = BC00019_A1Region[0];
            A2Sucursal = BC00019_A2Sucursal[0];
            A3RFMAnt = BC00019_A3RFMAnt[0];
            n3RFMAnt = BC00019_n3RFMAnt[0];
            A4RFMAct = BC00019_A4RFMAct[0];
            n4RFMAct = BC00019_n4RFMAct[0];
            A5Clientes = BC00019_A5Clientes[0];
            n5Clientes = BC00019_n5Clientes[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(7);
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
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bctResumenRFM) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bctResumenRFM, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A3RFMAnt = 0;
         n3RFMAnt = false;
         A4RFMAct = 0;
         n4RFMAct = false;
         A5Clientes = 0;
         n5Clientes = false;
         Z3RFMAnt = 0;
         Z4RFMAct = 0;
         Z5Clientes = 0;
      }

      protected void InitAll011( )
      {
         A1Region = 0;
         A2Sucursal = 0;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow1( SdttResumenRFM obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Rfmant = A3RFMAnt;
         obj1.gxTpr_Rfmact = A4RFMAct;
         obj1.gxTpr_Clientes = A5Clientes;
         obj1.gxTpr_Region = A1Region;
         obj1.gxTpr_Sucursal = A2Sucursal;
         obj1.gxTpr_Region_Z = Z1Region;
         obj1.gxTpr_Sucursal_Z = Z2Sucursal;
         obj1.gxTpr_Rfmant_Z = Z3RFMAnt;
         obj1.gxTpr_Rfmact_Z = Z4RFMAct;
         obj1.gxTpr_Clientes_Z = Z5Clientes;
         obj1.gxTpr_Rfmant_N = (short)(Convert.ToInt16(n3RFMAnt));
         obj1.gxTpr_Rfmact_N = (short)(Convert.ToInt16(n4RFMAct));
         obj1.gxTpr_Clientes_N = (short)(Convert.ToInt16(n5Clientes));
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdttResumenRFM obj1 )
      {
         obj1.gxTpr_Region = A1Region;
         obj1.gxTpr_Sucursal = A2Sucursal;
         return  ;
      }

      public void RowToVars1( SdttResumenRFM obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A3RFMAnt = obj1.gxTpr_Rfmant;
         n3RFMAnt = false;
         A4RFMAct = obj1.gxTpr_Rfmact;
         n4RFMAct = false;
         A5Clientes = obj1.gxTpr_Clientes;
         n5Clientes = false;
         A1Region = obj1.gxTpr_Region;
         A2Sucursal = obj1.gxTpr_Sucursal;
         Z1Region = obj1.gxTpr_Region_Z;
         Z2Sucursal = obj1.gxTpr_Sucursal_Z;
         Z3RFMAnt = obj1.gxTpr_Rfmant_Z;
         Z4RFMAct = obj1.gxTpr_Rfmact_Z;
         Z5Clientes = obj1.gxTpr_Clientes_Z;
         n3RFMAnt = (bool)(Convert.ToBoolean(obj1.gxTpr_Rfmant_N));
         n4RFMAct = (bool)(Convert.ToBoolean(obj1.gxTpr_Rfmact_N));
         n5Clientes = (bool)(Convert.ToBoolean(obj1.gxTpr_Clientes_N));
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1Region = (short)getParm(obj,0);
         A2Sucursal = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1Region = A1Region;
            Z2Sucursal = A2Sucursal;
         }
         ZM011( -1) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bctResumenRFM, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1Region = A1Region;
            Z2Sucursal = A2Sucursal;
         }
         ZM011( -1) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
               {
                  A1Region = Z1Region;
                  A2Sucursal = Z2Sucursal;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bctResumenRFM, 0) ;
         SaveImpl( ) ;
         VarsToRow1( bctResumenRFM) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bctResumenRFM, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bctResumenRFM) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdttResumenRFM auxBC = new SdttResumenRFM(context) ;
            IGxSilentTrn auxTrn = auxBC.getTransaction() ;
            auxBC.Load(A1Region, A2Sucursal);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bctResumenRFM);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bctResumenRFM, 0) ;
         UpdateImpl( ) ;
         VarsToRow1( bctResumenRFM) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bctResumenRFM, 0) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow1( bctResumenRFM) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bctResumenRFM, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
            {
               A1Region = Z1Region;
               A2Sucursal = Z2Sucursal;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A1Region != Z1Region ) || ( A2Sucursal != Z2Sucursal ) )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("tresumenrfm_bc",pr_default);
         VarsToRow1( bctResumenRFM) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public String GetMode( )
      {
         Gx_mode = bctResumenRFM.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( String lMode )
      {
         Gx_mode = lMode;
         bctResumenRFM.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bctResumenRFM )
         {
            bctResumenRFM = (SdttResumenRFM)(sdt);
            if ( StringUtil.StrCmp(bctResumenRFM.gxTpr_Mode, "") == 0 )
            {
               bctResumenRFM.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bctResumenRFM) ;
            }
            else
            {
               RowToVars1( bctResumenRFM, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bctResumenRFM.gxTpr_Mode, "") == 0 )
            {
               bctResumenRFM.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bctResumenRFM, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdttResumenRFM tResumenRFM_BC
      {
         get {
            return bctResumenRFM ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         BC00014_A1Region = new short[1] ;
         BC00014_A2Sucursal = new short[1] ;
         BC00014_A3RFMAnt = new int[1] ;
         BC00014_n3RFMAnt = new bool[] {false} ;
         BC00014_A4RFMAct = new int[1] ;
         BC00014_n4RFMAct = new bool[] {false} ;
         BC00014_A5Clientes = new int[1] ;
         BC00014_n5Clientes = new bool[] {false} ;
         BC00015_A1Region = new short[1] ;
         BC00015_A2Sucursal = new short[1] ;
         BC00013_A1Region = new short[1] ;
         BC00013_A2Sucursal = new short[1] ;
         BC00013_A3RFMAnt = new int[1] ;
         BC00013_n3RFMAnt = new bool[] {false} ;
         BC00013_A4RFMAct = new int[1] ;
         BC00013_n4RFMAct = new bool[] {false} ;
         BC00013_A5Clientes = new int[1] ;
         BC00013_n5Clientes = new bool[] {false} ;
         sMode1 = "";
         BC00012_A1Region = new short[1] ;
         BC00012_A2Sucursal = new short[1] ;
         BC00012_A3RFMAnt = new int[1] ;
         BC00012_n3RFMAnt = new bool[] {false} ;
         BC00012_A4RFMAct = new int[1] ;
         BC00012_n4RFMAct = new bool[] {false} ;
         BC00012_A5Clientes = new int[1] ;
         BC00012_n5Clientes = new bool[] {false} ;
         BC00019_A1Region = new short[1] ;
         BC00019_A2Sucursal = new short[1] ;
         BC00019_A3RFMAnt = new int[1] ;
         BC00019_n3RFMAnt = new bool[] {false} ;
         BC00019_A4RFMAct = new int[1] ;
         BC00019_n4RFMAct = new bool[] {false} ;
         BC00019_A5Clientes = new int[1] ;
         BC00019_n5Clientes = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tresumenrfm_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1Region, BC00012_A2Sucursal, BC00012_A3RFMAnt, BC00012_n3RFMAnt, BC00012_A4RFMAct, BC00012_n4RFMAct, BC00012_A5Clientes, BC00012_n5Clientes
               }
               , new Object[] {
               BC00013_A1Region, BC00013_A2Sucursal, BC00013_A3RFMAnt, BC00013_n3RFMAnt, BC00013_A4RFMAct, BC00013_n4RFMAct, BC00013_A5Clientes, BC00013_n5Clientes
               }
               , new Object[] {
               BC00014_A1Region, BC00014_A2Sucursal, BC00014_A3RFMAnt, BC00014_n3RFMAnt, BC00014_A4RFMAct, BC00014_n4RFMAct, BC00014_A5Clientes, BC00014_n5Clientes
               }
               , new Object[] {
               BC00015_A1Region, BC00015_A2Sucursal
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00019_A1Region, BC00019_A2Sucursal, BC00019_A3RFMAnt, BC00019_n3RFMAnt, BC00019_A4RFMAct, BC00019_n4RFMAct, BC00019_A5Clientes, BC00019_n5Clientes
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z1Region ;
      private short A1Region ;
      private short Z2Sucursal ;
      private short A2Sucursal ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private int Z3RFMAnt ;
      private int A3RFMAnt ;
      private int Z4RFMAct ;
      private int A4RFMAct ;
      private int Z5Clientes ;
      private int A5Clientes ;
      private String scmdbuf ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String Gx_mode ;
      private String sMode1 ;
      private bool n3RFMAnt ;
      private bool n4RFMAct ;
      private bool n5Clientes ;
      private bool mustCommit ;
      private SdttResumenRFM bctResumenRFM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00014_A1Region ;
      private short[] BC00014_A2Sucursal ;
      private int[] BC00014_A3RFMAnt ;
      private bool[] BC00014_n3RFMAnt ;
      private int[] BC00014_A4RFMAct ;
      private bool[] BC00014_n4RFMAct ;
      private int[] BC00014_A5Clientes ;
      private bool[] BC00014_n5Clientes ;
      private short[] BC00015_A1Region ;
      private short[] BC00015_A2Sucursal ;
      private short[] BC00013_A1Region ;
      private short[] BC00013_A2Sucursal ;
      private int[] BC00013_A3RFMAnt ;
      private bool[] BC00013_n3RFMAnt ;
      private int[] BC00013_A4RFMAct ;
      private bool[] BC00013_n4RFMAct ;
      private int[] BC00013_A5Clientes ;
      private bool[] BC00013_n5Clientes ;
      private short[] BC00012_A1Region ;
      private short[] BC00012_A2Sucursal ;
      private int[] BC00012_A3RFMAnt ;
      private bool[] BC00012_n3RFMAnt ;
      private int[] BC00012_A4RFMAct ;
      private bool[] BC00012_n4RFMAct ;
      private int[] BC00012_A5Clientes ;
      private bool[] BC00012_n5Clientes ;
      private short[] BC00019_A1Region ;
      private short[] BC00019_A2Sucursal ;
      private int[] BC00019_A3RFMAnt ;
      private bool[] BC00019_n3RFMAnt ;
      private int[] BC00019_A4RFMAct ;
      private bool[] BC00019_n4RFMAct ;
      private int[] BC00019_A5Clientes ;
      private bool[] BC00019_n5Clientes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tresumenrfm_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00014 ;
          prmBC00014 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00015 ;
          prmBC00015 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00013 ;
          prmBC00013 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00012 ;
          prmBC00012 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00016 ;
          prmBC00016 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@RFMAnt",SqlDbType.Int,8,0} ,
          new Object[] {"@RFMAct",SqlDbType.Int,8,0} ,
          new Object[] {"@Clientes",SqlDbType.Int,8,0}
          } ;
          Object[] prmBC00017 ;
          prmBC00017 = new Object[] {
          new Object[] {"@RFMAnt",SqlDbType.Int,8,0} ,
          new Object[] {"@RFMAct",SqlDbType.Int,8,0} ,
          new Object[] {"@Clientes",SqlDbType.Int,8,0} ,
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00018 ;
          prmBC00018 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          Object[] prmBC00019 ;
          prmBC00019 = new Object[] {
          new Object[] {"@Region",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@Sucursal",SqlDbType.SmallInt,4,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [Region], [Sucursal], [RFMAnt], [RFMAct], [Clientes] FROM [tResumenRFM] WITH (UPDLOCK) WHERE [Region] = @Region AND [Sucursal] = @Sucursal ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [Region], [Sucursal], [RFMAnt], [RFMAct], [Clientes] FROM [tResumenRFM] WHERE [Region] = @Region AND [Sucursal] = @Sucursal ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT TM1.[Region], TM1.[Sucursal], TM1.[RFMAnt], TM1.[RFMAct], TM1.[Clientes] FROM [tResumenRFM] TM1 WHERE TM1.[Region] = @Region and TM1.[Sucursal] = @Sucursal ORDER BY TM1.[Region], TM1.[Sucursal]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT [Region], [Sucursal] FROM [tResumenRFM] WHERE [Region] = @Region AND [Sucursal] = @Sucursal  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "INSERT INTO [tResumenRFM]([Region], [Sucursal], [RFMAnt], [RFMAct], [Clientes]) VALUES(@Region, @Sucursal, @RFMAnt, @RFMAct, @Clientes)", GxErrorMask.GX_NOMASK,prmBC00016)
             ,new CursorDef("BC00017", "UPDATE [tResumenRFM] SET [RFMAnt]=@RFMAnt, [RFMAct]=@RFMAct, [Clientes]=@Clientes  WHERE [Region] = @Region AND [Sucursal] = @Sucursal", GxErrorMask.GX_NOMASK,prmBC00017)
             ,new CursorDef("BC00018", "DELETE FROM [tResumenRFM]  WHERE [Region] = @Region AND [Sucursal] = @Sucursal", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "SELECT TM1.[Region], TM1.[Sucursal], TM1.[RFMAnt], TM1.[RFMAct], TM1.[Clientes] FROM [tResumenRFM] TM1 WHERE TM1.[Region] = @Region and TM1.[Sucursal] = @Sucursal ORDER BY TM1.[Region], TM1.[Sucursal]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00019,100, GxCacheFrequency.OFF ,true,false )
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
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1) ;
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((int[]) buf[2])[0] = rslt.getInt(3) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
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
             case 5 :
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
             case 6 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
             case 7 :
                stmt.SetParameter(1, (short)parms[0]);
                stmt.SetParameter(2, (short)parms[1]);
                return;
       }
    }

 }

}
