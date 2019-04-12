using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using CarStore.Controllers;
using CarStore.Infrastructure;
using CarStore.Models;
using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;

namespace CarStore.Tests.Controllers
{

    [TestClass]
    public class CarsControllerTest
    {
        private StandardKernel _kernel;
        private CarsController _controller;
      
       

        public CarsControllerTest()
        {
            NinjectModule registrations = new NinjectСarDependencyResolver();
            _kernel = new StandardKernel(registrations);
            _controller = _kernel.Get<CarsController>();
        }
               
        [TestMethod]
        public void ListViewResultNotNull()
        {
                        
            ViewResult result = _controller.List() as ViewResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ListTypeCheck()
        {
            ViewResult result = _controller.List();
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<Car>));

        }
       
               
        [TestMethod]
        public void EditTest()
        {
            var guid = Guid.NewGuid().ToString();
            var repository = _kernel.Get<ICarRepository>();
            var editing = repository.Cars.FirstOrDefault();
            if (editing != null)
            {
                var editingId = editing.Id;
                var updatedEntity = new Car()
                {
                    Mark = guid,
                    Model = editing.Model,
                    Price = editing.Price
                };
                _controller.Edit(editingId, updatedEntity);
                var afterEditState = repository.GetById(editingId);
                Assert.AreEqual(updatedEntity.Model, afterEditState.Model);
                Assert.AreEqual(updatedEntity.Mark, afterEditState.Mark);
                Assert.AreEqual(updatedEntity.Price, afterEditState.Price);
            }

        }

        [TestMethod]
        public void DeleteTest()
        {
            var repository = _kernel.Get<ICarRepository>();
            var delete = repository.Cars.FirstOrDefault();
            if (delete != null)
            {
                var deleteId = delete.Id;
                var updatedEntity = new Car();
                _controller.Delete(deleteId, updatedEntity);

                var afterDeleteState = repository.GetById(deleteId);
                Debug.WriteLine(afterDeleteState);
                Assert.IsNull( afterDeleteState);
                

            }
        }


    }
}
