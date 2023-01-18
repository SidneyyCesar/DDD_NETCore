using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        
        // GET: CustomerController
        public ActionResult Index()
        {
            var customerList = _customerRepository.List();

            var listVm = new List<CustomerVm>();

            foreach (var item in customerList)
            {
                listVm.Add(new CustomerVm()
                {
                    Name = item.Name,
                    Email = item.Email,
                    LastName = item.LastName
                });
            }

            return View(listVm);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CustomerVm customerVm)
        {
            if (ModelState.IsValid)
            {
                var customerDomain = new Customer()
                {
                    Name = customerVm.Name,
                    LastName = customerVm.LastName,
                    Email = customerVm.Email
                };

                _customerRepository.Add(customerDomain);

                return RedirectToAction("Index");
            }

            return View(customerVm);
        }
        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
