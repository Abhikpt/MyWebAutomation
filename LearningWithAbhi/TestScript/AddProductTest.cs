using FrameWorkDesign.Driver;
using LearningWithAbhi.PageObject;
using FrameWorkDesign.Config;
using AutoFixture.NUnit3;

namespace LearningWithAbhi.TestScript
{

    [TestFixture(BrowserType.ChromeDriver)]
    [TestFixture(BrowserType.EdgeDriver)]
    public class AddProductTest{        
    private readonly AddProductPageObject _addProductObject ;
    public  TestSetting _testSetting;
        public AddProductTest(BrowserType brw)
        
        {
             _testSetting = new TestSetting() 
            {
                ApplicationURL = "https://abhikpt.github.io/LearningwithAbhi/productpage",
                browserType = brw,
                TimeOutInterval = 10
            };

            DriverFixture drv = new DriverFixture(_testSetting);
            _addProductObject = new AddProductPageObject(drv);            
        }

        
        [Test, Category("Verify page opened")]
        public void TC01_VerifyAddProductPage()
        {
            Assert.That(_addProductObject.PageHeading, Is.EqualTo("Product Management")); 
        }


        [Test, Category("Add funcation")]
        [AutoData]
        public void TC002_PopulatProductDetails(AddProductModel product)
        {   
            _addProductObject.PopulateProduct(product);
            Thread.Sleep(2000);
        }


        [Test]
        [TestCase(12,"Product 01","Description 01",12.34,"Generic")]
        [TestCase(11,"Product 02","Description 02",22.34,"NEW")]
        [TestCase(09,"Product 03","Description 03",32.34,"Main")]
        public void TC02_ADDProduct(int ID, string Name, String description, double price, string type )
        {
           
             _addProductObject.AddProduct(ID,Name,description,price,type);  
             _addProductObject.AddButton.Click(); 
            Thread.Sleep(2000);
        }


        [Test]
        public void TC03_AddProduct()
        {
            _addProductObject.AddButton.Click();
        }

        [Test]
        public void TC04_VerifyProductIsAdded()
        {

        }


        [OneTimeTearDown]
        public void Dispose()
        {
            _addProductObject.Dispose();
        }


    }

   
}