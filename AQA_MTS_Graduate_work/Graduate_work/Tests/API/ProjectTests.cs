using Graduate_work.Models;
using Graduate_work.Models.API;
using Newtonsoft.Json;
using NLog;

namespace Graduate_work.Tests.API;

public class ProjectTests : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project? _project;


    [Test]
    [Description("Тест создания проекта")]
    [Category("NFE")]
    [Order(1)]
    public async Task CreateProjectTest()
    {
        string projectJson = File.ReadAllText(@"Resources\test_Project.json");
        var projectObjectFromJson = JsonConvert.DeserializeObject<Project>(projectJson);

        var actualProject = await ProjectService?.CreateNewProject(projectObjectFromJson);

        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Status, Is.EqualTo(true));
            Assert.That(actualProject.Result?.Code, Is.EqualTo(projectObjectFromJson?.Code.ToUpper()));
        });

        _project = actualProject.Result;
        _logger.Info(_project.ToString);
    }

    [Test]
    [Description("Тест получения проекта по коду")]
    [Category("NFE")]
    [Order(2)]
    public async Task GetProjectByCode()
    {
        string projectJson = File.ReadAllText(@"Resources\test_Project.json");
        var projectObjectFromJson = JsonConvert.DeserializeObject<Project>(projectJson);
        
        var actualProject = await ProjectService.GetProjectByCode(projectObjectFromJson.Code.ToUpper());

        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Status, Is.EqualTo(true));
            Assert.That(actualProject.Result?.Code, Is.EqualTo(projectObjectFromJson.Code.ToUpper()));
        });

        _project = actualProject.Result;
        _logger.Info(_project.ToString);
    }
}