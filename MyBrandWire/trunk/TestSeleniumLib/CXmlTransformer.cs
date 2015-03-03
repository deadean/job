using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Xml.Linq;
using ADGLOB;

namespace TestSeleniumLib
{
    public class CXmlTransformer
    {
        public List<CommonConstants._TSiteElement> ParseData(string siteHref)
        {
            var result = new List<CommonConstants._TSiteElement>();
            try
            {
                XDocument xmlDocument = XDocument.Load(CommonConstants.csXMLData);
                IEnumerable<XElement> allSitesElements = xmlDocument.Descendants("root");
                IEnumerable<XElement> descElements = allSitesElements.Descendants("Site");

                foreach (var descElement in descElements)
                {
                    if (descElement.Descendants("Href").FirstOrDefault().Value == siteHref)
                    {
                        result.Add(this.ParseElement(descElement));
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.Log("ParseData",ex.Message);
            }

            return result;
        }

        private CommonConstants._TSiteElement ParseElement(XElement xElement)
        {
            var result = new CommonConstants._TSiteElement();
            try
            {
                result = new CommonConstants._TSiteElement
                {
                    ElementName = xElement.Descendants("ElementName").FirstOrDefault() == null ? String.Empty : xElement.Descendants("ElementName").FirstOrDefault().Value,
                    ElementText = xElement.Descendants("ElementText").FirstOrDefault() == null ? String.Empty : xElement.Descendants("ElementText").FirstOrDefault().Value,
                    SiteElementType = xElement.Descendants("SiteElementType").FirstOrDefault() == null ? CommonConstants.enSiteElement.NONE :
                        (CommonConstants.enSiteElement)
                            Enum.Parse(typeof(CommonConstants.enSiteElement),
                                xElement.Descendants("SiteElementType").FirstOrDefault().Value),
                    Action = xElement.Descendants("Action").FirstOrDefault() == null ? CommonConstants.enAction.NONE :
                        (CommonConstants.enAction)
                            Enum.Parse(typeof(CommonConstants.enAction),
                                xElement.Descendants("Action").FirstOrDefault().Value),
                    URL = xElement.Descendants("Url").FirstOrDefault() == null ? String.Empty : xElement.Descendants("Url").FirstOrDefault().Value
                };
            }
            catch (Exception ex)
            {
                CLog.Log("ParseElement", ex.Message);
            }

            return result;
        }

        public List<CommonConstants._TSiteElement> ParseDataAfterApply(string siteHref)
        {
            var result = new List<CommonConstants._TSiteElement>();
            try
            {
                XDocument xmlDocument = XDocument.Load(CommonConstants.csXMLData);
                IEnumerable<XElement> allSitesElements = xmlDocument.Descendants("root");
                IEnumerable<XElement> descElements = allSitesElements.Descendants("SiteAfterApply");

                foreach (var descElement in descElements)
                {
                    if (descElement.Descendants("Href").FirstOrDefault().Value == siteHref)
                    {
                        result.Add(this.ParseElement(descElement));
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.Log("ParseData", ex.Message);
            }

            return result;
        }
    }
}
