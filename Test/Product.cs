namespace Test;

public class Product : IProduct
{
    public int Id {get; set; }
    public string Name {get; set; } = string.Empty;
    public decimal Price {get; set; }
    public int Quantity {get; set; }

    public void PrintInfo()
    {   
        Console.WriteLine($"[ID: {Id}] | {Name} - ${Price} | quantity: {Quantity}");
    }
}
