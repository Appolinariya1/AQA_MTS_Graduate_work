using OpenQA.Selenium;

namespace Graduate_work.Pages;

public class ProjectPage : BasePage
{
    public ProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override string GetEndpoint()
    {
        throw new NotImplementedException();
    }

    public override bool IsPageOpened()
    {
        throw new NotImplementedException();
    }
}