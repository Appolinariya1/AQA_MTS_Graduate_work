using Graduate_work.Pages;
using Graduate_work.Pages.Modal;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class ProjectsSteps(IWebDriver driver) : BaseSteps(driver)
{
    private readonly CreateProjectModal _createProjectModal;
    private readonly ProjectsPage _projectsPage;

    public ProjectsSteps(IWebDriver driver, CreateProjectModal createProjectModal, ProjectsPage projectsPage) :
        this(driver)
    {
        _createProjectModal = createProjectModal;
        _projectsPage = projectsPage;
    }

    public ProjectPage CreateNewProject(string name, string code, string description, string accessType,
        string memberAccess = "all")
    {
        return new ProjectPage(Driver, false);
    }
}