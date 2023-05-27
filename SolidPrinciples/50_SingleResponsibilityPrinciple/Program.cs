// Single Responsibility Principle
// Page 50
//
// ==================================================
//
// The Single Responsibility Principle (SRP) states that a class or module should have only one reason to change. 
// It emphasizes that each class should have a single responsibility or purpose, resulting in higher cohesion, better code organization, 
// and improved maintainability. By adhering to SRP, changes to one responsibility do not affect unrelated parts, making the code more robust. 
// SRP promotes smaller, focused classes/modules, facilitating understanding, testing, and reuse. It aligns with the Open/Closed Principle, 
// allowing for extension without modification. SRP enables developers to create maintainable and flexible software systems by promoting a 
// modular design approach with clear responsibilities.

var sales = new Sales();

sales.AddSale(new Product("Soap", 2));
sales.AddSale(new Product("Beans", 3));
sales.AddSale(new Product("Ruffles", 5));

Report.Print(sales.ToString());











class Product
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class Sales
{
    public List<Product> ProductsSold => _productsSold;

    private List<Product> _productsSold = new List<Product>();
    private int count = 0;

    public int AddSale(Product product)
    {
        _productsSold.Add(product);
        return ++count;
    }

    public override string ToString()
    {
        var stringProductsSold = string.Empty;

        int i = 0;
        foreach (var p in _productsSold)
            stringProductsSold += $"{++i}: {p.Name} - ${p.Price}{Environment.NewLine}";

        return stringProductsSold;
    }
}

class Report
{
    // separated from the Sales class
    public static void Print(string report)
    {
        // imagine this is a save-to-file instead of a WriteLine
        Console.WriteLine(report);
    }
}