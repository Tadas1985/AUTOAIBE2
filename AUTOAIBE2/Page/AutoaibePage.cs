using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUTOAIBE2.Page
{
    public class AutoaibePage : BasePage
    {
        private const string PageAddress = "https://www.autoaibe.lt/";

        private SelectElement _carYearDropdown => new SelectElement(Driver.FindElement(By.Name("year")));
        private SelectElement _carMakeID => new SelectElement(Driver.FindElement(By.Name("make_id")));// Cia yra naudojamas naujas tipas, nebe  IwebElement
        private SelectElement _carModelID => new SelectElement(Driver.FindElement(By.Name("model_id")));
        private SelectElement _carEngineID => new SelectElement(Driver.FindElement(By.Name("submodel_id")));
        private IWebElement _brakeDiscs => Driver.FindElement(By.XPath("/html/body/div[5]/ul/li[1]/ul/li[7]/a"));

        private IWebElement findResultText => Driver.FindElement(By.CssSelector("body > div.category-page > div:nth-child(4) > div > h1 > strong"));
        public AutoaibePage(IWebDriver webdriver) : base(webdriver) { }
       
        public AutoaibePage NavigateToMainAutoAibePage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public AutoaibePage SelectFromCarYearDropDown(string carYear)
        {

            _carYearDropdown.SelectByText(carYear);
            return this;
        }
        public AutoaibePage SelectFromCarMakeIDrDropDown(string carManufacturer)
        {

            _carMakeID.SelectByText(carManufacturer);
            return this;
        }
        public AutoaibePage SelectFromCarModelIDrDropDown(string carModel)
        {
            _carModelID.SelectByText(carModel);
            return this;
        }
        public AutoaibePage SelectFromCarEngineDropDown(string carEngine)
        {
            Thread.Sleep(2000); // Just to see what has happened on the page
            _carEngineID.SelectByText(carEngine);
            return this;
        }
        private void WaitForResult()
        {

            GetWait(3).Until(d => findResultText.Displayed);
        }
        public AutoaibePage VerifyFoundResult(string ResultText)
        {

            System.Threading.Thread.Sleep(2000);
            WaitForResult();
            Assert.AreEqual(ResultText, findResultText.Text, "Result does not match");
            return this;
        }
    }
}
