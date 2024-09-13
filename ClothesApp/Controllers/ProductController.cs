using ClothesApp.Db;
using ClothesApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothesApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly DBContext OdbContext;
        public ProductController(DBContext OdbContext)
        {
            this.OdbContext = OdbContext;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            var AllData = OdbContext.Products.ToList();
            return View(AllData);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                OdbContext.Products.Add(collection);
                OdbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var fId = OdbContext.Products.FirstOrDefault(x => x.ProductID == id); 
            if(fId != null)
            {
                return View(fId);

            }
            else
            {
                return NotFound("Not Found");            }
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product collection)
        {
            try
            {
                OdbContext.Products.Update(collection);
                OdbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound("Invalid Data ❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌");
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int Id)
        {
            var findId = OdbContext.Products.FirstOrDefault(id => id.ProductID == Id);
            if (findId == null)
            {
                return NotFound("Not found Id");
            }
            else
            {
                return View(findId);

            }
        }




        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, Product collection)
        {
            try
            {
                var findId = OdbContext.Products.FirstOrDefault(id => id.ProductID == Id);
                if(findId != null)
                {
                    OdbContext.Products.Remove(findId);
                    OdbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound("Not Found Id");
                }
               
            }
            catch
            {
                return View();
            }
        }
    }
}
