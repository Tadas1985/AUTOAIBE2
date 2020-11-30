using AUTOAIBE2.Page;

using NUnit.Framework;

namespace AUTOAIBE2.Test
{
    public class AutoaibeTest : BaseTest
    {
        public const string TakeFromShop = "Atsiėmimas parduotuvėje";
        //public const string ShopName = "Minijos g. 169E";
        //public const string PayWithCard = "Apmokėjimas atsiėmimo metu (grynaisiais arba kortele)";
        string numberOfItems = "1";
        public const string ResultTex = "2011 SEAT IBIZA IV (6J5, 6P1) 1.6 TDI 66kW";
        string backDiskName = "AlliedNip AND6003 galinių stabdžių diskas";
        [Order(1)]
        [TestCase("2011", "SEAT", "IBIZA IV (6J5, 6P1)", "66 kW 1.6 TDI Dyz.", ResultTex, TestName = "2011 SEAT IBIZA IV (6J5, 6P1) 1.6 TDI 66kW")]
        public void CheckIfCarISFound(string carYear, string carManufacturer, string carModel, string carEngine, string ResultText)
        {


            System.Threading.Thread.Sleep(4000);
            _page.NavigateToMainAutoAibePage();
            _page.SelectFromCarYearDropDown(carYear);
            _page.SelectFromCarMakeIDrDropDown(carManufacturer);
            _page.SelectFromCarModelIDrDropDown(carModel);
            _page.SelectFromCarEngineDropDown(carEngine);
            _page.VerifyFoundResult(ResultText);
        }
        [Test, Order(2)]
        public void OpenDiscBrakepage()
        {
            _carDetails.SelectDiscBrakes();
            _carDetails.CheckIfYouOnTherightProductCategory();
        }

        [Test, Order(3)]
        public void CheckIfBackBrakesAddedToBasket()
        {

            _discPage.SelectAlliedNip();
            _discPage.AddToBasketBackBrakes();
            _discPage.NumberOfItems(numberOfItems);
            _discPage.ContinueShopping();
            //disc.GetFrontrakePrice();

        }
        [Test, Order(4)]
        public void CheckIfFrontBrakesAddedtoBasket()
        {


            // _discPage.SelectAlliedNip();
            _discPage.AddToBaskeFrontkBrakes();
            _discPage.NumberOfItems(numberOfItems);
            _discPage.ProceedWithShopping();
            // disc.ProceedWithShopping();
        }
        [Test, Order(5)]
        public void CheckIfYourItemsExistInFinalSheet()
        {
            _checkOutPage.VerifyThatBackDiscIsIYourBasket(backDiskName);
        }
    }
}