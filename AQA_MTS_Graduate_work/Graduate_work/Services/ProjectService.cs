using System.Net;
using Graduate_work.Clients;
using Graduate_work.Models;
using RestSharp;

namespace Graduate_work.Services;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<BaseApiResult<Project>> GetProjectByCode(string projectCode)
    {
        var request = new RestRequest("https://api.qase.io/v1/project/{code}")
            .AddUrlSegment("code", projectCode);

        return _client.ExecuteAsync<BaseApiResult<Project>>(request);
    }

    public Task<BaseApiResult<ApiListResult<Project>>> GetAllProjects()
    {
        var request = new RestRequest("https://api.qase.io/v1/project");

        return _client.ExecuteAsync<BaseApiResult<ApiListResult<Project>>>(request);
    }

    public Task<BaseApiResult<Project>> CreateNewProject(Project project)
    {
        var request = new RestRequest("https://api.qase.io/v1/project", Method.Post)
            .AddJsonBody(project);
        return _client.ExecuteAsync<BaseApiResult<Project>>(request);
    }

    public HttpStatusCode DeleteProjectByCode(string projectCode)
    {
        var request = new RestRequest("https://api.qase.io/v1/project/{code}", Method.Delete)
            .AddUrlSegment("code", projectCode);

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}