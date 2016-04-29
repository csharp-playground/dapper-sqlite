
using Xunit;
using Models;
using System;

public class SqLiteTests
{
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
        context.SaveCustomers(customer);
    }
}

public class Hello {
    [Fact]
    public void ShouldCheckEquality() {
        Assert.Equal(5,5);
    }
}
