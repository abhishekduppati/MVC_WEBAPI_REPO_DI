using System.Web.Http;
using Unity;
using Unity.WebApi;
using MVC_WEBAPI_REPO_DI.DataAccessRepository;
using MVC_WEBAPI_REPO_DI.Models;
namespace MVC_WEBAPI_REPO_DI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IDataAccessRepository<EmployeeInfo,int>, clsDataAccessRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}