/*
				   File: type_SdtQueryViewerAxes_Axis_AxisOrder
			Description: AxisOrder
				 Author: Nemo 🐠 for C# (.NET Core) version 16.0.10.142546
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.version1
{
	[XmlRoot(ElementName="QueryViewerAxes.Axis.AxisOrder")]
	[XmlType(TypeName="QueryViewerAxes.Axis.AxisOrder" , Namespace="RFM" )]
	[Serializable]
	public class SdtQueryViewerAxes_Axis_AxisOrder : GxUserType
	{
		public SdtQueryViewerAxes_Axis_AxisOrder( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Type = "";

		}

		public SdtQueryViewerAxes_Axis_AxisOrder(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override String JsonMap(String value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (String)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("Type", gxTpr_Type, false);

			if (gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public String gxTpr_Type
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Type; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Value" , IsNullable=false )]
		public GxSimpleCollection<String> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = new GxSimpleCollection<String>( );
				}
				return gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values;
			}
			set {
				if ( gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = new GxSimpleCollection<String>( );
				}
				gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<String> gxTpr_Values
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = new GxSimpleCollection<String>();
				}
				gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values ;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
				return gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values != null && gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values.Count > 0;

		}


		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Type = "";

			gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Type;
		 
		protected short gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values_N;
		protected GxSimpleCollection<String> gxTv_SdtQueryViewerAxes_Axis_AxisOrder_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerAxes.Axis.AxisOrder", Namespace="RFM")]
	public class SdtQueryViewerAxes_Axis_AxisOrder_RESTInterface : GxGenericCollectionItem<SdtQueryViewerAxes_Axis_AxisOrder>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerAxes_Axis_AxisOrder_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerAxes_Axis_AxisOrder_RESTInterface( SdtQueryViewerAxes_Axis_AxisOrder psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Type", Order=0)]
		public  String gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Values", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<String> gxTpr_Values
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Values_GxSimpleCollection_Json())
					return sdt.gxTpr_Values;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Values = value ;
			}
		}


		#endregion

		public SdtQueryViewerAxes_Axis_AxisOrder sdt
		{
			get { 
				return (SdtQueryViewerAxes_Axis_AxisOrder)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtQueryViewerAxes_Axis_AxisOrder() ;
			}
		}
	}
	#endregion
}