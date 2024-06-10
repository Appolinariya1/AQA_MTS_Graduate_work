using Graduate_work.Pages;
using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.GUI;

public class ReproduceBugTest : BaseGuiTest
{
    private ProjectsPage _projectsPage;

    [SetUp]
    public void ReproduceBugSetUp()
    {
        _projectsPage = _navigationSteps
            .NavigateToProjectsPage();
    }
    
    [Test]
    [Description("Тест, воспроизводящий дефект")]
    [AllureFeature("Negative")]
    public void ReproduceFakeBugTest()
    {
        Assert.That(_projectsSteps
                .FailCreateNewProject("MinOutOfRangeProject", "k",
                    "few sentences about project", "Private", "NoOne")
                .MinCharsPrCodeErrorLabel.Text.Trim(),
            Is.EqualTo("Fake error text"));
    }
}