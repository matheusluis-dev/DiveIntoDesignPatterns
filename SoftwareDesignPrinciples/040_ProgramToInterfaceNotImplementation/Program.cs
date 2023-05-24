// Program to an Interface, not an Implementation
// Page 40
//
// ==================================================
//
// Interfaces are useful in achieving abstraction and allowing objects to interact with each other. 
// They define a set of methods, properties, and events that a class must implement, but do not provide an implementation for them. 
// This allows for greater flexibility and reusability of code.
// By using interfaces, you can include behavior from multiple sources in a class.
// That capability is important in C# because the language doesn't support multiple inheritance of classes. 
//
// ==================================================
//
// I made an implementation of an Interface to deal with two different Database connections (Oracle and SQL Server)
// I've seen something similar on my actual work, a colleague made an implementation like this in a Desktop Application

using System.Globalization;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Data.SqlClient;

IDatabase db;

int choice = 0;
while (!Enumerable.Range(1, 2).Contains(choice))
{
    Console.Clear();

    Console.WriteLine("Choose the database:");
    Console.WriteLine("1. Oracle");
    Console.WriteLine("2. SQL Server");

    int.TryParse(Console.ReadLine(), NumberStyles.Integer, default, out choice);
}

switch (choice)
{
    case 1:
        db = new OracleDatabase();
        break;
    default:
        db = new SqlServerDatabase();
        break;
}

if (db.HasConnection()) Console.WriteLine("\nHas connection");
else Console.WriteLine("\nHasn't connection");











interface IDatabase
{
    public string ConnectionString { get; }

    bool HasConnection();
}

class OracleDatabase : IDatabase
{
    public string ConnectionString => "Data Source=interfaceTest;User Id=interfaceTest;Password=interfaceTest;";

    public bool HasConnection()
    {
        OracleConnection oc = new();

        oc.ConnectionString = ConnectionString;

        try
        {
            oc.Open();
            oc.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

class SqlServerDatabase : IDatabase
{
    public string ConnectionString => "Server=interfaceTest;Database=interfaceTest;User Id=interfaceTest;Password=interfaceTest";

    public bool HasConnection()
    {
        SqlConnection sc = new();

        sc.ConnectionString = ConnectionString;

        try
        {
            sc.Open();
            sc.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}