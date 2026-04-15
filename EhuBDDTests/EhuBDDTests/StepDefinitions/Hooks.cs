using Reqnroll;
using EhuTestsBDD.Drivers;

namespace EhuTestsBDD.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private static WebDriverManager _manager;

        [BeforeScenario]
        public void Setup()
        {
            _manager = new WebDriverManager();
            _manager.Start();
        }

        [AfterScenario]
        public void TearDown()
        {
            _manager.Stop();
        }

        public static WebDriverManager GetDriver()
        {
            return _manager;
        }
    }
}