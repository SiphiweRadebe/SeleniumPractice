using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SipTestProject.Pages;

namespace SipTestProject
{
    public class LoginTest1
    {
        private IWebDriver _driver;
        [SetUp]
        public void setup()
        {
            _driver = new ChromeDriver();
        }


        [Test]
        public void Login()
        {
            string? User = TestContext.Parameters["User"];
            string? Password = TestContext.Parameters["Password"];
            LoginPage lp = new LoginPage(_driver);

            _driver.Navigate().GoToUrl(TestContext.Parameters["Login_url"]);
            lp.Login(User, Password);    
            //Assert.Pass();

        }

        [TearDown]
        public void teardown()
        {
            _driver.Quit();
            _driver.Dispose();  
        }

    }
   } 
