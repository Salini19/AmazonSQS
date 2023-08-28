using CoreWebApi.Models;

namespace CoreWebApi.Services
{
    public interface IMethods
    {
        void AddEmp(Employee employee);
        void DeleteEmp(int empid);
        Employee GetEmployeeByID(int employeeId);
        List<Employee> GetAllEmployees();

        void UpdateEmployee(Employee employee);

    }
}
