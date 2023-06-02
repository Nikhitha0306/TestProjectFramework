using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestProjectFramework.Utilities
{
    public class BaseTests
    {


        public IWebDriver driver;
        
        [SetUp]

        public void StartBrowser()

        {
            InitBrowser("Chrome");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }
       

        //Handling Browser mechanism
        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;


                case "Edge":

                    driver = new EdgeDriver();
                    break;

            }


        }

        [TearDown]
        public void AfterTest() 
        { 
            driver.Quit();
        }
    }
}
