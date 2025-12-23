using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestWith_Selenium
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ExecuteTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Teste Selenium");

            Assert.That(driver.Title, Is.EqualTo("Google"));
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
