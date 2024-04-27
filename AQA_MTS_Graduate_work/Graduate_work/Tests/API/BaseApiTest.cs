using Graduate_work.Clients;
using NLog;
using NUnit.Allure.Core;

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