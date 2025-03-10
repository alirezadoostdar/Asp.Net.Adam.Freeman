﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleApp.Controllers;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Tests;

public class HomeControllerTests
{
    class FakeDataSource : IDataSource
    {
        public FakeDataSource(Product[] data) => Products = data;
        public IEnumerable<Product> Products { get; set; }
    }
    [Fact]
    public void IndexActionModelIsComplete2()
    {
        //Arrange
        Product[] testDate = new Product[]
        {
            new Product { Name = "P1", Price = 75.10M },
            new Product { Name = "P2", Price = 120M },
            new Product { Name = "P3", Price = 110M }
        };

        var mock = new Mock<IDataSource>();
        mock.SetupGet(m => m.Products).Returns(testDate);
        var controller = new HomeController();
        controller.datasource = mock.Object;

        //Act
        var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

        //Assert
        Assert.Equal(testDate, model,
            Comparer.Get<Product>((p1,p2) => p1?.Name == p2?.Name 
            && p1?.Price == p2?.Price));
        mock.VerifyGet(m => m.Products , Times.Once);
    }
    [Fact]
    public void IndexActionModelIsComplete()
    {
        //Arrange
        var controller = new HomeController();
        Product[] products = new Product[]
        {
            new Product { Name = "Kayak", Price = 275M },
            new Product { Name = "Lifejacket", Price = 48.95M}
        };

        //Act
        var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

        //Assert 
        Assert.Equal(products, model,
            Comparer.Get<Product>((p1, p2) => p1?.Name == p2?.Name
                && p1.Price == p2?.Price));
    }
}
