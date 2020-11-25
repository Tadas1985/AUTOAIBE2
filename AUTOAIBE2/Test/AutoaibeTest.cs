using AUTOAIBE2.Page;

using NUnit.Framework;

namespace AUTOAIBE2.Test
{
    public class AutoaibeTest: BaseTest
    {
        public const string TakeFromShop = "Atsiėmimas parduotuvėje";
        //public const string ShopName = "Minijos g. 169E";
        //public const string PayWithCard = "Apmokėjimas atsiėmimo metu (grynaisiais arba kortele)";
       
        public const string ResultTex = "2011 SEAT IBIZA IV (6J5, 6P1) 1.6 TDI 66kW";
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
        public void AddToBasketBackBrakes()
        {
          
            _discPage.SelectAlliedNip();
            _discPage.AddToBasketBackBrakes();
            _discPage.NumberOfItems("2");
            _discPage.ContinueShopping();
            //disc.GetFrontrakePrice();

        }
        [Test, Order(4)]
        public void AddToBasketFrontBrakes()
        {
          

            _discPage.SelectAlliedNip();
            _discPage.AddToBaskeFrontkBrakes();
            _discPage.NumberOfItems("2");
            _discPage.ProceedWithShopping();
            // disc.ProceedWithShopping();
        }
    }
}