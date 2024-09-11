using ClothesApp.Db;
using ClothesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ClothesApp.Controllers
{
    public class DashHomeController : Controller
    {
        private readonly DBContext oDBContext;
        public DashHomeController(DBContext oDBContext)
        {
            this.oDBContext = oDBContext;
        }
        public IActionResult Index()
        {

            // Fetch data from the database context
            var salesData = oDBContext.Sales.ToList();
            var productData = oDBContext.Products.ToList();
            //var orderData = oDBContext.Orders.ToList();
            //var returnData = oDBContext.Returns.ToList();

            // Calculate sums
            var sumSales = salesData.Sum(s => s.Quantity);
            // var orderSum = orderData.Sum(o => o.Quantity);
            var productCount = productData.Count;  // Count products
                                                   //   var returnSum = returnData.Sum(r => r.Quantity);

            // Create a new instance of DashHome with calculated values
            var Dash = new DashHome()
            {
                SalesSum = sumSales,
                ProducSum = productCount,
                //ReturnSum = returnSum,
                //OrderSum = orderSum,
                OSales = salesData
            };

            // Return the Dash model to the view
            return View(Dash);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sale prod)
        {
            try
            {
                oDBContext.Sales.Add(prod);
                oDBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("Invalid Data ❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌❌");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var SalesId = oDBContext.Sales.FirstOrDefault(s => s.ProductID == id);
            if (SalesId == null)
            {
                return NotFound("Id Not Found");
            }
            else
            {
                return View(SalesId);
            }
        }

        [HttpPost]
        public IActionResult Edit(Sale prod)
        {

            oDBContext.Sales.Update(prod);
            oDBContext.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Detailes(int Id)
        {
            var FId = oDBContext.Sales.FirstOrDefault(i => i.ProductID == Id);
            if (FId == null)
            {
                return NotFound("Not Found Id");
            }
            else
            {
                return View(FId);

            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sale = oDBContext.Sales.FirstOrDefault(i => i.SaleID == id);
            if (sale == null)
            {
                return NotFound("Not Found Id");
            }

            return View(sale);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var sale = oDBContext.Sales.FirstOrDefault(i => i.SaleID == id);
            if (sale == null)
            {
                return NotFound("Sale not found");
            }

            oDBContext.Sales.Remove(sale);
            oDBContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}