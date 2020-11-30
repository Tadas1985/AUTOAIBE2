using AUTOAIBE2.Driver;
using AUTOAIBE2.Page;
using AUTOAIBE2.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOAIBE2.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static AutoaibePage _page;
        public static AutoaibeCarDetailPage _carDetails;
        public static DiscBrakePage _discPage;
        public static AutoaibeCheckOutPage _checkOutPage;



        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();

            _page = new AutoaibePage(driver);
            _discPage = new DiscBrakePage(driver);
            _carDetails = new AutoaibeCarDetailPage(driver);
            _checkOutPage = new AutoaibeCheckOutPage(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                Myscreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
