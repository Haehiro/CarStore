using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStore.Models
{
    public class CarsRepositoryMock : ICarRepository
    {
        public List<Car> Cars => _carList;

        private List<Car> _carList;

        public CarsRepositoryMock()
        {
            _carList = new List<Car>{
                new Car {Mark = "BMW", Model = "M3", Price = 200000 },
                new Car { Mark = "Hundai", Model = "Solaris", Price = 500000 },
                new Car { Mark = "Vaz", Model = "2109", Price = 100000 }
            };
            
        }


        public int Create(Car value)
        {
            _carList.Add(value);
            return _carList.IndexOf(value);
        }

        public bool Delete(int id)
        {
            var item = _carList.FirstOrDefault(x => x.Id == id);
            return _carList.Remove(item);
        }

        public bool Edit(int id, Car value)
        {
            var item =
                _carList.FirstOrDefault(x => x.Id == id);
            if (item == null) return false;
            item.Model = value.Model;
            item.Mark = value.Mark;
            item.Price = value.Price;

            return true;
        }

        public Car GetById(int id)
        {
            return _carList.FirstOrDefault(x => x.Id == id);
        }
    }
}