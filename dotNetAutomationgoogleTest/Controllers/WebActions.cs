using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;


namespace dotNetAutomationgoogleTest.Controllers
{
    class WebActions
    {
        private string path;
        private string feature;
        private string evidencePath;
        private static int screenShotCounter;
        private static IWebDriver driver;

        public string getEvidencePath()
        {
            return evidencePath;
        }


        public void setEvidencePath(string evidencePath)
        {
            this.evidencePath = evidencePath;
        }

        public WebActions(string path, string feature, string scenario)
        {
            evidencePath = path;
            this.feature = feature;
            screenShotCounter = 0;
        }

        public IWebDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        private static NUnit.Framework.Internal.Logger _logger;

        public NUnit.Framework.Internal.Logger Logger
        {
            get => _logger;
            set => _logger = value;
        }


        public void launchWebApp(string browser, string url)
        {
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

            driver.Url = url;
        }

        public void closeWebApp()
        {
            driver.Close();
            driver.Quit();
        }

        public static void clickElement(IWebElement element, string elementNameOrDescription, bool takeScreenshot)
        {
            element.Click();
            if (takeScreenshot) takeScreenShot();
            _logger.Info("The element '"
                .Concat(elementNameOrDescription)
                .Concat("' was clicked. Screenshot taken: ")
                .Concat(string.Format(takeScreenshot.ToString())) as string);
            {
            }
        }

        public static void sendTextToElement(IWebElement element, string elementNameOrDescription, string text,
            bool takeScreenshot)
        {
            element.SendKeys(text);
            if (takeScreenshot) takeScreenShot();
            _logger.Info("In the element '"
                .Concat(elementNameOrDescription)
                .Concat("' was writter the string '")
                .Concat(text)
                .Concat("'. Screenshot taken: ")
                .Concat(string.Format(takeScreenshot.ToString())) as string);
            {
            }
        }

        public static string getTextFromElement(IWebElement element, string elementNameOrDescription,
            bool takeScreenshot)
        {
            if (takeScreenshot) takeScreenShot();
            string text = element.Text;
            _logger.Info("The element '"
                .Concat(elementNameOrDescription)
                .Concat("' has the text '")
                .Concat(text)
                .Concat("'. Screenshot taken: ")
                .Concat(string.Format(takeScreenshot.ToString())) as string);
            return text;
        }

        public static void waitVisible(By element, string elementNameOrDescription, TimeSpan timeout,
            bool takeScreenshot)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            if (takeScreenshot) takeScreenShot();
            _logger.Info("The element '"
                .Concat(elementNameOrDescription)
                .Concat("' is visible. Screenshot taken: '")
                .Concat(string.Format(takeScreenshot.ToString())) as string);
            {
            }
        }

        public static bool isVisible(By element, string elementNameOrDescription, TimeSpan timeOut,
            bool takeScreenshot)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeOut);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                if (takeScreenshot) takeScreenShot();
                {
                    _logger.Info((string)"The element '"
                        .Concat(elementNameOrDescription)
                        .Concat(" ' was visible. Screenshot taken: ")
                        .Concat(string.Format(takeScreenshot.ToString())));
                    return true;
                }
            }
            catch (Exception)
            {
                _logger.Info((string)"The element '"
                    .Concat(elementNameOrDescription)
                    .Concat(" ' wasnt visible. Screenshot taken: ")
                    .Concat(string.Format(takeScreenshot.ToString())));
                return false;
            }
        }

        public string getTabURL()
        {
            string url = driver.Url;
            _logger.Info((string)"The browser url is '"
                .Concat(url)
                .Concat("'"));
            return url;
        }

        public static void takeScreenShot()
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot screenshotFile = screenshot.GetScreenshot();
            //            File destinationFile = new File(path.Concat(feature)
            //                .Concat("-")
            //                .Concat(screenShotCounter)
            //                .Concat(".png"));
            screenShotCounter++;
        }
    }
}
