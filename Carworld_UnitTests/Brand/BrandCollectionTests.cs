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
        public void Create_CreateBrandWithValidBrandObject_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand = new Brand()
            {
                Name = "TestNameCreate1",
                Origin = "TestOriginCreate1"
            };

            //Act
            bool actual = brandCollection.Create(brand);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void Create_CreateBrandWithEmptyBrandObject_ShouldReturnFalse()
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

        [TestMethod()]
        public void Get_GetSecondCreatedBrand_ShouldReturnTrue()
        {
            //Arrange
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand0 = new Brand()
            {
                Name = "TestNameGet1",
                Origin = "TestOriginGet1"
            };
            Brand brand1 = new Brand()
            {
                Name = "TestNameGet2",
                Origin = "TestOriginGet2"
            };
            brandCollection.Create(brand0);
            brandCollection.Create(brand1);

            Brand expected = new Brand()
            {
                Id = 1,
                Name = "TestNameGet2",
                Origin = "TestOriginGet2"
            };

            //Act
            Brand get = brandCollection.Get(1);

            //Assert
            Assert.AreEqual(get.Id, expected.Id);
            Assert.AreEqual(get.Name, expected.Name);
            Assert.AreEqual(get.Origin, expected.Origin);
        }

        [TestMethod()]
        public void Get_GetNotExistingBrand_ShouldReturnFalse()
        {
            //Arrange
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand0 = new Brand()
            {
                Name = "TestNameGet1",
                Origin = "TestOriginGet1"
            };
            Brand brand1 = new Brand()
            {
                Name = "TestNameGet2",
                Origin = "TestOriginGet2"
            };
            brandCollection.Create(brand0);
            brandCollection.Create(brand1);

            Brand expected = new Brand()
            {
                Id = 1,
                Name = "TestNameGet2",
                Origin = "TestOriginGet2"
            };

            //Act
            Brand get = brandCollection.Get(5);

            //Assert
            Assert.AreNotEqual(get.Id, expected.Id);
            Assert.AreNotEqual(get.Name, expected.Name);
            Assert.AreNotEqual(get.Origin, expected.Origin);
        }

        [TestMethod()]
        public void GetAll_GetAll3CreatedBrands_ShouldReturnTrue()
        {
            //Arrange
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());

            Brand brand0 = new Brand()
            {
                Id = 0,
                Name = "TestNameGet1",
                Origin = "TestOriginGet1"
            };
            Brand brand1 = new Brand()
            {
                Id = 1,
                Name = "TestNameGet2",
                Origin = "TestOriginGet2"
            };
            Brand brand2= new Brand()
            {
                Id = 2,
                Name = "TestNameGet3",
                Origin = "TestOriginGet3"
            };
           
            brandCollection.Create(brand0);
            brandCollection.Create(brand1);
            brandCollection.Create(brand2);

            List<Brand> expectedBrandList = new List<Brand>();
            expectedBrandList.Add(brand0);
            expectedBrandList.Add(brand1);
            expectedBrandList.Add(brand2);

            bool actual = true;

            //Act
            List<Brand> actualBrandList = brandCollection.GetAll();

            //Assert
            for (int i = 0; i < 2; i++)
            {
                if(expectedBrandList[i].Id != actualBrandList[i].Id & 
                    expectedBrandList[i].Name != actualBrandList[i].Name &
                    expectedBrandList[i].Origin != actualBrandList[i].Origin)
                {
                    actual = false;
                }
            }

            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void Delete_DeleteSecondCreatedBrand_ShouldReturnTrue()
        {
            //Arrange
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand0 = new Brand()
            {
                Id = 0,
                Name = "TestNameGet1",
                Origin = "TestOriginGet1"
            };
            Brand brand1 = new Brand()
            {
                Id = 1,
                Name = "TestNameGet2",
                Origin = "TestOriginGet2"
            };
            brandCollection.Create(brand0);
            brandCollection.Create(brand1);

            bool expected = true;

            //Act
            bool actual = brandCollection.Delete(1);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void Delete_DeletingNonExistingBrand_ShouldReturnFalse()
        {
            //Arrange
            BrandCollection brandCollection = new BrandCollection(new BrandTestDAL());
            Brand brand0 = new Brand()
            {
                Id = 0,
                Name = "TestNameGet1",
                Origin = "TestOriginGet1"
            };
            brandCollection.Create(brand0);

            bool expected = false;

            //Act
            bool actual = brandCollection.Delete(3);

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}