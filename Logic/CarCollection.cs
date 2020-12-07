using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Logic
{
    public class CarCollection
    {
        public List<Car> getCars()
        {
            List<Car> carList = new List<Car>();
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var cars = CarFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            foreach (var car in cars)
            {
                carList.Add(new Car(car.Id, brands[car.Brand].Name, car.Model,
                            car.Year, car.Price, car.Power, car.Torque, car.Acceleration,
                            car.Topspeed, carClasses[car.Class].Name, fuels[car.Fuel].Name, car.FuelConsumption, car.UserId));
            }

            return carList;
        }
    }
}
