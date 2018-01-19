using System;
using System.Data;
using MySql.Data.MySqlClient;


public class Customer {
    public int Id { set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public DateTime DateOfBirth { set; get; }
}