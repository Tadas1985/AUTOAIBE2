using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOAIBE2.Page
{
    public class AutoaibeCheckOutPage : BasePage
    {
        protected const string pageAddress = "https://www.autoaibe.lt/checkout/create/51556/";


        private IWebElement username => Driver.FindElement(By.Id("id_user_name"));
        private IWebElement emailAdress => Driver.FindElement(By.Id("id_email"));
        private IWebElement phoneNumber => Driver.FindElement(By.Id("id_phone_num"));
        private IWebElement purchasedBycompany => Driver.FindElement(By.Id("id_is_company"));
        private SelectElement deliveryMethod => new SelectElement(Driver.FindElement(By.Id("id_shipping_method")));
        private SelectElement deliveryShop => new SelectElement(Driver.FindElement(By.Id("shipping_store")));
        private SelectElement methodOfPayment => new SelectElement(Driver.FindElement(By.Id("id_payment_method")));
        private IWebElement customerComment => Driver.FindElement(By.Id("id_customer_comment"));
        private IWebElement rulesAgreement => Driver.FindElement(By.Id("id_agree_with_rules"));
        private IWebElement confirmPurchase => Driver.FindElement(By.CssSelector("#checkout-form > div.rules-discount-container.clearfix > button"));
        private IWebElement backDiscName => Driver.FindElement(By.CssSelector("body > div.basket-container > div > div.left > div.basket-items-container > ul > li:nth-child(1) > div.cart-item-name-and-model-container > a"));
        private IWebElement frontDiscName => Driver.FindElement(By.CssSelector("body > div.basket-container > div > div.left > div.basket-items-container > ul > li:nth-child(2) > div.cart-item-name-and-model-container > a"));





        public AutoaibeCheckOutPage(IWebDriver webDriver) : base(webDriver)
        {
            //Driver.Url = pageAdress;
        }
        public AutoaibeCheckOutPage NavigateToFirstAutoAibePage()
        {
            if (Driver.Url != pageAddress)
                Driver.Url = pageAddress;


            return this;
        }

        public AutoaibeCheckOutPage EnterUserName(string userName)
        {
            username.Clear();
            username.SendKeys(userName);
            return this;
        }
        public AutoaibeCheckOutPage EnterEmail(string email)
        {
            emailAdress.Clear();
            emailAdress.SendKeys(email);
            return this;
        }
        public AutoaibeCheckOutPage EnterPhoneNumber(string _phoneNumber)
        {
            phoneNumber.Clear();
            phoneNumber.SendKeys(_phoneNumber);
            return this;
        }
        public AutoaibeCheckOutPage IsPuchasedByCompany(bool _purchasedByCompany)
        {
            if (_purchasedByCompany != purchasedBycompany.Selected)
                purchasedBycompany.Click();
            return this;
        }
        public AutoaibeCheckOutPage DeliveryMethod(string _deliveryMethod)
        {

            deliveryMethod.SelectByText(_deliveryMethod);
            return this;
        }
        public AutoaibeCheckOutPage WhereToDeliver(string _whereToDeliver)
        {
            deliveryShop.SelectByText(_whereToDeliver);
            return this;
        }
        public AutoaibeCheckOutPage HowToPay(string _howToPay)
        {
            methodOfPayment.SelectByText(_howToPay);
            return this;
        }
        public AutoaibeCheckOutPage EnterCustomerComment(string _customerComment)
        {
            customerComment.Clear();
            customerComment.SendKeys(_customerComment);
            return this;
        }
        public AutoaibeCheckOutPage RulesAgreement(bool _rulesAgreement)
        {
            if (_rulesAgreement != rulesAgreement.Selected)
                purchasedBycompany.Click();
            return this;
        }
        public AutoaibeCheckOutPage ConfirmOrder()
        {
            confirmPurchase.Click();
            return this;
        }
        public string GetBackDiscNamefromCheckout()
        {
            return backDiscName.Text;

        }
        public string GetFronDiscName()
        {
            return backDiscName.Text;

        }
        public AutoaibeCheckOutPage VerifyThatBackDiscIsIYourBasket(string discName)
        {
            Assert.AreSame(GetBackDiscNamefromCheckout(), discName, "Seems that your discs does not match");
            return this;
        }
        public AutoaibeCheckOutPage VerifyThatFrontDiscIsIYourBasket(string discName)
        {
            Assert.AreSame(GetFronDiscName(), discName, "Seems that your discs does not match");
            return this;
        }

    }
}

