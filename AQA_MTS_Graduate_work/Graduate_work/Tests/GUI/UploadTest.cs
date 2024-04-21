using System.Reflection;
using Graduate_work.Pages;

namespace Graduate_work.Tests.GUI;

public class UploadTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;
    private ProjectPage _projectPage;
    private ProjectSettingsPage _projectSettingsPage;

    [SetUp]
    public void UploadTestSetUp()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
        _projectPage = _projectsSteps.
            CreateNewProject("UploadProject", "12345", "some words", "Private");
        _projectSettingsPage = _navigationSteps.NavigateToProjectSettingsPage();
    }

    [Test]
    [Description("Тест на загрузку файла в проект")]
    [Category("Positive")]
    public void UploadProjectFileTest()
    {
        _projectPage.ClickProjectSettingsButton();
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Resources", "cat.jpg");
        _projectsSteps.ChangeProjectLogo(path);
        Assert.That(_projectSettingsPage.SuccessfulChangeLogoMessage.Displayed);
    }
    
    [TearDown]
    public void UploadTestTearDown()
    {
        _navigationSteps.NavigateToProjectsPageFromMenu();
        _projectsPage.FillSearchForProjects("UploadProject");
        _projectsSteps.DeleteProject();
    }
}