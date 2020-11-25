using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOAIBE2.Page
{
    public class AutoaibeCarDetailPage : BasePage
    {
        private const string ResultTex = "2011 SEAT IBIZA IV (6J5, 6P1) 1.6 TDI 66kW";
        private const string resultToCompareWithCategoryTitle = "2011 SEAT IBIZA IV (6J5, 6P1) 1.6 TDI 66kW Stabdžių diskai";
        private const string PageAddress = "https://www.autoaibe.lt/2011-seat-ibizaiv6j56p1-autodalys/";
        private IWebElement _brakeDiscs => Driver.FindElement(By.CssSelector("body > div.category-page > ul > li:nth-child(1) > ul > li:nth-child(7) > a"));
        private IWebElement _categoryTitle => Driver.FindElement(By.ClassName("CATEGORY_TITLE"));

        //private IWebElement findResultText => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > div.car-fit-alert > span"));
        public AutoaibeCarDetailPage(IWebDriver webdriver) : base(webdriver)
        {}
        public AutoaibeCarDetailPage NavigateToFirstAutoAibePage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
       
        public AutoaibeCarDetailPage SelectDiscBrakes()
        {
            _brakeDiscs.Click();
            return this;
        }
        public AutoaibeCarDetailPage CheckIfYouOnTherightProductCategory()
        {
            Assert.AreEqual(resultToCompareWithCategoryTitle, _categoryTitle.Text, "Results are not the same");
            return this;
        }
    }
}
