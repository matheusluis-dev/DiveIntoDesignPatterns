// Open/Closed Principle
// Page 52
//
// ==================================================
//
// The Open/Closed Principle (OCP) is a principle in software development that states that classes or entities 
// should be open for extension but closed for modification. It means that the behavior of a class can be extended 
// without modifying its source code. Instead of modifying existing code, new functionality is added through inheritance, 
// interfaces, or composition. This principle promotes code reusability, maintainability, and minimizes the risk of 
// introducing bugs when making changes. By adhering to OCP, developers can create flexible and robust systems that can be 
// easily extended and modified without impacting existing code.

using System;

Order orderByAir = new("air", new Air(), 150, 200);
Order orderByGround = new("ground", new Ground(), 1, 1);

Console.WriteLine($"Air -> {orderByAir.ShippingCost} | {orderByAir.ShippingDate}");
Console.WriteLine($"Ground -> {orderByGround.ShippingCost} | {orderByGround.ShippingDate}");











public interface IShippingMethod
{
    public double GetCost(Order order);
    public DateTime GetDate(Order order);
}

public class Order
{
    public string LineItems { get; set; }
    public IShippingMethod ShippingMethod { get; set; }
    public double Total { get; set; }
    public double TotalWeight { get; set; }
    public double ShippingCost => ShippingMethod.GetCost(this);
    public DateTime ShippingDate => ShippingMethod.GetDate(this);

    public Order(string lineItems, IShippingMethod shippingMethod, double total, double totalWeight)
    {
        LineItems = lineItems;
        ShippingMethod = shippingMethod;
        Total = total;
        TotalWeight = totalWeight;
    }
}

class Ground : IShippingMethod
{
    private const double MinimalCost = 10;

    public double GetCost(Order order)
    {
        if (order.Total > 100) return 0;

        var value = order.TotalWeight * 1.5;
        return MinimalCost > value ? MinimalCost : value;
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now;
    }
}

public class Air : IShippingMethod
{
    public double GetCost(Order order)
    {
        return order.TotalWeight * 5;
    }

    public DateTime GetDate(Order order)
    {
        return DateTime.Now;
    }
}