using System.Net;
using Graduate_work.Models;

namespace Graduate_work.Services;

public interface IProjectService
{
    Task<BaseApiResult<Project>> GetProjectByCode(string projectCode);
    Task<BaseApiResult<ApiListResult<Project>>> GetAllProjects();
    Task<BaseApiResult<Project>> CreateNewProject(Project project);
    HttpStatusCode DeleteProjectByCode(string projectCode);
}