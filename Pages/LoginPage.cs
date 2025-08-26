using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipTestProject.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement emailItxt;
        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement passwordtxt;
        [FindsBy(How = How.Id, Using = "login-submit")]
        private IWebElement loginbtn;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        public void Login(string username, string password)
        {
            emailItxt.SendKeys(username);
            passwordtxt.SendKeys(password);
            loginbtn.Click();
        }
    }
}
