using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADGLOB
{
    public class CommonConstants
    {
        public static string IDENTIFIER_BACK_SLASH = "/";
        public static string Google = "Google";
        public static string csProviderName = "provider";
        public static string csDataBaseName = "dataBase";
        public static string csDBSites1 = "http://i-ii.ru/services";
        public static string csUserEmail = "dextronis@yandex.ru";
        public static string csXMLData = "XML/xmlData.xml";


        public class _TPoint
        {
            public int X;
            public int Y;
            public bool IsClick;
            public bool IsTrippleClick;
        }

        public enum enSiteElement{Name,Link,NONE};
        public enum enAction { SendKeys, Submit, GoToUrl, SelectCombobox, GetUrl, SubmitWithOutRefresh, NONE };

        public class _TSiteElement
        {
            public enSiteElement SiteElementType { get; set; }
            public string ElementName { get; set; }
            public enAction Action { get; set; }
            public string ElementText { get; set; }

            public string URL { get; set; }
        }

        
    }
}
