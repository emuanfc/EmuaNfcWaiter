//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Entities.Concrete
{
	using Project.Core.Entities;
	using System;
    using System.Collections.Generic;
    
    public partial class NfcCompanyDeskAlarm 
	{
        public int Id { get; set; }
        public string AlarmTypeName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int DeskId { get; set; }
        public int CompanyId { get; set; }
    
        public virtual NfcCompany NfcCompany { get; set; }
        public virtual NfcDesk NfcDesk { get; set; }
    }
}
