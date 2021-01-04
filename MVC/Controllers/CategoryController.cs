using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService ImpCat;

        public CategoryController(ICategoryService _ImpCat)
        {
            ImpCat = _ImpCat;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View(ImpCat.GetAllCategoty());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Cat = ImpCat.GetCategoryById(id);
            if (Cat  != null)
            {
                return View(Cat);
            }
            else
            {
                return HttpNotFound();
            }

        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel CatModel)
        {
            try
            {
                ImpCat.CreateCategory(CatModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Cat = ImpCat.GetCategoryById(id);
            if (Cat != null)
            {
                return View(Cat);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryModel CatModel)
        {
            try
            {
                var categoryModelFromImpCat = ImpCat.GetCategoryById(id);
                if (categoryModelFromImpCat == null)
                {
                    return HttpNotFound();
                }
                ImpCat.UpdateCategory(CatModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
