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
        string work = @"//mat-select[@name='RussianEmployment']";
        string yes = @"//span[@data-test-id='option-label-0']";
        string bkiRequestCheckBox = @"//rui-checkbox[@name='BkiRequestAgreementConcent']";

        public void FillDebitCardApplication(IWebDriver driver, WebDriverWait wait, Steps step, TestUserModel _userProfile)
        {
            step.FillElement(driver, wait, lastNameXpath, _userProfile.LastName);
            step.FillElement(driver, wait, firstNameXpath, _userProfile.FirstName);
            step.FillElement(driver, wait, middleNameXpath, _userProfile.MiddleName);
            step.ClickElement(driver, wait, manGenderXparh);
            step.FillElement(driver, wait, birthdayXpath, _userProfile.Birthday);
            step.FillElement(driver, wait, phoneNumberXpath, _userProfile.PhoneNumber);
            step.ClickElement(driver, wait, citizenshipXpath);
            step.ClickElement(driver, wait, RFXpath);
            step.ClickElement(driver, wait, work);
            step.ClickElement(driver, wait, yes);
            step.ClickElement(driver, wait, personalDataXpath);
            step.ClickElement(driver, wait, bkiRequestCheckBox);
        }
    }
}
