using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework27.Context;
using Microsoft.EntityFrameworkCore;
using Homework27.Models;
using System.Threading;

namespace Homework27.Controllers {
    public class ProductController : Controller {
        private readonly MVCContext _context;
        public ProductController(MVCContext context) {
            _context = context;
        }

        public async Task<ActionResult> IndexAsync() {
            var result = new List<Models.Product>();
            
            result = await _context.Products.ToListAsync();

            return View(result);
        }


        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, CancellationToken token) {
            if(!ModelState.IsValid)
                return View(product);

            _context.Products.Add(product);
            await _context.SaveChangesAsync(token);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ID) {
            var product = await _context.Products.FindAsync(ID);

            if(product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product _product) {
            if(!ModelState.IsValid) 
                return View(_product);

            var product = await _context.Products.FindAsync(_product.ID);

            if(_product == null) 
                return RedirectToAction("Index");

            product.Cost = _product.Cost;
            product.Name = _product.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int ID) {
            Product product = await _context.Products.FindAsync(ID);

            if(product == null)
                return RedirectToAction("Index");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
