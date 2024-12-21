
using FrameworkDesign.Config;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using LearningWithAbhi.PageObject.Flipkart;

namespace LearningWithAbhi.Practice;

public class FlipkartE2E 
{

    public  HomePageModel hom;     
    public FlipkartE2E( )
    {
        TestSetting testSetting =  ConfigReader.ReadConfig();
        hom = new HomePageModel(new DriverFixture(testSetting)) ;        
    }

   
    [Test, Category("Flipkart Automation global search")]
    public void SearchAndFindElement()
   {
     Assert.That(hom.Title, Is.EqualTo("Online Shopping Site for Mobiles, Electronics, Furniture, Grocery, Lifestyle, Books & More. Best Offers!"));

     hom.SendSearchvalue("iphone");
    var values = hom.GetAutosugestionValue();
     Console.WriteLine(values);

 

   }




      [OneTimeTearDownAttribute]
    public void release()
    {
        hom.Dispose();
    }






}

