using Graduate_work.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Graduate_work.Tests.GUI;

public class HoverTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;
    private ProjectPage _projectPage;

    [SetUp]
    public void BoundaryTestsInit()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
        _projectPage = _projectsSteps.CreateNewProject("HoverProject", "1234", "some words", "Private");
        _projectSteps.CreateNewSuite("HoverSuite");
    }

    [Test]
    [Description("Тест на проверку всплывающего сообщения")]
    [Category("Positive")]
    public void HoverChatTest()
    {
        Actions actions = new Actions(Driver);
        actions.MoveToElement(_projectPage.CreateSuiteOrCaseButton, 10, 10).Perform();

        Assert.That(Driver.FindElement(By.XPath("//div[text()='Create suite or case']")).Displayed);
    }

    [TearDown]
    public void HoverTearDown()
    {
        _navigationSteps.NavigateToProjectsPageFromMenu();
        _projectsPage.FillSearchForProjects("HoverProject");
        _projectsSteps.DeleteProject();
    }
}