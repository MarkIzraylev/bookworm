//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace book_store
{
    using System;
    using System.Collections.Generic;
    
    public partial class bs_edition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bs_edition()
        {
            this.bs_user_edition = new HashSet<bs_user_edition>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int id_publisher { get; set; }
        public int id_author { get; set; }
        public int id_release_form { get; set; }
        public System.DateTime release_date { get; set; }
        public string text { get; set; }
        public string cover { get; set; }
        public Nullable<decimal> rating { get; set; }
    
        public virtual bs_author bs_author { get; set; }
        public virtual bs_publisher bs_publisher { get; set; }
        public virtual bs_release_form bs_release_form { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bs_user_edition> bs_user_edition { get; set; }
    }
}
