using Graduate_work.Pages.Modal;
using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectsPage : BasePage
{
    private static string END_POINT = "projects";
    
    // Описание элементов
    private static readonly By TitleLabelBy = By.XPath("//h1[text()='Projects']");
    private static readonly By CreateNewProjectButtonBy = By.Id("createButton");
    private static readonly By SearchForProjectsInputBy = By.XPath("//input[@placeholder='Search for projects']");
    private static readonly By ProjectMenuButtonBy = By.XPath("//table//tr//td[last()]/div/button");
    private static readonly By RemoveProjectButtonBy = By.XPath("//table//tr//td[last()]/div/button/..//ul[@role='menu']/button[text()='Remove']");
    private static readonly By DeleteProjectButtonBy = By.XPath("//button//span[text()='Delete project']");
    private static readonly By ProjectNotFoundLabelBy =
        By.XPath("//div[text()='Looks like you don’t have any projects yet.']");
    public ProjectsPage(IWebDriver driver, bool openPageByUrl = true) : base(driver, openPageByUrl)
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
    public IWebElement CreateNewProjectButton => WaitsHelper.WaitForExists(CreateNewProjectButtonBy);
    public IWebElement SearchForProjectsInput => WaitsHelper.WaitForExists(SearchForProjectsInputBy);
    public IWebElement ProjectMenuButton => WaitsHelper.WaitForExists(ProjectMenuButtonBy);
    public IWebElement RemoveProjectButton => WaitsHelper.WaitForExists(RemoveProjectButtonBy);
    public IWebElement DeleteProjectButton => WaitsHelper.WaitForExists(DeleteProjectButtonBy);
    public IWebElement ProjectNotFoundLabel => WaitsHelper.WaitForExists(ProjectNotFoundLabelBy);
    
    
    //Методы действий
    public CreateProjectModal ClickCreateNewProjectButton()
    {
        CreateNewProjectButton.Click();
        return new CreateProjectModal(Driver);
    }

    public void FillSearchForProjects(string projectName)
    {
        SearchForProjectsInput.SendKeys(projectName);
    }

    public void ClickProjectMenuButton() => ProjectMenuButton.Click();
    public void ClickRemoveProjectButton() => RemoveProjectButton.Click();
    public void ClickDeleteProjectButton() => DeleteProjectButton.Click();
    
}