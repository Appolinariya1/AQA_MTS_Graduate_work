using Graduate_work.Pages.Modal;
using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectsPage : BasePage
{
    private static string END_POINT = "projects";
    
    // Описание элементов
    private static readonly By TitleLabelBy = By.XPath("//h1[text()='Projects']");
    private static readonly By CreateProjectButtonBy = By.Id("createButton");
    
    
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
    
    
    //Методы действий
    public CreateProjectModal ClickCreateProjectButton()
    {
        CreateProjectButton.Click();
        return new CreateProjectModal(Driver);
    }
}