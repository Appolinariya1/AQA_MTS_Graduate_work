using Graduate_work.Pages;
using Graduate_work.Steps;

namespace Graduate_work.Tests.GUI;

public class DeleteProjectTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void DeleteProjectSetUp()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
    }

    [Test]
    [Description("Тест на удаление сущности / проекта")]
    [Category("Positive")]
    public void DeleteOneProjectTest()
    {
        var projectName = "TestProject";
        _projectsSteps.CreateNewProject(projectName, "123", "some words about project", "Public");
        _navigationSteps.NavigateToProjectsPageFromMenu();
        _projectsPage.FillSearchForProjects(projectName);
        Assert.Multiple(() =>
        {
            Assert.That(_projectsSteps.DeleteProject().IsPageOpened);
            Assert.That(_projectsPage.ProjectNotFoundLabel.Displayed);
        });
    }
}