using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
	
	namespace LWASpecflow.Steps
	{
		[Binding]
		public class LoginSteps
		{
            private string loginResult;

			private readonly ScenarioContext _scenarioContext;
	
			public LoginSteps(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
[Given(@"the user navigates to the login page")]
        public void Giventheusernavigatestotheloginpage()
        {
            //WebDriver.Navigate().GoToUrl();
        }

[When(@"the user enters username ""(.*)"" and password ""(.*)""")]
    public void Whentheuserentersusernameandpassword(string username,string password)
    {
        Console.WriteLine($"Entered Username: {username}, Password: {password}");
            // Add login logic here, e.g., send keys to UI fields or API request.

            // Mock result logic
            if (username == "admin" && password == "admin123")
                loginResult = "Success";
            else if (username == "user" && password == "user123")
                loginResult = "Success";
            else
                loginResult = "Failure";
    }

        [Then(@"the login should be ""(.*)""")]
    public void Thentheloginshouldbe(string expectedResult)
    {
        Assert.AreEqual(expectedResult, loginResult, "Login result did not match!");

            }
	}
    }