using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace MyWebAutomation.FrameWorkDesign.Rough;

    public class TestBase
    {
        public ExtentReports extent;
        public ExtentTest test;
        String browserName;

        //report file
        [OneTimeSetUp]
        public void Setup()

        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath =projectDirectory + "//index.html";
            var htmlReporter = new   ExtentSparkReporter(reportPath);
             extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Rahul Shetty");

        }


       // public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void StartBrowser()

        {
          test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Configuration
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {

                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);

            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";


        }

        public IWebDriver getDriver()

        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;


                case "Edge":

                    driver.Value = new EdgeDriver();
                    break;

            }


        }

        // public static JsonReader getDataParser()
        // {
        //     return new JsonReader();
        // }

        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
              
                test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail,"test failed with logtrace"+ stackTrace);

            }
            else if (status == TestStatus.Passed)
            {
          
            }

            extent.Flush();
             driver.Value.Quit();
        }

        public Media captureScreenShot(IWebDriver driver,String screenShotName)

        {
            ITakesScreenshot ts= (ITakesScreenshot)driver;
           var screenshot= ts.GetScreenshot().AsBase64EncodedString;

           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }




    }

