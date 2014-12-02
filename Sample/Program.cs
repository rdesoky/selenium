
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
           
			DesiredCapabilities ie = DesiredCapabilities.InternetExplorer();
			ie.SetCapability("browserAttachTimeout", 300000);
			ie.SetCapability("initialBrowserUrl", "http://www.google.com");
			ie.SetCapability("ie.forceCreateProcessApi", true);
			//ie.SetCapability("ie.forceShellWindowsApi",true);

            //IWebDriver driver = new InternetExplorerDriver();
			IWebDriver driver = new RemoteWebDriver(
				new Uri("http://127.0.0.1:5555"), 
				ie, 
				new TimeSpan(0,30,0) // 30 minutes timeout limit
			);
            //driver.Navigate().GoToUrl("http://www.google.com/");
			//IWebElement query = driver.FindElement(By.Name("q"));
			//query.SendKeys("Cheese");
			//query.Submit();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(30));
			wait.Until((d) => { return d.Title.ToLower().StartsWith("about"); });
			//System.Console.WriteLine("Page title is: " + driver.Title);
			//Thread.Sleep(TimeSpan.FromSeconds(10));
            driver.Quit();

        }
    }
}
