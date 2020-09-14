using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainqueryviewerxaxislabels
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainqueryviewerxaxislabels ()
      {
         domain["Horizontally"] = "Horizontally";
         domain["Rotated30"] = "Rotated 30º";
         domain["Rotated45"] = "Rotated 45º";
         domain["Rotated60"] = "Rotated 60º";
         domain["Vertically"] = "Vertically";
      }

      public static string getDescription( IGxContext context ,
                                           String key )
      {
         string rtkey ;
         String value ;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (String)(key)));
         value = (String)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<String> getValues( )
      {
         GxSimpleCollection<String> value = new GxSimpleCollection<String>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (String key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static String getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Horizontally"] = "Horizontally";
            domainMap["Rotated30"] = "Rotated30";
            domainMap["Rotated45"] = "Rotated45";
            domainMap["Rotated60"] = "Rotated60";
            domainMap["Vertically"] = "Vertically";
         }
         return (String)domainMap[key] ;
      }

   }

}
