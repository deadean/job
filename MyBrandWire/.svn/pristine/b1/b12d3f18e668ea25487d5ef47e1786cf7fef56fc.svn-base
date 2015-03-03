using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADGLOB;
using Model.Entity;

namespace TestSeleniumLib
{
    internal class CPublisherInformation
    {
        public string SiteHref { get; set; }
        public string Header { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public List<CommonConstants._TSiteElement> Elements { get; set; }
        public CPressRealise PressRealize { get; set; }

        public void ApplyPressRealize()
        {
            this.Elements.Add(new CommonConstants._TSiteElement() { Action = CommonConstants.enAction.SelectCombobox, ElementText = "3", ElementName = "subcat" });
            this.Elements.Add(new CommonConstants._TSiteElement() { Action = CommonConstants.enAction.SendKeys, ElementText = PressRealize.Header , ElementName = "header" });
            this.Elements.Add(new CommonConstants._TSiteElement() { Action = CommonConstants.enAction.SendKeys, ElementText = PressRealize.Paragraph, ElementName = "short" });
            this.Elements.Add(new CommonConstants._TSiteElement() { Action = CommonConstants.enAction.SendKeys, ElementText = PressRealize.FullText, ElementName = "message" });
        }
    }
}
