using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeleniumInitialize_Tests
{
    public class Steps
    {


        public void ClickElement(IWebDriver driver, WebDriverWait wait, string xpath)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            var element = driver.FindElement(By.XPath(xpath));
            element.Click();
            Thread.Sleep(500);
        }

        public void FillElement(IWebDriver driver, WebDriverWait wait, string xpath, string text)
        {
            var element = driver.FindElement(By.XPath(xpath));
            element.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            element = driver.FindElement(By.XPath(xpath));
            element.SendKeys(text);
            Thread.Sleep(500);
        }

        public string ConvertColor(string cssColor)
        {
            int left = cssColor.IndexOf('(');
            int right = cssColor.IndexOf(')');

            string noBrackets = cssColor.Substring(left + 1, right - left - 1);
            string[] parts = noBrackets.Split(',');
            int r = int.Parse(parts[0], CultureInfo.InvariantCulture);
            int g = int.Parse(parts[1], CultureInfo.InvariantCulture);
            int b = int.Parse(parts[2], CultureInfo.InvariantCulture);
            int a = int.Parse(parts[3], CultureInfo.InvariantCulture);

            var color = Color.FromArgb((int)(a * 255), r, g, b);
            var htmlColor = ColorTranslator.ToHtml(color);

            return htmlColor;
        }

        /// <summary>
        /// Метод возвращает XPath до чекбокса "Категория" на странице "Твой кешбек" по номеру чекбокса
        /// </summary>
        /// <param name="checkBoxNumber"></param>
        /// <returns></returns>
        public string CheckBoxUniversalXPath(int checkBoxNumber)
        {
            return $@"//rui-modal-content[@class='body rui-modal-content']//li[{checkBoxNumber}]/rui-checkbox";
        }
    }
}
