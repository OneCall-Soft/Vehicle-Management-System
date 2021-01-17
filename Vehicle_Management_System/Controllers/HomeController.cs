using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle_Management_System.Models;
using WebGrease.Css.Extensions;

namespace Vehicle_Management_System.Controllers
{
    public class HomeController : Controller
    {
        List<OrderPlanModal> orderPlans = null; // order plan list
        IVehicleModel _vehicleModel = null;

        public HomeController(IVehicleModel vehicle)
        {
            _vehicleModel = vehicle;
            orderPlans = new List<OrderPlanModal>();

        }

        public ActionResult Index()
        {
            if (!object.ReferenceEquals(Session["user"], null) && Session["user"].ToString() != "")
            {
                Session["currentMonthPlanCount"] = _vehicleModel.GetPlanQuantity_CurrentMonth(100);
                Session["currentMonthDispatchCount"] = _vehicleModel.GetDispatchQuantity_CurrentMonth(100);
                Session["currentMonthApproveCount"] = _vehicleModel.GetApproveQuantity_CurrentMonth(100);
                Session["currentMonthMyDispatchCount"] = _vehicleModel.GetMyDispatched_CurrentMonth(100);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult OrderPlan()
        {
            try
            {
                ViewBag.Message = "Your application description page.";
                orderPlans = _vehicleModel.GetOrderPlanModals();
                return View(orderPlans);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult OrderPlan(OrderPlanModal orderPlan)
        {
            try
            {
                ViewBag.Message = "Your application description page.";

                return View(orderPlan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public void GetPlan(order order)
        {
            try
            {
                var isupdated = _vehicleModel.UpdateOrderPlanModal(new OrderPlanModal { ID = Convert.ToInt32(order.id), mid = Convert.ToInt32(order.mid), Quantity = Convert.ToInt32(order.inputValue), loginid = Convert.ToInt32(Session["loginid"].ToString()) });

                RedirectToAction("OrderPlan");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult PlanVsDispatch()
        {
            Session["currentMonthPlanCount"] = _vehicleModel.GetPlanQuantity_CurrentMonth(100);
            Session["currentMonthDispatchCount"] = _vehicleModel.GetDispatchQuantity_CurrentMonth(100);
            Session["currentMonthApproveCount"] = _vehicleModel.GetApproveQuantity_CurrentMonth(100);
            Session["currentMonthMyDispatchCount"] = _vehicleModel.GetMyDispatched_CurrentMonth(100);
            ViewBag.Message = "Your application description page.";

            PlanDispatchModel orderPlan = new PlanDispatchModel();

            orderPlan.FetchDetails = new FetchPlanDatetime { id = 100, PlanYear = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() };

            PlanDispatchModel planDispatcDetails = _vehicleModel.GetPlanDetails(orderPlan.FetchDetails); //fetching plan details of reveived month

            orderPlan.PlanDispatchDetails = planDispatcDetails.PlanDispatchDetails;

            ViewBag.Message = "Your application description page.";
            return View(orderPlan);
            
        }

        [HttpPost]
        public ActionResult PlanVsDispatch(PlanDispatchModel orderPlan)
        {
            orderPlan.FetchDetails.id = 100;
            ViewBag.currentMonthPlanCount = _vehicleModel.GetPlanQuantity_CurrentMonth(100);
            PlanDispatchModel planDispatcDetails = _vehicleModel.GetPlanDetails(orderPlan.FetchDetails); //fetching plan details of reveived month

            orderPlan.PlanDispatchDetails = planDispatcDetails.PlanDispatchDetails;

            ViewBag.Message = "Your application description page.";
            return View(orderPlan);
        }


    }

    public class order
    {
        public string id { get; set; }
        public string mid { get; set; }
        public string inputValue { get; set; }
    }
}