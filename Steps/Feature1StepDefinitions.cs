using OpenQA.Selenium;
using SpecFlowNunit.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowNunit.Steps
{
    [Binding]
    public sealed class Feature1StepDefinitions
    {
        IWebDriver driver;
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public Feature1StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Open the Browser")]
        public void GivenOpenTheBrowser(Table table)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

        }


        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "https://bstackdemo.com/";
        }

        [Then(@"Click on Login")]
        public void ThenClickOnLogin()
        {
            Console.WriteLine(driver.Title);
        }


    }
}
