using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStore.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository repository;

        
        public CarsController(ICarRepository repo)
        {
            repository = repo;
            
        }

        public ViewResult List()
        {
            return View(repository.Cars);
        }

    
       
        public ActionResult Details(int id)
        {
            //var item = repository.Cars.FirstOrDefault(x => x.Id == id);
            var item = repository.GetById(id);
            return View(item);
        }

       
        public ActionResult Create()
        {

            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Car car)
        {
            try
            {
                repository.Create(car);
                
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            return View(repository.GetById(id));
        }

       
        [HttpPost]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                repository.Edit(id, car);
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            return View(repository.GetById(id));
        }

        
        [HttpPost]
        public ActionResult Delete(int id, Car car)
        {
            try
            {
                repository.Delete(id);
                
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

    }
}