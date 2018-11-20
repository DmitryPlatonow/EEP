using EEP.DAL.Interfaces;
using EEP.DAL.UnitOfWork;
using EEP.Entities;
using System;
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
        public async Task<Project> CreateAsync(Project project)
        {
             await _unitOfWork.ProjectRepository.AddAsync(project);

      
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

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(id);

            if (project == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
       //     var outProject = new Project { ProjectId = project.ProjectId, Description = project.Description, Employees = project.Employees, ProjectName = project.ProjectName, ProjectStatus = project.ProjectStatus, EndProjectDate = project.EndProjectDate.ToShortDateString() }; 
            return project;
        }

        // U
        public async Task<Project> UpdateAsync(Project project)
        {
            
            await _unitOfWork.ProjectRepository.UpdateAsync(project, project.ProjectId);

       
            await _unitOfWork.CommitAsync();

            return project;
        }
        
        //D
        public async Task DeleteAsync(int id)
        {
            var result =  _unitOfWork.ProjectRepository.DeleteAsync(id);
            if (result == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
            await _unitOfWork.CommitAsync();
        }

        
    }
}
