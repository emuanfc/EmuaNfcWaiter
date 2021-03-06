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

	public partial class NfcMenu:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool IsAdmin { get; set; }
        public int CompanyId { get; set; }
    
        public virtual NfcCompany NfcCompany { get; set; }
    }
}
