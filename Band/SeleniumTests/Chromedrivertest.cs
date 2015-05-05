using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Band.SeleniumTests
{
    class Chromedrivertests
    {
        static void main()
        {
           IWebDriver driver = new ChromeDriver();

           driver.Navigate().GoToUrl("localhost");

           driver.time.sleep(2000);

           driver.Navigate().GoToUrl("localhost/register");

           driver.time.sleep(2000);
        }
    }
}