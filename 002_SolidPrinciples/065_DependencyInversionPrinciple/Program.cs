using System;
// Interface Segregation Principle
// Page 65
//
// ==================================================
//
// The Dependency Inversion Principle (DIP) is a principle in software development that promotes the 
// decoupling of modules or classes by inverting the traditional dependency flow. It suggests that high-level 
// modules should not depend on low-level modules; both should depend on abstractions. This principle encourages 
// the use of interfaces or abstract classes to define contracts and dependencies, allowing for flexibility, extensibility,
// and easier testing. By applying DIP, changes in low-level modules do not directly impact high-level modules, 
// promoting modular and loosely coupled systems. It enables the interchangeability of components and facilitates the introduction 
// of new implementations without modifying existing code.

// High level
interface IDatabase
{
    void Select(DateTime dateTime);
    void Insert();
    void Update();
    void Delete();
}

class BudgetReport
{
    public IDatabase Database { get; set; }

    void Open(DateTime dateTime)
    {
        Database.Select(dateTime);
    }

    void Save()
    {
        Database.Update();
    }
}

// Low level
class MySql : IDatabase
{
    void Select(DateTime dateTime)
    {

    }

    void Insert()
    {

    }

    void Update()
    {

    }

    void Delete()
    {

    }
}

class MongoDb : IDatabase
{
    void Select(DateTime dateTime)
    {

    }

    void Insert()
    {

    }

    void Update()
    {

    }

    void Delete()
    {

    }
}