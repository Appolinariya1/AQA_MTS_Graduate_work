using Graduate_work.Core;
using Graduate_work.Helpers.Configuration;
using Graduate_work.Pages;
using Graduate_work.Steps;
using OpenQA.Selenium;

namespace Graduate_work.Tests;

public class BaseGuiTest
{
    protected IWebDriver Driver { get; private set; }
    
    protected NavigationSteps _navigationSteps;
    //добавлю шаги 
    
    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        
        _navigationSteps = new NavigationSteps(Driver);
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}