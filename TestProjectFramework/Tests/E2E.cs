using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestProjectFramework.PageObjects;
using TestProjectFramework.Utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectFramework.Tests
{
    public class E2ETest : BaseTests
    {



        [Test]
        public void EndToEndFlow()

        {

            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.validLogin("rahulshettyacademy", "learning");

           
            
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))

                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);

            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;



            }
            Assert.That(actualProducts, Is.EqualTo(expectedProducts));

            driver.FindElement(By.CssSelector(".btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();


            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
            string confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;

            StringAssert.Contains("Success", confirText);



        }
    }

}
