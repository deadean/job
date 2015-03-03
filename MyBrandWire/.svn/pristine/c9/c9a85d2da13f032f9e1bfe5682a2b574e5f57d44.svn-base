using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ADGLOB;
using CaptchaAnalizator;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //SampleWorker sw = new SampleWorker();
            //sw.Start();

            var result = new List<CommonConstants._TSiteElement>();
            try
            {
                
                XDocument xmlDocument = XDocument.Load(CommonConstants.csXMLData);
                IEnumerable<XElement> allSitesElements = xmlDocument.Descendants("root");
                IEnumerable<XElement> descElements = allSitesElements.Descendants("Site");

                foreach (var descElement in descElements)
                {
                    if (descElement.Descendants("Href").FirstOrDefault().Value == CommonConstants.csDBSites1)
                    {
                        result.Add(ParseElement(descElement));
                    }
                }
            }
            catch (Exception ex)
            {
                CLog.Log("ParseData", ex.Message);
            }
        }

        private static CommonConstants._TSiteElement ParseElement(XElement xElement)
        {
            var result = new CommonConstants._TSiteElement();
            try
            {
                result = new CommonConstants._TSiteElement
                {
                    ElementName = xElement.Descendants("ElementName").FirstOrDefault() == null? String.Empty : xElement.Descendants("ElementName").FirstOrDefault().Value,
                    ElementText = xElement.Descendants("ElementText").FirstOrDefault() == null? String.Empty : xElement.Descendants("ElementText").FirstOrDefault().Value,
                    SiteElementType =xElement.Descendants("SiteElementType").FirstOrDefault() == null? CommonConstants.enSiteElement.NONE : 
                        (CommonConstants.enSiteElement)
                            Enum.Parse(typeof(CommonConstants.enSiteElement),
                                xElement.Descendants("SiteElementType").FirstOrDefault().Value),
                    Action =xElement.Descendants("Action").FirstOrDefault() == null? CommonConstants.enAction.NONE : 
                        (CommonConstants.enAction)
                            Enum.Parse(typeof(CommonConstants.enAction),
                                xElement.Descendants("Action").FirstOrDefault().Value),
                    URL = xElement.Descendants("Url").FirstOrDefault() ==null ? String.Empty : xElement.Descendants("Url").FirstOrDefault().Value
                }
                    ;
            }
            catch (Exception ex)
            {
                CLog.Log("ParseElement", ex.Message);
            }

            return result;
        }


    }

    class SampleWorker
    {
        private void TakeAndSave()
        {
            Bitmap _bitmap = TakeScreenShot(Screen.PrimaryScreen);
            SaveScreenShot(_bitmap);
        }

        private Bitmap TakeScreenShot(Screen currentScreen)
        {
            Bitmap bmpScreenShot = new Bitmap(currentScreen.Bounds.Width, currentScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            Graphics gScreenShot = Graphics.FromImage(bmpScreenShot);

            gScreenShot.CopyFromScreen(currentScreen.Bounds.X, currentScreen.Bounds.Y, 0, 0, currentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenShot;
        }

        private void SaveScreenShot(Bitmap _bitmap)
        {
            string filename = "screen" + ".jpg";
            _bitmap.Save(filename, ImageFormat.Jpeg);
        }

        internal void Start()
        {
            Bitmap bp = new Bitmap("InputImage/1.jpg");
            CCaptchaAnalizator captchaAnalizator = new CCaptchaAnalizator(bp);
            captchaAnalizator.StartAnalize();
        }
    }
}

