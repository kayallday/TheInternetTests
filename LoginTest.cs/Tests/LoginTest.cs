using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace Tests
{
    [TestFixture]
    [Parallelizable]
    class LoginTest : BaseTest
    {
        LoginPage Login;

        [SetUp]
        public new void SetUp()
        {
            Login = new LoginPage(Driver); 
        }

        [Test]
        [Category("Shallow")]
        public void ValidAccount()
        {
            Login.With("tomsmith", "SuperSecretPassword!");
            Assert.That(Login.SuccessMessagePresent);
        }

        [Test]
        [Category("Deep")]
        public void BadPasswordProvided()
        {
            Login.With("tomsmith", "SuperSecretPasswad!");
            Assert.That(Login.SuccessMessagePresent, Is.Not.True);
        }
     }
}
