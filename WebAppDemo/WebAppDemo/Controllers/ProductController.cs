using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repo;

        public ProductController()
        {
            this.repo = new ProductRepository();
        }

        // GET: Student
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel emp)
        {
            if (ModelState.IsValid)
            {
                var count = repo.Add(emp);
                if (count > 0)
                {
                    return RedirectToAction("GetAll");
                }
            }
            return View();
        }

        [Authorize(Roles = "Manager,Customer")]
        public ActionResult GetAll()
        {
            var data = repo.GetAllData();
            return View(data);
        }

        [Authorize(Roles = "Manager,Customer")]
        public ActionResult Details(int id)
        {
            var data = repo.GetDetails(id);
            return View(data);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int id)
        {
            var data = repo.GetDetails(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, ProductModel emp)
        {
            if (ModelState.IsValid)
            {
                var count = repo.UpdateData(id, emp);

                return RedirectToAction("GetAll");

            }
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int id)
        {
            var data = repo.DeleteData(id);
            return RedirectToAction("GetAll");
        }
    }
}