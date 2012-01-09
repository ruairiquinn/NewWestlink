using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWestlink.Models;

namespace NewWestlink.Controllers
{   
    public class ReferenceDatasController : Controller
    {
		private readonly IReferenceDataRepository referencedataRepository;

        public ReferenceDatasController(IReferenceDataRepository referencedataRepository)
        {
			this.referencedataRepository = referencedataRepository;
        }

        //
        // GET: /ReferenceDatas/

        public ViewResult Index()
        {
            return View(referencedataRepository.All);
        }

        //
        // GET: /ReferenceDatas/Details/5

        public ViewResult Details(string id)
        {
            return View(referencedataRepository.Find(id));
        }

        //
        // GET: /ReferenceDatas/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ReferenceDatas/Create

        [HttpPost]
        public ActionResult Create(ReferenceData referencedata)
        {
            if (ModelState.IsValid) {
                referencedataRepository.InsertOrUpdate(referencedata);
                referencedataRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ReferenceDatas/Edit/5
 
        public ActionResult Edit(string id)
        {
             return View(referencedataRepository.Find(id));
        }

        //
        // POST: /ReferenceDatas/Edit/5

        [HttpPost]
        public ActionResult Edit(ReferenceData referencedata)
        {
            if (ModelState.IsValid) {
                referencedataRepository.InsertOrUpdate(referencedata);
                referencedataRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ReferenceDatas/Delete/5
 
        public ActionResult Delete(string id)
        {
            return View(referencedataRepository.Find(id));
        }

        //
        // POST: /ReferenceDatas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            referencedataRepository.Delete(id);
            referencedataRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

