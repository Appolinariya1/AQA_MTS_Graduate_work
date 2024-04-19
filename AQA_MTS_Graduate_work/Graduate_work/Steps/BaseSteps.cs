using Graduate_work.Pages;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class BaseSteps(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;
}