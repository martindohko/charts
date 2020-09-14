/*
				   File: type_SdtResumen
			Description: Resumen
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
	[XmlRoot(ElementName="Resumen")]
	[XmlType(TypeName="Resumen" , Namespace="RFM" )]
	[Serializable]
	public class SdtResumen : GxUserType
	{
		public SdtResumen( )
		{
			/* Constructor for serialization */
			gxTv_SdtResumen_From = "";

			gxTv_SdtResumen_To = "";

		}

		public SdtResumen(IGxContext context)
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
			AddObjectProperty("From", gxTpr_From, false);


			AddObjectProperty("To", gxTpr_To, false);


			AddObjectProperty("Weight", gxTpr_Weight, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="From")]
		[XmlElement(ElementName="From")]
		public String gxTpr_From
		{
			get { 
				return gxTv_SdtResumen_From; 
			}
			set { 
				gxTv_SdtResumen_From = value;
				SetDirty("From");
			}
		}




		[SoapElement(ElementName="To")]
		[XmlElement(ElementName="To")]
		public String gxTpr_To
		{
			get { 
				return gxTv_SdtResumen_To; 
			}
			set { 
				gxTv_SdtResumen_To = value;
				SetDirty("To");
			}
		}




		[SoapElement(ElementName="Weight")]
		[XmlElement(ElementName="Weight")]
		public short gxTpr_Weight
		{
			get { 
				return gxTv_SdtResumen_Weight; 
			}
			set { 
				gxTv_SdtResumen_Weight = value;
				SetDirty("Weight");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtResumen_From = "";
			gxTv_SdtResumen_To = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtResumen_From;
		 

		protected String gxTv_SdtResumen_To;
		 

		protected short gxTv_SdtResumen_Weight;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"Resumen", Namespace="RFM")]
	public class SdtResumen_RESTInterface : GxGenericCollectionItem<SdtResumen>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtResumen_RESTInterface( ) : base()
		{
		}

		public SdtResumen_RESTInterface( SdtResumen psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="From", Order=0)]
		public  String gxTpr_From
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_From);

			}
			set { 
				 sdt.gxTpr_From = value;
			}
		}

		[DataMember(Name="To", Order=1)]
		public  String gxTpr_To
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_To);

			}
			set { 
				 sdt.gxTpr_To = value;
			}
		}

		[DataMember(Name="Weight", Order=2)]
		public short gxTpr_Weight
		{
			get { 
				return sdt.gxTpr_Weight;

			}
			set { 
				sdt.gxTpr_Weight = value;
			}
		}


		#endregion

		public SdtResumen sdt
		{
			get { 
				return (SdtResumen)Sdt;
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
				sdt = new SdtResumen() ;
			}
		}
	}
	#endregion
}