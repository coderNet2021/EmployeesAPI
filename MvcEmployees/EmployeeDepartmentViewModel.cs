using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcEmployees.Models;

namespace MvcEmployees
{
    public class EmployeeDepartmentViewModel
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}