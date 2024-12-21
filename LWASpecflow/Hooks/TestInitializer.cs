using System;
using TechTalk.SpecFlow;

namespace LWASpecflow.Hooks
{
    [Binding]
    public sealed class TestInitializer
    {

         [BeforeFeature]
        public static void BeforeFeature()
        {
            
            
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenariowithTag()
        {
          // this tag will call only with specific scenarion "tag1"
        }

         [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
             // this scenario will run based on order
        }   

         [BeforeScenario]
        public void BeforeScenario()
        {
            // this scenario will run based on order
        }

        [BeforeTestRun]
        public  static void BeforeTestRun()
        {
            Console.WriteLine("this hooks method line will execute before any test run");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // this scenario will run based on order
        }

       
        
    }
}
