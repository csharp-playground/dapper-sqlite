
using Xunit;
using Models;
using System;

public class MySqlTests{
    [Fact]
    public void ShoudCreateSchema()
    {
        var customer = new Customer
        {
            FirstName = "wk",
            LastName = "wk",
            DateOfBirth = DateTime.Now
        };

        var context = new Respository();
        var id = context.SaveCustomers(customer);
        Assert.True(id > 0);
    }

    [Fact]
    public void ShouldQuery()
    {
        var customers = new Respository().GetCustomers();
        Assert.True(customers.Count > 0);
    }
}