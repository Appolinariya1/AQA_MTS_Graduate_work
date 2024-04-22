using System.ComponentModel.DataAnnotations;
using System.Security;
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
    private static readonly By CreateProjectButtonBy = By.XPath("//button[@type='submit']");

    private static readonly By MinCharsPrCodeErrorLabelBy =
        By.XPath("//div[text()='The code must be at least 2 characters.']");

    private static readonly By MaxCharsPrCodeErrorLabelBy =
        By.XPath("//div[text()='The code may not be greater than 10 characters.']");

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
    public IWebElement ProjectMemberAccessAll => WaitsHelper.WaitForExists(ProjectMemberAccessAllBy);
    public IWebElement ProjectMemberAccessGroup => WaitsHelper.WaitForExists(ProjectMemberAccessGroupBy);
    public IWebElement ProjectMemberAccessNoOne => WaitsHelper.WaitForExists(ProjectMemberAccessNoOneBy);
    public IWebElement CreateProjectButton => WaitsHelper.WaitForExists(CreateProjectButtonBy);
    public IWebElement MinCharsPrCodeErrorLabel => WaitsHelper.WaitForExists(MinCharsPrCodeErrorLabelBy);
    public IWebElement MaxCharsPrCodeErrorLabel => WaitsHelper.WaitForExists(MaxCharsPrCodeErrorLabelBy);

    public void FillProjectName(string name)
    {
        ProjectNameInput.SendKeys(name);
    }

    public void FillProjectCode(string code)
    {
        ProjectCodeInput.Clear(); //чтобы очистить автоматически заполненное поле кода после заполнения имени проекта
        ProjectCodeInput.SendKeys(code);
    }

    public void FillProjectDescription(string description)
    {
        ProjectDescriptionArea.SendKeys(description);
    }

    public void SelectAccessType(string accessType, string memberAccess)
    {
        if (accessType == "Private")
        {
            ProjectAccessPrivateInput.Click();
            switch (memberAccess)
            {
                case "All":
                    ProjectMemberAccessAll.Click();
                    break;
                case "Group":
                    ProjectMemberAccessGroup.Click();
                    break;
                case "NoOne":
                    ProjectMemberAccessNoOne.Click();
                    break;
                default:
                    throw new ValidationException("Please select member access");
            }
        }
        else
        {
            ProjectAccessPublicInput.Click();
        }
    }

    public void ClickCreateProjectButton() => CreateProjectButton.Click();
}