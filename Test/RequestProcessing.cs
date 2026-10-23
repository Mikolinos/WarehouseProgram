using System;
using System.Runtime.CompilerServices;

namespace Test;

public class RequestProcessing
{
    public void AddProduct (List<IProduct> product)
    {
        //variables
        string name; 
        decimal price; 
        int quantity;

        //navigation
        int input;

        do
        {

            do
            {
                Console.Write("Enter product name: ");

                name = Console.ReadLine() ?? string.Empty;

            }while(string.IsNullOrWhiteSpace(name));

            while (true)
            {
                Console.Write("Enter product price: ");

                bool isSuccess = decimal.TryParse(Console.ReadLine(), out price);

                if (isSuccess && price > 0 && price <= 100000)
                {
                    break;
                }
            }

            while (true)
            {
                Console.Write("Enter product quantity: ");

                bool isSuccess = int.TryParse(Console.ReadLine(), out quantity);

                if (isSuccess && quantity >= 0 && quantity <= 10000)
                {
                    break;
                }
            }

            Console.WriteLine($"\nName: {name} \t Price: {price} \t Quantity {quantity}");
            
            while (true)
            {
                Console.WriteLine("\nAre you sure you want to add this product?\n0 - No (Cancel/Retry) \t 1 - Yes (Save)");
                bool isSuccess = int.TryParse(Console.ReadLine(), out input);

                if (isSuccess && (input == 0 || input == 1))
                {
                    break;
                }
                Console.WriteLine("Please enter 0 or 1.");
            }

            if (input == 1)
            {
                int newId = product.Count + 1;

                Product newProduct = new Product
                {
                    Id = newId,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };

                product.Add(newProduct);
                
                Console.WriteLine("Product successfully added to the database!\n");
                break;
            }
            else
            {
                Console.WriteLine("Let's try filling the product data again.\n");
            }

        }while(input == 0 || input == 1);
    }

    public void DeleteProduct(List<IProduct> product)
    {
        int input;

        while (true)
        {
            Console.Write("Enter id product to delete it (0 to exit): ");

            bool isSuccess = int.TryParse(Console.ReadLine(), out input);

            if (isSuccess && input >= 1)
            {
                IProduct? targetProduct = null;

                foreach (var item in product)
                {
                    if (item.Id == input)
                    {
                        targetProduct = item;
                        break;
                    }
                }

                if (targetProduct == null)
                {
                    Console.WriteLine("Product with this id was not found!");
                    return;
                }

                targetProduct.PrintInfo();

                while (true)
                {
                    Console.Write("Are you sure, that want to delete it ? (0 - cancel | 1 - apply): ");

                    isSuccess = int.TryParse(Console.ReadLine(), out input);

                    if(isSuccess && input == 1)
                    {
                        product.Remove(targetProduct);
                        Console.WriteLine("Product was successfully deleted");
                        break;
                    }
                    else if (isSuccess && input == 0)
                    {
                        Console.WriteLine("Deleting was canceled");
                        break;
                    }   
                }
                
                break;
            }   
        }
    }

    public void ShowProductList(List<IProduct> product)
    {
        foreach (var item in product)
        {
            item.PrintInfo();
        }
    }

    public void SearchProductById(List<IProduct> product)
    {
        int idInput;

        while (true)
        {
            Console.Write("Please enter product id (or 0 to exit): ");

            bool isSuccess = int.TryParse(Console.ReadLine(), out idInput);

            if (isSuccess && idInput >= 1)
            {
                foreach (var item in product)
                {
                    if (item.Id == idInput)
                    {
                        item.PrintInfo();
                    }
                }
            }
            else if (idInput == 0)
            {
                break;
            }
        }

    }

    public void ChangeProductQuantity(List<IProduct> product)
    {
        int input;

        Console.Write("Enter product id which you want change (0 to exit): ");

        bool isSuccess = int.TryParse(Console.ReadLine(), out input);

        if (isSuccess && input >= 1)
        {
            IProduct? targetProduct = null;

            foreach (var item in product)
            {
                if (item.Id == input)
                {
                    targetProduct = item;
                    break;
                }
            }

            if (targetProduct == null)
            {
                Console.WriteLine("Product with this ID was not found!");
                return;
            }

            targetProduct.PrintInfo();

            while (true)
            {
                Console.Write("Enter new product quantity (Enter to cancel): ");
                string? inputLine = Console.ReadLine();
                if (string.IsNullOrEmpty(inputLine))
                {
                    break;
                }
                else if (int.TryParse(inputLine, out int newQuantity) && newQuantity >= 0)
                {
                    targetProduct.Quantity = newQuantity;
                    targetProduct.PrintInfo();
                    break;
                }
            }
        }
    }
}
