using EEP.DAL.Interfaces;
using EEP.DAL.UnitOfWork;
using EEP.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProjectService()
        {
            _unitOfWork = new UnitOfWork();
        }

        //C create
        public async Task<Project> CreateProjectAsunc(Project project)
        {

            var result = _unitOfWork.ProjectRepository.AddAsync(project);

            if (result.Exception != null)
            {
                throw new UserFriendlyException("Server Error");

            }
            await _unitOfWork.CommitAsync();

            return project;
        }

        //R Get all project
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var listProject = await _unitOfWork.ProjectRepository.GetAllAsync();
            if (listProject == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
            return listProject;

        }

        public async Task<Project> GetProjectByIdAsunc(int? id)
        {
            if (id == null)
            {
                throw new UserFriendlyException("Id is not valid");
            }

            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            if (project == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
            return project;
        }

        // U
        public async Task<Project> UpdateProjectAsync(Project project)
        {


            var result = _unitOfWork.ProjectRepository.UpdateAsync(project);

            if (result.Exception != null)
            {
                throw new UserFriendlyException("Server Error");
            }
            await _unitOfWork.CommitAsync();

            return project;
        }

        //D
        public async Task DeleteProjectAsync(Project project)
        {
            try
            {
                await _unitOfWork.ProjectRepository.DeleteAsync(project);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                throw new UserFriendlyException("Server Error");
            }
        }
    }
}
