using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Xunit;


namespace TechnicalTask
{
    public class UnitTest2
    {
        
        [Fact]
        public void Test2()
        {
            
            IWebDriver driver;
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("browser", "Chrome");
            capability.SetCapability("browser_version", "68.0");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("resolution", "1366x768");
            capability.SetCapability("browserstack.timezone", "+02:00"); 
            capability.SetCapability("browserstack.user", "alex6661");
            capability.SetCapability("browserstack.key", "UJDqJ1s1Cm7tHKfzTQz3");

            driver = new RemoteWebDriver(
                new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            
            driver.Navigate().GoToUrl("https://en.todoist.com/Users/showLogin");
//            Thread.Sleep(5000);

            var email = driver.FindElement(By.CssSelector("input[type='email']"));
            var passw = driver.FindElement(By.CssSelector("input[type='password']"));
            var confirm = driver.FindElements(By.CssSelector("a[href='#']"));

            email.SendKeys("aleksandr.tyrenko@gmail.com");
            passw.SendKeys("144358");
            confirm[2].Click();

            var plus = driver.FindElements(By.CssSelector("span[class='icon icon-add']"));
            plus[3].Click();

            var className =
                driver.FindElement(
                    By.CssSelector("div[class='richtext_editor sel_richtext_editor']"));
            var confirmTask =
                driver.FindElement(
                    By.CssSelector("a[class='ist_button ist_button_red submit_btn']"));
            
            className.SendKeys("Test add Task");
            confirmTask.Click();
            
            var counters = driver.FindElements(By.CssSelector("small[class='item_counter']"));
            Assert.Equal("1", counters[0].Text);

            var deleteTask =
                driver.FindElements(
                    By.CssSelector("tr[class='sel_delete_task danger menu_item']"));
            

            var items = driver.FindElement(
                By.CssSelector("td[class='text_cursor content task_content_item']"));
            var action = new Actions(driver);
            action.ContextClick(items);
            action.Perform();
            deleteTask[1].Click();

            var confirmDelete =
                driver.FindElement(By.CssSelector("a[class='ist_button ist_button_red']"));
            confirmDelete.Click();

            var counter = driver.FindElements(By.CssSelector("small[class='item_counter']"));
            Assert.Equal("", counter[0].Text);

            Thread.Sleep(200);
            var menu = driver.FindElement(By.Id("gear_holder"));
            menu.Click();

            Thread.Sleep(200);
            var logOut = driver.FindElement(By.CssSelector("td[data-track='navigation|logout'"));
            logOut.Click();

/**            var confirmLogOut =
*               driver.FindElement(By.CssSelector("a[class='ist_button ist_button_red']"));
*          confirmLogOut.Click();
 *
 *   If very fast logOut user need comfirm
*/              
            Thread.Sleep(200);
            Console.WriteLine("End");
            driver.Close();
        }
    }
}