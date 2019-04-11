using CarStore.Models;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStore.Infrastructure
{
    public class NinjectСarDependencyResolver : NinjectModule
    {
        private void AddBindings()
        {
            var mock = new Mock<CarsRepositoryMock>();
            //mock.Setup(m => m.Cars).Returns(new List<Car>{
            //    new Car {Mark = "BMW", Model = "M3", Price = 200000 },
            //    new Car { Mark = "Hundai", Model = "Solaris", Price = 500000 },
            //    new Car { Mark = "Vaz", Model = "2109", Price = 100000 }
            //});
            Bind<ICarRepository>().ToConstant(mock.Object);
        }

        public override void Load()
        {
            AddBindings();
        }
    }
}