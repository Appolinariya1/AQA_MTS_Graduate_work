using Graduate_work.Core;
using Graduate_work.Helpers.Configuration;
using Graduate_work.Pages;
using OpenQA.Selenium;

namespace Graduate_work.Tests;

public class BaseGuiTest
{
    protected IWebDriver Driver { get; private set; }
    
    //добавлю шаги 
    
    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }
    
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}