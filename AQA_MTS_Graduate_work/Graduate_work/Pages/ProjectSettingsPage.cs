using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectSettingsPage : BasePage
{
    private static readonly By ProjectSettingsLabelBy = By.XPath("//h1[text()='Project settings']");
    private static readonly By ChangeLogoButtonBy = By.XPath("//label[text()='Change logo']");
    private static readonly By SuccessfulChangeLogoMessageBy = By.XPath("//span[text()='Project avatar was successfully updated!']");
    private static readonly By ChangeLogoInputBy = By.XPath("//input[@type='file']");
    
    public ProjectSettingsPage(IWebDriver driver, bool openPageByUrl=false) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint()
    {
        return "";
    }

    public override bool IsPageOpened()
    {
        return ProjectSettingsLabel.Displayed;
    }
    
    public IWebElement ProjectSettingsLabel => WaitsHelper.WaitForExists(ProjectSettingsLabelBy);
    public IWebElement ChangeLogoButton => WaitsHelper.WaitForExists(ChangeLogoButtonBy);
    public IWebElement SuccessfulChangeLogoMessage => WaitsHelper.WaitForExists(SuccessfulChangeLogoMessageBy);
    public IWebElement ChangeLogoInput => WaitsHelper.WaitForExists(ChangeLogoInputBy);

    public void ClickChangeLogoButton() => ChangeLogoButton.Click();
}