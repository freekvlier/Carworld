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
        public void CreateTest_ShouldReturnTrue()
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
        public void DeleteTest()
        {
            //Arrange
            bool expected = true;
            bool actual = false;
            CarClassDTO carclass = new CarClassDTO();
            carclass.Name = "test";
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
    }
}