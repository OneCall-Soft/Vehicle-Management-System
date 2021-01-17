using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle_Management_System.Models
{
    public class OrderPlanModal
    {
        public int ID { get; set; }
        public int mid { get; set; }
        public string ModalName { get; set; }
        public string ModalColor { get; set; }
        public int Quantity { get; set; }
        public int loginid { get; set; }

    }


    public class PlanDispatchModel {
        public FetchPlanDatetime FetchDetails { get; set; }
        public List<PlanDispatcDetails> PlanDispatchDetails { get; set; }
    }

    public class FetchPlanDatetime
    {

        [Display(Name = "Month")]
        [DataType(DataType.Text)]
        public string PlanMonth { get; set; }

        [Display(Name = "Year")]
        [DataType(DataType.Text)]
        public string PlanYear { get; set; }

        [Display(Name = "ID")]
        [DataType(DataType.Text)]
        public int id { get; set; }


    }

    public class PlanDispatcDetails
    {

        [Display(Name = "Modal Name")]
        [DataType(DataType.Text)]
        public string ModalName { get; set; }
        [Display(Name = "Modal Color")]
        [DataType(DataType.Text)]
        public string ModalColor { get; set; }
        [Display(Name = "Plan-Quantity")]
        [DataType(DataType.Text)]
        public int PlanQuantity { get; set; }
        [Display(Name = "Approve")]
        [DataType(DataType.Text)]
        public int ApproveQuantity { get; set; }
        [Display(Name = "Dispatch")]
        [DataType(DataType.Text)]
        public int DispatchQuantity { get; set; }
        [Display(Name = "Balance")]
        [DataType(DataType.Text)]
        public int BalanceQuantity { get; set; }

    }
}