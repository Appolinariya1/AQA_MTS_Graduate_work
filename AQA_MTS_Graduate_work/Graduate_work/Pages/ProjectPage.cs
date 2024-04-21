using Graduate_work.Pages.Modal;
using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectPage : BasePage
{
    private static string END_POINT = "";
    
    private static readonly By CreateCaseButtonBy = By.Id("create-case-button");
    private static readonly By ProjectsMenuRefBy = By.XPath("//a[@href='/projects'][text()='Projects']");
    private static readonly By CreateSuiteButtonBy = By.Id("create-suite-button");
    private static readonly By CreateSuiteOrCaseButtonBy = By.XPath("//button[@aria-label='Create suite or case']");
    
    public ProjectPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public override bool IsPageOpened()
    {
       return CreateCaseButton.Displayed;
    }

    public IWebElement CreateCaseButton => WaitsHelper.WaitForExists(CreateCaseButtonBy);
    public IWebElement ProjectsMenuRef => WaitsHelper.WaitForExists(ProjectsMenuRefBy);
    public IWebElement CreateSuiteButton => WaitsHelper.WaitForExists(CreateSuiteButtonBy);
    public IWebElement CreateSuiteOrCaseButton => WaitsHelper.WaitForExists(CreateSuiteOrCaseButtonBy);

    public void ClickProjectsMenuRef() => ProjectsMenuRef.Click();

    public CreateSuiteModal ClickCreateSuiteButton()
    {
        CreateSuiteButton.Click();
        return new CreateSuiteModal(Driver);
    }
}