using Domain.Abstract;
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

    }
}