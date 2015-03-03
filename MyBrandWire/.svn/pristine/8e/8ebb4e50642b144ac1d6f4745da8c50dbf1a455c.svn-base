using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ADGLOB;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestSeleniumLib
{
    internal class CSitePressRealisePublisher
    {
        private readonly IWebDriver modWebDriver;
        private readonly CPublisherInformation modPublisherInformation;

        public string PublicHref { get; set; }

        internal CSitePressRealisePublisher(IWebDriver driver, CPublisherInformation information)
        {
            try
            {
                if (driver == null || information == null)
                    throw new ArgumentException("Driver or information is null");

                modWebDriver = driver;
                modPublisherInformation = information;
            }
            catch (Exception ex)
            {
                CLog.Log(ex.Message);
            }
        }

        internal void Publish()
        {
            try
            {
                IWebElement query=null;
                Action<CommonConstants._TSiteElement> actionSendKeys = (x) => 
                {
                    if (x.Action == CommonConstants.enAction.GetUrl)
                    {
                        string pageSource = modWebDriver.PageSource;
                        int indexEnd = pageSource.IndexOf(x.ElementText);
                        string dyno = String.Empty;
                        string href = String.Empty;
                        for (int i = indexEnd-3; i > 0; i--)
                        {
                            if (pageSource[i] == '"')
                                break;
                            href += pageSource[i];
                        }
                        char[] c = href.ToCharArray();
                        Array.Reverse(c);
                        href = new string(c);
                        this.PublicHref = href;
                        return;
                    }
                    if (x.Action == CommonConstants.enAction.SelectCombobox)
                    {
                        query = modWebDriver.FindElement(By.Name(x.ElementName));
                        SelectElement clickThis = new SelectElement(query);
                        clickThis.SelectByIndex(Convert.ToInt32(x.ElementText));
                        return;
                    }
                    if (x.Action == CommonConstants.enAction.GoToUrl)
                    {
                        modWebDriver.Navigate().GoToUrl(x.URL);
                        Thread.Sleep(500);
                        modWebDriver.Navigate().Refresh();
                        Thread.Sleep(500);
                        return;
                    }
                    if (x.Action != CommonConstants.enAction.Submit && x.Action != CommonConstants.enAction.SubmitWithOutRefresh)
                    {
                        query = x.SiteElementType == CommonConstants.enSiteElement.Name ? modWebDriver.FindElement(By.Name(x.ElementName)) : modWebDriver.FindElement(By.LinkText(x.ElementName));
                    }
                    if(x.Action==CommonConstants.enAction.SendKeys){
                        query.SendKeys(x.ElementText);
                    }
                    if(x.Action==CommonConstants.enAction.Submit){
                        query.Submit();
                        modWebDriver.Navigate().Refresh();
                        Thread.Sleep(1000);
                    }
                    if (x.Action == CommonConstants.enAction.SubmitWithOutRefresh)
                    {
                        query.Submit();
                        Thread.Sleep(1000);
                    }
                };

                modWebDriver.Navigate().GoToUrl(modPublisherInformation.SiteHref);

                Thread.Sleep(2000);

                modPublisherInformation.Elements.ForEach(x => actionSendKeys.Invoke(x));

                Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                CLog.Log("Publish",ex.Message);
            }
        }
    }
}
