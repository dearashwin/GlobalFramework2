using GlobalAutoFramework.Config;
using GlobalAutoFramework.Helpers;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAutoFramework.Base
{
   public abstract class TestInitializeHook : Base
    {

        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {

            Browser = browser;
        }

        public void InitializeSetting()
        {

            ConfigReader.SetFrameworkSettings();

            LogHelpers.CreateLogFile();

            OpenBrowser(Browser);

            LogHelpers.Write("Initialize Framework");

        }

        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    //           DriverContext.Driver = new InternetExplorerDriver();
                    //         DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    //       DriverContext.Driver = new FireFoxDriver();
                    //     DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                    //default:
                    //    DriverContext.Driver = new ChromeDriver();
                    //    DriverContext.Browser = new Browser(DriverContext.Driver);
                    //    break;

            }
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);

        }


    }
}
