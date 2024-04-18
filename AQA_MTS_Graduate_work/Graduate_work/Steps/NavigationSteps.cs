using Graduate_work.Models;
using Graduate_work.Pages;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class NavigationSteps : BaseSteps
{
    private LoginPage _loginPage;
    private ProjectsPage _projectsPage;
    
    public NavigationSteps(IWebDriver driver) : base(driver)
    {
        _loginPage = new LoginPage(Driver);
        _projectsPage = new ProjectsPage(Driver);
    }
    
    [AllureStep]
    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver);
    }
    
    [AllureStep]
    public ProjectsPage NavigateToProjectsPage()
    {
        return new ProjectsPage(Driver);
    }
    
    [AllureStep]
    public ProjectsPage SuccessfulLogin(User? user)
    {
        _loginPage.EmailInput.SendKeys(user.Email);
        _loginPage.PswInput.SendKeys(user.Password);
        _loginPage.ClickLoginButton();
        
        return new ProjectsPage (Driver);
    }
    
    [AllureStep]
    public LoginPage IncorrectLogin(string email, string password)
    {
        _loginPage.EmailInput.SendKeys(email);
        _loginPage.PswInput.SendKeys(password);
        _loginPage.ClickLoginButton();
        
        return _loginPage;
    }
}