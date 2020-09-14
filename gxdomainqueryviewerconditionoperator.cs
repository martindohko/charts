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
   public class gxdomainqueryviewerconditionoperator
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainqueryviewerconditionoperator ()
      {
         domain["EQ"] = "Equal";
         domain["LT"] = "Less Than";
         domain["GT"] = "Greater Than";
         domain["LE"] = "Less Or Equal";
         domain["GE"] = "Greater Or Equal";
         domain["NE"] = "Not Equal";
         domain["IN"] = "Interval";
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
            domainMap["Equal"] = "EQ";
            domainMap["LessThan"] = "LT";
            domainMap["GreaterThan"] = "GT";
            domainMap["LessOrEqual"] = "LE";
            domainMap["GreaterOrEqual"] = "GE";
            domainMap["NotEqual"] = "NE";
            domainMap["Interval"] = "IN";
         }
         return (String)domainMap[key] ;
      }

   }

}
