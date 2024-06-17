
using OpenQA.Selenium;


namespace LearningWithAbhi.PageObject{
    


        public interface IHomePageObject
        {
            IWebElement UserInput {get;}
            IWebElement PassInput {get;}

            string PageUrl {get;}
            void Login();

        }
}