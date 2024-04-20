using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class LoginPage : BasePage
{
    private static string END_POINT = "login";
    
    //описание элементов
    private static readonly By EmailInputBy = By.Name("email");
    private static readonly By PswInputBy = By.Name("password");
    private static readonly By RememberMeCheckBoxBy = By.Name("remember");
    private static readonly By LoginInButtonBy = By.XPath("//form//button[@type='submit']");
    private static readonly By ErrorAlertBy = By.XPath("//div[@role='alert']/span/span");
    
    //инициализация класса
    public LoginPage(IWebDriver driver, bool openPageByUrl = true) : base(driver, openPageByUrl)
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
    
    //методы поиска элементов
    public IWebElement EmailInput => WaitsHelper.WaitForExists(EmailInputBy);
    public IWebElement PswInput => WaitsHelper.WaitForExists(PswInputBy);
    public IWebElement RememberMeCheckBox => WaitsHelper.WaitForExists(RememberMeCheckBoxBy);
    public IWebElement LoginInButton => WaitsHelper.WaitForExists(LoginInButtonBy);
    public IWebElement ErrorAlert => WaitsHelper.WaitForExists(ErrorAlertBy);

    //методы действий
    public void ClickLoginButton() => LoginInButton.Click();
}