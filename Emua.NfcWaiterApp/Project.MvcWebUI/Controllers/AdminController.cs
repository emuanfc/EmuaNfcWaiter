﻿using Project.Business.Abstract;
using Project.Entities.Concrete;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Project.MvcWebUI.Controllers
{
	public class AdminController : Controller
	{
		private dbEmuaNfcContext db = new dbEmuaNfcContext();

		private INfcCompanyBOL _nfcCompanyBol;
		private INfcCompanyDeskAlarmBOL _nfcCompanyDeskAlarmBol;
		private INfcDeskBOL _nfcDeskBol;
		private INfcDeskCategoryBOL _nfcDeskCategoryBol;
		private INfcTagBOL _nfcTagBol;
		private INfcMenuBOL _nfcMenuBol;

		public AdminController
			(INfcCompanyBOL nfcCompanyBol,
			INfcCompanyDeskAlarmBOL nfcCompanyDeskAlarmBol,
			INfcDeskBOL nfcDeskBol,
			INfcDeskCategoryBOL nfcDeskCategoryBol,
			INfcTagBOL nfcTagBol,
			INfcMenuBOL nfcMenuBol)
		{
			_nfcCompanyBol = nfcCompanyBol;
			_nfcCompanyDeskAlarmBol = nfcCompanyDeskAlarmBol;
			_nfcDeskBol = nfcDeskBol;
			_nfcDeskCategoryBol = nfcDeskCategoryBol;
			_nfcTagBol = nfcTagBol;
			_nfcMenuBol = nfcMenuBol;
		}

		// GET: Admin
		public ActionResult Index()
		{
			return View();
		}

		#region ŞİRKET(NFCCOMPANY) İŞLEMLERİ

		// GET: NfcCompany
		public ActionResult NfcCompanyIndex()
		{
			return View(_nfcCompanyBol.GetAll());
		}

		// GET: NfcCompany/Details/5
		public ActionResult NfcCompanyDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcCompany nfcCompany = _nfcCompanyBol.Get(id);
			if (nfcCompany == null)
			{
				return HttpNotFound();
			}
			return View(nfcCompany);
		}

		// GET: NfcCompany/Create
		public ActionResult NfcCompanyCreate()
		{
			return View();
		}

		// POST: NfcCompany/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcCompanyCreate([Bind(Include = "Id,Name,LogoUrl,WebSiteUrl,Adress,Mail,Phone,CreatedDate")] NfcCompany nfcCompany)
		{
			if (ModelState.IsValid)
			{
				_nfcCompanyBol.Add(nfcCompany);
				return RedirectToAction("Index");
			}

			return View(nfcCompany);
		}

		// GET: NfcCompany/Edit/5
		public ActionResult NfcCompanyEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcCompany nfcCompany = db.NfcCompany.Find(id);
			if (nfcCompany == null)
			{
				return HttpNotFound();
			}
			return View(nfcCompany);
		}

		// POST: NfcCompany/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcCompanyEdit([Bind(Include = "Id,Name,LogoUrl,WebSiteUrl,Adress,Mail,Phone,CreatedDate")] NfcCompany nfcCompany)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nfcCompany).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(nfcCompany);
		}

		// GET: NfcCompany/Delete/5
		public ActionResult NfcCompanyDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcCompany nfcCompany = db.NfcCompany.Find(id);
			if (nfcCompany == null)
			{
				return HttpNotFound();
			}
			return View(nfcCompany);
		}

		// POST: NfcCompany/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult NfcCompanyDeleteConfirmed(int id)
		{
			NfcCompany nfcCompany = db.NfcCompany.Find(id);
			db.NfcCompany.Remove(nfcCompany);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		#endregion ŞİRKET(NFCCOMPANY) İŞLEMLERİ

		#region MASA ALARMI (NFCCOMPANYDESKALARM) İŞLEMLERİ
		public ActionResult NfcCompanyDeskAlarmIndex()
		{
			var nfcCompanyDeskAlarm = db.NfcCompanyDeskAlarm.Include(n => n.NfcCompany).Include(n => n.NfcDesk);
			return View(nfcCompanyDeskAlarm);
		}

		// GET: NfcCompanyDeskAlarms/Details/5
		public ActionResult NfcCompanyDeskAlarmDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcCompanyDeskAlarm nfcCompanyDeskAlarm = db.NfcCompanyDeskAlarm.Find(id);
			if (nfcCompanyDeskAlarm == null)
			{
				return HttpNotFound();
			}
			return View(nfcCompanyDeskAlarm);
		}

		// GET: NfcCompanyDeskAlarms/Create
		public ActionResult NfcCompanyDeskAlarmCreate()
		{
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name");
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name");
			return View();
		}

		// POST: NfcCompanyDeskAlarms/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcCompanyDeskAlarmCreate([Bind(Include = "Id,AlarmTypeName,CreatedDate,DeskId,CompanyId")] NfcCompanyDeskAlarm nfcCompanyDeskAlarm)
		{
			if (ModelState.IsValid)
			{
				db.NfcCompanyDeskAlarm.Add(nfcCompanyDeskAlarm);
				db.SaveChanges();
				return RedirectToAction("NfcCompanyDeskAlarmIndex");
			}

			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcCompanyDeskAlarm.CompanyId);
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name", nfcCompanyDeskAlarm.DeskId);
			return View(nfcCompanyDeskAlarm);
		}

		// GET: NfcCompanyDeskAlarms/Edit/5
		public ActionResult NfcCompanyDeskAlarmEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcCompanyDeskAlarm nfcCompanyDeskAlarm = db.NfcCompanyDeskAlarm.Find(id);
			if (nfcCompanyDeskAlarm == null)
			{
				return HttpNotFound();
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcCompanyDeskAlarm.CompanyId);
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name", nfcCompanyDeskAlarm.DeskId);
			return View(nfcCompanyDeskAlarm);
		}

		// POST: NfcCompanyDeskAlarms/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcCompanyDeskAlarmEdit([Bind(Include = "Id,AlarmTypeName,CreatedDate,DeskId,CompanyId")] NfcCompanyDeskAlarm nfcCompanyDeskAlarm)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nfcCompanyDeskAlarm).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("NfcCompanyDeskAlarmIndex");
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcCompanyDeskAlarm.CompanyId);
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name", nfcCompanyDeskAlarm.DeskId);
			return View(nfcCompanyDeskAlarm);
		}

		// GET: NfcCompanyDeskAlarms/Delete/5
		public ActionResult NfcCompanyDeskAlarmDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcCompanyDeskAlarm nfcCompanyDeskAlarm = db.NfcCompanyDeskAlarm.Find(id);
			if (nfcCompanyDeskAlarm == null)
			{
				return HttpNotFound();
			}
			return View(nfcCompanyDeskAlarm);
		}

		// POST: NfcCompanyDeskAlarms/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult NfcCompanyDeskAlarmDeleteConfirmed(int id)
		{
			NfcCompanyDeskAlarm nfcCompanyDeskAlarm = db.NfcCompanyDeskAlarm.Find(id);
			db.NfcCompanyDeskAlarm.Remove(nfcCompanyDeskAlarm);
			db.SaveChanges();
			return RedirectToAction("NfcCompanyDeskAlarmIndex");
		}
		#endregion MASA ALARMI (NFCCOMPANYDESKALARM) İŞLEMLERİ

		#region MASA KATEGORİ(NFCDESKCATEGORY) İŞLEMLERİ
		// GET: NfcDeskCategory
		public ActionResult NfcDeskCategoryIndex()
		{
			var nfcDeskCategory = db.NfcDeskCategory.Include(n => n.NfcCompany);
			return View(nfcDeskCategory.ToListAsync());
		}

		// GET: NfcDeskCategory/Details/5
		public ActionResult NfcDeskCategoryDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDeskCategory nfcDeskCategory = db.NfcDeskCategory.Find(id);
			if (nfcDeskCategory == null)
			{
				return HttpNotFound();
			}
			return View(nfcDeskCategory);
		}

		// GET: NfcDeskCategory/Create
		public ActionResult NfcDeskCategoryCreate()
		{
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name");
			return View();
		}

		// POST: NfcDeskCategory/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcDeskCategoryCreate([Bind(Include = "Id,Name,OrderNumber,CreatedDate,CompanyId")] NfcDeskCategory nfcDeskCategory)
		{
			if (ModelState.IsValid)
			{
				db.NfcDeskCategory.Add(nfcDeskCategory);
				db.SaveChanges();
				return RedirectToAction("NfcDeskCategoryIndex");
			}

			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcDeskCategory.CompanyId);
			return View(nfcDeskCategory);
		}

		// GET: NfcDeskCategory/Edit/5
		public ActionResult NfcDeskCategoryEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDeskCategory nfcDeskCategory = db.NfcDeskCategory.Find(id);
			if (nfcDeskCategory == null)
			{
				return HttpNotFound();
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcDeskCategory.CompanyId);
			return View(nfcDeskCategory);
		}

		// POST: NfcDeskCategory/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcDeskCategoryEdit([Bind(Include = "Id,Name,OrderNumber,CreatedDate,CompanyId")] NfcDeskCategory nfcDeskCategory)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nfcDeskCategory).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("NfcDeskCategoryIndex");
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcDeskCategory.CompanyId);
			return View(nfcDeskCategory);
		}

		// GET: NfcDeskCategory/Delete/5
		public ActionResult NfcDeskCategoryDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDeskCategory nfcDeskCategory = db.NfcDeskCategory.Find(id);
			if (nfcDeskCategory == null)
			{
				return HttpNotFound();
			}
			return View(nfcDeskCategory);
		}

		// POST: NfcDeskCategory/Delete/5
		[HttpPost, ActionName("NfcDeskCategoryDelete")]
		[ValidateAntiForgeryToken]
		public ActionResult NfcDeskCategoryDeleteConfirmed(int id)
		{
			NfcDeskCategory nfcDeskCategory = db.NfcDeskCategory.Find(id);
			db.NfcDeskCategory.Remove(nfcDeskCategory);
			db.SaveChanges();
			return RedirectToAction("NfcDeskCategoryIndex");
		}
		#endregion MASA KATEGORİ(NFCDESKCATEGORY) İŞLEMLERİ

		#region MASA (NFCDESK) İŞLEMLERİ
		// GET: NfcDesk
		public ActionResult NfcDeskIndex()
		{
			var nfcDesk = db.NfcDesk.Include(n => n.NfcCompany).Include(n => n.NfcDeskCategory);
			return View(nfcDesk);
		}

		// GET: NfcDesk/Details/5
		public ActionResult NfcDeskDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDesk nfcDesk = db.NfcDesk.Find(id);
			if (nfcDesk == null)
			{
				return HttpNotFound();
			}
			return View(nfcDesk);
		}

		// GET: NfcDesk/Create
		public ActionResult NfcDeskCreate()
		{
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name");
			ViewBag.DeskCategoryId = new SelectList(db.NfcDeskCategory, "Id", "Name");
			return View();
		}

		// POST: NfcDesk/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcDeskCreate([Bind(Include = "Id,Name,CreatedDate,DeskCategoryId,CompanyId")] NfcDesk nfcDesk)
		{
			if (ModelState.IsValid)
			{
				db.NfcDesk.Add(nfcDesk);
				db.SaveChanges();
				return RedirectToAction("NfcDeskIndex");
			}

			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcDesk.CompanyId);
			ViewBag.DeskCategoryId = new SelectList(db.NfcDeskCategory, "Id", "Name", nfcDesk.DeskCategoryId);
			return View(nfcDesk);
		}

		// GET: NfcDesk/Edit/5
		public ActionResult NfcDeskEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDesk nfcDesk = db.NfcDesk.Find(id);
			if (nfcDesk == null)
			{
				return HttpNotFound();
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcDesk.CompanyId);
			ViewBag.DeskCategoryId = new SelectList(db.NfcDeskCategory, "Id", "Name", nfcDesk.DeskCategoryId);
			return View(nfcDesk);
		}

		// POST: NfcDesk/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcDeskEdit([Bind(Include = "Id,Name,CreatedDate,DeskCategoryId,CompanyId")] NfcDesk nfcDesk)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nfcDesk).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("NfcDeskIndex");
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcDesk.CompanyId);
			ViewBag.DeskCategoryId = new SelectList(db.NfcDeskCategory, "Id", "Name", nfcDesk.DeskCategoryId);
			return View(nfcDesk);
		}

		// GET: NfcDesk/Delete/5
		public ActionResult NfcDeskDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDesk nfcDesk = db.NfcDesk.Find(id);
			if (nfcDesk == null)
			{
				return HttpNotFound();
			}
			return View(nfcDesk);
		}

		// POST: NfcDesk/Delete/5
		[HttpPost, ActionName("NfcDeskDelete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			NfcDesk nfcDesk = db.NfcDesk.Find(id);
			db.NfcDesk.Remove(nfcDesk);
			db.SaveChanges();
			return RedirectToAction("NfcDeskIndex");
		}
		#endregion MASA (NFCDESK) İŞLEMLERİ

		#region MENU (NFCMENU) İŞLEMLERİ
		// GET: NfcMenu
		public ActionResult NfcMenuIndex()
		{
			var nfcMenu = db.NfcMenu.Include(n => n.NfcCompany);
			return View(nfcMenu);
		}

		// GET: NfcMenu/Details/5
		public ActionResult NfcMenuDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcMenu nfcMenu = db.NfcMenu.Find(id);
			if (nfcMenu == null)
			{
				return HttpNotFound();
			}
			return View(nfcMenu);
		}

		// GET: NfcMenu/Create
		public ActionResult NfcMenuCreate()
		{
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name");
			return View();
		}

		// POST: NfcMenu/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcMenuCreate([Bind(Include = "Id,Name,ImageUrl,Url,Title,OrderNumber,Status,CreatedDate,IsAdmin,CompanyId")] NfcMenu nfcMenu)
		{
			if (ModelState.IsValid)
			{
				db.NfcMenu.Add(nfcMenu);
				db.SaveChanges();
				return RedirectToAction("NfcMenuIndex");
			}

			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcMenu.CompanyId);
			return View(nfcMenu);
		}

		// GET: NfcMenu/Edit/5
		public ActionResult NfcMenuEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcMenu nfcMenu = db.NfcMenu.Find(id);
			if (nfcMenu == null)
			{
				return HttpNotFound();
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcMenu.CompanyId);
			return View(nfcMenu);
		}

		// POST: NfcMenu/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcMenuEdit([Bind(Include = "Id,Name,ImageUrl,Url,Title,OrderNumber,Status,CreatedDate,IsAdmin,CompanyId")] NfcMenu nfcMenu)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nfcMenu).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("NfcMenuIndex");
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcMenu.CompanyId);
			return View(nfcMenu);
		}

		// GET: NfcMenu/Delete/5
		public ActionResult NfcMenuDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcMenu nfcMenu = db.NfcMenu.Find(id);
			if (nfcMenu == null)
			{
				return HttpNotFound();
			}
			return View(nfcMenu);
		}

		// POST: NfcMenu/Delete/5
		[HttpPost, ActionName("NfcMenuDelete")]
		[ValidateAntiForgeryToken]
		public ActionResult NfcMenuDeleteConfirmed(int id)
		{
			NfcMenu nfcMenu = db.NfcMenu.Find(id);
			db.NfcMenu.Remove(nfcMenu);
			db.SaveChanges();
			return RedirectToAction("NfcMenuIndex");
		}
		#endregion MENU (NFCMENU) İŞLEMLERİ

		#region ETİKET (NFCTAG) İŞLEMLERİ
		// GET: NfcTag
		public ActionResult NfcTagIndex()
		{
			var nfcTag = db.NfcTag.Include(n => n.NfcCompany).Include(n => n.NfcDesk);
			return View(nfcTag);
		}

		// GET: NfcTag/Details/5
		public ActionResult NfcTagDetails(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcTag nfcTag = db.NfcTag.Find(id);
			if (nfcTag == null)
			{
				return HttpNotFound();
			}
			return View(nfcTag);
		}

		// GET: NfcTag/Create
		public ActionResult NfcTagCreate()
		{
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name");
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name");
			return View();
		}

		// POST: NfcTag/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcTagCreate([Bind(Include = "Id,Name,Code,CreatedDate,CompanyId,DeskId")] NfcTag nfcTag)
		{
			if (ModelState.IsValid)
			{
				db.NfcTag.Add(nfcTag);
				db.SaveChanges();
				return RedirectToAction("NfcTagIndex");
			}

			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcTag.CompanyId);
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name", nfcTag.DeskId);
			return View(nfcTag);
		}

		// GET: NfcTag/Edit/5
		public ActionResult NfcTagEdit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcTag nfcTag = db.NfcTag.Find(id);
			if (nfcTag == null)
			{
				return HttpNotFound();
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcTag.CompanyId);
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name", nfcTag.DeskId);
			return View(nfcTag);
		}

		// POST: NfcTag/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult NfcTagEdit([Bind(Include = "Id,Name,Code,CreatedDate,CompanyId,DeskId")] NfcTag nfcTag)
		{
			if (ModelState.IsValid)
			{
				db.Entry(nfcTag).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("NfcTagIndex");
			}
			ViewBag.CompanyId = new SelectList(db.NfcCompany, "Id", "Name", nfcTag.CompanyId);
			ViewBag.DeskId = new SelectList(db.NfcDesk, "Id", "Name", nfcTag.DeskId);
			return View(nfcTag);
		}

		// GET: NfcTag/Delete/5
		public ActionResult NfcTagDelete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcTag nfcTag = db.NfcTag.Find(id);
			if (nfcTag == null)
			{
				return HttpNotFound();
			}
			return View(nfcTag);
		}

		// POST: NfcTag/Delete/5
		[HttpPost, ActionName("NfcTagDelete")]
		[ValidateAntiForgeryToken]
		public ActionResult NfcTagDeleteConfirmed(int id)
		{
			NfcTag nfcTag = db.NfcTag.Find(id);
			db.NfcTag.Remove(nfcTag);
			db.SaveChanges();
			return RedirectToAction("NfcTagIndex");
		}
		#endregion ETİKET (NFCTAG) İŞLEMLERİ

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}