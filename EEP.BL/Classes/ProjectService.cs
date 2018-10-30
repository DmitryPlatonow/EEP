using EEP.DAL.Interfaces;
using EEP.DAL.UnitOfWork;
using EEP.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class ProjectService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProjectService()
        {
            _unitOfWork = new UnitOfWork();
        }

        //C create
        public async Task CreateProject(Project project)
        {
            try
            {
                await _unitOfWork.ProjectRepository.AddAsync(project);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                throw new UserFriendlyException("Server Error");
            }
        }

        //R Get all project
        public async Task<IEnumerable<Project>> GetAllAsync(Project project)
        {
            var listProject = await _unitOfWork.ProjectRepository.GetAllAsync();
            if (listProject == null)
            {
                return null;
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
        public async Task UpdateProjectAsync(Project project)
        {
            try
            {
                await _unitOfWork.ProjectRepository.UpdateAsync(project);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                throw new UserFriendlyException("Server Error");
            }

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
