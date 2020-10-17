using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuickKart.Test
{
    public class LoginTest
    {
        [Fact]
        public void UserLoginTest()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://localhost:44399/Home/Login");

                IWebElement applicationButton = driver.FindElement(By.Name("RegisterUser"));

                applicationButton.Click();

                Assert.Equal("RegisterUser - QuickKart", driver.Title);
            }
        }
        //[Fact]
        //public void RegisterNewUser()
        //{
        //    using (IWebDriver driver = new ChromeDriver())
        //    {
        //        driver.Manage().Window.Maximize();

        //        driver.Navigate().GoToUrl("https://localhost:44399/User/RegisterUser");

        //        IWebElement firstNameInput = driver.FindElement(By.Id("EmailId"));
        //        firstNameInput.SendKeys("Satyatr@gmail.com");

        //        driver.FindElement(By.Id("UserPassword")).SendKeys("abc123");

        //        driver.FindElement(By.Id("Gender")).SendKeys("M");

        //        driver.FindElement(By.Id("DateOfBirth")).SendKeys("06-03-1995");

        //        driver.FindElement(By.Id("Address")).SendKeys("Hyderabad");


        //        driver.FindElement(By.Name("Register")).Click();

        //        Assert.Equal("Login - QuickKart", driver.Title);

        //    }
        //}
        [Fact]
        public void CustomerLogin()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://localhost:44399/");

                IWebElement firstNameInput = driver.FindElement(By.Id("name"));
                firstNameInput.SendKeys("Yoshi@gmail.com");

                driver.FindElement(By.Id("pwd")).SendKeys("RICAR@1234");

           
                driver.FindElement(By.Id("btnLogin")).Click();

                Assert.Equal("CustomerHome - QuickKart", driver.Title);

            }
        }


    }
}