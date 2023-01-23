using AutoMapper;
using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDD.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productService;
        private readonly ICustomerApplicationService _customerService;
        private readonly IMapper _mapper;
        public ProductController(IProductApplicationService productService, ICustomerApplicationService customerService, IMapper mapper)
        {
            _productService = productService;
            _customerService = customerService;
            this._mapper = mapper;
        }

        public ActionResult Index()
        {
            var productList = _productService.List();

            var listVm = new List<ProductVm>();

            foreach (var product in productList)
            {
                var productVm = _mapper.Map<ProductVm>(product);
                listVm.Add(productVm);
            }

            return View(listVm);
        }

        public ActionResult Details(int id)
        {
            var product = _productService.Select(id);
            var productVm = _mapper.Map<ProductVm>(product);

            return View(productVm);
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
            var productDomain = _mapper.Map<Product>(product);

            _productService.Add(productDomain);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = _productService.Select(id);
            var productVm = _mapper.Map<ProductVm>(product);

            ViewBag.CustomerId = new SelectList(_customerService.List(), "Id", "Name", product.CustomerId);

            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVm productVm)
        {
            if (ModelState.IsValid)
            {
                var productDomain = _mapper.Map<Product>(productVm);

                _productService.Update(productDomain);

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_customerService.List(), "Id", "Name", productVm.CustomerId);
            return View(productVm);
        }

        public ActionResult Delete(int id)
        {
            var product = _productService.Select(id);
            var productVm = _mapper.Map<Product>(product);

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
