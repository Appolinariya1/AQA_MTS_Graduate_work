using Graduate_work.Pages;

namespace Graduate_work.Tests.GUI;

public class BoundaryTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void DialogWindowTestInit()
    {
        _projectsPage = NavigationSteps
            .NavigateToProjectsPage();
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (2)")]
    [Category("Positive")]
    public void MinValueTest()
    {
        var modal = _projectsPage.ClickCreateProjectButton();
    }
}