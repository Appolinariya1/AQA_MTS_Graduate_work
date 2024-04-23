using Graduate_work.Clients;
using Graduate_work.Steps;
using NLog;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace Graduate_work.Tests.API;

[Parallelizable(scope: ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
    }
}