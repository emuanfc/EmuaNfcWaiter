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

	public partial class NfcTag
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public Nullable<System.DateTime> CreatedDate { get; set; }
		public int CompanyId { get; set; }
		public int DeskId { get; set; }

		public virtual NfcCompany NfcCompany { get; set; }
		public virtual NfcDesk NfcDesk { get; set; }
	}
}
