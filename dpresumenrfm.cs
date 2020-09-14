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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class dpresumenrfm : GXProcedure
   {
      public dpresumenrfm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public dpresumenrfm( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<SdtResumen> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<SdtResumen>( context, "Resumen", "RFM") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<SdtResumen> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<SdtResumen> aP0_Gxm2rootcol )
      {
         dpresumenrfm objdpresumenrfm;
         objdpresumenrfm = new dpresumenrfm();
         objdpresumenrfm.Gxm2rootcol = new GXBaseCollection<SdtResumen>( context, "Resumen", "RFM") ;
         objdpresumenrfm.context.SetSubmitInitialConfig(context);
         objdpresumenrfm.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdpresumenrfm);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((dpresumenrfm)stateInfo).executePrivate();
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
         /* Using cursor P00022 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A3RFMAnt = P00022_A3RFMAnt[0];
            n3RFMAnt = P00022_n3RFMAnt[0];
            A4RFMAct = P00022_A4RFMAct[0];
            n4RFMAct = P00022_n4RFMAct[0];
            A5Clientes = P00022_A5Clientes[0];
            n5Clientes = P00022_n5Clientes[0];
            A1Region = P00022_A1Region[0];
            A2Sucursal = P00022_A2Sucursal[0];
            Gxm1resumen = new SdtResumen(context);
            Gxm2rootcol.Add(Gxm1resumen, 0);
            Gxm1resumen.gxTpr_Sdfrom = StringUtil.Str( (decimal)(A3RFMAnt), 8, 0);
            Gxm1resumen.gxTpr_Sdto = StringUtil.Str( (decimal)(A4RFMAct), 8, 0);
            Gxm1resumen.gxTpr_Sdweight = (short)(A5Clientes);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
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
         scmdbuf = "";
         P00022_A3RFMAnt = new int[1] ;
         P00022_n3RFMAnt = new bool[] {false} ;
         P00022_A4RFMAct = new int[1] ;
         P00022_n4RFMAct = new bool[] {false} ;
         P00022_A5Clientes = new int[1] ;
         P00022_n5Clientes = new bool[] {false} ;
         P00022_A1Region = new short[1] ;
         P00022_A2Sucursal = new short[1] ;
         Gxm1resumen = new SdtResumen(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.dpresumenrfm__default(),
            new Object[][] {
                new Object[] {
               P00022_A3RFMAnt, P00022_n3RFMAnt, P00022_A4RFMAct, P00022_n4RFMAct, P00022_A5Clientes, P00022_n5Clientes, P00022_A1Region, P00022_A2Sucursal
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1Region ;
      private short A2Sucursal ;
      private int A3RFMAnt ;
      private int A4RFMAct ;
      private int A5Clientes ;
      private String scmdbuf ;
      private bool n3RFMAnt ;
      private bool n4RFMAct ;
      private bool n5Clientes ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00022_A3RFMAnt ;
      private bool[] P00022_n3RFMAnt ;
      private int[] P00022_A4RFMAct ;
      private bool[] P00022_n4RFMAct ;
      private int[] P00022_A5Clientes ;
      private bool[] P00022_n5Clientes ;
      private short[] P00022_A1Region ;
      private short[] P00022_A2Sucursal ;
      private GXBaseCollection<SdtResumen> aP0_Gxm2rootcol ;
      private GXBaseCollection<SdtResumen> Gxm2rootcol ;
      private SdtResumen Gxm1resumen ;
   }

   public class dpresumenrfm__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00022 ;
          prmP00022 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("P00022", "SELECT [RFMAnt], [RFMAct], [Clientes], [Region], [Sucursal] FROM [tResumenRFM] ORDER BY [Region], [Sucursal] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00022,100, GxCacheFrequency.OFF ,false,false )
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

 }

}
