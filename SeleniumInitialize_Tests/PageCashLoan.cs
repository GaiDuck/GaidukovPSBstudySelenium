using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Tests
{
    internal class PageCashLoan : PageYourCashback
    {
        /// <summary>
        /// Выпадающий список Трудоустройство
        /// </summary>
        string work = @"//mat-select[@name='RussianEmployment']";
        /// <summary>
        /// Пункт Да
        /// </summary>
        string yes = @"//span[@data-test-id='option-label-0']";
        /// <summary>
        /// Чекбокс Согласие на запрос в кредитное бюро
        /// </summary>
        string bkiRequestCheckBox = @"//rui-checkbox[@name='BkiRequestAgreementConcent']";

        public override void FillDebitCardApplication(IWebDriver driver, WebDriverWait wait, Steps step, TestUserModel _userProfile)
        {
            step.ClickElement(driver, wait, work);
            step.ClickElement(driver, wait, yes);
            step.ClickElement(driver, wait, bkiRequestCheckBox);
        }
    }
}
