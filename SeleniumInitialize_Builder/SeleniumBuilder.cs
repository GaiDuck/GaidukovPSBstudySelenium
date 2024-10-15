using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.DOMSnapshot;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace SeleniumInitialize_Builder
{
    public class SeleniumBuilder : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        public int Port { get; private set; }
        public bool IsDisposed { get; private set; }
        public bool HeadLessMod { get; set; }
        public List<string> ChangedArguments { get; private set; }
        public Dictionary<string, object> ChangedUserOptions { get; private set; }
        public TimeSpan Timeout { get; private set; } = TimeSpan.Zero;
        public string StartingURL { get; private set; } = null;
        
        ChromeOptions _chromeOptions { get; set; }
        ChromeDriverService _chromeService { get; set; }

        public SeleniumBuilder()
        {
            _chromeOptions = new ChromeOptions();
        }

        public IWebDriver Build()
        {
            //Создать экземпляр драйвера, присвоить получившийся результат переменной WebDriver, вернуть в качестве результата данного метода.
            WebDriver = new ChromeDriver(_chromeOptions);
            IsDisposed = false;

            if (Timeout != TimeSpan.Zero)
            {
                WebDriver.Manage().Timeouts().ImplicitWait = Timeout;
            }

            if (StartingURL != null)
            {
                WebDriver.Navigate().GoToUrl(StartingURL);
            }

            return WebDriver;
        }

        public void Dispose()
        {
            //Закрыть браузер, очистить использованные ресурсы, по завершении переключить IsDisposed на состояние true
            if (WebDriver != null)
            {
                WebDriver.Quit();
                WebDriver = null;
            }

            var chromeDriverProceses = Process.GetProcessesByName("chromedriver");
            foreach (var process in chromeDriverProceses)
            {
                process.Kill();
            }

            IsDisposed = true;
        }
        
        public SeleniumBuilder ChangePort(int port)
        {
            //Реализовать смену порта, на котором развёрнут IWebDriver для этого необходимо ознакомиться с классом DriverService соответствующего драйвера (ChromeDriverService для хрома)
            //Изменить свойство Port на тот порт, на который поменяли.
            //Builder в данном методе должен возвращать сам себя
            //Build();
            _chromeService = ChromeDriverService.CreateDefaultService();
            _chromeService.Port = port;
            Port = port;
            return this;
        }

        public SeleniumBuilder SetArgument(string argument)
        {
            //Реализовать добавление аргумента. При решении данной задаче ознакомитесь с классом Options соответствующего драйвера (ChromeOptions для браузера Chrome)
            //Все изменённые/добавленные аргументы необходимо отразить в свойстве СhangedArguments, которое перед этим нужно где-то будет проинициализировать.
            //Builder в данном методе должен возвращать сам себя
            _chromeOptions.AddArgument(argument);
            ChangedArguments.Clear();
            ChangedArguments.Add(argument);
            return this;
        }

        public SeleniumBuilder SetHeadLessMod()
        {
            _chromeOptions.AddArgument("headless");

            HeadLessMod = true;
            return this;
        }

        public SeleniumBuilder SetUserOption(string option, object value) 
        {
            //Реализовать добавление пользовательской настройки.
            //Все изменения сохранить в свойстве ChangedUserOptions
            //Builder в данном методе должен возвращать сам себя
            throw new NotImplementedException(); 
        }
        
        public SeleniumBuilder WithTimeout(TimeSpan timeout)
        {
            //Реализовать изменение изначального таймаута запускаемого браузера
            //Отслеживать изменения в свойстве Timeout
            //Builder возвращает себя
            Timeout = timeout;

            return this;
        }

        public SeleniumBuilder WithURL(string url)
        {
            //Реализовать изменения изначального URL запускаемого браузера
            //Отслеживать изменения в строке StartingURL
            //Builder возвращает себя
            StartingURL = url;
            return this;
        }
    }
}