using Graduate_work.Pages;
using Graduate_work.Steps;

namespace Graduate_work.Tests.GUI;

public class CreateProjectTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;
    private ProjectsSteps _projectsSteps;

    [SetUp]
    public void CreateProjectSetUp()
    {
        _projectsPage = NavigationSteps
            .NavigateToProjectsPage();
        _projectsSteps = new ProjectsSteps(Driver, _projectsPage);
    }
    
    [Test]
    [Description("Тест на создание сущности / проекта")]
    [Category("Positive")]
    public void CreateNewProjectTest()
    {
        Assert.That(_projectsSteps
            .CreateNewProject("NormalProject", "01",
                "few sentences about project", "Private", "All")
            .IsPageOpened);
    }
}