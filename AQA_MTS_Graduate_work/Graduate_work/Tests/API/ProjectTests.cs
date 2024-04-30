using Graduate_work.Models.API;
using Newtonsoft.Json;
using NLog;
using NUnit.Allure.Attributes;

namespace Graduate_work.Tests.API;

public class ProjectTests : BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private Project? _project;

    [Test]
    [Description("Тест создания проекта")]
    [Category("POST")]
    [AllureFeature("NFE")]
    [Order(1)]
    public async Task CreateProjectTest()
    {
        string projectJson = File.ReadAllText(@"Resources\test_Project.json");
        var projectObjectFromJson = JsonConvert.DeserializeObject<Project>(projectJson);

        var actualProject = await ProjectService.CreateNewProject(projectObjectFromJson);

        Assert.Multiple(() =>
        {
            Assert.That(actualProject.Status, Is.EqualTo(true));
            Assert.That(actualProject.Result?.Code, Is.EqualTo(projectObjectFromJson.Code.ToUpper()));
        });

        _project = actualProject.Result;
        _logger.Info(_project.ToString);
    }

    [Test]
    [Description("Тест получения проекта по коду")]
    [Category("GET")]
    [AllureFeature("NFE")]
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

    [Test]
    [Description("Тест получения всех проектов")]
    [Category("GET")]
    [AllureFeature("NFE")]
    [Order(3)]
    public async Task GetAllProjects()
    {
        var actualProjects = await ProjectService.GetAllProjects();

        Assert.Multiple(() =>
        {
            Assert.That(actualProjects.Status, Is.EqualTo(true));
            Assert.That(actualProjects.Result?.Total, Is.GreaterThan(0));
        });
    }

    [Test]
    [Description("Тест удаления проекта по коду")]
    [Category("DELETE")]
    [AllureFeature("NFE")]
    [Order(4)]
    public async Task DeleteProjectTest()
    {
        string projectJson = File.ReadAllText(@"Resources\test_Project.json");
        var projectObjectFromJson = JsonConvert.DeserializeObject<Project>(projectJson);

        var result = await ProjectService.DeleteProjectByCode(projectObjectFromJson.Code.ToUpper());

        var deletedProject = await ProjectService.GetProjectByCode(projectObjectFromJson.Code.ToUpper());

        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(true));
            Assert.That(deletedProject.Status, Is.EqualTo(false));
            Assert.That(deletedProject.ErrorMessage, Is.EqualTo("Project not found"));
        });
    }

    [Test]
    [Description("Тест удаления проекта по несуществующему коду")]
    [Category("DELETE")]
    [AllureFeature("AFE")]
    [Order(5)]
    public async Task DeleteFakeProjectTest()
    {
        var code = "KUKU102030FAKE";

        var result = await ProjectService.DeleteProjectByCode(code);

        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(false));
            Assert.That(result.ErrorMessage, Is.EqualTo("Project not found"));
        });
    }

    [Test]
    [Description("Тест создания проекта без кода")]
    [Category("POST")]
    [AllureFeature("AFE")]
    [Order(6)]
    public async Task CreateProjectWithoutCodeTest()
    {
        var project = new Project() { Title = "Pupupu" };
        var result = await ProjectService.CreateNewProject(project);

        Assert.Multiple(() =>
        {
            Assert.That(result.Status, Is.EqualTo(false));
            Assert.That(result.ErrorMessage, Is.EqualTo("Data is invalid."));
            Assert.That(result.ErrorFields.Any(field => field.Error == "Project code is required."));
        });
    }
}