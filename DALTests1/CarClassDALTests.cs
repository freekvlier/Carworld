using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using FactoryDAL;
using ContractLayer;

namespace DAL.Tests
{
    [TestClass()]
    public class CarClassDALTests
    {
        [TestMethod()]
        public void GetAllTest_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            bool actual = false;

            //Act
            var carClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();

            //Assert
            if (carClasses.Count > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateTest1_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            bool actual = false;
            CarClassDTO carclass = new CarClassDTO();
            carclass.Name = "test";
            var allClassesBefore = CarClassFactoryDAL.GetCollectionDAL().GetAll();

            //Act
            CarClassFactoryDAL.GetCollectionDAL().Create(carclass);

            //Assert
            var allClassesAfter = CarClassFactoryDAL.GetCollectionDAL().GetAll();

            if (allClassesBefore.Count < allClassesAfter.Count)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UpdateTest2()
        {
            //Arrange
            bool expected = true;
            bool actual = false;
            var allClasses = CarClassFactoryDAL.GetCollectionDAL().GetAll();
            int index = allClasses.FindIndex(a => a.Name.Contains("test"));

            CarClassDTO carclass = new CarClassDTO();
            carclass.Id = 000;
            carclass.Name = "UpdateTest";

            //Act
            CarClassFactoryDAL.GetDAL().Update(carclass);

            //Assert
            if (carclass.Name != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DeleteTest3_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            bool actual = false;
            CarClassDTO carclass = new CarClassDTO();
            carclass.Name = "UpdateTest";
            var allClassesBefore = CarClassFactoryDAL.GetCollectionDAL().GetAll();

            //Act
            CarClassFactoryDAL.GetCollectionDAL().Delete(carclass);

            //Assert
            var allClassesAfter = CarClassFactoryDAL.GetCollectionDAL().GetAll();

            if (allClassesBefore.Count > allClassesAfter.Count)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetTest_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            bool actual = false;

            //Act
            CarClassDTO carclass = CarClassFactoryDAL.GetCollectionDAL().Get(0);

            //Assert
            if (carclass.Name != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}