using Graduate_work.Pages;
using Graduate_work.Steps;
using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.GUI;

public class CreateProjectTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void CreateProjectSetUp()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
        _projectsSteps = new ProjectsSteps(Driver, _projectsPage);
    }
    
    [Test]
    [Description("Тест на создание сущности / проекта")]
    [AllureFeature("Positive")]
    public void CreateNewProjectTest()
    {
        Assert.That(_projectsSteps
            .CreateNewProject("NormalProject", "01",
                "few sentences about project", "Private", "All")
            .IsPageOpened);
    }

    [TearDown]
    public void DeleteCreatedProjectTearDown()
    {
        _navigationSteps.NavigateToProjectsPageFromMenu();
        _projectsPage.FillSearchForProjects("NormalProject");
        _projectsSteps.DeleteProject();
    }
}