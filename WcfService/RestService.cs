using System.Collections.Generic;
using System.Linq;
using WcfService.Data;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestService" in both code and config file together.
    public class RestService : IRestService
    {
        public List<Employee> GetAllEmployeeDetails()
        {
            return EmployeeData.Instance.EmployeeList;
        }

        public Employee GetEmployee(int id)
        {
            var empList = EmployeeData.Instance.EmployeeList.Where(x => x.EmpId == id);

            return empList.First();
        }

        public void AddEmployee(Employee newEmp)
        {
            EmployeeData.Instance.Add(newEmp);
        }

        public void UpdateEmployee(Employee newEmp)
        {
            EmployeeData.Instance.Update(newEmp);
        }

        public void DeleteEmployee(string empId)
        {
            EmployeeData.Instance.Delete(System.Convert.ToInt32(empId));
        }
    }
}
