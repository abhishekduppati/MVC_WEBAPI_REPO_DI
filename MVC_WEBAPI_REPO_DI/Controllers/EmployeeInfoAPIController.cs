using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_WEBAPI_REPO_DI.DataAccessRepository;
using MVC_WEBAPI_REPO_DI.Models;
using System.Web.Http.Description;

namespace MVC_WEBAPI_REPO_DI.Controllers
{
    public class EmployeeInfoAPIController : ApiController
    {
        private IDataAccessRepository<EmployeeInfo, int> _repository;
        // Injecting DataAccessRepository using Constructor Injection
        public EmployeeInfoAPIController(IDataAccessRepository<EmployeeInfo, int> r)
        {
            _repository = r;
        }
        [ResponseType(typeof(EmployeeInfo))]
        public IEnumerable<EmployeeInfo> Get()
        {
            return _repository.Get();
        }
        [ResponseType(typeof(EmployeeInfo))]
        public IHttpActionResult Post(EmployeeInfo employeeInfo)
        {
            _repository.Post(employeeInfo);
            return Ok(employeeInfo);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, EmployeeInfo employeeInfo)
        {
            _repository.Put(id, employeeInfo);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            _repository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
