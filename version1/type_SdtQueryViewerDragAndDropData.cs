/*
				   File: type_SdtQueryViewerDragAndDropData
			Description: QueryViewerDragAndDropData
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
	[XmlRoot(ElementName="QueryViewerDragAndDropData")]
	[XmlType(TypeName="QueryViewerDragAndDropData" , Namespace="RFM" )]
	[Serializable]
	public class SdtQueryViewerDragAndDropData : GxUserType
	{
		public SdtQueryViewerDragAndDropData( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerDragAndDropData_Name = "";

			gxTv_SdtQueryViewerDragAndDropData_Axis = "";

		}

		public SdtQueryViewerDragAndDropData(IGxContext context)
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


			AddObjectProperty("Axis", gxTpr_Axis, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public String gxTpr_Name
		{
			get { 
				return gxTv_SdtQueryViewerDragAndDropData_Name; 
			}
			set { 
				gxTv_SdtQueryViewerDragAndDropData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Axis")]
		[XmlElement(ElementName="Axis")]
		public String gxTpr_Axis
		{
			get { 
				return gxTv_SdtQueryViewerDragAndDropData_Axis; 
			}
			set { 
				gxTv_SdtQueryViewerDragAndDropData_Axis = value;
				SetDirty("Axis");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerDragAndDropData_Name = "";
			gxTv_SdtQueryViewerDragAndDropData_Axis = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtQueryViewerDragAndDropData_Name;
		 

		protected String gxTv_SdtQueryViewerDragAndDropData_Axis;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerDragAndDropData", Namespace="RFM")]
	public class SdtQueryViewerDragAndDropData_RESTInterface : GxGenericCollectionItem<SdtQueryViewerDragAndDropData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerDragAndDropData_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerDragAndDropData_RESTInterface( SdtQueryViewerDragAndDropData psdt ) : base(psdt)
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

		[DataMember(Name="Axis", Order=1)]
		public  String gxTpr_Axis
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Axis);

			}
			set { 
				 sdt.gxTpr_Axis = value;
			}
		}


		#endregion

		public SdtQueryViewerDragAndDropData sdt
		{
			get { 
				return (SdtQueryViewerDragAndDropData)Sdt;
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
				sdt = new SdtQueryViewerDragAndDropData() ;
			}
		}
	}
	#endregion
}