//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vehicle_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class dispatch_quantities
    {
        public int dqid { get; set; }
        public int dispatch_quantity { get; set; }
        public System.DateTime dispatch_datetime { get; set; }
        public int mid { get; set; }
        public int loginid { get; set; }
        public int aqid { get; set; }
    
        public virtual approve_quantities approve_quantities { get; set; }
        public virtual modal_details modal_details { get; set; }
    }
}
