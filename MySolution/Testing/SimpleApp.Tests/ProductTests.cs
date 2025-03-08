using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Tests;

public class ProductTests
{
    [Fact]
    public void CanChangeProductName()
    {
        // Arange 
        var p = new Product { Name = "Test", Price = 100M };

        // Act
        p.Name = "New Name";

        //Assert
        Assert.Equal("Test", p.Name);
    }

    [Fact]
    public void CanChangeProductPrice()
    {
        // Arrange
        var p = new Product { Name = "Test", Price = 100M };

        // Act
        p.Price = 200M;

        //Assert
        Assert.Equal(100M, p.Price);
    }
}
