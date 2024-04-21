using Graduate_work.Pages;
using Graduate_work.Pages.Modal;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class ProjectsSteps(IWebDriver driver) : BaseSteps(driver)
{
    private readonly ProjectsPage _projectsPage;

    public ProjectsSteps(IWebDriver driver, ProjectsPage projectsPage) :
        this(driver)
    {
        _projectsPage = projectsPage;
    }

    [AllureStep("Create new project")]
    public ProjectPage CreateNewProject(string name, string code, string description, string accessType,
        string memberAccess = "All")
    {
        var modal = _projectsPage.ClickCreateNewProjectButton();
        modal.FillProjectName(name);
        modal.FillProjectCode(code);
        modal.FillProjectDescription(description);
        modal.SelectAccessType(accessType, memberAccess);
        modal.ClickCreateProjectButton();
        return new ProjectPage(Driver, false);
    }
    
    [AllureStep("Incorrect create new project")]
    public CreateProjectModal FailCreateNewProject(string name, string code, string description, string accessType,
        string memberAccess = null)
    {
        var modal = _projectsPage.ClickCreateNewProjectButton();
        modal.FillProjectName(name);
        modal.FillProjectCode(code);
        modal.FillProjectDescription(description);
        modal.SelectAccessType(accessType, memberAccess);
        modal.ClickCreateProjectButton();
        return modal; 
    }

    [AllureStep("Delete project")]
    public ProjectsPage DeleteProject()
    {
        _projectsPage.ClickProjectMenuButton();
        _projectsPage.ClickRemoveProjectButton();
        _projectsPage.ClickDeleteProjectButton();

        return _projectsPage;
    }
}