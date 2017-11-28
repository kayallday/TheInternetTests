using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Configuration;

namespace Tests
{
    [TestFixture]
    class BaseTest
    {
        public IWebDriver Driver;
        public static string ApplicationBaseUrl;

        private void LoadConfigValues()
        {
            var configReader = new AppSettingsReader();
            ApplicationBaseUrl = (string)configReader.GetValue("ApplicationBaseUrl", typeof(string));
        }

        [SetUp]
        protected void SetUp()
        {
            Driver = new ChromeDriver();
        }

        [TearDown]

        protected void TearDown()
        {
            Driver.Quit();
        }
    }
}
