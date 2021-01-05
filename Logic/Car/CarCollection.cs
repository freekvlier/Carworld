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
                carList.Add(new Car(car.Id, brands[car.BrandId].Name, car.Model,
                            car.Year, car.Price, car.Horsepower, car.Torque, car.Acceleration,
                            car.Topspeed, carClasses[car.CarClassId].Name, fuels[car.FuelId].Name, car.FuelConsumption, car.MadeByUser));
            }

            return carList;
        }

        public bool addCar(Car carinput)
        {
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            CarDTO dto = new CarDTO
            {
                Id = carinput.Id,
                BrandId = brands.FindIndex(item => item.Name == carinput.Brand),
                Model = carinput.Model,
                Year = carinput.Year,
                Price = carinput.Price,
                Horsepower = carinput.Horsepower,
                Torque = carinput.Torque,
                Acceleration = carinput.Acceleration,
                Topspeed = carinput.Topspeed,
                CarClassId = carClasses.FindIndex(item => item.Name == carinput.CarClass),
                FuelId = fuels.FindIndex(item => item.Name == carinput.Fuel),
                FuelConsumption = carinput.FuelConsumption,
                MadeByUser = carinput.UserId
            };

            if (CarFactoryDAL.GetCollectionDAL().Create(dto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
