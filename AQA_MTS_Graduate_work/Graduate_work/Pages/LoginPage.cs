using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class LoginPage : BasePage
{
    private static string END_POINT = "login";
    
    private static readonly By EmailInputBy = By.Name("email");
    private static readonly By PswInputBy = By.Name("password");
    private static readonly By RememberMeCheckBoxBy = By.Name("remember");
    private static readonly By LoginInButtonBy = By.CssSelector(".exOCAW.Ipyboe");
    
    public LoginPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public override bool IsPageOpened()
    {
        return LoginInButton.Displayed && EmailInput.Displayed;
    }
    
    public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
    public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
    public IWebElement RememberMeCheckBox => WaitsHelper.WaitForExists(RememberMeCheckBoxBy);
    public IWebElement LoginInButton => WaitsHelper.WaitForExists(LoginInButtonBy);

    public ProjectsPage SuccessfulLogin(string email, string password)
    {
        EmailInput.SendKeys(email);
        PswInput.SendKeys(password);
        LoginInButton.Click();

        return new ProjectsPage(Driver, false);
    }
}