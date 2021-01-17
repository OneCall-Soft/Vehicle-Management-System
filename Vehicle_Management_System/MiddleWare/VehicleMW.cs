using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle_Management_System.Models
{
    public class VehicleMW : IVehicleModel
    {

        VMSEntities VMSEntities;
        private int PlanCounts = 0;
        private int DispatchPlanCounts = 0;
        private int ApprovePlanCounts = 0;
        private int MyPlanCounts = 0;
        private DateTime dtfrom;
        private DateTime dtto;
        private List<PlanDispatcDetails> planlist =null;


        public VehicleMW()
        {
            VMSEntities= new VMSEntities(); //Entity init
            dtfrom = Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-1 00:01:00");
            dtto = Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-30 00:01:00");
        }

        public OrderPlanModal GetOrderPlanModal(int mid)
        {
            try
            {
                OrderPlanModal planModal = (from m in VMSEntities.modal_details
                                            join p in VMSEntities.plan_quantities on m.mid equals p.mid
                                            where m.mid == mid
                                            select new { ID = m.mid, ModalName = m.modal_name, ModalColor = m.modal_color, Quantity = p.plan_quantity }).Cast<OrderPlanModal>().FirstOrDefault();
                return planModal;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public bool UpdateOrderPlanModal(OrderPlanModal orderPlan)
        {
            try
            {
                var plan = VMSEntities.plan_quantities.Where(x => x.pqid == orderPlan.ID).FirstOrDefault();
                if (plan != null)
                {
                    plan.plan_quantity = orderPlan.Quantity;
                }
                else
                {
                    VMSEntities.plan_quantities.Add(new plan_quantities { plan_quantity = orderPlan.Quantity, plan_datetime = DateTime.Now, mid = orderPlan.mid, loginid = orderPlan.loginid });
                }


                VMSEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<OrderPlanModal> GetOrderPlanModals()
        {
            try
            {
                List<modal_details> models = VMSEntities.modal_details.ToList();
                List<plan_quantities> plan_Quantities = VMSEntities.plan_quantities.ToList();

                List<OrderPlanModal> plans = new List<OrderPlanModal>();

                foreach (var item in models)
                {
                    var planQnty = plan_Quantities.Where(x => x.mid == item.mid).FirstOrDefault();
                    if (plan_Quantities.Count > 0 && planQnty != null)
                        plans.Add(new OrderPlanModal { mid = item.mid, ID = plan_Quantities.FirstOrDefault(x => x.mid == item.mid).pqid, ModalName = item.modal_name, ModalColor = item.modal_color, Quantity = Convert.ToInt32(plan_Quantities.FirstOrDefault(x => x.mid == item.mid).plan_quantity) });
                    else
                        plans.Add(new OrderPlanModal { mid = item.mid, ID = 0, ModalName = item.modal_name, ModalColor = item.modal_color, Quantity = 0 });
                }


                return plans;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetPlanQuantity_CurrentMonth(int id)
        {
            try
            {
                if (id == 0)
                {
                    PlanCounts = VMSEntities.plan_quantities.Where(x => x.plan_datetime> dtfrom && x.plan_datetime< dtto ).Count();
                }
                else
                {
                    PlanCounts = VMSEntities.plan_quantities.Where(x => x.plan_datetime > dtfrom && x.plan_datetime < dtto && x.loginid == id).Count();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
            return PlanCounts;
        }

        public int GetDispatchQuantity_CurrentMonth(int id)
        {
            try
            {
                if (id == 0)
                {
                    DispatchPlanCounts = VMSEntities.dispatch_quantities.Where(x => x.dispatch_datetime > dtfrom && x.dispatch_datetime < dtto).Sum(x => x.dispatch_quantity);
                }
                else
                {
                    DispatchPlanCounts = VMSEntities.dispatch_quantities.Where(x => x.dispatch_datetime > dtfrom && x.dispatch_datetime < dtto&&x.loginid==id).Sum(x => x.dispatch_quantity);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return DispatchPlanCounts;
        }

        public int GetApproveQuantity_CurrentMonth(int id)
        {
            try
            {
                if (id == 0)
                {
                    ApprovePlanCounts = VMSEntities.approve_quantities.Where(x => x.approve_datetime > dtfrom && x.approve_datetime < dtto).Sum(x=>x.approve_quantity);
                }
                else
                {
                    ApprovePlanCounts = VMSEntities.approve_quantities.Where(x => x.approve_datetime > dtfrom && x.approve_datetime < dtto&&x.loginid==id).Sum(x => x.approve_quantity);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return ApprovePlanCounts;
        }

        public int GetMyDispatched_CurrentMonth(int id)
        {
            try
            {
                MyPlanCounts = VMSEntities.dispatch_quantities.Where(x => x.dispatch_datetime > dtfrom && x.dispatch_datetime < dtto && x.loginid == id).Sum(x => x. dispatch_quantity);

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return MyPlanCounts;
        }

        public PlanDispatchModel GetPlanDetails(FetchPlanDatetime fetchPlanDatetime)
        {

            dtfrom = Convert.ToDateTime(fetchPlanDatetime.PlanYear.Split('-')[0] + "-" + fetchPlanDatetime.PlanYear.Split('-')[1] + "-1 00:01:00");

            dtto = Convert.ToDateTime(fetchPlanDatetime.PlanYear.Split('-')[0] + "-" + fetchPlanDatetime.PlanYear.Split('-')[1] + "-28 00:01:00");

            planlist = new List<PlanDispatcDetails>();
            try
            {
                var plans = VMSEntities.plan_quantities.ToList();
                var approved = VMSEntities.approve_quantities.ToList();
                var dispatch = VMSEntities.dispatch_quantities.ToList();
                var vechicles = VMSEntities.modal_details.ToList();

                foreach (var v in vechicles)
                {
                    planlist.Add(new PlanDispatcDetails {
                             ModalName=v.modal_name,
                             ModalColor=v.modal_color,
                             PlanQuantity=  plans.Where(x => x.plan_datetime> dtfrom && x.plan_datetime < dtto && x.loginid == fetchPlanDatetime.id&& x.mid==v.mid).Select(x=>x.plan_quantity).FirstOrDefault(),
                             ApproveQuantity= approved.Where(x => x.approve_datetime > dtfrom && x.approve_datetime< dtto && x.loginid == fetchPlanDatetime.id && x.mid == v.mid).Select(x => x.approve_quantity).FirstOrDefault(),
                             DispatchQuantity=dispatch.Where(x => x.dispatch_datetime > dtfrom && x.dispatch_datetime < dtto && x.loginid == fetchPlanDatetime.id && x.mid == v.mid).Select(x=>x.dispatch_quantity).FirstOrDefault(),
                             BalanceQuantity=0
                    });
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }

            return new PlanDispatchModel { FetchDetails=fetchPlanDatetime,PlanDispatchDetails=planlist};
        }
    }
}