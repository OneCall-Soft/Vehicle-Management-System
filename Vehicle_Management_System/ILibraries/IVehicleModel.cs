using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Management_System.Models
{
   public interface IVehicleModel
    {
        /// <summary>
        /// call this to get all plans submitted
        /// </summary>
        /// <returns>lists of orderplanmodal</returns>
        List<OrderPlanModal> GetOrderPlanModals();
        /// <summary>
        /// it takes model id and return respectively plan order
        /// </summary>
        /// <param name="mid">modal id</param>
        /// <returns>orderplanmodal </returns>
        OrderPlanModal GetOrderPlanModal(int mid);

        /// <summary>
        /// it updates plan quantity
        /// </summary>
        /// <param name="orderplan">orderplan</param>
        /// <returns>if plan updated return true then false</returns>
        bool UpdateOrderPlanModal(OrderPlanModal orderPlan);

        /// <summary>
        /// returns plan quantity of current month
        /// </summary>
        /// <param name=""></param>
        /// <returns>plan count</returns>
        int GetPlanQuantity_CurrentMonth(int id);


        /// <summary>
        /// returns dispatched item quantity of current month
        /// </summary>
        /// <param name=""></param>
        /// <returns>dipatched count</returns>
        int GetDispatchQuantity_CurrentMonth(int id);


        /// <summary>
        /// returns approved item quantity of current month
        /// </summary>
        /// <param name=""></param>
        /// <returns>approved count</returns>
        int GetApproveQuantity_CurrentMonth(int id);

        /// <summary>
        /// returns dispatched item quantity of current month of given id
        /// </summary>
        /// <param name="id">user login id</param>
        /// <returns>approved count</returns>
        int GetMyDispatched_CurrentMonth(int id);

        /// <summary>
        /// returns all orders  of current month of given id
        /// </summary>
        /// <param name="id">user login id</param>
        /// <returns>Vehicle plan details</returns>
        PlanDispatchModel GetPlanDetails(FetchPlanDatetime fetchPlanDatetime);


    }
}
