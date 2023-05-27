// Program to an Interface, not an Implementation - Example
// Page 42
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
// Implementation of example given in page 42.

var company = new Company();
Console.WriteLine("-> company");
company.CreateSoftware();

var companyGameDev = new CompanyGameDev();
Console.WriteLine("-> companyGameDev");
companyGameDev.CreateSoftware();

var companyOutsourcing = new CompanyOutsourcing();
Console.WriteLine("-> companyOutsourcing");
companyOutsourcing.CreateSoftware();











class Company
{
    public void CreateSoftware()
    {
        foreach (var e in GetEmployees()) e.DoWork();
    }

    public virtual IEmployee[] GetEmployees()
    {
        return new IEmployee[] { new Designer(), new Programmer(), new Tester() };
    }
}

class CompanyGameDev : Company
{
    public override IEmployee[] GetEmployees()
    {
        return new IEmployee[] { new Designer(), new Artist() };
    }
}

class CompanyOutsourcing : Company
{
    public override IEmployee[] GetEmployees()
    {
        return new IEmployee[] { new Programmer(), new Tester() };
    }
}

interface IEmployee
{
    void DoWork();
}

class Designer : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Designer editing stuff...");
    }
}


class Artist : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Artist drawing stuff...");
    }
}

class Programmer : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Programmer coding...");
    }
}

class Tester : IEmployee
{
    public void DoWork()
    {
        Console.WriteLine("Testing programmer bugs...");
    }
}