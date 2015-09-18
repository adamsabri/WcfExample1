using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WcfService.Data;

namespace WcfService
{
    [ServiceContract]
    public interface IRestService
    {
        [WebGet(UriTemplate = "Employee")]
        [OperationContract]
        List<Employee> GetAllEmployeeDetails();

        [WebGet(UriTemplate = "Employee?id={id}")]
        [OperationContract]
        Employee GetEmployee(int id);

        [WebInvoke(Method = "POST", UriTemplate = "EmployeePOST")]
        [OperationContract]
        void AddEmployee(Employee newEmp);
        
        [WebInvoke(Method = "PUT", UriTemplate = "EmployeePUT")]
        [OperationContract]
        void UpdateEmployee(Employee newEmp);

        [WebInvoke(Method = "DELETE", UriTemplate = "Employee/{empId}")]
        [OperationContract]
        void DeleteEmployee(string empId);
    }
}
