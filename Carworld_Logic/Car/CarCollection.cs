using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;
using FactoryDAL;

namespace Carworld_Logic
{
    public class CarCollection
    {
        public List<Car> GetAll()
        {
            List<Car> carList = new List<Car>();
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var cars = CarFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();
            
            if(cars != null)
            {
                foreach (var car in cars)
                {
                    carList.Add(new Car(car.Id, brands[brands.FindIndex(item => item.Id == car.BrandId)].Name, car.Model,
                                car.Year, car.Price, car.Horsepower, car.Torque, car.Acceleration,
                                car.Topspeed, carClasses[carClasses.FindIndex(item => item.Id == car.CarClassId)].Name, fuels[fuels.FindIndex(item => item.Id == car.FuelId)].Name,
                                car.FuelConsumption, car.MadeByUser));
                }
            }

            return carList;
        }

        public List<Car> GetAllSorted(string property)
        {
            List<Car> carList = new List<Car>();
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var cars = CarFactoryDAL.GetCollectionDAL().GetAllSorted(property);
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            foreach (var car in cars)
            {
                carList.Add(new Car(car.Id, brands[brands.FindIndex(item => item.Id == car.BrandId)].Name, car.Model,
                            car.Year, car.Price, car.Horsepower, car.Torque, car.Acceleration,
                            car.Topspeed, carClasses[carClasses.FindIndex(item => item.Id == car.CarClassId)].Name, fuels[fuels.FindIndex(item => item.Id == car.FuelId)].Name,
                            car.FuelConsumption, car.MadeByUser));
            }
 
            return carList;
        }

        public int Create(Car carinput)
        {
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            CarDTO carDTO = new CarDTO
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
                MadeByUser = carinput.MadeByUser
            };

            return CarFactoryDAL.GetCollectionDAL().Create(carDTO);
        }

        public bool Delete(int Id)
        {
            return CarFactoryDAL.GetCollectionDAL().Delete(Id);
        }

        public Car Get(int id)
        {
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();

            var getCar = CarFactoryDAL.GetCollectionDAL().Get(id);
            Car car = new Car   (getCar.Id, brands[brands.FindIndex(item => item.Id == getCar.BrandId)].Name, getCar.Model,
                                getCar.Year, getCar.Price, getCar.Horsepower, getCar.Torque, getCar.Acceleration,
                                getCar.Topspeed, carClasses[carClasses.FindIndex(item => item.Id == getCar.CarClassId)].Name, fuels[fuels.FindIndex(item => item.Id == getCar.FuelId)].Name,
                                getCar.FuelConsumption, getCar.MadeByUser);

            return car;

        }

        public List<Car> GetAllFavorites(int userId)
        {
            List<Car> carList = new List<Car>();
            var favorites = FavoriteFactoryDAL.GetCollectionDAL().GetAllByUserId(userId);

            foreach (var favorite in favorites)
            {
                carList.Add(Get(favorite.CarId));
            }
    
            return carList;
        }

        public List<Car> SearhModelName(string search)
        {
            List<Car> carList = new List<Car>();

            var cars = CarFactoryDAL.GetCollectionDAL().SearhModelName(search);
            var brands = BrandFactoryDAL.GetCollectionDAL().GetAll();
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            var fuels = FuelFactoryDAL.GetCollectionDAL().GetAll();
            if(cars != null)
            { 
                foreach (var car in cars)
                {
                    carList.Add(new Car(car.Id, brands[brands.FindIndex(item => item.Id == car.BrandId)].Name, car.Model,
                             car.Year, car.Price, car.Horsepower, car.Torque, car.Acceleration,
                             car.Topspeed, carClasses[carClasses.FindIndex(item => item.Id == car.CarClassId)].Name, fuels[fuels.FindIndex(item => item.Id == car.FuelId)].Name,
                             car.FuelConsumption, car.MadeByUser));
                }
            }

            return carList;
        }

    }
}
