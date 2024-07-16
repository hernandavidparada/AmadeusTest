using Azure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsManager.Api.Controllers;
using ProductsManager.Core.Entites;
using ProductsManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagerTest
{

    [TestClass]
    public class CRUDProductsTest
    {

        [TestMethod]
        public void TestGetProducts()
        {
            //Arrange
            List<Product> productsResult = new List<Product>();
            List <Product> products = new List<Product>();

            Product prod1 = new Product {
                Name = "Example1",
                Type = "Type 2",
                Description = "This is a description",
                EntryDate = "2017/02/05",
                Cost = 2000,
                Units = 11,
                StoreNumber = 2,
                Dispatcher = "Dispatcher1",
                };

            Product prod2 = new Product
            {
                Name = "Example2",
                Type = "Type 3",
                Description = "This is another description",
                EntryDate = "2011/04/11",
                Cost = 50000,
                Units = 1,
                StoreNumber = 33,
                Dispatcher = "Dispatcher2",
            };

            products.Add(prod1);
            products.Add(prod2);

            var productsRepository = new Mock<IProductsRepository>();
            productsRepository.Setup(x=>x.GetProducts()).Returns(products);

            var productsController = new ProductsController(productsRepository.Object);

            //Act
            var result = productsController.GetProducts();
            OkObjectResult okResult = (OkObjectResult)result;
            productsResult = okResult.Value is null? new List<Product>(): (List<Product>)okResult.Value;


            //Asserts
            Assert.IsNotNull(okResult);
            Assert.AreEqual(okResult.StatusCode, 200);
            Assert.IsTrue (productsResult.Count > 1 );
            Assert.AreEqual(productsResult[1].Cost, 50000);

        }

        [TestMethod]
        public void TestInsertProducts()
        {
            //Arrange
            
            Product prod1 = new Product
            {
                Name = "Example1",
                Type = "Type 2",
                Description = "This is a description",
                EntryDate = "2017/02/05",
                Cost = 2000,
                Units = 11,
                StoreNumber = 2,
                Dispatcher = "Dispatcher1",
            };

            var productsRepository = new Mock<IProductsRepository>();
            productsRepository.Setup(x => x.InsertProducts(prod1)).Returns("1");

            var productsController = new ProductsController(productsRepository.Object);

            //Act
            var result = productsController.InsertProducts(prod1);
            OkObjectResult okResult = (OkObjectResult)result;
            string stringResult = okResult.Value is null ? "" : (string)okResult.Value;


            //Asserts
            Assert.IsNotNull(okResult);
            Assert.AreEqual(okResult.StatusCode, 200);
            Assert.AreNotEqual(stringResult, "0");

        }


        [TestMethod]
        public void TestDeleteProducts()
        {
            //Arrange

            int prod1 = 2;

            var productsRepository = new Mock<IProductsRepository>();
            productsRepository.Setup(x => x.DeleteProducts(prod1)).Returns("1");

            var productsController = new ProductsController(productsRepository.Object);

            //Act
            var result = productsController.DeleteProducts(prod1);
            OkObjectResult okResult = (OkObjectResult)result;
            string stringResult = okResult.Value is null ? "" : (string)okResult.Value;


            //Asserts
            Assert.IsNotNull(okResult);
            Assert.AreEqual(stringResult, "1");

        }



    }
}
