using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.version1 {
   [XmlRoot(ElementName = "tResumenRFM" )]
   [XmlType(TypeName =  "tResumenRFM" , Namespace = "RFM" )]
   [Serializable]
   public class SdttResumenRFM : GxSilentTrnSdt
   {
      public SdttResumenRFM( )
      {
      }

      public SdttResumenRFM( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override String JsonMap( String value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (String)mapper[value]; ;
      }

      public void Load( short AV1Region ,
                        short AV2Sucursal )
      {
         IGxSilentTrn obj ;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1Region,(short)AV2Sucursal});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"Region", typeof(short)}, new Object[]{"Sucursal", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties() ;
         metadata.Set("Name", "Version1\\tResumenRFM");
         metadata.Set("BT", "tResumenRFM");
         metadata.Set("PK", "[ \"Region\",\"Sucursal\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection() ;
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Region_Z");
         state.Add("gxTpr_Sucursal_Z");
         state.Add("gxTpr_Rfmant_Z");
         state.Add("gxTpr_Rfmact_Z");
         state.Add("gxTpr_Clientes_Z");
         state.Add("gxTpr_Rfmant_N");
         state.Add("gxTpr_Rfmact_N");
         state.Add("gxTpr_Clientes_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.version1.SdttResumenRFM sdt ;
         sdt = (GeneXus.Programs.version1.SdttResumenRFM)(source);
         gxTv_SdttResumenRFM_Region = sdt.gxTv_SdttResumenRFM_Region ;
         gxTv_SdttResumenRFM_Sucursal = sdt.gxTv_SdttResumenRFM_Sucursal ;
         gxTv_SdttResumenRFM_Rfmant = sdt.gxTv_SdttResumenRFM_Rfmant ;
         gxTv_SdttResumenRFM_Rfmact = sdt.gxTv_SdttResumenRFM_Rfmact ;
         gxTv_SdttResumenRFM_Clientes = sdt.gxTv_SdttResumenRFM_Clientes ;
         gxTv_SdttResumenRFM_Mode = sdt.gxTv_SdttResumenRFM_Mode ;
         gxTv_SdttResumenRFM_Initialized = sdt.gxTv_SdttResumenRFM_Initialized ;
         gxTv_SdttResumenRFM_Region_Z = sdt.gxTv_SdttResumenRFM_Region_Z ;
         gxTv_SdttResumenRFM_Sucursal_Z = sdt.gxTv_SdttResumenRFM_Sucursal_Z ;
         gxTv_SdttResumenRFM_Rfmant_Z = sdt.gxTv_SdttResumenRFM_Rfmant_Z ;
         gxTv_SdttResumenRFM_Rfmact_Z = sdt.gxTv_SdttResumenRFM_Rfmact_Z ;
         gxTv_SdttResumenRFM_Clientes_Z = sdt.gxTv_SdttResumenRFM_Clientes_Z ;
         gxTv_SdttResumenRFM_Rfmant_N = sdt.gxTv_SdttResumenRFM_Rfmant_N ;
         gxTv_SdttResumenRFM_Rfmact_N = sdt.gxTv_SdttResumenRFM_Rfmact_N ;
         gxTv_SdttResumenRFM_Clientes_N = sdt.gxTv_SdttResumenRFM_Clientes_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("Region", gxTv_SdttResumenRFM_Region, false, includeNonInitialized);
         AddObjectProperty("Sucursal", gxTv_SdttResumenRFM_Sucursal, false, includeNonInitialized);
         AddObjectProperty("RFMAnt", gxTv_SdttResumenRFM_Rfmant, false, includeNonInitialized);
         AddObjectProperty("RFMAnt_N", gxTv_SdttResumenRFM_Rfmant_N, false, includeNonInitialized);
         AddObjectProperty("RFMAct", gxTv_SdttResumenRFM_Rfmact, false, includeNonInitialized);
         AddObjectProperty("RFMAct_N", gxTv_SdttResumenRFM_Rfmact_N, false, includeNonInitialized);
         AddObjectProperty("Clientes", gxTv_SdttResumenRFM_Clientes, false, includeNonInitialized);
         AddObjectProperty("Clientes_N", gxTv_SdttResumenRFM_Clientes_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdttResumenRFM_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdttResumenRFM_Initialized, false, includeNonInitialized);
            AddObjectProperty("Region_Z", gxTv_SdttResumenRFM_Region_Z, false, includeNonInitialized);
            AddObjectProperty("Sucursal_Z", gxTv_SdttResumenRFM_Sucursal_Z, false, includeNonInitialized);
            AddObjectProperty("RFMAnt_Z", gxTv_SdttResumenRFM_Rfmant_Z, false, includeNonInitialized);
            AddObjectProperty("RFMAct_Z", gxTv_SdttResumenRFM_Rfmact_Z, false, includeNonInitialized);
            AddObjectProperty("Clientes_Z", gxTv_SdttResumenRFM_Clientes_Z, false, includeNonInitialized);
            AddObjectProperty("RFMAnt_N", gxTv_SdttResumenRFM_Rfmant_N, false, includeNonInitialized);
            AddObjectProperty("RFMAct_N", gxTv_SdttResumenRFM_Rfmact_N, false, includeNonInitialized);
            AddObjectProperty("Clientes_N", gxTv_SdttResumenRFM_Clientes_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.version1.SdttResumenRFM sdt )
      {
         if ( sdt.IsDirty("Region") )
         {
            gxTv_SdttResumenRFM_Region = sdt.gxTv_SdttResumenRFM_Region ;
         }
         if ( sdt.IsDirty("Sucursal") )
         {
            gxTv_SdttResumenRFM_Sucursal = sdt.gxTv_SdttResumenRFM_Sucursal ;
         }
         if ( sdt.IsDirty("RFMAnt") )
         {
            gxTv_SdttResumenRFM_Rfmant_N = 0;
            gxTv_SdttResumenRFM_Rfmant = sdt.gxTv_SdttResumenRFM_Rfmant ;
         }
         if ( sdt.IsDirty("RFMAct") )
         {
            gxTv_SdttResumenRFM_Rfmact_N = 0;
            gxTv_SdttResumenRFM_Rfmact = sdt.gxTv_SdttResumenRFM_Rfmact ;
         }
         if ( sdt.IsDirty("Clientes") )
         {
            gxTv_SdttResumenRFM_Clientes_N = 0;
            gxTv_SdttResumenRFM_Clientes = sdt.gxTv_SdttResumenRFM_Clientes ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "Region" )]
      [  XmlElement( ElementName = "Region"   )]
      public short gxTpr_Region
      {
         get {
            return gxTv_SdttResumenRFM_Region ;
         }

         set {
            if ( gxTv_SdttResumenRFM_Region != value )
            {
               gxTv_SdttResumenRFM_Mode = "INS";
               this.gxTv_SdttResumenRFM_Region_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Sucursal_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Rfmant_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Rfmact_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Clientes_Z_SetNull( );
            }
            gxTv_SdttResumenRFM_Region = value;
            SetDirty("Region");
         }

      }

      [  SoapElement( ElementName = "Sucursal" )]
      [  XmlElement( ElementName = "Sucursal"   )]
      public short gxTpr_Sucursal
      {
         get {
            return gxTv_SdttResumenRFM_Sucursal ;
         }

         set {
            if ( gxTv_SdttResumenRFM_Sucursal != value )
            {
               gxTv_SdttResumenRFM_Mode = "INS";
               this.gxTv_SdttResumenRFM_Region_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Sucursal_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Rfmant_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Rfmact_Z_SetNull( );
               this.gxTv_SdttResumenRFM_Clientes_Z_SetNull( );
            }
            gxTv_SdttResumenRFM_Sucursal = value;
            SetDirty("Sucursal");
         }

      }

      [  SoapElement( ElementName = "RFMAnt" )]
      [  XmlElement( ElementName = "RFMAnt"   )]
      public int gxTpr_Rfmant
      {
         get {
            return gxTv_SdttResumenRFM_Rfmant ;
         }

         set {
            gxTv_SdttResumenRFM_Rfmant_N = 0;
            gxTv_SdttResumenRFM_Rfmant = value;
            SetDirty("Rfmant");
         }

      }

      public void gxTv_SdttResumenRFM_Rfmant_SetNull( )
      {
         gxTv_SdttResumenRFM_Rfmant_N = 1;
         gxTv_SdttResumenRFM_Rfmant = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Rfmant_IsNull( )
      {
         return (gxTv_SdttResumenRFM_Rfmant_N==1) ;
      }

      [  SoapElement( ElementName = "RFMAct" )]
      [  XmlElement( ElementName = "RFMAct"   )]
      public int gxTpr_Rfmact
      {
         get {
            return gxTv_SdttResumenRFM_Rfmact ;
         }

         set {
            gxTv_SdttResumenRFM_Rfmact_N = 0;
            gxTv_SdttResumenRFM_Rfmact = value;
            SetDirty("Rfmact");
         }

      }

      public void gxTv_SdttResumenRFM_Rfmact_SetNull( )
      {
         gxTv_SdttResumenRFM_Rfmact_N = 1;
         gxTv_SdttResumenRFM_Rfmact = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Rfmact_IsNull( )
      {
         return (gxTv_SdttResumenRFM_Rfmact_N==1) ;
      }

      [  SoapElement( ElementName = "Clientes" )]
      [  XmlElement( ElementName = "Clientes"   )]
      public int gxTpr_Clientes
      {
         get {
            return gxTv_SdttResumenRFM_Clientes ;
         }

         set {
            gxTv_SdttResumenRFM_Clientes_N = 0;
            gxTv_SdttResumenRFM_Clientes = value;
            SetDirty("Clientes");
         }

      }

      public void gxTv_SdttResumenRFM_Clientes_SetNull( )
      {
         gxTv_SdttResumenRFM_Clientes_N = 1;
         gxTv_SdttResumenRFM_Clientes = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Clientes_IsNull( )
      {
         return (gxTv_SdttResumenRFM_Clientes_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public String gxTpr_Mode
      {
         get {
            return gxTv_SdttResumenRFM_Mode ;
         }

         set {
            gxTv_SdttResumenRFM_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdttResumenRFM_Mode_SetNull( )
      {
         gxTv_SdttResumenRFM_Mode = "";
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdttResumenRFM_Initialized ;
         }

         set {
            gxTv_SdttResumenRFM_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdttResumenRFM_Initialized_SetNull( )
      {
         gxTv_SdttResumenRFM_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Region_Z" )]
      [  XmlElement( ElementName = "Region_Z"   )]
      public short gxTpr_Region_Z
      {
         get {
            return gxTv_SdttResumenRFM_Region_Z ;
         }

         set {
            gxTv_SdttResumenRFM_Region_Z = value;
            SetDirty("Region_Z");
         }

      }

      public void gxTv_SdttResumenRFM_Region_Z_SetNull( )
      {
         gxTv_SdttResumenRFM_Region_Z = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Region_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Sucursal_Z" )]
      [  XmlElement( ElementName = "Sucursal_Z"   )]
      public short gxTpr_Sucursal_Z
      {
         get {
            return gxTv_SdttResumenRFM_Sucursal_Z ;
         }

         set {
            gxTv_SdttResumenRFM_Sucursal_Z = value;
            SetDirty("Sucursal_Z");
         }

      }

      public void gxTv_SdttResumenRFM_Sucursal_Z_SetNull( )
      {
         gxTv_SdttResumenRFM_Sucursal_Z = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Sucursal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RFMAnt_Z" )]
      [  XmlElement( ElementName = "RFMAnt_Z"   )]
      public int gxTpr_Rfmant_Z
      {
         get {
            return gxTv_SdttResumenRFM_Rfmant_Z ;
         }

         set {
            gxTv_SdttResumenRFM_Rfmant_Z = value;
            SetDirty("Rfmant_Z");
         }

      }

      public void gxTv_SdttResumenRFM_Rfmant_Z_SetNull( )
      {
         gxTv_SdttResumenRFM_Rfmant_Z = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Rfmant_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RFMAct_Z" )]
      [  XmlElement( ElementName = "RFMAct_Z"   )]
      public int gxTpr_Rfmact_Z
      {
         get {
            return gxTv_SdttResumenRFM_Rfmact_Z ;
         }

         set {
            gxTv_SdttResumenRFM_Rfmact_Z = value;
            SetDirty("Rfmact_Z");
         }

      }

      public void gxTv_SdttResumenRFM_Rfmact_Z_SetNull( )
      {
         gxTv_SdttResumenRFM_Rfmact_Z = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Rfmact_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Clientes_Z" )]
      [  XmlElement( ElementName = "Clientes_Z"   )]
      public int gxTpr_Clientes_Z
      {
         get {
            return gxTv_SdttResumenRFM_Clientes_Z ;
         }

         set {
            gxTv_SdttResumenRFM_Clientes_Z = value;
            SetDirty("Clientes_Z");
         }

      }

      public void gxTv_SdttResumenRFM_Clientes_Z_SetNull( )
      {
         gxTv_SdttResumenRFM_Clientes_Z = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Clientes_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RFMAnt_N" )]
      [  XmlElement( ElementName = "RFMAnt_N"   )]
      public short gxTpr_Rfmant_N
      {
         get {
            return gxTv_SdttResumenRFM_Rfmant_N ;
         }

         set {
            gxTv_SdttResumenRFM_Rfmant_N = value;
            SetDirty("Rfmant_N");
         }

      }

      public void gxTv_SdttResumenRFM_Rfmant_N_SetNull( )
      {
         gxTv_SdttResumenRFM_Rfmant_N = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Rfmant_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RFMAct_N" )]
      [  XmlElement( ElementName = "RFMAct_N"   )]
      public short gxTpr_Rfmact_N
      {
         get {
            return gxTv_SdttResumenRFM_Rfmact_N ;
         }

         set {
            gxTv_SdttResumenRFM_Rfmact_N = value;
            SetDirty("Rfmact_N");
         }

      }

      public void gxTv_SdttResumenRFM_Rfmact_N_SetNull( )
      {
         gxTv_SdttResumenRFM_Rfmact_N = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Rfmact_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Clientes_N" )]
      [  XmlElement( ElementName = "Clientes_N"   )]
      public short gxTpr_Clientes_N
      {
         get {
            return gxTv_SdttResumenRFM_Clientes_N ;
         }

         set {
            gxTv_SdttResumenRFM_Clientes_N = value;
            SetDirty("Clientes_N");
         }

      }

      public void gxTv_SdttResumenRFM_Clientes_N_SetNull( )
      {
         gxTv_SdttResumenRFM_Clientes_N = 0;
         return  ;
      }

      public bool gxTv_SdttResumenRFM_Clientes_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdttResumenRFM_Mode = "";
         IGxSilentTrn obj ;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tresumenrfm", "GeneXus.Programs.version1.tresumenrfm_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      private short gxTv_SdttResumenRFM_Region ;
      private short gxTv_SdttResumenRFM_Sucursal ;
      private short gxTv_SdttResumenRFM_Initialized ;
      private short gxTv_SdttResumenRFM_Region_Z ;
      private short gxTv_SdttResumenRFM_Sucursal_Z ;
      private short gxTv_SdttResumenRFM_Rfmant_N ;
      private short gxTv_SdttResumenRFM_Rfmact_N ;
      private short gxTv_SdttResumenRFM_Clientes_N ;
      private int gxTv_SdttResumenRFM_Rfmant ;
      private int gxTv_SdttResumenRFM_Rfmact ;
      private int gxTv_SdttResumenRFM_Clientes ;
      private int gxTv_SdttResumenRFM_Rfmant_Z ;
      private int gxTv_SdttResumenRFM_Rfmact_Z ;
      private int gxTv_SdttResumenRFM_Clientes_Z ;
      private String gxTv_SdttResumenRFM_Mode ;
   }

   [DataContract(Name = @"Version1\tResumenRFM", Namespace = "RFM")]
   public class SdttResumenRFM_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.version1.SdttResumenRFM>
   {
      public SdttResumenRFM_RESTInterface( ) : base()
      {
      }

      public SdttResumenRFM_RESTInterface( GeneXus.Programs.version1.SdttResumenRFM psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Region" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Region
      {
         get {
            return sdt.gxTpr_Region ;
         }

         set {
            sdt.gxTpr_Region = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Sucursal" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sucursal
      {
         get {
            return sdt.gxTpr_Sucursal ;
         }

         set {
            sdt.gxTpr_Sucursal = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RFMAnt" , Order = 2 )]
      [GxSeudo()]
      public String gxTpr_Rfmant
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rfmant), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Rfmant = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "RFMAct" , Order = 3 )]
      [GxSeudo()]
      public String gxTpr_Rfmact
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Rfmact), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Rfmact = (int)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "Clientes" , Order = 4 )]
      [GxSeudo()]
      public String gxTpr_Clientes
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clientes), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Clientes = (int)(NumberUtil.Val( value, "."));
         }

      }

      public GeneXus.Programs.version1.SdttResumenRFM sdt
      {
         get {
            return (GeneXus.Programs.version1.SdttResumenRFM)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.version1.SdttResumenRFM() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (String)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private String md5Hash ;
   }

}
