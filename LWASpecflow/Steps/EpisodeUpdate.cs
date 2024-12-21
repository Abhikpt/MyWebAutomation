using System;
using TechTalk.SpecFlow;

	
	namespace MyNamespace
	{
		[Binding]
		public class StepDefinitions
		{
			private readonly ScenarioContext _scenarioContext;
            
	
			public StepDefinitions(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
[Given(@"user is on my PrivateJOb page")]
public void GivenuserisonmyPrivateJObpage()
{
	
}

[Given(@"user is able to see the click me element")]
public void Givenuserisabletoseetheclickmeelement()
{
	_scenarioContext.Pending();
}

		}
	}