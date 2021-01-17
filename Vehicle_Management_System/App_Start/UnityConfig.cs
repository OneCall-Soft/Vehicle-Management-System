using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Vehicle_Management_System.Models;

namespace Vehicle_Management_System
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<ILogin, Logins>();
             container.RegisterType<IVehicleModel, VehicleMW>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}