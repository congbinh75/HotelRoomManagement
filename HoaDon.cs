//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLPKS
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string SDT { get; set; }
        public Nullable<double> ThanhTien { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}