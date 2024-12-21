using System.Net;
using FrameworkDesign.Config;
using FrameWorkDesign.Config;
using FrameWorkDesign.Driver;
using OpenQA.Selenium;  


namespace BrokenLinksonPage
{

    public  class BrokenLinksonPage :IDisposable
    {
        IWebDriver driver;

        public BrokenLinksonPage()
        {
              var _testSetting = new TestSetting() 
            {
                ApplicationURL = "https://demoqa.com/links",
                browserType = BrowserType.ChromeDriver,
                TimeOutInterval = 10
            };

            driver = new DriverFixture(_testSetting).Driver;

        }


       [Test, Category("verify the broken link on curret page")]
        public async Task validateBrokenLinks()
        {
            List<string> AllLinks = new List<string>();

          var Linkelms = driver.FindElements(By.TagName("a"));

          foreach (var linkElm in Linkelms)
          {
               string href = linkElm.GetAttribute("href");

               if(!string.IsNullOrEmpty(href))
               {
                AllLinks.Add(href); 
               }
        
          }
             // Check each link
          foreach (var link in AllLinks)
          {
            await CheckLink(link);

          }


        }

        public async Task CheckLink(string URL)
        {
            HttpClient client = new HttpClient();

            try{
                
                var response = await client.GetAsync(URL);
                if(response.IsSuccessStatusCode)
                Console.WriteLine($"this link {URL} is working fine");
                else
                Console.WriteLine($"link {URL} is not working");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error while checking link: {ex.Message}");

            }

        }

        public void Dispose()
        {
           driver.Dispose();
        }
    }
}