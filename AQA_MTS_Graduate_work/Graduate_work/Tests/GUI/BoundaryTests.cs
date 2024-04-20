using Graduate_work.Pages;
using Graduate_work.Steps;

namespace Graduate_work.Tests.GUI;

public class BoundaryTests : BaseGuiTest
{
    private ProjectsPage _projectsPage;
    private ProjectsSteps _projectsSteps;

    [OneTimeSetUp]
    public void BoundaryTestsInit()
    {
        _projectsPage = NavigationSteps
            .NavigateToProjectsPage();
        _projectsSteps = new ProjectsSteps(Driver, _projectsPage);
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (2)")]
    [Category("Positive")]
    public void MinValueTest()
    {
        Assert.That(_projectsSteps
            .CreateNewProject("MinProject", "ps",
                "few sentences about project", "Private", "NoOne")
            .IsPageOpened);
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (10)")]
    [Category("Positive")]
    public void MaxValueTest()
    {
        Assert.That(_projectsSteps
            .CreateNewProject("MaxProject", "0123456789",
                "few sentences about project", "Private", "NoOne")
            .IsPageOpened);
    }

    [Test]
    [Description("Тест на проверку поля для ввода на граничные значения (1)")]
    [Category("Negative")]
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
    [Category("Negative")]
    public void MaxOutOfRangeValueTest()
    {
        Assert.That(_projectsSteps
                .FailCreateNewProject("MinOutOfRangeProject", "0123456789p",
                    "few sentences about project", "Private", "All")
                .MaxCharsPrCodeErrorLabel.Text.Trim(),
            Is.EqualTo("The code may not be greater than 10 characters."));
    }

    /*[OneTimeTearDown]
    public void DeleteCreatedProjectsTearDown()
    {
       //допишу после создания метода удаления проекта 
    }*/
}