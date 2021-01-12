using Microsoft.VisualStudio.TestTools.UnitTesting;
using Carworld_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Carworld_LogicTests;

namespace Carworld_Logic.Tests
{
    [TestClass()]
    public class BrandCollectionTests
    {
        [TestMethod()]
        public void CreateBrandWithValidBrandObject_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand = new Brand()
            {
                Name = "testBrand",
                Origin = "Country"
            };

            //Act
            bool actual = brandCollection.Create(brand);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void CreateBrandWithEmptyBrandObject_ShouldReturnFalse()
        {
            //Arrange
            bool expected = false;
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand = new Brand();

            //Act
            bool actual = brandCollection.Create(brand);

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}