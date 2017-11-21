using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace LoginTest.cs
{
    [TestFixture]
    public class LoginTest
    {
        IWebDriver Driver;
        LoginPage Login;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Login = new LoginPage(Driver); 
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ValidAccount()
        {
            Login.With("tomsmith", "SuperSecretPassword!");
            Assert.That(Login.SuccessMessagePresent);
        }

        [Test]
        public void BadPasswordProvided()
        {
            Login.With("tomsmith", "SuperSecretPasswad!");
            Assert.That(Login.FailureMessagePresent);
        }
     }
}
