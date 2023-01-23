using AutoMapper;
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
        private readonly IMapper _mapper;
        public CustomerController(ICustomerApplicationService _customerApplicationService, IMapper mapper)
        {
            this._customerApplicationService = _customerApplicationService;
            this._mapper = mapper;
        }
        
        public ActionResult Index()
        {
            var customerList = _customerApplicationService.List();

            var listVm = new List<CustomerVm>();

            foreach (var item in customerList)
            {
                var customerVm = _mapper.Map<CustomerVm>(item);
                listVm.Add(customerVm);
            }

            return View(listVm);
        }
        public ActionResult Details(int id)
        {
            var customer = _customerApplicationService.Select(id);
            var customerVm = _mapper.Map<CustomerVm>(customer);

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
                var customer = _mapper.Map<Customer>(customerVm);

                _customerApplicationService.Add(customer);

                return RedirectToAction("Index");
            }

            return View(customerVm);
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerApplicationService.Select(id);
            var customerVm = _mapper.Map<CustomerVm>(customer);

            return View(customerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerVm customerVm)
        {
            if (ModelState.IsValid)
            {
                var customerDomain = _mapper.Map<Customer>(customerVm);

                _customerApplicationService.Update(customerDomain);

                return RedirectToAction("Index");
            }

            return View(customerVm);
        }

        public ActionResult Delete(int id)
        {
            var customer = _customerApplicationService.Select(id);
            var customerVm = _mapper.Map<CustomerVm>(customer);

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
