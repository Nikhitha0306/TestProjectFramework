using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestProjectFramework.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
            
         
        }

        //PageObject Factory

      

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkbox;

        [FindsBy(How = How.CssSelector, Using = "input[value='Sign In")]
        private IWebElement signInButton;

        public void validLogin(String user, String pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkbox.Click();
            signInButton.Click();   






        }







        }









    }


