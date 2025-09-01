using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SipTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipTestProject
{
    public class BookingTest_edge
    {
        //Here we define the driver 
        private IWebDriver _driver;
        [SetUp]
        public void setup()
        {
            _driver = new EdgeDriver();
        }
        //Here we call the Booking method from BookingPage class    
        [Test]
        public void booking()
        {
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

