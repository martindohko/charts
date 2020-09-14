/*
				   File: type_SdtSDTCorte
			Description: SDTCorte
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
	[XmlRoot(ElementName="SDTCorte")]
	[XmlType(TypeName="SDTCorte" , Namespace="RFM" )]
	[Serializable]
	public class SdtSDTCorte : GxUserType
	{
		public SdtSDTCorte( )
		{
			/* Constructor for serialization */
		}

		public SdtSDTCorte(IGxContext context)
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
			AddObjectProperty("Corte1", gxTpr_Corte1, false);


			AddObjectProperty("Corte2", gxTpr_Corte2, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Corte1")]
		[XmlElement(ElementName="Corte1")]
		public int gxTpr_Corte1
		{
			get { 
				return gxTv_SdtSDTCorte_Corte1; 
			}
			set { 
				gxTv_SdtSDTCorte_Corte1 = value;
				SetDirty("Corte1");
			}
		}




		[SoapElement(ElementName="Corte2")]
		[XmlElement(ElementName="Corte2")]
		public int gxTpr_Corte2
		{
			get { 
				return gxTv_SdtSDTCorte_Corte2; 
			}
			set { 
				gxTv_SdtSDTCorte_Corte2 = value;
				SetDirty("Corte2");
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

		protected int gxTv_SdtSDTCorte_Corte1;
		 

		protected int gxTv_SdtSDTCorte_Corte2;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SDTCorte", Namespace="RFM")]
	public class SdtSDTCorte_RESTInterface : GxGenericCollectionItem<SdtSDTCorte>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTCorte_RESTInterface( ) : base()
		{
		}

		public SdtSDTCorte_RESTInterface( SdtSDTCorte psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Corte1", Order=0)]
		public  String gxTpr_Corte1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Corte1, 8, 0));

			}
			set { 
				sdt.gxTpr_Corte1 = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Corte2", Order=1)]
		public  String gxTpr_Corte2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Corte2, 8, 0));

			}
			set { 
				sdt.gxTpr_Corte2 = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDTCorte sdt
		{
			get { 
				return (SdtSDTCorte)Sdt;
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
				sdt = new SdtSDTCorte() ;
			}
		}
	}
	#endregion
}