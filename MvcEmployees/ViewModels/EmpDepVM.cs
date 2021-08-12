using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEmployees.ViewModels
{
    public class EmpDepVM
    {
        public int empId { get; set; }
        public int depId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string departmentName { get; set; }

        //constructeur 
        public EmpDepVM()
        {
            this.empId = 0;
            this.depId = 0;
            this.firstName = "";
            this.lastName = "";
            this.departmentName = "";
        }
    }
}