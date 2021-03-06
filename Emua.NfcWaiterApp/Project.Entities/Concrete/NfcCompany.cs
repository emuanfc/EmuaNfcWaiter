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

	public partial class NfcCompany : IEntity
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public NfcCompany()
		{
			this.NfcCompanyDeskAlarm = new HashSet<NfcCompanyDeskAlarm>();
			this.NfcDesk = new HashSet<NfcDesk>();
			this.NfcDeskCategory = new HashSet<NfcDeskCategory>();
			this.NfcMenu = new HashSet<NfcMenu>();
			this.NfcTag = new HashSet<NfcTag>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string LogoUrl { get; set; }
		public string WebSiteUrl { get; set; }
		public string Adress { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public Nullable<System.DateTime> CreatedDate { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NfcCompanyDeskAlarm> NfcCompanyDeskAlarm { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NfcDesk> NfcDesk { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NfcDeskCategory> NfcDeskCategory { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NfcMenu> NfcMenu { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<NfcTag> NfcTag { get; set; }
	}
}
