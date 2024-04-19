using Graduate_work.Pages;

namespace Graduate_work.Tests.GUI;

public class DialogWindowTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void DialogWindowTestInit()
    {
        _projectsPage = NavigationSteps
            .NavigateToProjectsPage();
    }

    [Test]
    public void DialogWindowCreateProjectTest()
    {
        var modal = _projectsPage.ClickCreateProjectButton();

        Assert.That(modal.ModalElement.Displayed);
    }
}