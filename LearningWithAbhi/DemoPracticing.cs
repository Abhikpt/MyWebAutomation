using System.Reflection;
using System.Runtime.CompilerServices;
using FrameWorkDesign.Driver;
using LearningWithAbhi.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningWithAbhi;

public class DemoPracticing
{
  public  IWebDriver? driver;
   
  
  [Test, Category("Adding screen shots")]
  public void ScreenShotCapture()
  {
    driver = new ChromeDriver();
    driver.Url = "https://www.saucedemo.com/" ;   
    
    driver.FindElement(By.CssSelector("#login-button")).Click();

     ITakesScreenshot screenshot = (ITakesScreenshot)driver;    
      Screenshot  ssFile =  screenshot.GetScreenshot();
      string workingDir = Environment.CurrentDirectory;
      String projectDir = Directory.GetParent(workingDir).Parent.Parent.ToString();
      ssFile.SaveAsFile(projectDir + "\\Screenshots\\File02.png");   

  
  
  }


  [TearDown]
    public void Dispose()
        {
            driver?.Dispose();
        }



}