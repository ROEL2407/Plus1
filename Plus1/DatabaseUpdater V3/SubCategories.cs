//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseUpdater_V3
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubCategories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubCategories()
        {
            this.SubSubCategories = new HashSet<SubSubCategories>();
        }
    
        public string Name { get; set; }
        public string Parent_Name { get; set; }
    
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubSubCategories> SubSubCategories { get; set; }
    }
}