//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_ly_thue_sach.Rela_tables
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTacgia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTacgia()
        {
            this.tblSach = new HashSet<tblSach>();
        }
    
        public string Matacgia { get; set; }
        public string Tentacgia { get; set; }
        public System.DateTime Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Diachi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSach> tblSach { get; set; }
    }
}
