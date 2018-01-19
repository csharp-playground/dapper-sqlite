using Xunit;
using System;
using System.Linq;

public class MySqlTests {

    [Fact]
    public void ShoudCreateSchema() {
        var customer = new Customer {
            FirstName = "wk",
            LastName = "wk",
            DateOfBirth = DateTime.Now
        };

        var context = new Respository();
        var id = context.SaveCustomers(customer);
        Assert.True(id > 0);
    }

    [Fact]
    public void ShouldQuery() {
        var customers = new Respository().GetCustomers();
        Assert.True(customers.Count > 0);
    }

    [Fact]
    public void ShouldCrateDynamicQuery() {
        var query = "SELECT Id, DateOfBirth from Customer";
        var rs = new Respository().Query(query);
        var sumId = rs.Select(x => (Int32)x.Id).Sum();
        var birthDateOfType = rs.All(x => x.DateOfBirth is string);
        Assert.True(birthDateOfType);
    }
}