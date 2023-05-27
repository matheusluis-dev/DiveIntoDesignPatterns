// Factory Method
// Page 72
//
// ==================================================
//
// The Factory Method is a creational design pattern that provides an interface for creating objects, 
// but lets subclasses decide which class to instantiate. It encapsulates the object creation logic within a separate method, 
// allowing subclasses to provide their own implementation of the method to create specific instances. 
// The Factory Method promotes flexibility and extensibility, enabling the addition of new product types without modifying existing client code. 
// It abstracts the instantiation process and provides a consistent interface for object creation, facilitating loose coupling and adhering 
// to the Open/Closed Principle. This pattern is useful when there is a need to delegate the responsibility of object creation to subclasses 
// or when the exact object type is determined at runtime.

using System;

ICreditCard[] cards = { CreditCardFactory.CreateCreditCard(CardType.Gold),
                        CreditCardFactory.CreateCreditCard(CardType.Platinum),
                        CreditCardFactory.CreateCreditCard(CardType.Black) };

foreach (var c in cards)
{
    Console.WriteLine($"Type: {c.Type} | MinimumLimit: {c.MinimumLimit} | MaximumLimit: {c.MaximumLimit} | AnnualCharge: {c.AnnualCharge}");
}

public enum CardType
{
    Gold,
    Platinum,
    Black
}

public interface ICreditCard
{
    public CardType Type { get; }
    public double MinimumLimit { get; }
    public double MaximumLimit { get; }
    public double AnnualCharge { get; }
}

public class CreditCardFactory
{
    public static ICreditCard CreateCreditCard(CardType type)
    {
        switch (type)
        {
            case CardType.Gold:
                return new GoldCard();
            case CardType.Platinum:
                return new PlatinumCard();
            case CardType.Black:
                return new BlackCard();
            default:
                throw new ArgumentException("Invalid card type.");
        }
    }
}

public class GoldCard : ICreditCard
{
    public CardType Type => CardType.Gold;
    public double MinimumLimit => 500;
    public double MaximumLimit => 5000;
    public double AnnualCharge => 12.5;
}

public class PlatinumCard : ICreditCard
{
    public CardType Type => CardType.Platinum;
    public double MinimumLimit => 5000;
    public double MaximumLimit => 15000;
    public double AnnualCharge => 30.99;
}

public class BlackCard : ICreditCard
{
    public CardType Type => CardType.Black;
    public double MinimumLimit => 15000;
    public double MaximumLimit => 100000;
    public double AnnualCharge => 200;
}
