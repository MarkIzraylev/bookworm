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
    
    public partial class bs_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bs_user()
        {
            this.bs_user_edition = new HashSet<bs_user_edition>();
        }
    
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
        public int id_role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public System.DateTime sign_up_date { get; set; }
        public System.DateTime date_of_birth { get; set; }
        public string passport { get; set; }
        public string phone { get; set; }
        public Nullable<int> font_size { get; set; }
        public string font_color { get; set; }
        public string background_color { get; set; }
    
        public virtual bs_role bs_role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bs_user_edition> bs_user_edition { get; set; }
    }
}
