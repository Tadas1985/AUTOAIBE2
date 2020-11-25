using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOAIBE2.Page
{
    public class DiscBrakePage : BasePage
    {

        private const string PageAddress = "https://www.autoaibe.lt/2011-seat-ibizaiv6j56p1-autodalys/detales/stabdziu-sistema/stabdziu-diskai/?subm.td=31600";

        private IWebElement _alliedNipponCheckBox => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.filter-wrapper > form > div:nth-child(2) > div.filter-attributes > div:nth-child(6) > div > label > span.checkmark"));

        //private IWebElement _montuojamaShowMore => Driver.FindElement(By.XPath("body > div.category-page > div.container.clearfix > div.filter-wrapper > form > div:nth-child(3) > div.filter-attributes > div.more.link > span.more-text"));
        private IWebElement alliedNipBtnBackBrakes => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > ul > li:nth-child(1) > form > button"));
        private IWebElement alliedNipBtnFrontBrakes => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > ul > li:nth-child(2) > form > button"));
        private SelectElement amountOfItems => new SelectElement(Driver.FindElement(By.CssSelector("#quantity-dropdown")));

        private IWebElement goTopayment => Driver.FindElement(By.CssSelector("body > div.basket-container > div > div.basket-summary-container > a"));

        private IWebElement continueShopingBtn => Driver.FindElement(By.CssSelector("body > div.basket-container > div > div.left > a > span:nth-child(2)"));
        private IWebElement rearBrakePrice => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > ul > li:nth-child(1) > div.product-price-container > span.user-price"));
        private IWebElement frontBrakePrice => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > ul > li:nth-child(2) > div.product-price-container > span.user-price"));
        private IWebElement backDiscBrakeName => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > ul > li:nth-child(1) > a"));
        private IWebElement frontDiscBrakeName => Driver.FindElement(By.CssSelector("body > div.category-page > div.container.clearfix > div.product-list-wrapper.product-list-results > ul > li:nth-child(1) > a"));

        public DiscBrakePage(IWebDriver webdriver) : base(webdriver) { }
        Actions builder = new Actions(Driver);

        public DiscBrakePage NavigateToMainAutoAibePage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public DiscBrakePage SelectAlliedNip()
        {
            _alliedNipponCheckBox.Click();

            return this;
        }
        public DiscBrakePage AddToBasketBackBrakes()
        {
            alliedNipBtnBackBrakes.Click();
            return this;
        }
        public DiscBrakePage AddToBaskeFrontkBrakes()
        {
            alliedNipBtnFrontBrakes.Click();
            return this;
        }
        public DiscBrakePage NumberOfItems(string numOfItems)
        {

            amountOfItems.SelectByValue(numOfItems);
            return this;
        }
        public DiscBrakePage ContinueShopping()
        {

            continueShopingBtn.Click();
            return this;
        }
        public DiscBrakePage ProceedWithShopping()
        {
            System.Threading.Thread.Sleep(2000);
           
            builder.DoubleClick(goTopayment);     // Double click-- 
            builder.Build().Perform();
            return this;
        }
        public int GetRearBrakePrice()
        {
            return Convert.ToInt32(rearBrakePrice.Text);

        }
        public int GetFrontrakePrice()
        {
            return Convert.ToInt32(frontBrakePrice.Text);

        }
        public string GetBackDiscName()
        {
            return backDiscBrakeName.Text;

        }
        public string GetFrontDiscName()
        {
            return frontDiscBrakeName.Text;

        }
    }
}
