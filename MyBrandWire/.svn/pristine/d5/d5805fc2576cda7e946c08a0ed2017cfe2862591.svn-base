using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using CaptchaAnalizator;
using SendKeysEmulator;
using ADGLOB;
using OpenQA.Selenium.Chrome;
using System.Windows;

namespace TestSeleniumLib
{
    [TestFixture]
    public class Driver
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void StartTest()
        {
            try
            {
                driver.Manage().Window.Size = new Size((int)SystemParameters.VirtualScreenWidth - 25, (int)SystemParameters.VirtualScreenHeight - 50);

                driver.Navigate().GoToUrl("http://google.com");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                bool res = wait.Until((d) => { return d.Title.StartsWith(CommonConstants.Google); });

                if (!res)
                {
                    CLog.Log("Driver can not connect to google.com");
                    return;
                }

                CSitePublisherFactory factory = new CSitePublisherFactory();
                factory.Driver = driver;
                factory.Initialize();
                factory.StartPublish();
            }
            catch (Exception ex)
            {
                CLog.Log("Factory doesnt stop work normally : "+ex.StackTrace);
            }
        }
    }
}


