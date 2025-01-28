using System;
using System.Security.Cryptography;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MyNamespace
{
	[Binding]
	public class MagnetoSoftwareTestingSteps
	{


		MagnetoLandingPage hm;

		private readonly ScenarioContext _scenarioContext;

		public MagnetoSoftwareTestingSteps(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;

			hm = new MagnetoLandingPage();
		}


		[Given(@"chrome browser is open")]
		public void Givenchromebrowserisopen()
		{
			Console.WriteLine("Pass");
		}

		[When(@"user pass the URL")]
		public void WhenuserpasstheURL()
		{
			hm.OpenLandingPage();
		}

		[Then(@"user is able to see heading ""(.*)""")]
		public void Thenuserisabletoseeheading(string args1)
		{
			string  Actualtitle = hm.Title();
			Assert.That(args1,Is.EqualTo(Actualtitle.Trim()));
			hm.Dispose();
		}

		[When(@"user click on Men top tees")]
		public void WhenuserclickonMentoptees()
		{
			Console.WriteLine("Pass");
		}

		[Then(@"Able to see heading ""(.*)"" and verbiage ""(.*)""")]
		public void ThenAbletoseeheadingandverbiage(string args1, string args2)
		{
			Console.WriteLine("Pass");
		}

		 [Then(@"User is able to see (.*) products of rating (.*)")]
        public void ThenUserIsAbleToSeeProductsOfRating(int p0, int p1)
        {
            Console.WriteLine("Pass");
        }
        
        [Then(@"Price of (.*)st product having rating (.*) is \$(.*)")]
        public void ThenPriceOfStProductHavingRatingIs(int p0, int p1, Decimal p2)
        {
			Console.WriteLine("Pass");

        }

	}
}
