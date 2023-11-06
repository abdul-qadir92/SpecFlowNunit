using OpenQA.Selenium;
using SpecFlowNunit.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowNunit.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        private readonly ScenarioContext _scenarioContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public HookInit(ScenarioContext scenarioContext)
        {
           _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Console.WriteLine("Selenium WebDriver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
        }
    }
}
