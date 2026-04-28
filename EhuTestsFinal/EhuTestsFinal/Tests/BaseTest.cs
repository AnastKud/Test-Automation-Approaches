using NUnit.Framework;
using OpenQA.Selenium;
using EhuTestsFinal.Driver;
using System;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using EhuTestsFinal.Utils;

namespace EhuTestsFinal.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected DateTime startTime;

        [SetUp]
        public void Setup()
        {
            startTime = DateTime.Now;

            Logger.Info($"========== START TEST: {TestContext.CurrentContext.Test.Name} ==========");

            driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var duration = DateTime.Now - startTime;

                Logger.Info($"TEST STATUS: {status}");
                Logger.Info($"EXECUTION TIME: {duration.TotalSeconds:F2} sec");

                if (driver != null &&
                    status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    Logger.Error($"TEST FAILED: {TestContext.CurrentContext.Test.Name}");

                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                    var screenshotsDir = System.IO.Path.Combine(
                        TestContext.CurrentContext.WorkDirectory, "Screenshots");

                    System.IO.Directory.CreateDirectory(screenshotsDir);

                    var fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    var filePath = System.IO.Path.Combine(screenshotsDir, fileName);

                    screenshot.SaveAsFile(filePath);

                    TestContext.AddTestAttachment(filePath, "Screenshot on failure");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"TearDown Error: {ex.Message}");
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                    driver = null;
                }

                DriverSingleton.QuitDriver();

                Logger.Info($"========== END TEST ==========\n");
            }
        }
    }
}