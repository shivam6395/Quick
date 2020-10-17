using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace QuickKart.Test.Steps
{
    [Binding]
    public class UserRegistrationSteps
    {
        private IWebDriver _driver;

        [Given(@"I am on the Registration  page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl("https://localhost:44399/User/RegisterUser");
        }
        
        [Given(@"I have entered my EmailId as (.*)")]
        public void GivenIHaveEnteredMyEmailIdAs(string emailid)
        {
            _driver.FindElement(By.Id("EmailId")).SendKeys(emailid);

        }

        [Given(@"I have entered my User Password as (.*)")]
        public void GivenIHaveEnteredMyUserPasswordAs(string password)
        {
            _driver.FindElement(By.Id("UserPassword")).SendKeys(password);
        }
        
        [Given(@"I have entered my Gender as (.*)")]
        public void GivenIHaveEnteredMyGenderAs(string gender)
        {
           _driver.FindElement(By.Id("Gender")).SendKeys(gender);
        }
        
        [Given(@"I have entered my DateOfBirth as (.*)")]
        public void GivenIHaveEnteredMyDateOfBirthAs(string dob)
        {
            _driver.FindElement(By.Id("DateOfBirth")).SendKeys(dob);

        }

        [Given(@"I have entered my Address as (.*)")]
        public void GivenIHaveEnteredMyAddressAs(string address)
        {
            _driver.FindElement(By.Id("Address")).SendKeys(address);
        }
        
        [When(@"I press Register")]
        public void WhenIPressRegister()
        {
            _driver.FindElement(By.Name("Register")).Click();
            
        }
        
        [Then(@"I should be redirected to the Login page")]
        public void ThenIShouldBeRedirectedToTheLoginPage()
        {
            Assert.Equal("Login - QuickKart", _driver.Title);
            _driver.Close();
            _driver.Dispose();
        }

    }
}
