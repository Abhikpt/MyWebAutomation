
using FrameWorkDesign;
using FrameWorkDesign.Driver;
using OpenQA.Selenium;

namespace LearningWithAbhi.PageObject
{

    public class AddProductPageObject : IDisposable
    {       
        private IWebDriver _driver; 
        public AddProductPageObject(DriverFixture driverFixture)
        {                      
            _driver = driverFixture.Driver;
        }

        readonly By Heading = By.CssSelector( "#app > div > main > article > h3" );
        readonly  By IdLocator = By.CssSelector( "#productID" );
        readonly By NameLocator = By.CssSelector( "#productName" );
        readonly By DescriptionLocator = By.CssSelector( "#productDescription" );
        readonly By PriceLocator = By.CssSelector( "#productPrice" );
        readonly By ProductTypeLocator = By.CssSelector( "#productType" );
        readonly By AddBtnLocator = By.CssSelector( "#app > div > main > article > section:nth-child(2) > form > button:nth-child(6)" );
        readonly By ResetBtnLocator = By.CssSelector( "#app > div > main > article > section:nth-child(2) > form > button:nth-child(7)" );

        // locators values        
         public string PageHeading => _driver.FindElement( Heading ).Text;

        private IWebElement ID => _driver.FindElement( IdLocator );
        private IWebElement Name => _driver.FindElement( NameLocator); 
        private IWebElement Description => _driver.FindElement(DescriptionLocator)  ;
        private IWebElement Price => _driver.FindElement(PriceLocator) ;
        private IWebElement ProductType => _driver.FindElement(ProductTypeLocator) ;
        public IWebElement AddButton => _driver.FindElement(AddBtnLocator) ;
        public IWebElement Resetbutton => _driver.FindElement(ResetBtnLocator);

        // loacatores
        public void PopulateProduct(AddProductModel productModel)
        {
            ID.SendKeys(productModel.ProductID.ToString());
            Name.SendKeys(productModel.ProductName);
            Description.SendKeys(productModel.ProductDescription);
            Price.SendKeys(productModel.ProductPrice.ToString() );
            ProductType.SendKeys(productModel.ProductType);
        }

         public void AddProduct(int ProductID, string PName, string PDescription, double PPrice, string PProductType)
        {
            ID.SendKeys(ProductID.ToString());
            Name.SendKeys(PName);
            Description.SendKeys(PDescription);
            Price.SendKeys(PPrice.ToString());
            ProductType.SendKeys(PProductType);
        }




        public void Dispose()
        {
        _driver.Dispose();
        }
    }

   
    public class AddProductModel
    {
        public int ProductID{ get; set; }    
        public string? ProductName { get; set;}
        public string? ProductDescription { get; set;}
        public double ProductPrice { get; set;} = 0;
        public string? ProductType { get; set;}

    }
}