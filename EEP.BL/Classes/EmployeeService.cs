using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEP.DAL.UnitOfWork;
using EEP.Entities;

namespace EEP.BL.Classes
{
    public class EmployeeService : ICRUDService<int, Employee>
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeeService()
        {
            _unitOfWork = new UnitOfWork();
        }

        //C create
        public async Task<Employee> CreateAsync(Employee employee)
        {
            var result = _unitOfWork.EmployeeRepository.AddAsync(employee);

            if (result.Exception != null)
            {
                throw new UserFriendlyException("Server Error");

            }
            await _unitOfWork.CommitAsync();

            return employee;
        }

        //R Get all project
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var listEmployee = await _unitOfWork.EmployeeRepository.GetAllAsync();
            if (listEmployee == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }

            return listEmployee;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
            return employee;
        }

        // U
        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var result = _unitOfWork.EmployeeRepository.UpdateAsync(employee);

            if (result.Exception != null)
            {
                throw new UserFriendlyException("Server Error");
            }
            await _unitOfWork.CommitAsync();

            return employee;
        }

        //D
        public async Task DeleteAsync(int id)
        {
            var result = _unitOfWork.EmployeeRepository.DeleteAsync(id);
            if (result == null)
            {
                throw new UserFriendlyException(404, "Not Found");
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
