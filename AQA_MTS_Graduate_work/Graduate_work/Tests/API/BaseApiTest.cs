using Graduate_work.Clients;
using Graduate_work.Services;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Graduate_work.Tests.API;

[AllureNUnit]
[AllureSuite("API Tests")]
public class BaseApiTest
{
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    protected ProjectService? ProjectService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();

        ProjectService = new ProjectService(restClient);
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        ProjectService.Dispose();
    }
}