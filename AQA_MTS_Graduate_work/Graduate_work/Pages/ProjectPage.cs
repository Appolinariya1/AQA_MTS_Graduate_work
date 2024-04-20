using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectPage : BasePage
{
    private static string END_POINT = "";
    
    private static readonly By CreateCaseButtonBy = By.Id("create-case-button");
    
    public ProjectPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }

    public override bool IsPageOpened()
    {
       return CreateCaseButton.Displayed;
    }

    public IWebElement CreateCaseButton => WaitsHelper.WaitForExists(CreateCaseButtonBy);
}