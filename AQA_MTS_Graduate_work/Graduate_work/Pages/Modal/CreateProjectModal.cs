using Graduate_work.Helpers;
using OpenQA.Selenium;

namespace Graduate_work.Pages.Modal;

public class CreateProjectModal : BaseModal
{
    private static readonly By CreateProjectModalBy = By.XPath(
        "//div[@class='ReactModalPortal']//div[@role='dialog']//h3[text()='Create new project']");

    public CreateProjectModal(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement ModalElement => WaitsHelper.WaitForExists(CreateProjectModalBy);
}