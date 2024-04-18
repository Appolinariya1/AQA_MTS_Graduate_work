using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectsPage : BasePage
{
    private static string END_POINT = "projects";
    
    // Описание элементов
    private static readonly By TitleLabelBy = By.XPath("//h1[text()='Projects']");
    private static readonly By CreateProjectButtonBy = By.Id("createButton");
    private static readonly By CreateProjectModalBy = By.XPath(
        "//div[@class='ReactModalPortal']//div[@role='dialog']//h3[text()='Create new project']");
    
    public ProjectsPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public override bool IsPageOpened()
    {
        return TitleLabel.Text.Trim().Equals("Projects");
    }
    
    // Методы
    public IWebElement TitleLabel => WaitsHelper.WaitForExists(TitleLabelBy);
    public IWebElement CreateProjectButton => WaitsHelper.WaitForExists(CreateProjectButtonBy);
    public IWebElement CreateProjectModal => WaitsHelper.WaitForExists(CreateProjectModalBy);
    
    //Методы действий
    public void ClickCreateProjectButton() => CreateProjectButton.Click();
}