using NUnit;
using OpenQA.Selenium;  
using OpenQA.Selenium.Chrome;   
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;   
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace SeleniumPractice
{
    public class Tests
    {   
        
        // Here we are going to create a setup method   
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            // here we are going to initialize the chrome driver    
            driver = new ChromeDriver();
            // here we are going to maximize the browser window 
            driver.Manage().Window.Maximize();
        }



        // Here we are going to create a test for text box  
        [Test] 
        public void TextBox()
        {
            //here we navigate to the website   
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
            //here we find the text box by its id and send some text to it  
            driver.FindElement(By.Id("Text1")).Clear();
            driver.FindElement(By.Id("Text1")).SendKeys("admin123456");
        }


        // Here we are going to create a test for text area
        [Test]
        public void TextArea()
        {
            //here we navigate to the website   
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            //here we find the text area by its name and send some text to it   
            driver.FindElement(By.Name("TextArea2")).Clear();
            driver.FindElement(By.Name("TextArea2")).SendKeys("Just send something man i have nothing to say");
        }



        // Here we are going to create a test for the Button
        [Test]
        public void Button()
        {
            //here we navigate to the website   
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            //here we find the button by its id and click on it 
            driver.FindElement(By.Id("Button1")).Click();
            Thread.Sleep(1000); 
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void RadioButtonCheckBox()
        {
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            void SpecialClick(By locator)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                try
                {
                    IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    element.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    IWebElement element = driver.FindElement(locator);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                }
            }

            SpecialClick(By.Id("Checkbox1"));
            SpecialClick(By.Name("Radio2"));

        }

        // Here we are going to create a test for the website navigation
        [Test]
        public void Test1()
        {  //here we navigate to the website
            driver.Navigate().GoToUrl("https://admlucid.com/");

            //here we find the about us link by its link text and click on it
            Assert.That(driver.Url, Is.EqualTo("https://admlucid.com/"));
            Assert.That(driver.Title, Is.EqualTo("Home Page - Admlucid"));    
            //Assert.Pass();
        }


        //// Here we are going to create a test for the file input    
        //[Test]
        //public void FileInput() 
        //{
        //    //here we navigate to the website
        //    driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");
        //    //here we find the file input by its name and send the file path to it  
        //    driver.FindElement(By.Name("File2")).SendKeys("@\"C:\\Users\\ra\\Downloads\\SampleFile.txt");
        //}


        // Here we are going to create a test for the form submit   

        [Test]
        public void FormSubmit()
        {   //here we navigate to the website
            driver.Navigate().GoToUrl("https://admlucid.com/Home/WebElements");

            //here we find the form elements by their names and send some text to them  
            driver.FindElement(By.Name("Name")).SendKeys("Test Name");  
            driver.FindElement(By.Name("EMail")).SendKeys("siphiwemoketsi1@gmail.com"); 
            driver.FindElement(By.Name("Telephone")).SendKeys("1234567890");
            
            //here we find the select element by its name and select an option by its text
            var selectElement = driver .FindElement(By.Name("age"));   
            var select = new SelectElement(selectElement); select.SelectByText("4");

            //here we find the select element by its name and select an option by its text  
            var selectElement2 = driver.FindElement(By.Name("Service"));
            var select2 = new SelectElement(selectElement2); select2.SelectByText("Child Care");

            //here we find the submit button by its name and click on it    
            driver.FindElement(By.Name("Submit")).Submit();
            Thread.Sleep(1000); 
            driver.SwitchTo().Alert().Accept();
            
            SpecialClick(By.Name("Gender"));
            void SpecialClick(By locator)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                try
                {
                    IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    element.Click();
                }
                catch (ElementClickInterceptedException)
                {
                    IWebElement element = driver.FindElement(locator);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                }
            }
        }

        [Test]
        public void multiplewin()
        { 
            string originalWin = driver.CurrentWindowHandle;
            driver.Navigate().GoToUrl("https://www.alberta.ca/child-care-subsidy");
            driver.FindElement(By.LinkText("online subsidy estimator")).Click();
            foreach (string window in driver.WindowHandles)
            {
               if(originalWin != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.That(driver.FindElement(By.XPath("/html/body/form/div/div[2]/div/div[2]/h1")).Text, Is.EqualTo("Child Care Subsidy Estimator"));

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //Assert.That(driver.FindElement(By.XPath("/html/body/form/div/div[2]/div/div[2]/h1")).Text, Is.EqualTo("Child Care Subsidy Estimator"));
        }

        // Here we are going to create a tear down method
        [TearDown]  
        public void CloseBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }   
    }
}