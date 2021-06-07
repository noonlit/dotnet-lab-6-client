using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace tests
{
    class Test_E2E
    {
        private IWebDriver _driver;
        [SetUp]
        public void SetupDriver()
        {
            _driver = new ChromeDriver("C:\\Users\\julie\\Downloads");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        [Test]
        public void UsersCanViewMovieDetails()
        {
            _driver.Url = "http://localhost:4200/movies";

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement detailsLink = wait.Until(drv => drv.FindElement(By.XPath("//ion-icon[@name='chevron-forward-outline']")));
            detailsLink.Click();

            IWebElement title = wait.Until(drv => drv.FindElement(By.XPath("//app-view-movie")));
            Assert.Pass();
        }

        [Test]
        public void LoggedInUserCanViewFavourites()
        {
            _driver.Url = "http://localhost:4200/login";

            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement name = wait.Until(drv => drv.FindElement(By.XPath("//input[@name='email']")));
            IWebElement password = wait.Until(drv => drv.FindElement(By.XPath("//input[@name='password']")));
            name.Click();
            name.SendKeys("test123@test.com");
            password.Click();
            password.SendKeys("Test_123");

            _driver.Navigate().GoToUrl("http://localhost:4200/favourites");

            Assert.Pass();
        }
    }
}
