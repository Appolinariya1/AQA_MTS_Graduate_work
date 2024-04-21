using Graduate_work.Core;
using Graduate_work.Helpers.Configuration;
using Graduate_work.Pages;
using Graduate_work.Steps;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace Graduate_work.Tests.GUI;

[Parallelizable(scope: ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public abstract class BaseGuiTest
{
    protected IWebDriver Driver { get; private set; }
    protected NavigationSteps _navigationSteps;
    protected ProjectsSteps _projectsSteps;

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _navigationSteps = new NavigationSteps(Driver);
        _projectsSteps = new ProjectsSteps(Driver, new ProjectsPage(Driver));
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}