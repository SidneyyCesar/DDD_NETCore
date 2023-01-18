using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerApplicationService _customerApplicationService;
        public CustomerController(ICustomerApplicationService _customerApplicationService)
        {
            this._customerApplicationService = _customerApplicationService;
        }
        
        public ActionResult Index()
        {
            var customerList = _customerApplicationService.List();

            var listVm = new List<CustomerVm>();

            foreach (var item in customerList)
            {
                listVm.Add(new CustomerVm()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    LastName = item.LastName,
                    Active = item.Active
                });
            }

            return View(listVm);
        }
        public ActionResult Details(int id)
        {
            var customer = _customerApplicationService.Select(id);
            var customerVm = new CustomerVm()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                LastName = customer.LastName,
                Active = customer.Active
            };

            return View(customerVm);
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
                    Id = customerVm.Id,
                    Name = customerVm.Name,
                    LastName = customerVm.LastName,
                    Email = customerVm.Email,
                    Active = customerVm.Active
                };

                _customerApplicationService.Add(customerDomain);

                return RedirectToAction("Index");
            }

            return View(customerVm);
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerApplicationService.Select(id);
            var customerVm = new CustomerVm()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                LastName = customer.LastName,
                Active = customer.Active
            };

            return View(customerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerVm customerVm)
        {
            if (ModelState.IsValid)
            {
                var customerDomain = new Customer()
                {
                    Id = customerVm.Id,
                    Name = customerVm.Name,
                    LastName = customerVm.LastName,
                    Email = customerVm.Email,
                    Active = customerVm.Active
                    
                };

                _customerApplicationService.Update(customerDomain);

                return RedirectToAction("Index");
            }

            return View(customerVm);
        }

        public ActionResult Delete(int id)
        {
            var customer = _customerApplicationService.Select(id);
            var customerVm = new CustomerVm()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                LastName = customer.LastName,
                Active = customer.Active
            };

            return View(customerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _customerApplicationService.Select(id);
            _customerApplicationService.Remove(customer);

            return RedirectToAction("Index");
        }
    }
}
