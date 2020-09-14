/*
				   File: type_SdtQueryViewerAxes_Axis_Actions
			Description: Actions
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
	[XmlRoot(ElementName="QueryViewerAxes.Axis.Actions")]
	[XmlType(TypeName="QueryViewerAxes.Axis.Actions" , Namespace="RFM" )]
	[Serializable]
	public class SdtQueryViewerAxes_Axis_Actions : GxUserType
	{
		public SdtQueryViewerAxes_Axis_Actions( )
		{
			/* Constructor for serialization */
		}

		public SdtQueryViewerAxes_Axis_Actions(IGxContext context)
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
			AddObjectProperty("RaiseItemClick", gxTpr_Raiseitemclick, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RaiseItemClick")]
		[XmlElement(ElementName="RaiseItemClick")]
		public bool gxTpr_Raiseitemclick
		{
			get { 
				return gxTv_SdtQueryViewerAxes_Axis_Actions_Raiseitemclick; 
			}
			set { 
				gxTv_SdtQueryViewerAxes_Axis_Actions_Raiseitemclick = value;
				SetDirty("Raiseitemclick");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerAxes_Axis_Actions_Raiseitemclick = true;
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtQueryViewerAxes_Axis_Actions_Raiseitemclick;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerAxes.Axis.Actions", Namespace="RFM")]
	public class SdtQueryViewerAxes_Axis_Actions_RESTInterface : GxGenericCollectionItem<SdtQueryViewerAxes_Axis_Actions>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerAxes_Axis_Actions_RESTInterface( ) : base()
		{
		}

		public SdtQueryViewerAxes_Axis_Actions_RESTInterface( SdtQueryViewerAxes_Axis_Actions psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="RaiseItemClick", Order=0)]
		public bool gxTpr_Raiseitemclick
		{
			get { 
				return sdt.gxTpr_Raiseitemclick;

			}
			set { 
				sdt.gxTpr_Raiseitemclick = value;
			}
		}


		#endregion

		public SdtQueryViewerAxes_Axis_Actions sdt
		{
			get { 
				return (SdtQueryViewerAxes_Axis_Actions)Sdt;
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
				sdt = new SdtQueryViewerAxes_Axis_Actions() ;
			}
		}
	}
	#endregion
}