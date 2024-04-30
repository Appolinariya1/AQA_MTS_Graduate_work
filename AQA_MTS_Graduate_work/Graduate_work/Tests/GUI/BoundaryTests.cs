using Graduate_work.Pages;
using Graduate_work.Steps;
using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.GUI;

public class BoundaryTests : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void BoundaryTestsInit()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (2)")]
    [AllureFeature("Positive")]
    public void MinValueTest()
    {
        Assert.That(_projectsSteps
            .CreateNewProject("MinProject", "ps",
                "few sentences about project", "Private", "NoOne")
            .IsPageOpened);
        
        _navigationSteps.NavigateToProjectsPageFromMenu();
        _projectsPage.FillSearchForProjects("MinProject");
        _projectsSteps.DeleteProject();
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (10)")]
    [AllureFeature("Positive")]
    public void MaxValueTest()
    {
        Assert.That(_projectsSteps
            .CreateNewProject("MaxProject", "0123456789",
                "few sentences about project", "Private", "NoOne")
            .IsPageOpened);
        
        _navigationSteps.NavigateToProjectsPageFromMenu();
        _projectsPage.FillSearchForProjects("MaxProject");
        _projectsSteps.DeleteProject();
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (1)")]
    [AllureFeature("Negative")]
    public void MinOutOfRangeValueTest()
    {
        Assert.That(_projectsSteps
                .FailCreateNewProject("MinOutOfRangeProject", "k",
                    "few sentences about project", "Private", "NoOne")
                .MinCharsPrCodeErrorLabel.Text.Trim(),
            Is.EqualTo("The code must be at least 2 characters."));
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (11)")]
    [AllureFeature("Negative")]
    public void MaxOutOfRangeValueTest()
    {
        Assert.That(_projectsSteps
                .FailCreateNewProject("MinOutOfRangeProject", "0123456789p",
                    "few sentences about project", "Private", "All")
                .MaxCharsPrCodeErrorLabel.Text.Trim(),
            Is.EqualTo("The code may not be greater than 10 characters."));
    }
}