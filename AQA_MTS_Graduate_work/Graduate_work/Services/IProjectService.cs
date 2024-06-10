using System.Net;
using Graduate_work.Models;
using Graduate_work.Models.API;

namespace Graduate_work.Services;

public interface IProjectService
{
    Task<BaseApiResult<Project>> GetProjectByCode(string projectCode);
    Task<BaseApiResult<ApiListResult<Project>>> GetAllProjects();
    Task<BaseApiResult<Project>> CreateNewProject(Project project);
    Task<BaseApiResult<Project>> DeleteProjectByCode(string projectCode);
}