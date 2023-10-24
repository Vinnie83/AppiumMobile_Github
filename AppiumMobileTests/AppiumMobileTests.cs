using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Runtime.CompilerServices;

namespace AppiumMobileTests
{
    public class AppiumMobileTests
    {
        

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        public const string appLocation = @"C:\com.android.example.github.apk";
        public const string appiumServer = "http://127.0.0.1:4723/wd/hub";

        [SetUp]

        public void PrepareApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android"};
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement> (new Uri(appiumServer), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TearDown]

        public void CloseApp() 
        
        { 
            driver.Quit(); 
        }

        [Test]

        public void Test_VerifyBarancev()
        {
            var inputSearchField = driver.FindElementById("com.android.example.github:id/input");
            inputSearchField.Click();
            inputSearchField.SendKeys("Selenium");

            driver.PressKeyCode(AndroidKeyCode.Enter);

            var textSelenium = driver.FindElementByXPath("//android.view.ViewGroup/android.widget.TextView[2]");
            Assert.That(textSelenium.Text, Is.EqualTo("SeleniumHQ/selenium"));

            textSelenium.Click();

            var listTextBarancev = driver.FindElementByXPath("//android.widget.FrameLayout[2]/android.view.ViewGroup/android.widget.TextView");
            Assert.That(listTextBarancev.Text, Is.EqualTo("barancev"));

            listTextBarancev.Click();

            var textFieldBarancev = driver.FindElementByXPath("//android.widget.TextView[@content-desc='user name']");
            Assert.That(textFieldBarancev.Text, Is.EqualTo("Alexei Barantsev")); 

        }   


    }
}