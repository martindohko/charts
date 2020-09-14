/*
				   File: type_SdtQueryViewerAxes_Axis
			Description: QueryViewerAxes
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
	[XmlRoot(ElementName="Axis")]
	[XmlType(TypeName="Axis" , Namespace="RFM" )]
	[Serializable]
	public class SdtQueryViewerAxes_Axis : GxUserType
	{
		public SdtQueryViewerAxes_Axis( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerAxes_Axis_Name = "";

			gxTv_SdtQueryViewerAxes_Axis_Title = "";

			gxTv_SdtQueryViewerAxes_Axis_Datafield = "";

			gxTv_SdtQueryViewerAxes_Axis_Type = "";

			gxTv_SdtQueryViewerAxes_Axis_Aggregation = "";

		}

		public SdtQueryViewerAxes_Axis(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("DataField", gxTpr_Datafield, false);


			AddObjectProperty("Visible", gxTpr_Visible, false);


			AddObjectProperty("Type", gxTpr_Type, false);


			AddObjectProperty("Aggregation", gxTpr_Aggregation, false);

			if (gxTv_SdtQueryViewerAxes_Axis_Filter != null)
			{
				AddObjectProperty("Filter", gxTv_SdtQueryViewerAxes_Axis_Filter, false);  
			}
			if (gxTv_SdtQueryViewerAxes_Axis_Expandcollapse != null)
			{
				AddObjectProperty("ExpandCollapse", gxTv_SdtQueryViewerAxes_Axis_Expandcollapse, false);  
			}
			if (gxTv_SdtQueryViewerAxes_Axis_Axisorder != null)
			{
				AddObjectProperty("AxisOrder", gxTv_SdtQueryViewerAxes_Axis_Axisorder, false);  
			}
			if (gxTv_SdtQueryViewerAxes_Axis_Format != null)
			{
				AddObjectProperty("Format", gxTv_SdtQueryViewerAxes_Axis_Format, false);  
			}
			if (gxTv_SdtQueryViewerAxes_Axis_Grouping != null)
			{
				AddObjectProperty("Grouping", gxTv_SdtQueryViewerAxes_Axis_Grouping, false);  
			}
			if (gxTv_SdtQueryViewerAxes_Axis_Actions != null)
			{
				AddObjectProperty("Actions", gxTv_SdtQueryViewerAxes_Axis_Actions, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public String gxTpr_Name
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Name; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public String gxTpr_Title
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Title; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="DataField")]
		[XmlElement(ElementName="DataField")]
		public String gxTpr_Datafield
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Datafield; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Datafield = value;
				SetDirty("Datafield");
			}
		}




		[SoapElement(ElementName="Visible")]
		[XmlElement(ElementName="Visible")]
		public bool gxTpr_Visible
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Visible; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Visible = value;
				SetDirty("Visible");
			}
		}




		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public String gxTpr_Type
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Type; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Type = value;
				SetDirty("Type");
			}
		}




		[SoapElement(ElementName="Aggregation")]
		[XmlElement(ElementName="Aggregation")]
		public String gxTpr_Aggregation
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Aggregation; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Aggregation = value;
				SetDirty("Aggregation");
			}
		}



		[SoapElement(ElementName="Filter" )]
		[XmlElement(ElementName="Filter" )]
		public SdtQueryViewerAxes_Axis_Filter gxTpr_Filter
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_Filter == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_Filter = new SdtQueryViewerAxes_Axis_Filter(context);
				}
				gxTv_SdtQueryViewerAxes_Axis_Filter_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_Filter;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_Filter_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_Filter = value;
				SetDirty("Filter");
			}

		}

		public void gxTv_SdtQueryViewerAxes_Axis_Filter_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_Filter_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_Filter = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_Filter_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_Filter == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Filter_Json()
		{
					return gxTv_SdtQueryViewerAxes_Axis_Filter != null;

		}


		[SoapElement(ElementName="ExpandCollapse" )]
		[XmlElement(ElementName="ExpandCollapse" )]
		public SdtQueryViewerAxes_Axis_ExpandCollapse gxTpr_Expandcollapse
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_Expandcollapse == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_Expandcollapse = new SdtQueryViewerAxes_Axis_ExpandCollapse(context);
				}
				gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_Expandcollapse;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_Expandcollapse = value;
				SetDirty("Expandcollapse");
			}

		}

		public void gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_Expandcollapse = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_Expandcollapse == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Expandcollapse_Json()
		{
					return gxTv_SdtQueryViewerAxes_Axis_Expandcollapse != null;

		}


		[SoapElement(ElementName="AxisOrder" )]
		[XmlElement(ElementName="AxisOrder" )]
		public SdtQueryViewerAxes_Axis_AxisOrder gxTpr_Axisorder
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_Axisorder == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_Axisorder = new SdtQueryViewerAxes_Axis_AxisOrder(context);
				}
				gxTv_SdtQueryViewerAxes_Axis_Axisorder_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_Axisorder;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_Axisorder_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_Axisorder = value;
				SetDirty("Axisorder");
			}

		}

		public void gxTv_SdtQueryViewerAxes_Axis_Axisorder_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_Axisorder_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_Axisorder = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_Axisorder_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_Axisorder == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Axisorder_Json()
		{
					return gxTv_SdtQueryViewerAxes_Axis_Axisorder != null;

		}


		[SoapElement(ElementName="Format" )]
		[XmlElement(ElementName="Format" )]
		public SdtQueryViewerAxes_Axis_Format gxTpr_Format
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_Format == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_Format = new SdtQueryViewerAxes_Axis_Format(context);
				}
				gxTv_SdtQueryViewerAxes_Axis_Format_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_Format;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_Format_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_Format = value;
				SetDirty("Format");
			}

		}

		public void gxTv_SdtQueryViewerAxes_Axis_Format_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_Format_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_Format = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_Format_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_Format == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Format_Json()
		{
					return gxTv_SdtQueryViewerAxes_Axis_Format != null;

		}


		[SoapElement(ElementName="Grouping" )]
		[XmlElement(ElementName="Grouping" )]
		public SdtQueryViewerAxes_Axis_Grouping gxTpr_Grouping
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_Grouping == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_Grouping = new SdtQueryViewerAxes_Axis_Grouping(context);
				}
				gxTv_SdtQueryViewerAxes_Axis_Grouping_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_Grouping;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_Grouping_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_Grouping = value;
				SetDirty("Grouping");
			}

		}

		public void gxTv_SdtQueryViewerAxes_Axis_Grouping_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_Grouping_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_Grouping = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_Grouping_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_Grouping == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Grouping_Json()
		{
					return gxTv_SdtQueryViewerAxes_Axis_Grouping != null;

		}


		[SoapElement(ElementName="Actions" )]
		[XmlElement(ElementName="Actions" )]
		public SdtQueryViewerAxes_Axis_Actions gxTpr_Actions
		{
			get {
				if ( gxTv_SdtQueryViewerAxes_Axis_Actions == null )
				{
					gxTv_SdtQueryViewerAxes_Axis_Actions = new SdtQueryViewerAxes_Axis_Actions(context);
				}
				gxTv_SdtQueryViewerAxes_Axis_Actions_N = 0;

				return gxTv_SdtQueryViewerAxes_Axis_Actions;
			}
			set {
				gxTv_SdtQueryViewerAxes_Axis_Actions_N = 0;

				gxTv_SdtQueryViewerAxes_Axis_Actions = value;
				SetDirty("Actions");
			}

		}

		public void gxTv_SdtQueryViewerAxes_Axis_Actions_SetNull()
		{
			gxTv_SdtQueryViewerAxes_Axis_Actions_N = 1;

			gxTv_SdtQueryViewerAxes_Axis_Actions = null;
			return  ;
		}

		public bool gxTv_SdtQueryViewerAxes_Axis_Actions_IsNull()
		{
			if (gxTv_SdtQueryViewerAxes_Axis_Actions == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Actions_Json()
		{
					return gxTv_SdtQueryViewerAxes_Axis_Actions != null;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerAxes_Axis_Name = "";
			gxTv_SdtQueryViewerAxes_Axis_Title = "";
			gxTv_SdtQueryViewerAxes_Axis_Datafield = "";
			gxTv_SdtQueryViewerAxes_Axis_Visible = true;
			gxTv_SdtQueryViewerAxes_Axis_Type = "";
			gxTv_SdtQueryViewerAxes_Axis_Aggregation = "";

			gxTv_SdtQueryViewerAxes_Axis_Filter_N = 1;


			gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_N = 1;


			gxTv_SdtQueryViewerAxes_Axis_Axisorder_N = 1;


			gxTv_SdtQueryViewerAxes_Axis_Format_N = 1;


			gxTv_SdtQueryViewerAxes_Axis_Grouping_N = 1;


			gxTv_SdtQueryViewerAxes_Axis_Actions_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtQueryViewerAxes_Axis_Name;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Title;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Datafield;
		 

		protected bool gxTv_SdtQueryViewerAxes_Axis_Visible;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Type;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Aggregation;
		 
		protected short gxTv_SdtQueryViewerAxes_Axis_Filter_N;
		protected SdtQueryViewerAxes_Axis_Filter gxTv_SdtQueryViewerAxes_Axis_Filter = null; 

		protected short gxTv_SdtQueryViewerAxes_Axis_Expandcollapse_N;
		protected SdtQueryViewerAxes_Axis_ExpandCollapse gxTv_SdtQueryViewerAxes_Axis_Expandcollapse = null; 

		protected short gxTv_SdtQueryViewerAxes_Axis_Axisorder_N;
		protected SdtQueryViewerAxes_Axis_AxisOrder gxTv_SdtQueryViewerAxes_Axis_Axisorder = null; 

		protected short gxTv_SdtQueryViewerAxes_Axis_Format_N;
		protected SdtQueryViewerAxes_Axis_Format gxTv_SdtQueryViewerAxes_Axis_Format = null; 

		protected short gxTv_SdtQueryViewerAxes_Axis_Grouping_N;
		protected SdtQueryViewerAxes_Axis_Grouping gxTv_SdtQueryViewerAxes_Axis_Grouping = null; 

		protected short gxTv_SdtQueryViewerAxes_Axis_Actions_N;
		protected SdtQueryViewerAxes_Axis_Actions gxTv_SdtQueryViewerAxes_Axis_Actions = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Axis", Namespace="RFM")]
	public class SdtQueryViewerAxes_Axis_RESTInterface : GxGenericCollectionItem<SdtQueryViewerAxes_Axis>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerAxes_Axis_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerAxes_Axis_RESTInterface( SdtQueryViewerAxes_Axis psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  String gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  String gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="DataField", Order=2)]
		public  String gxTpr_Datafield
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Datafield);

			}
			set { 
				 sdt.gxTpr_Datafield = value;
			}
		}

		[DataMember(Name="Visible", Order=3)]
		public bool gxTpr_Visible
		{
			get { 
				return sdt.gxTpr_Visible;

			}
			set { 
				sdt.gxTpr_Visible = value;
			}
		}

		[DataMember(Name="Type", Order=4)]
		public  String gxTpr_Type
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Type);

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Aggregation", Order=5)]
		public  String gxTpr_Aggregation
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Aggregation);

			}
			set { 
				 sdt.gxTpr_Aggregation = value;
			}
		}

		[DataMember(Name="Filter", Order=6, EmitDefaultValue=false)]
		public SdtQueryViewerAxes_Axis_Filter_RESTInterface gxTpr_Filter
		{
			get {
				if (sdt.ShouldSerializegxTpr_Filter_Json())
					return new SdtQueryViewerAxes_Axis_Filter_RESTInterface(sdt.gxTpr_Filter);
				else
					return null;

			}

			set {
				sdt.gxTpr_Filter = value.sdt;
			}

		}

		[DataMember(Name="ExpandCollapse", Order=7, EmitDefaultValue=false)]
		public SdtQueryViewerAxes_Axis_ExpandCollapse_RESTInterface gxTpr_Expandcollapse
		{
			get {
				if (sdt.ShouldSerializegxTpr_Expandcollapse_Json())
					return new SdtQueryViewerAxes_Axis_ExpandCollapse_RESTInterface(sdt.gxTpr_Expandcollapse);
				else
					return null;

			}

			set {
				sdt.gxTpr_Expandcollapse = value.sdt;
			}

		}

		[DataMember(Name="AxisOrder", Order=8, EmitDefaultValue=false)]
		public SdtQueryViewerAxes_Axis_AxisOrder_RESTInterface gxTpr_Axisorder
		{
			get {
				if (sdt.ShouldSerializegxTpr_Axisorder_Json())
					return new SdtQueryViewerAxes_Axis_AxisOrder_RESTInterface(sdt.gxTpr_Axisorder);
				else
					return null;

			}

			set {
				sdt.gxTpr_Axisorder = value.sdt;
			}

		}

		[DataMember(Name="Format", Order=9, EmitDefaultValue=false)]
		public SdtQueryViewerAxes_Axis_Format_RESTInterface gxTpr_Format
		{
			get {
				if (sdt.ShouldSerializegxTpr_Format_Json())
					return new SdtQueryViewerAxes_Axis_Format_RESTInterface(sdt.gxTpr_Format);
				else
					return null;

			}

			set {
				sdt.gxTpr_Format = value.sdt;
			}

		}

		[DataMember(Name="Grouping", Order=10, EmitDefaultValue=false)]
		public SdtQueryViewerAxes_Axis_Grouping_RESTInterface gxTpr_Grouping
		{
			get {
				if (sdt.ShouldSerializegxTpr_Grouping_Json())
					return new SdtQueryViewerAxes_Axis_Grouping_RESTInterface(sdt.gxTpr_Grouping);
				else
					return null;

			}

			set {
				sdt.gxTpr_Grouping = value.sdt;
			}

		}

		[DataMember(Name="Actions", Order=11, EmitDefaultValue=false)]
		public SdtQueryViewerAxes_Axis_Actions_RESTInterface gxTpr_Actions
		{
			get {
				if (sdt.ShouldSerializegxTpr_Actions_Json())
					return new SdtQueryViewerAxes_Axis_Actions_RESTInterface(sdt.gxTpr_Actions);
				else
					return null;

			}

			set {
				sdt.gxTpr_Actions = value.sdt;
			}

		}


		#endregion

		public SdtQueryViewerAxes_Axis sdt
		{
			get { 
				return (SdtQueryViewerAxes_Axis)Sdt;
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
				sdt = new SdtQueryViewerAxes_Axis() ;
			}
		}
	}
	#endregion
}