/*
				   File: type_SdtSDTRFMAct
			Description: SDTRFMAct
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
	[XmlRoot(ElementName="SDTRFMAct")]
	[XmlType(TypeName="SDTRFMAct" , Namespace="RFM" )]
	[Serializable]
	public class SdtSDTRFMAct : GxUserType
	{
		public SdtSDTRFMAct( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTRFMAct(IGxContext context)
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
			AddObjectProperty("RFMAct", gxTpr_Rfmact, false);


			AddObjectProperty("SumClientes", gxTpr_Sumclientes, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RFMAct")]
		[XmlElement(ElementName="RFMAct")]
		public int gxTpr_Rfmact
		{
			get { 
				return gxTv_SdtSDTRFMAct_Rfmact; 
			}
			set { 
				gxTv_SdtSDTRFMAct_Rfmact = value;
				SetDirty("Rfmact");
			}
		}




		[SoapElement(ElementName="SumClientes")]
		[XmlElement(ElementName="SumClientes")]
		public short gxTpr_Sumclientes
		{
			get { 
				return gxTv_SdtSDTRFMAct_Sumclientes; 
			}
			set { 
				gxTv_SdtSDTRFMAct_Sumclientes = value;
				SetDirty("Sumclientes");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSDTRFMAct_Rfmact;
		 

		protected short gxTv_SdtSDTRFMAct_Sumclientes;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTRFMAct", Namespace="RFM")]
	public class SdtSDTRFMAct_RESTInterface : GxGenericCollectionItem<SdtSDTRFMAct>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTRFMAct_RESTInterface( ) : base()
		{
		}

		public SdtSDTRFMAct_RESTInterface( SdtSDTRFMAct psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="RFMAct", Order=0)]
		public  String gxTpr_Rfmact
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Rfmact, 8, 0));

			}
			set { 
				sdt.gxTpr_Rfmact = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SumClientes", Order=1)]
		public short gxTpr_Sumclientes
		{
			get { 
				return sdt.gxTpr_Sumclientes;

			}
			set { 
				sdt.gxTpr_Sumclientes = value;
			}
		}


		#endregion

		public SdtSDTRFMAct sdt
		{
			get { 
				return (SdtSDTRFMAct)Sdt;
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
				sdt = new SdtSDTRFMAct() ;
			}
		}
	}
	#endregion
}