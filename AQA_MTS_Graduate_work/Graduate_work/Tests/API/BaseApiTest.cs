using Graduate_work.Steps;
using OpenQA.Selenium;

namespace Graduate_work.Tests.API;

public class BaseApiTest
{
    protected IWebDriver Driver { get; private set; }

    protected NavigationSteps NavigationSteps;
    
}