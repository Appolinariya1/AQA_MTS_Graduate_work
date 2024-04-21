using OpenQA.Selenium;

namespace Graduate_work.Pages.Modal;

public class CreateSuiteModal : BaseModal
{
    private static readonly By ModalSuiteElementBy = By.XPath(
        "//div[@class='ReactModalPortal']//div[@role='dialog']//h3[text()='Create suite']");
    private static readonly By SuiteNameInputBy = By.Id("title");
    private static readonly By CreateButtonBy = By.XPath("//span[text()='Create']");
    
    
    public CreateSuiteModal(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsModalOpened()
    {
        return ModalSuiteElement.Displayed;
    }
    
    public IWebElement ModalSuiteElement => WaitsHelper.WaitForExists(ModalSuiteElementBy);
    public IWebElement SuiteNameInput => WaitsHelper.WaitForExists(SuiteNameInputBy);
    public IWebElement CreateButton => WaitsHelper.WaitForExists(CreateButtonBy);

    public void FillSuiteName(string suiteName)
    {
        SuiteNameInput.SendKeys(suiteName);
    }
    public void ClickCreateButton() => CreateButton.Click();
}