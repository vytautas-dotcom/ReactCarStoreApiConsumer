using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCarStoreApiConsumer.Models
{
    public interface ICarRepository
    {
        void AddCar(Guid storeId, Car car);
        Task<Car> GetCar(Guid storeId, Guid carId);
        void UpdateCar(Guid storeId, Car car);
        void DeleteCar(Guid storeId, Guid carId);
    }
}
