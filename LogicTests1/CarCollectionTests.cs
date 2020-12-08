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
            var poep = test.getCars();

            bool failed = false;
            foreach (var auto in poep)
            {
                if(auto.Id < 0 || auto.Brand == null || auto.Model == null || auto.Year == null || auto.Price == 0 
                        || auto.Power == 0 || auto.Torque == 0 || auto.Acceleration == 0 || auto.Topspeed == 0 
                        || auto.Class == null || auto.Fuel == null || auto.Consumption == 0 || auto.UserId == 0)
                {
                    failed = true;
                }
                
            }
            Assert.AreEqual(true, failed);
        }
    }
}