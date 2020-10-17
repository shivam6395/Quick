using System;
using TechTalk.SpecFlow;

namespace QuickKart.Test
{
    [Binding]
    public class AdminLoginSteps
    {
        [Given(@"I am on the  page")]
        public void GivenIAmOnThePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have  my username as (.*)")]
        public void GivenIHaveMyUsernameAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have  my password as (.*)")]
        public void GivenIHaveMyPasswordAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I  login")]
        public void WhenILogin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the i  see the customers page")]
        public void ThenTheISeeTheCustomersPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
