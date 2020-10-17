using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using TechTalk.SpecFlow.Assist;

namespace QuickKart.Test
{
    [Binding]
    public class CustomerLoginSteps
    {
        private IWebDriver _driver;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl("https://localhost:44399/Home/Login");
        }
        
        [Given(@"I have entered my username as (.*)")]
        public void GivenIHaveEnteredMyUsername(string username)
        {
           _driver.FindElement(By.Id("name")).SendKeys(username);
        }

        [Given(@"I have entered my password as (.*)")]
        public void GivenIHaveEnteredMyPassword(string password)
        {
            _driver.FindElement(By.Id("pwd")).SendKeys(password);

        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _driver.FindElement(By.Id("btnLogin")).Click();
        }
        
        [Then(@"the i should see the customers page")]
        public void ThenTheIShouldSeeTheCustomersPage()
        {
            Assert.Equal("CustomerHome - QuickKart", _driver.Title);
            _driver.Quit();
            _driver.Dispose();
        }

        [Then(@"the i should not able see the customers page")]
        public void ThenTheIShouldNotAbleSeeTheCustomersPage()
        {
            Assert.NotEqual("CustomerHome - QuickKart", _driver.Title);
            _driver.Quit();
            _driver.Dispose();
        }

        //[Given(@"I have entered my Credentials")]
        //public void GivenIHaveEnteredMyCredentials(Table table)
        //{
        //    dynamic credentials = table.CreateDynamicInstance();
        //    _driver.FindElement(By.Id("name")).SendKeys(credentials.Username);
        //    _driver.FindElement(By.Id("pwd")).SendKeys(credentials.Password);
        //}

        
    }
}
