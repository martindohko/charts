/*
				   File: type_SdtQueryViewerAxes_Axis_Format_ConditionalStyle
			Description: ConditionalStyles
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
	[XmlRoot(ElementName="QueryViewerAxes.Axis.Format.ConditionalStyle")]
	[XmlType(TypeName="QueryViewerAxes.Axis.Format.ConditionalStyle" , Namespace="RFM" )]
	[Serializable]
	public class SdtQueryViewerAxes_Axis_Format_ConditionalStyle : GxUserType
	{
		public SdtQueryViewerAxes_Axis_Format_ConditionalStyle( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Operator = "";

			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value1 = "";

			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value2 = "";

			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Styleorclass = "";

		}

		public SdtQueryViewerAxes_Axis_Format_ConditionalStyle(IGxContext context)
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
			AddObjectProperty("Operator", gxTpr_Operator, false);


			AddObjectProperty("Value1", gxTpr_Value1, false);


			AddObjectProperty("Value2", gxTpr_Value2, false);


			AddObjectProperty("StyleOrClass", gxTpr_Styleorclass, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Operator")]
		[XmlElement(ElementName="Operator")]
		public String gxTpr_Operator
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Operator; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Operator = value;
				SetDirty("Operator");
			}
		}




		[SoapElement(ElementName="Value1")]
		[XmlElement(ElementName="Value1")]
		public String gxTpr_Value1
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value1; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value1 = value;
				SetDirty("Value1");
			}
		}




		[SoapElement(ElementName="Value2")]
		[XmlElement(ElementName="Value2")]
		public String gxTpr_Value2
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value2; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value2 = value;
				SetDirty("Value2");
			}
		}




		[SoapElement(ElementName="StyleOrClass")]
		[XmlElement(ElementName="StyleOrClass")]
		public String gxTpr_Styleorclass
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Styleorclass; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Styleorclass = value;
				SetDirty("Styleorclass");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Operator = "";
			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value1 = "";
			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value2 = "";
			gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Styleorclass = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Operator;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value1;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Value2;
		 

		protected String gxTv_SdtQueryViewerAxes_Axis_Format_ConditionalStyle_Styleorclass;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerAxes.Axis.Format.ConditionalStyle", Namespace="RFM")]
	public class SdtQueryViewerAxes_Axis_Format_ConditionalStyle_RESTInterface : GxGenericCollectionItem<SdtQueryViewerAxes_Axis_Format_ConditionalStyle>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerAxes_Axis_Format_ConditionalStyle_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerAxes_Axis_Format_ConditionalStyle_RESTInterface( SdtQueryViewerAxes_Axis_Format_ConditionalStyle psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Operator", Order=0)]
		public  String gxTpr_Operator
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Operator);

			}
			set { 
				 sdt.gxTpr_Operator = value;
			}
		}

		[DataMember(Name="Value1", Order=1)]
		public  String gxTpr_Value1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value1);

			}
			set { 
				 sdt.gxTpr_Value1 = value;
			}
		}

		[DataMember(Name="Value2", Order=2)]
		public  String gxTpr_Value2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Value2);

			}
			set { 
				 sdt.gxTpr_Value2 = value;
			}
		}

		[DataMember(Name="StyleOrClass", Order=3)]
		public  String gxTpr_Styleorclass
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Styleorclass);

			}
			set { 
				 sdt.gxTpr_Styleorclass = value;
			}
		}


		#endregion

		public SdtQueryViewerAxes_Axis_Format_ConditionalStyle sdt
		{
			get { 
				return (SdtQueryViewerAxes_Axis_Format_ConditionalStyle)Sdt;
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
				sdt = new SdtQueryViewerAxes_Axis_Format_ConditionalStyle() ;
			}
		}
	}
	#endregion
}