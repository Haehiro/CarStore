using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface ICarRepository
    {
        List<Car> Cars { get; }

        Car GetById(int id);
        bool Edit(int id, Car value);
        int Create(Car value);
        bool Delete(int id);

    }
}
