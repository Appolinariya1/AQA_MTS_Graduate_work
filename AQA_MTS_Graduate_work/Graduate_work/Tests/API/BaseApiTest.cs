using Graduate_work.Clients;
using Graduate_work.Services;
using NLog;
using NUnit.Allure.Core;

namespace Graduate_work.Tests.API;

[Parallelizable(scope: ParallelScope.Fixtures)]
[AllureNUnit]
public class BaseApiTest
{
    protected ProjectService? ProjectService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();

        ProjectService = new ProjectService(restClient);
    }
}