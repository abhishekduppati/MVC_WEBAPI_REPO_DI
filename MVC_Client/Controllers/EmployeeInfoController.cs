using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Client.Models;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVC_Client.Controllers
{
    public class EmployeeInfoController : Controller
    {
        HttpClient client;
        string URL = "http://localhost:55988/api/EmployeeInfoAPI";

        public EmployeeInfoController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("ApplicationException/Json"));
        }
        //Getting the details of Employees to perform Post
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(URL);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var Employees = JsonConvert.DeserializeObject<List<EmployeeInfo>>(responseData);
                return View(Employees);
            }
            return View("Error");
        }
        //Post Method
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeInfo employeeInfo)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(URL, employeeInfo);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        // Getting the details of Employees to perform PUT
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(URL + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<EmployeeInfo>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EmployeeInfo Emp)
        {

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URL + "/" + id, Emp);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        //Getting the details of Employees to perform Delete
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(URL + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Employee = JsonConvert.DeserializeObject<EmployeeInfo>(responseData);

                return View(Employee);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EmployeeInfo Emp)
        {

            HttpResponseMessage responseMessage = await client.DeleteAsync(URL + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");

        }
    }
}