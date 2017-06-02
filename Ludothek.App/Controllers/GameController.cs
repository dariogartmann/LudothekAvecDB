using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Ludothek.Storage.Models;
using Ludothek.Storage.Repositories;

namespace Ludothek.App.Controllers
{
    public class GameController : Base.SecureBaseController
    {
        private readonly GameRepository m_gameRepository;
        private List<Filiale> m_branches;
        private List<Tarifkategorie> m_priceCategories;

        public GameController() {
            m_gameRepository = new GameRepository();
            BranchRepository branchRepo = new BranchRepository();
            PriceCategoryRepository priceRepo = new PriceCategoryRepository();
            m_branches = branchRepo.GetAllBranches();
            m_priceCategories = priceRepo.GetAllPriceCategories();

        }

        // GET: Game
        public ActionResult Index()
        {
            var games = m_gameRepository.GetAllGames();
            return View("Index", games);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            ViewBag.FK_Filiale = new SelectList(m_branches, "FilialKeyGUID", "Vereinsname");
            ViewBag.FK_Tarifkategorie = new SelectList(m_priceCategories, "TarifkategorieKeyGUID", "Bezeichnung");
            return View("Create");
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpielKeyGUID,EANNummer,Name,FK_Tarifkategorie,Spielkategorie,FK_Filiale")] Spiel game)
        {
            if (ModelState.IsValid)
            {
                game.SpielKeyGUID = Guid.NewGuid();
                m_gameRepository.Create(game);
                return RedirectToAction("Index");
            }

            ViewBag.FK_Filiale = new SelectList(m_branches, "FilialKeyGUID", "Vereinsname", game.FK_Filiale);
            ViewBag.FK_Tarifkategorie = new SelectList(m_priceCategories, "TarifkategorieKeyGUID", "Bezeichnung", game.FK_Tarifkategorie);
            return View("Create", game);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spiel game = m_gameRepository.GetGame(id.Value);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Filiale = new SelectList(m_branches, "FilialKeyGUID", "Vereinsname", game.FK_Filiale);
            ViewBag.FK_Tarifkategorie = new SelectList(m_priceCategories, "TarifkategorieKeyGUID", "Bezeichnung", game.FK_Tarifkategorie);
            return View("Edit", game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpielKeyGUID,EANNummer,Name,FK_Tarifkategorie,Spielkategorie,FK_Filiale")] Spiel spiel)
        {
            if (ModelState.IsValid)
            {
                m_gameRepository.Update(spiel);
                return RedirectToAction("Index");
            }
            ViewBag.FK_Filiale = new SelectList(m_branches, "FilialKeyGUID", "Vereinsname", spiel.FK_Filiale);
            ViewBag.FK_Tarifkategorie = new SelectList(m_priceCategories, "TarifkategorieKeyGUID", "Bezeichnung", spiel.FK_Tarifkategorie);
            return View("Edit", spiel);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spiel spiel = m_gameRepository.GetGame(id.Value);
            if (spiel == null)
            {
                return HttpNotFound();
            }
            return View(spiel);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            m_gameRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
