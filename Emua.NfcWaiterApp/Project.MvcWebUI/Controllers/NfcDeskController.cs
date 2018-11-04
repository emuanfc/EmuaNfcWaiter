﻿using Project.Business.Abstract;
using Project.Entities.Concrete;
using System;
using System.Net;
using System.Web.Mvc;

namespace Project.MvcWebUI.Controllers
{
	public class NfcDeskController : Controller
	{
		dbEmuaNfcContext db = new dbEmuaNfcContext();
		private INfcDeskBOL _nfcDeskBol;
		private INfcCompanyBOL _nfcCompanyBol;
		private INfcDeskCategoryBOL _nfcDeskCategoryBol;
		private INfcCompanyDeskAlarmBOL _nfcCompanyDeskAlarmBol;

		public NfcDeskController(INfcDeskBOL nfcDeskBol, INfcCompanyBOL nfcCompanyBol, INfcDeskCategoryBOL nfcDeskCategoryBol, INfcCompanyDeskAlarmBOL nfcCompanyDeskAlarmBol)
		{
			_nfcCompanyBol = nfcCompanyBol;
			_nfcDeskBol = nfcDeskBol;
			_nfcDeskCategoryBol = nfcDeskCategoryBol;
			_nfcCompanyDeskAlarmBol = nfcCompanyDeskAlarmBol;
		}

		// GET: NfcDesk
		public ActionResult Index()
		{
			//login esnasına veya başka bir durumda şirket Id bilgisi dinamik olarak dolduruluacak.
			int? companyId = 1;
			var nfcDeskList = _nfcDeskBol.GetAllInclude(companyId);
			return View(nfcDeskList);
		}

		[HttpGet]
		public ActionResult Index(int deskId, int companyId, string alarmTypeName)
		{
			//login esnasına veya başka bir durumda şirket Id bilgisi dinamik olarak dolduruluacak.
			NfcCompanyDeskAlarm entity = new NfcCompanyDeskAlarm();
			entity.CompanyId = companyId;
			entity.DeskId = deskId;
			entity.AlarmTypeName = alarmTypeName;
			entity.CreatedDate = DateTime.Now;
			_nfcCompanyDeskAlarmBol.Add(entity);
			return View();
		}

		// GET: NfcDesk/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDesk nfcDesk = _nfcDeskBol.GetInclude(id);
			if (nfcDesk == null)
			{
				return HttpNotFound();
			}
			return View(nfcDesk);
		}

		// GET: NfcDesk/Create
		public ActionResult Create()
		{
			ViewBag.CompanyId = new SelectList(_nfcCompanyBol.GetAll(), "Id", "Name");
			ViewBag.DeskCategoryId = new SelectList(_nfcDeskCategoryBol.GetAll(), "Id", "Name");
			return View();
		}

		// POST: NfcDesk/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,CreatedDate,DeskCategoryId,CompanyId")] NfcDesk nfcDesk)
		{
			if (ModelState.IsValid)
			{
				_nfcDeskBol.Add(nfcDesk);
				return RedirectToAction("Index");
			}

			ViewBag.CompanyId = new SelectList(_nfcCompanyBol.GetAll(), "Id", "Name", nfcDesk.CompanyId);
			ViewBag.DeskCategoryId = new SelectList(_nfcDeskCategoryBol.GetAll(), "Id", "Name", nfcDesk.DeskCategoryId);
			return View(nfcDesk);
		}

		// GET: NfcDesk/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDesk nfcDesk = _nfcDeskBol.Get(id);
			if (nfcDesk == null)
			{
				return HttpNotFound();
			}
			ViewBag.CompanyId = new SelectList(_nfcCompanyBol.GetAll(), "Id", "Name", nfcDesk.CompanyId);
			ViewBag.DeskCategoryId = new SelectList(_nfcDeskCategoryBol.GetAll(), "Id", "Name", nfcDesk.DeskCategoryId);
			return View(nfcDesk);
		}

		// POST: NfcDesk/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,CreatedDate,DeskCategoryId,CompanyId")] NfcDesk nfcDesk)
		{
			if (ModelState.IsValid)
			{
				_nfcDeskBol.Update(nfcDesk);
				return RedirectToAction("Index");
			}
			ViewBag.CompanyId = new SelectList(_nfcCompanyBol.GetAll(), "Id", "Name", nfcDesk.CompanyId);
			ViewBag.DeskCategoryId = new SelectList(_nfcDeskCategoryBol.GetAll(), "Id", "Name", nfcDesk.DeskCategoryId);
			return View(nfcDesk);
		}

		// GET: NfcDesk/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			NfcDesk nfcDesk = _nfcDeskBol.Get(id);
			if (nfcDesk == null)
			{
				return HttpNotFound();
			}
			return View(nfcDesk);
		}

		// POST: NfcDesk/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			NfcDesk nfcDesk = _nfcDeskBol.Get(id);
			_nfcDeskBol.Delete(nfcDesk);
			return RedirectToAction("Index");
		}

		//protected override void Dispose(bool disposing)
		//      {
		//          if (disposing)
		//          {
		//              db.Dispose();
		//          }
		//          base.Dispose(disposing);
		//      }
	}
}
