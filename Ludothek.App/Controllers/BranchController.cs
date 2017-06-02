using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Ludothek.Storage.Models;
using Ludothek.Storage.Repositories;

namespace Ludothek.App.Controllers
{
    public class BranchController : Base.SecureBaseController
    {
        private readonly BranchRepository m_branchRepository;
        private readonly FederationRepository m_federationRepository;
        private readonly List<Verband> m_federations;

        public BranchController() {
            m_branchRepository = new BranchRepository();
            m_federationRepository = new FederationRepository();

            m_federations = m_federationRepository.GetAllFederations();
        }

        // GET: Branch
        public ActionResult Index()
        {
            var branches = m_branchRepository.GetAllBranches();
            return View(branches);
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            ViewBag.FK_Verband = new SelectList(m_federations, "VerbandKeyGUID", "Name");
            return View();
        }

        // POST: Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilialKeyGUID,Vereinsname,Strasse,Ort,PLZ,FK_Verband")] Filiale filiale)
        {
            if (ModelState.IsValid)
            {
                filiale.FilialKeyGUID = Guid.NewGuid();
                m_branchRepository.Create(filiale);
                return RedirectToAction("Index");
            }
            ViewBag.FK_Verband = new SelectList(m_federations, "VerbandKeyGUID", "Name", filiale.FK_Verband);
            return View(filiale);
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filiale filiale = m_branchRepository.GetBranch(id.Value);
            if (filiale == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Verband = new SelectList(m_federations, "VerbandKeyGUID", "Name", filiale.FK_Verband);
            return View(filiale);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilialKeyGUID,Vereinsname,Strasse,Ort,PLZ,FK_Verband")] Filiale filiale)
        {
            if (ModelState.IsValid)
            {
                m_branchRepository.Update(filiale);
                return RedirectToAction("Index");
            }

            ViewBag.FK_Verband = new SelectList(m_federations, "VerbandKeyGUID", "Name", filiale.FK_Verband);
            return View(filiale);
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filiale filiale = m_branchRepository.GetBranch(id.Value);
            if (filiale == null)
            {
                return HttpNotFound();
            }
            return View(filiale);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            m_branchRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
