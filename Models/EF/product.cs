//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace final_exam_app.Models.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.order_ = new HashSet<order_>();
        }
    
        public int product_id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<int> brand_id { get; set; }
        public byte[] pic { get; set; }
        public string detail { get; set; }
        public Nullable<int> size { get; set; }
        public string color { get; set; }
        public string material { get; set; }
    
        public virtual brand brand { get; set; }
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_> order_ { get; set; }
    }
}
