using EEP.DAL.Interfaces;
using EEP.DAL.UnitOfWork;
using EEP.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EEP.BL.Classes
{
    public class ResourceManagerServvice
    {
        private readonly UnitOfWork _unitOfWork;

        public ResourceManagerServvice()
        {
            _unitOfWork = new UnitOfWork();
        }

        //C create
        public void CreateProject(Project project)
        {
            _unitOfWork.ProjectRepository.Add(project);
            _unitOfWork.Commit();
        }

        //R get all project
        public IEnumerable<Project> GetAllProjects(Project project)
        {
            return _unitOfWork.ProjectRepository.GetAll().ToList();
        }

        public Project GetProject(int id)
        {
            return _unitOfWork.ProjectRepository.GetByID(id);
        }

        // U
        public void UpdateProject(Project project)
        {
            _unitOfWork.ProjectRepository.Update(project);
            _unitOfWork.Commit();
        }

        //D
        public void DeleteProject(Project project)
        {
            _unitOfWork.ProjectRepository.Delete(project);
            _unitOfWork.Commit();
        }
    }
}
