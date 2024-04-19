using Graduate_work.Helpers;
using OpenQA.Selenium;

namespace Graduate_work.Pages.Modal;

public class CreateProjectModal : BaseModal
{
    private static readonly By ModalElementBy = By.XPath(
        "//div[@class='ReactModalPortal']//div[@role='dialog']//h3[text()='Create new project']");
    private static readonly By ProjectNameInputBy = By.Id("project-name");
    private static readonly By ProjectCodeInputBy = By.Id("project-code");
    private static readonly By ProjectDescritpionAreaBy = By.Id("description-area");
    private static readonly By ProjectAccessPrivateInputBy = By.XPath("//input[@value='private']");
    private static readonly By ProjectAccessPublicInputBy = By.XPath("//input[@value='public']");
    private static readonly By ProjectMemberAccessAllBy = By.XPath("//input[@value='all']");
    private static readonly By ProjectMemberAccessGroupBy = By.XPath("//input[@value='group']");
    private static readonly By ProjectMemberAccessNoOneBy = By.XPath("//input[@value='none']");
    
    public CreateProjectModal(IWebDriver driver) : base(driver)
    {
    }
    
    public override bool IsModalOpened()
    {
        return ModalElement.Displayed;
    }

    public IWebElement ModalElement => WaitsHelper.WaitForExists(ModalElementBy);
    public IWebElement ProjectNameInput => WaitsHelper.WaitForExists(ProjectNameInputBy);
    public IWebElement ProjectCodeInput => WaitsHelper.WaitForExists(ProjectCodeInputBy);
    public IWebElement ProjectDescriptionArea => WaitsHelper.WaitForExists(ProjectDescritpionAreaBy);
    public IWebElement ProjectAccessPrivateInput => WaitsHelper.WaitForExists(ProjectAccessPrivateInputBy);
    public IWebElement ProjectAccessPublicInput => WaitsHelper.WaitForExists(ProjectAccessPublicInputBy);
    public IWebElement rojectMemberAccessAll => WaitsHelper.WaitForVisibilityLocatedBy(ProjectMemberAccessAllBy);
    public IWebElement rojectMemberAccessGroup => WaitsHelper.WaitForVisibilityLocatedBy(ProjectMemberAccessGroupBy);
    public IWebElement rojectMemberAccessNoOne => WaitsHelper.WaitForVisibilityLocatedBy(ProjectMemberAccessNoOneBy);
}