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
    
    public partial class approve_quantities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public approve_quantities()
        {
            this.dispatch_quantities = new HashSet<dispatch_quantities>();
        }
    
        public int aqid { get; set; }
        public int approve_quantity { get; set; }
        public System.DateTime approve_datetime { get; set; }
        public int mid { get; set; }
        public int loginid { get; set; }
        public int pqid { get; set; }
    
        public virtual approve_quantities approve_quantities1 { get; set; }
        public virtual approve_quantities approve_quantities2 { get; set; }
        public virtual modal_details modal_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dispatch_quantities> dispatch_quantities { get; set; }
    }
}