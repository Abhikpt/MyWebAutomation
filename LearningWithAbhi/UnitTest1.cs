using FrameWorkDesign.Driver;
using LearningWithAbhi.PageObject;
using OpenQA.Selenium;

namespace LearningWithAbhi;

public class UnitTest1
{

 private HomePageObject hm;
 IWebDriver? driver;

    // public UnitTest1( HomePageObject homePageObject)
    // {
    //     //   hm = homePageObject;
    // }
  
  [Test]
  public void TestURLnavigation()
  {

    //  Assert.That(hm.PageUrl, Is.EqualTo("https://www.saucedemo.com/"));

  }


}