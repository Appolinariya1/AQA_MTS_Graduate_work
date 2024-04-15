using Graduate_work.Models;
using Graduate_work.Pages;
using OpenQA.Selenium;

namespace Graduate_work.Steps;

public class NavigationSteps : BaseSteps
{
    public NavigationSteps(IWebDriver driver) : base(driver) { }
    
    public LoginPage NavigateToLoginPage()
    {
        return new LoginPage(Driver);
    }
    
    public ProjectsPage NavigateToProjectsPage()
    {
        return new ProjectsPage(Driver);
    }
    
    public ProjectsPage SuccessfulLogin(User? user)
    {
        return Login<ProjectsPage>(user);
    }
    
    public LoginPage IncorrectLogin(User? user)
    {
        return Login<LoginPage>(user);
    }
    
    public T Login<T>(User? user) where T : BasePage
    {
        LoginPage = new LoginPage(Driver);
        
        LoginPage.EmailInput.SendKeys(user.Email);
        LoginPage.PswInput.SendKeys(user.Password);
        LoginPage.LoginInButton.Click();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }
}