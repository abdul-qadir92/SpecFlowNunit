using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowNunit.Drivers
{
    class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Setup()
        {
            //Environment.SetEnvironmentVariable("BROWSERSTACK_AUTOMATION", "false",EnvironmentVariableTarget.Process);
            //File.WriteAllText(@"C:\Users\qadir\source\repos\SpecFlowNunit\log\envlogs.txt", DateTime.Now.ToString()+Environment.GetEnvironmentVariable("BROWSERSTACK_AUTOMATION"));


            switch ("CHROME")
            {
                case "CHROME":
                    Console.WriteLine("CHROME BROWSERSTACK_AUTOMATION:", Environment.GetEnvironmentVariable("BROWSERSTACK_AUTOMATION"));

                    var chromeOptions = new ChromeOptions();

                    driver = new ChromeDriver(".",chromeOptions);

                    break;
                case "FIREFOX":
                    Console.WriteLine("FIREFOX BROWSERSTACK_AUTOMATION:", Environment.GetEnvironmentVariable("BROWSERSTACK_AUTOMATION"));

                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    // TODO: Refactor this code. NEED TO LOOK INTO ADDING A SETTING HERE FOR IT TO DISABLE SECURITY CERTIFICATE ERROR THAT COMES UP.
                    driver = new FirefoxDriver(firefoxOptions);
                    
                    break;
                default:
                    throw new Exception("The browser entered in the appconfig.json file is not valid.");
            }

            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
