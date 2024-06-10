using Graduate_work.Pages;
using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.GUI;

public class DialogWindowTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void DialogWindowTestInit()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
    }

    [Test]
    [Description("Тест отображения диалогового окна")]
    [AllureFeature("Positive")]
    public void DialogWindowCreateProjectTest()
    {
        var modal = _projectsPage.ClickCreateNewProjectButton();

        Assert.That(modal.ModalElement.Displayed);
    }
}