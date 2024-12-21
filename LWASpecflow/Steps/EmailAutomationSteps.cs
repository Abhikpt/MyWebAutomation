using System;
using FrameWorkDesign.Utilities;
using TechTalk.SpecFlow;
	
namespace Steps;

    [Binding]
    public class StepDefinitions
    {
			private readonly ScenarioContext _scenarioContext;
	
			public StepDefinitions(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
            [Given(@"the user is on the registration page")]
            public void Giventheuserisontheregistrationpage()
            {

                EmailService.SendEmail("abhishekcpj@gmail.com");

            }

            [When(@"the user registers with a valid email address")]
            public void Whentheuserregisterswithavalidemailaddress()
            {
                _scenarioContext.Pending();
            }

            [Then(@"an email verification link should be sent to the user's email")]
            public void Thenanemailverificationlinkshouldbesenttotheusersemail()
            {
                _scenarioContext.Pending();
            }

            [Given(@"the email should contain a verification link")]
            public void Giventheemailshouldcontainaverificationlink()
            {
                _scenarioContext.Pending();
            }

            [When(@"the user clicks on the verification link")]
            public void Whentheuserclicksontheverificationlink()
            {
                _scenarioContext.Pending();
            }

            [Then(@"the user should be redirected to the email verification success page")]
            public void Thentheusershouldberedirectedtotheemailverificationsuccesspage()
            {
                _scenarioContext.Pending();
            }

            [Given(@"the user should see a success message indicating their email has been verified")]
            public void Giventheusershouldseeasuccessmessageindicatingtheiremailhasbeenverified()
            {
                _scenarioContext.Pending();
            }

}
	