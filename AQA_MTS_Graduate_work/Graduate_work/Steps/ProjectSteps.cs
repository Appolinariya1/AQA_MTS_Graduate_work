using Graduate_work.Pages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class ProjectSteps(IWebDriver driver) : BaseSteps(driver)
{
    private readonly ProjectPage _projectPage;
    
    public ProjectSteps(IWebDriver driver, ProjectPage projectPage) :
        this(driver)
    {
        _projectPage = projectPage;
    }

    [AllureStep("Create new suite")]
    public ProjectPage CreateNewSuite(string suiteName)
    {
        var modal = _projectPage.ClickCreateSuiteButton();
        modal.FillSuiteName(suiteName);
        modal.ClickCreateButton();
        return _projectPage;
    }
}