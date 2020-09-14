using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class listprograms : GXProcedure
   {
      public listprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public listprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<SdtProgramNames_ProgramName>( context, "ProgramName", "RFM") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         listprograms objlistprograms;
         objlistprograms = new listprograms();
         objlistprograms.AV9ProgramNames = new GXBaseCollection<SdtProgramNames_ProgramName>( context, "ProgramName", "RFM") ;
         objlistprograms.context.SetSubmitInitialConfig(context);
         objlistprograms.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistprograms);
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listprograms)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProgramNames = new GXBaseCollection<SdtProgramNames_ProgramName>( context, "ProgramName", "RFM");
         AV11name = "WWResumenRFMGlobal";
         AV12description = "Resumen RFMGlobals";
         AV13link = "wwresumenrfmglobal.aspx";
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11name = "WWtResumenRFM";
         AV12description = "t Resumen RFMs";
         AV13link = "wwtresumenrfm.aspx";
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         AV8IsAuthorized = true;
         GXt_boolean1 = AV8IsAuthorized;
         new isauthorized(context ).execute(  AV11name, out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV11name;
            AV10ProgramName.gxTpr_Description = AV12description;
            AV10ProgramName.gxTpr_Link = AV13link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV11name = "";
         AV12description = "";
         AV13link = "";
         AV10ProgramName = new SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private String AV11name ;
      private String AV12description ;
      private String AV13link ;
      private GXBaseCollection<SdtProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<SdtProgramNames_ProgramName> AV9ProgramNames ;
      private SdtProgramNames_ProgramName AV10ProgramName ;
   }

}
