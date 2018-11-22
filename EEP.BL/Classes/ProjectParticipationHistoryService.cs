using EEP.DAL.UnitOfWork;
using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public class ProjectParticipationHistoryService : IProjectParticipationHistoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProjectParticipationHistoryService()
        {
            _unitOfWork = new UnitOfWork();
        }

        //C create
        public async Task<ProjectParticipationHistory> CreateAsync(ProjectParticipationHistory projectParticipationHistory)
        {
            
  // projectParticipationHistory.User = await _unitOfWork.UserRepository.
            await _unitOfWork.ProjectParticipationHistory.AddAsync(projectParticipationHistory);

            await _unitOfWork.CommitAsync();

            return projectParticipationHistory;
        }

        //R Get all project
        public async Task<IEnumerable<ProjectParticipationHistory>> GetAllAsync()
        {
            var listHistory = await _unitOfWork.ProjectParticipationHistory.GetAllAsync();
            if (listHistory == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }

            return listHistory;
        }

        public async Task<ProjectParticipationHistory> GetByIdAsync(int id)
        {
            var project = await _unitOfWork.ProjectParticipationHistory.GetByIdAsync(id);

            if (project == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
            //     var outProject = new Project { ProjectId = project.ProjectId, Description = project.Description, Employees = project.Employees, ProjectName = project.ProjectName, ProjectStatus = project.ProjectStatus, EndProjectDate = project.EndProjectDate.ToShortDateString() }; 
            return project;
        }

        // U
        public async Task<ProjectParticipationHistory> UpdateAsync(ProjectParticipationHistory projectParticipationHistory)
        {

            var result = await _unitOfWork.ProjectParticipationHistory.UpdateAsync(projectParticipationHistory, projectParticipationHistory.ProjectId);

            if (result == null)
            {
                throw new UserFriendlyException(500, "Internal server Error");
            }

            await _unitOfWork.CommitAsync();

            return result;
        }

        //D
        public async Task DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.ProjectParticipationHistory.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw new UserFriendlyException(501, "Delete ex");
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
