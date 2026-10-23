using Test;

//Objects
RequestProcessing operation = new RequestProcessing();

List<IProduct> productsList = new List<IProduct>();

void MainMenu()
{
    //navigation variable
    int input;
    
    do
    {
        Console.WriteLine("---------------\t (Main menu) \t---------------");
        Console.WriteLine("1. Add new product \n2. Show product list \n3. Search product by ID \n4. Change product quantity \n5. Delete product by ID \n0. Exit");
        Console.Write("Choose an option: ");

        bool isSuccess = int.TryParse(Console.ReadLine(), out input);

        if (isSuccess == true && input >= 0 && input <= 5)
        {
            switch (input)
            {
                case 1:
                    operation.AddProduct(productsList);
                    break;
                case 2:
                    operation.ShowProductList(productsList);
                    break;
                case 3:
                    operation.SearchProductById(productsList);
                    break;
                case 4:
                    operation.ChangeProductQuantity(productsList);
                    break;
                case 5:
                    operation.DeleteProduct(productsList);
                    break;
                case 0:
                    Console.WriteLine("Good bye!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter correct value");
        }

    }while(input != 0);
}

MainMenu();