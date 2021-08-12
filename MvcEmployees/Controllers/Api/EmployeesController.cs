using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcEmployees.Models;
using System.Web.Script.Serialization;
using System.Data;
using MvcEmployees.ViewModels;

namespace MvcEmployees.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private EmployeeDBEntities context;
        public EmployeesController()
        {
            context = new EmployeeDBEntities();
        }

        //Get /api/customers
        public IEnumerable<Employee> GetEmployees() {
            return context.Employees.ToList();
        }

        //Get /api/customers/1
        public Employee GetEmployee(int id) {
            var employee = context.Employees.SingleOrDefault(c => c.ID == id);
            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return employee;
        }

        //Post /api/employees
        [HttpPost]
        public Employee CreateEmployee(Employee employee) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        // Put /api/employee/1
        [HttpPut]
        public void UpdateCustomer(int id,Employee employee) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var employeeInDb = context.Employees.SingleOrDefault(c => c.ID == id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            employeeInDb.FirstName = employee.FirstName;
            employeeInDb.LastName = employee.LastName;
            /* ...... to be continued*/

            context.SaveChanges();
        }

        //DELETE api/employee/1
        [HttpDelete]
        public void DeleteEmployee(int id) {
            var employeeInDb = context.Employees.SingleOrDefault(c => c.ID == id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Employees.Remove(employeeInDb);
            context.SaveChanges();
        }

        //custom method names :
        [Route("api/Employees/GetEmpDep")]
        [HttpGet]
        public HttpResponseMessage GetEmpDep()
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string hh = "";
            List<EmpDepVM> listOfEmpDepVM = new List<EmpDepVM>();
            DataTable dTable = EmployeeAdapter.GetempwithDep();
            foreach (DataRow row in dTable.Rows)
            {
                //definition foreach iteration
                EmpDepVM aEDvm = new EmpDepVM();
                aEDvm.firstName = (string)row["FirstName"];
                aEDvm.lastName = (string)row["LastName"];
                aEDvm.departmentName = (string)row["DepartmentName"];
                listOfEmpDepVM.Add(aEDvm);
            }
           // hh = js.Serialize(listOfEmpDepVM);
            return Request.CreateResponse(HttpStatusCode.OK,
                         listOfEmpDepVM);//entities.Employees.ToList()


        }

        /*
         
        public class StudentController : ApiController
{
    public StudentController()
    {
    }

    public IHttpActionResult GetAllStudents(bool includeAddress = false)
    {
        IList<StudentViewModel> students = null;

        using (var ctx = new SchoolDBEntities())
        {
            students = ctx.Students.Include("StudentAddress").Select(s => new StudentViewModel()
            {
                Id = s.StudentID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Address = s.StudentAddress == null || includeAddress == false ? null : new AddressViewModel()
                {
                    StudentId = s.StudentAddress.StudentID,
                    Address1 = s.StudentAddress.Address1,
                    Address2 = s.StudentAddress.Address2,
                    City = s.StudentAddress.City,
                    State = s.StudentAddress.State
                }
            }).ToList<StudentViewModel>();
        }

        if (students == null)
        {
            return NotFound();
        }

        return Ok(students);
    }

    public IHttpActionResult GetStudentById(int id)
    {
        StudentViewModel student = null;

        using (var ctx = new SchoolDBEntities())
        {
            student = ctx.Students.Include("StudentAddress")
                .Where(s => s.StudentID == id)
                .Select(s => new StudentViewModel()
                {
                    Id = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).FirstOrDefault<StudentViewModel>();
        }

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    public IHttpActionResult GetAllStudents(string name)
    {
        IList<StudentViewModel> students = null;

        using (var ctx = new SchoolDBEntities())
        {
            students = ctx.Students.Include("StudentAddress")
                .Where(s => s.FirstName.ToLower() == name.ToLower())
                .Select(s => new StudentViewModel()
                {
                    Id = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.StudentAddress == null ? null : new AddressViewModel()
                    {
                        StudentId = s.StudentAddress.StudentID,
                        Address1 = s.StudentAddress.Address1,
                        Address2 = s.StudentAddress.Address2,
                        City = s.StudentAddress.City,
                        State = s.StudentAddress.State
                    }
                }).ToList<StudentViewModel>();
        }

        if (students.Count == 0)
        {
            return NotFound();
        }

        return Ok(students);
    }

    public IHttpActionResult GetAllStudentsInSameStandard(int standardId)
    {
        IList<StudentViewModel> students = null;

        using (var ctx = new SchoolDBEntities())
        {
            students = ctx.Students.Include("StudentAddress").Include("Standard").Where(s => s.StandardId == standardId)
                        .Select(s => new StudentViewModel()
                        {
                            Id = s.StudentID,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            Address = s.StudentAddress == null ? null : new AddressViewModel()
                            {
                                StudentId = s.StudentAddress.StudentID,
                                Address1 = s.StudentAddress.Address1,
                                Address2 = s.StudentAddress.Address2,
                                City = s.StudentAddress.City,
                                State = s.StudentAddress.State
                            },
                            Standard = new StandardViewModel()
                            {
                                StandardId = s.Standard.StandardId,
                                Name = s.Standard.StandardName
                            }
                        }).ToList<StudentViewModel>();
        }

        if (students.Count == 0)
        {
            return NotFound();
        }

        return Ok(students);
    }
}
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
          public IHttpActionResult PostNewStudent(StudentViewModel student)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data.");

        using (var ctx = new SchoolDBEntities())
        {
            ctx.Students.Add(new Student()
            {
                StudentID = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            });

            ctx.SaveChanges();
        }

        return Ok();
    }
         * 
         * 
         * 
         * 
         * 
         * 
         
          public IHttpActionResult Put(StudentViewModel student)
    {
        if (!ModelState.IsValid)
            return BadRequest("Not a valid model");

        using (var ctx = new SchoolDBEntities())
        {
            var existingStudent = ctx.Students.Where(s => s.StudentID == student.Id)
                                                    .FirstOrDefault<Student>();

            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;

                ctx.SaveChanges();
            }
            else
            {
                return NotFound();
            }
        }

        return Ok();
    }
         * 
         * 
         * 
         * 
         * 
         * 
         
         
         public IHttpActionResult Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Not a valid student id");

        using (var ctx = new SchoolDBEntities())
        {
            var student = ctx.Students
                .Where(s => s.StudentID == id)
                .FirstOrDefault();

            ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
        }

        return Ok();
    }
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         
         
         
         
         
         
         
         */


    }
}
