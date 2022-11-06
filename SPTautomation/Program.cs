using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SPTautomation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open chrome browser
            IWebDriver driver = new ChromeDriver();

            //Launch the url
            driver.Navigate().GoToUrl("https://www.spanishpoint.ie/");

            //Maximize webpage
            driver.Manage().Window.Maximize();

            //Identify the 'Solution and Service' and mouse over 
            IWebElement ss = driver.FindElement(By.XPath("//a/span[1]"));

            Actions act = new Actions(driver);

            act.MoveToElement(ss).Perform();

            //Identify and click on 'Modern Work' and click on the tab
            IWebElement mw = driver.FindElement(By.XPath("(//span[1])[3]"));
            mw.Click();

            //Identify and click on the 'Accept All Cookies' tab
            IWebElement ctab = driver.FindElement(By.XPath("//a[@id ='wt-cli-accept-btn']"));
            ctab.Click();

            //Identify and click on the 'Employee Experience' tab
            IWebElement ee = driver.FindElement(By.XPath("(//span[@class='vc_tta-title-text'])[2]"));
            ee.Click();

            //scroll page down using javascript executor code
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,500)");

            //Identify header
            IWebElement header = driver.FindElement(By.XPath("(//div[@class='wpb_wrapper'][contains(., 'Employee Experience')])[2]"));

            ////Identify the paragraph 
            //IWebElement validation = driver.FindElement(By.XPath("(//div[contains(@class,'wpb_wrapper')])[12]/p/strong"));

            // Assert that required text is visible on the page
            if (header.Text == "Employee Experience")
            {
                Console.WriteLine("You have successfully navigated to the right page. test passed");
            }

            else
            {
                Console.WriteLine("Test not successful");
            }
        }
    }
}
