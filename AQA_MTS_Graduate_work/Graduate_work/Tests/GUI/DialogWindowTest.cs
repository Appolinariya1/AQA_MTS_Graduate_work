using Graduate_work.Helpers.Configuration;
using Graduate_work.Pages;
using Graduate_work.Steps;

namespace Graduate_work.Tests;

public class DialogWindowTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void DialogWindowTestInit()
    {
        _projectsPage = NavigationSteps
            .SuccessfulLogin(Configurator.Users.First(x => x?.Email == "polinaholod97@gmail.com"));
    }

    [Test]
    public void DialogWindowCreateProjectTest()
    {
        _projectsPage.ClickCreateProjectButton();

        Assert.That(_projectsPage.CreateProjectModal.Displayed);
    }
}