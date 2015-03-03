using System;
using System.Collections.Generic;
using System.Windows;
using ADGLOB;
using OpenQA.Selenium;
using SendKeysEmulator;
using Model;

namespace TestSeleniumLib
{
    public partial class CSitePublisherFactory
    {
        public IWebDriver Driver { get; set; }
        private IModelService _model = new ModelServices();
        private Dictionary<string,Func<CPublisherInformation>> PublisherForSites = new Dictionary<string, Func<CPublisherInformation>>();
        private CXmlTransformer xmlParser = new CXmlTransformer();

        public CSitePublisherFactory()
        {
            PublisherForSites.Add(CommonConstants.csDBSites1,this.GetPublishInformationForSite1);
        }

        public void Initialize()
        {
            List<ADGLOB.CommonConstants._TPoint> path = new List<ADGLOB.CommonConstants._TPoint>();
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 30, Y = 70 });
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 100, Y = 550 });
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 30, Y = 650, IsTrippleClick = true });
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 1100, Y = 680 });
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 30, Y = 700 });
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 1100, Y = 550 });
            path.Add(new ADGLOB.CommonConstants._TPoint() { IsClick = true, X = (int)SystemParameters.VirtualScreenWidth - 970, Y = 40 });
            CSendKeysEmulator keysEmulator = new CSendKeysEmulator(path);
            keysEmulator.StartEmulate();
        }

        public void StartPublish()
        {
            try
            {
                Action<CPublisherInformation> publishOnTheOneSite = (x) =>
                {
                    try
                    {
                        this.AnaliseFinalElementsForPublish(x);
                        CSitePressRealisePublisher publisher = new CSitePressRealisePublisher(Driver, x);
                        publisher.Publish();
                        x.PressRealize.PublicHref = publisher.PublicHref;

                        if (String.IsNullOrEmpty(publisher.PublicHref))
                            throw new ArgumentException("PublicHref is NULL. Operation doesnt complete successfully");
                        _model.UpdatePressRealise(x.PressRealize);
                    }
                    catch (Exception ex)
                    {
                        CLog.Log("Action_publishOnTheOneSite",ex.Message);
                    }
                };

                _model.GetAllSites().ForEach(x =>
                {
                    if (this.PublisherForSites.ContainsKey(x.Href))
                        publishOnTheOneSite.Invoke(this.PublisherForSites[x.Href].Invoke());
                });
            }
            catch (Exception ex)
            {
                CLog.Log("StartPublish", ex.Message);
            }
        }

        #region Private Services

        private void AnaliseFinalElementsForPublish(CPublisherInformation info)
        {
            for (int i = 0; i < info.Elements.Count; i++)
            {
                if (info.Elements[i].Action == CommonConstants.enAction.GetUrl)
                    info.Elements[i].ElementText = info.PressRealize.Header;
            }
        }

        #endregion
    }
}
