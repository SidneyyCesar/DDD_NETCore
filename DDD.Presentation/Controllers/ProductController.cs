using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDD.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productService;
        private readonly ICustomerApplicationService _customerService;

        public ProductController(IProductApplicationService productService, ICustomerApplicationService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var productList = _productService.List();

            var listVm = new List<ProductVm>();

            foreach (var product in productList)
            {
                listVm.Add(new ProductVm()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Value = product.Value,
                    Avaliable = product.Avaliable,
                    CustomerId = product.CustomerId,
                    Customer = new CustomerVm()
                    {
                        Name = product.Customer.Name
                    }
                });
            }

            return View(listVm);
        }

        public ActionResult Details(int id)
        {
            var product = _productService.Select(id);
            var produtoViewModel = new ProductVm()
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                Avaliable = product.Avaliable,
                CustomerId = product.CustomerId
            };

            return View(produtoViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_customerService.List(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVm product)
        {
            var productDomain = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                Avaliable = product.Avaliable,
                CustomerId = product.CustomerId
            };

            _productService.Add(productDomain);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _productService.Select(id);
            var productVm = new ProductVm()
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                Avaliable = product.Avaliable,
                CustomerId = product.CustomerId
            };

            ViewBag.CustomerId = new SelectList(_customerService.List(), "Id", "Name", product.CustomerId);

            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVm productVm)
        {
            if (ModelState.IsValid)
            {
                var productDomain = new Product()
                {
                    Id = productVm.Id,
                    Name = productVm.Name,
                    Value = productVm.Value,
                    Avaliable = productVm.Avaliable,
                    CustomerId = productVm.CustomerId
                };

                _productService.Update(productDomain);

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_customerService.List(), "Id", "Name", productVm.CustomerId);
            return View(productVm);
        }

        public ActionResult Delete(int id)
        {
            var product = _productService.Select(id);
            var productVm = new ProductVm()
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                Avaliable = product.Avaliable,
                CustomerId = product.CustomerId
            };

            return View(productVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productService.Select(id);
            _productService.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
