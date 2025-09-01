using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using SipTestProject.Pages;
using NUnit.Framework.Internal; 
using NUnit.Framework; 

namespace SipTestProject
{
    public class BookingTest_chrome
    {// Test case to book a golf session using Chrome browser

        //Here we define the driver 
        private IWebDriver _driver;
        [SetUp]
        public void setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }
        //Here we call the Booking method from BookingPage class    
        [Test]
        public void booking() { 
            BookingPage b = new BookingPage(_driver);
            b.Booking();
        }
        //Here we close and dispose the driver  
        [TearDown]
        public void teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }   
    }
}
