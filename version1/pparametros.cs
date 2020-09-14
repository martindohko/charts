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
namespace GeneXus.Programs.version1 {
   public class pparametros : GXProcedure
   {
      public pparametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pparametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref String aP0_parametro ,
                           ref short aP1_clave1 ,
                           ref short aP2_clave2 )
      {
         this.AV10parametro = aP0_parametro;
         this.AV11clave1 = aP1_clave1;
         this.AV12clave2 = aP2_clave2;
         initialize();
         executePrivate();
         aP0_parametro=this.AV10parametro;
         aP1_clave1=this.AV11clave1;
         aP2_clave2=this.AV12clave2;
      }

      public short executeUdp( ref String aP0_parametro ,
                               ref short aP1_clave1 )
      {
         execute(ref aP0_parametro, ref aP1_clave1, ref aP2_clave2);
         return AV12clave2 ;
      }

      public void executeSubmit( ref String aP0_parametro ,
                                 ref short aP1_clave1 ,
                                 ref short aP2_clave2 )
      {
         pparametros objpparametros;
         objpparametros = new pparametros();
         objpparametros.AV10parametro = aP0_parametro;
         objpparametros.AV11clave1 = aP1_clave1;
         objpparametros.AV12clave2 = aP2_clave2;
         objpparametros.context.SetSubmitInitialConfig(context);
         objpparametros.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpparametros);
         aP0_parametro=this.AV10parametro;
         aP1_clave1=this.AV11clave1;
         aP2_clave2=this.AV12clave2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pparametros)stateInfo).executePrivate();
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
         AV11clave1 = 0;
         AV12clave2 = 0;
         /* Using cursor P000E2 */
         pr_default.execute(0, new Object[] {AV10parametro});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A26Parametro = P000E2_A26Parametro[0];
            A27Clave1 = P000E2_A27Clave1[0];
            A28Clave2 = P000E2_A28Clave2[0];
            AV11clave1 = A27Clave1;
            AV12clave2 = A28Clave2;
            /* Exiting from a For First loop. */
            if (true) break;
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
         P000E2_A26Parametro = new String[] {""} ;
         P000E2_A27Clave1 = new short[1] ;
         P000E2_A28Clave2 = new short[1] ;
         A26Parametro = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.version1.pparametros__default(),
            new Object[][] {
                new Object[] {
               P000E2_A26Parametro, P000E2_A27Clave1, P000E2_A28Clave2
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11clave1 ;
      private short AV12clave2 ;
      private short A27Clave1 ;
      private short A28Clave2 ;
      private String scmdbuf ;
      private String AV10parametro ;
      private String A26Parametro ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private String aP0_parametro ;
      private short aP1_clave1 ;
      private short aP2_clave2 ;
      private IDataStoreProvider pr_default ;
      private String[] P000E2_A26Parametro ;
      private short[] P000E2_A27Clave1 ;
      private short[] P000E2_A28Clave2 ;
   }

   public class pparametros__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000E2 ;
          prmP000E2 = new Object[] {
          new Object[] {"@AV10parametro",SqlDbType.NVarChar,100,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("P000E2", "SELECT [Parametro], [Clave1], [Clave2] FROM [Parametros] WHERE [Parametro] = @AV10parametro ORDER BY [Parametro] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000E2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2) ;
                ((short[]) buf[2])[0] = rslt.getShort(3) ;
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
       }
    }

 }

}
