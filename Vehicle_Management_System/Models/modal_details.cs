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
    
    public partial class modal_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modal_details()
        {
            this.approve_quantities = new HashSet<approve_quantities>();
            this.dispatch_quantities = new HashSet<dispatch_quantities>();
            this.plan_quantities = new HashSet<plan_quantities>();
        }
    
        public int mid { get; set; }
        public string modal_name { get; set; }
        public string modal_color { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<approve_quantities> approve_quantities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dispatch_quantities> dispatch_quantities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plan_quantities> plan_quantities { get; set; }
    }
}