using Allure.Net.Commons;
using Graduate_work.Core;
using Graduate_work.Helpers.Configuration;
using Graduate_work.Pages;
using Graduate_work.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace Graduate_work.Tests.GUI;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureSuite("GUI Tests")]
[AllureNUnit]
public abstract class BaseGuiTest
{
    protected IWebDriver Driver { get; private set; }
    protected NavigationSteps _navigationSteps;
    protected ProjectsSteps _projectsSteps;
    protected ProjectSteps _projectSteps;

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _navigationSteps = new NavigationSteps(Driver);
        _projectsSteps = new ProjectsSteps(Driver, new ProjectsPage(Driver), new ProjectSettingsPage(Driver));
        _projectSteps = new ProjectSteps(Driver, new ProjectPage(Driver));
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshoteBytes = screenshot.AsByteArray;

                AllureApi.AddAttachment("Screenshot", "image/png", screenshoteBytes);
            }
        }
        catch
        {
            //ignore
        }

        Driver.Quit();
    }
}