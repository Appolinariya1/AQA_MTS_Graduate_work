using Graduate_work.Helpers;
using Graduate_work.Helpers.Configuration;
using OpenQA.Selenium;

namespace Graduate_work.Pages.Modal;

public abstract class BaseModal
{
    protected IWebDriver Driver { get; private set; }
    protected WaitsHelper WaitsHelper { get; private set; }

    public BaseModal(IWebDriver driver)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
    }
    
    public abstract bool IsModalOpened();
}