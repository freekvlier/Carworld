using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tests
{
    [TestClass()]
    public class CarCollectionTests
    {
        [TestMethod()]
        public void getCarsTest()
        {
            CarCollection test = new CarCollection();
            var testje = test.getCars();

            bool failed = false;
            foreach (var auto in testje)
            {
                if (auto.Id < 0 || auto.Brand == null || auto.Model == null || auto.Year == null || auto.Price == 0
                        || auto.Power == 0 || auto.Torque == 0 || auto.Acceleration == 0 || auto.Topspeed == 0
                        || auto.Class == null || auto.Fuel == null || auto.FuelConsumption == 0 || auto.UserId == 0)
                {
                    failed = true;
                }

            }
            Assert.AreEqual(true, failed);
        }

        [TestMethod()]
        public void addCarTest()
        {
            Car car = new Car(2, "BMW", "Model", "Jaar", 200, 300, 250, 2, 150, "Sport", "Benzine", 2, 2);
            bool actual = false;
            if(new CarCollection().addCar(car))
            {
                actual = true;
            }
            Assert.AreEqual(true, actual);
        }
    }
}