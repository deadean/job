using System;
using System.Linq;
using ADGLOB;
using Model.Entity;

namespace TestSeleniumLib
{
    public partial class CSitePublisherFactory
    {
        private CPublisherInformation GetPublishInformationForSite1()
        {
            CPublisherInformation information = null;
            try
            {
                CPressRealise pressRealise = _model.GetAllPressRealises().FirstOrDefault();
                if (pressRealise == null)
                    throw new ArgumentException("pressRealise can not be null");

                information = new CPublisherInformation
                {
                    PressRealize = pressRealise,
                    SiteHref = CommonConstants.csDBSites1
                };

                information.Elements = xmlParser.ParseData(CommonConstants.csDBSites1);

                information.ApplyPressRealize();

                xmlParser.ParseDataAfterApply(CommonConstants.csDBSites1).ForEach(x=>information.Elements.Add(x));

            }
            catch (Exception ex)
            {
                CLog.Log("GetPublishInformation", ex.Message);
            }
            return information;
        }
    }
}
