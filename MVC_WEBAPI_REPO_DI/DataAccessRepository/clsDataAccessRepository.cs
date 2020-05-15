using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_WEBAPI_REPO_DI.Models;
using Unity;

namespace MVC_WEBAPI_REPO_DI.DataAccessRepository
{
    public class clsDataAccessRepository: IDataAccessRepository<EmployeeInfo, int>
    {
        [Dependency]    //Eliminating need of creating entities using new keyword with the help of Dependency attribute over class.
        public ApplicationEntities db { get; set; }

        //Get All Employees
        public IEnumerable<EmployeeInfo> Get()
        {
            var a = db.EmployeeInfoes.ToList();
            return a;
        }
        //Get Employees based on id
        public EmployeeInfo Get(int id)
        {
            var a = db.EmployeeInfoes.Find(id);
            return a;
        }

        //Create Employees
        public void Post(EmployeeInfo entity)
        {
            db.EmployeeInfoes.Add(entity);
            db.SaveChanges();
        }

        //Update Employees
        public void Put(int id, EmployeeInfo entity)
        {
            var a = db.EmployeeInfoes.Find(id);
            if(a!=null)
            {
                a.EmpName = entity.EmpName;
                a.DeptName = entity.DeptName;
                a.Designation = entity.Designation;
                a.Salary = entity.Salary;
                db.SaveChanges();
            }
        }
        //Delete Employee
        public void Delete(int id)
        {
            var a = db.EmployeeInfoes.Find(id);
            if(a!=null)
            {
                db.EmployeeInfoes.Remove(a);
                db.SaveChanges();
            }
            
        }


    }
}