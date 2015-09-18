using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IRestService
    {
        //[OperationContract]
        ////[WebGet(ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetProductList/")]
        ////[WebGet(UriTemplate = "{0}/GetProductList/")]
        //[WebGet]
        //List<Product> GetProductList();

        [WebGet(UriTemplate = "Employee", RequestFormat = WebMessageFormat.Xml)]
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

    [DataContract]
    public class Product
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public int Price { get; set; }
    }

    public class Products
    {
        private static readonly Products _instance = new Products();
        private static readonly List<Product> _products = new List<Product>
            {
                new Product{ProductId = 1, Name = "Prod 1", CategoryName = "Cat 1", Price = 10},
                new Product{ProductId = 2, Name = "Prod 2", CategoryName = "Cat 2", Price = 15}
            };

        public static Products Instance
        {
            get { return _instance; }
        }

        private Products()
        {
        }

        public List<Product> ProductList
        {
            get { return _products; }
        }

    }
}
