using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestWith_Selenium
{
    public class Tests
    {
        //LOGIN IN AMAZON WEBSITE TEST
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            //Go to amazon page
            driver.Navigate().GoToUrl("https://www.amazon.com");
        }

        [Test]
        public void ExecuteTest()
        {
            driver.Manage().Window.Maximize();
            IWebElement Shopping = driver.FindElement(By.ClassName("a-button-text"));
            Shopping.Click();
            IWebElement SigniIn = driver.FindElement(By.Id("nav-link-accountList"));
            SigniIn.Click();

            IWebElement EmailField = driver.FindElement(By.Id("ap_email_login"));
            EmailField.SendKeys("pewpew@abv.bg");

            IWebElement ContinueButton = driver.FindElement(By.Id("continue"));
            ContinueButton.Click();

            IWebElement ErrorMessage = driver.FindElement(By.ClassName("a-alert-heading"));
            String ActualErrorMessageTexte = ErrorMessage.Text;
            String ExpectedErrorMessageText = "There was a problem";
            Assert.Equals(ActualErrorMessageTexte, ExpectedErrorMessageText);
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            //driver?.Quit();
            driver?.Dispose();
        }
    }
}
