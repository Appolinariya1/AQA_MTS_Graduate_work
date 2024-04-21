using Graduate_work.Helpers.Configuration;
using Graduate_work.Models;
using Graduate_work.Pages;
using Graduate_work.Pages.Modal;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class NavigationSteps : BaseSteps
{
    private LoginPage _loginPage;
    private ProjectsPage _projectsPage;
    private ProjectPage _projectPage;
    
    public NavigationSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
        _projectsPage = new ProjectsPage(Driver);
        _projectPage = new ProjectPage(Driver);
    }
    
    [AllureStep("Open login page")]
    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver);
    }
    
    [AllureStep("Open projects page")]
    public ProjectsPage NavigateToProjectsPage()
    {
        return SuccessfulLogin(Configurator.Users.First(x => x?.Email == "polinaholod97@gmail.com"));
    }
    
    [AllureStep("Successful login")]
    public ProjectsPage SuccessfulLogin(User? user)
    {
        _loginPage.EmailInput.SendKeys(user.Email);
        _loginPage.PswInput.SendKeys(user.Password);
        _loginPage.ClickLoginButton();
        
        return new ProjectsPage (Driver);
    }
    
    [AllureStep("Incorrect login")]
    public LoginPage IncorrectLogin(string email, string password)
    {
        _loginPage.EmailInput.SendKeys(email);
        _loginPage.PswInput.SendKeys(password);
        _loginPage.ClickLoginButton();
        
        return _loginPage;
    }

    public ProjectsPage NavigateToProjectsPageFromMenu()
    {
        _projectPage.ClickProjectsMenuRef();
        return _projectsPage;
    }
}