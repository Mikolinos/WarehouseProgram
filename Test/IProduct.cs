namespace Test;

public interface IProduct
{
    int Id {get;}
    string Name {get; set;}
    decimal Price {get; set;}
    int Quantity {get; set;}
    void PrintInfo();
}
