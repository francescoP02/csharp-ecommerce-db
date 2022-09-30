// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using csharp_ecommerce_db;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

EcommerceContext db = new EcommerceContext();

//Customer francesco = new Customer();
//francesco.Name = "Francesco";
//francesco.Surname = "Partipilo";
//francesco.Email = "francesco@gmail.com";

//db.Customer.Add(francesco);

//db.SaveChanges();

string choice;
string userInput;
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("-If you want to register insert 'register'");
    Console.WriteLine("-Are you register? 'login' for login");
    Console.WriteLine("-For terminate the process insert 'exit'");
    choice = Console.ReadLine();
    bool logged = false;
    switch(choice)
    {
        case ("register"):
            try
            {
                Console.Clear();
                Customer newCustomer = new Customer();
                Console.WriteLine("Insert name:");
                string newCustomeName = Console.ReadLine();
                Console.WriteLine("Insert surname:");
                string newCustomeSurname = Console.ReadLine();
                Console.WriteLine("Insert email:");
                string newCustomeEmail = Console.ReadLine();
                newCustomer.Name = newCustomeName;
                newCustomer.Surname = newCustomeSurname;
                newCustomer.Email = newCustomeEmail;

                db.Customer.Add(newCustomer);
                db.SaveChanges();

                logged = true;

                if (logged)
                {
                    Main(newCustomer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid values");
                Console.WriteLine();
            }
            break;

        case ("login"):
            try
            {
                Console.Clear();
                Console.WriteLine("Insert your email:");
                string loginMail = Console.ReadLine();

                Customer customer;
                customer = db.Customer.Where(customer => customer.Email == loginMail).First();
                customer = (from s in db.Customer
                            where s.Email == loginMail
                            select s).First();
                logged = true;

                if (logged)
                {
                    Main(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email not found");
                Console.WriteLine();
            }
            break;
    }

}while (choice != "exit");

void Main(Customer customer){
    Console.Clear();
    Console.WriteLine($"****Welcome {customer.Name}****");
    do
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("-If you want to add a product insert 'product'");
        Console.WriteLine("-If you want to make an order insert 'order'");
        Console.WriteLine("-For terminate the process insert 'stop'");
        userInput = Console.ReadLine();
        switch (userInput)
        {
            case ("product"):
                try
                {
                    Console.Clear();
                    Console.WriteLine("****Insert new product****: ");
                    Console.WriteLine("Insert product's name: ");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Insert product's description: ");
                    string productDescription = Console.ReadLine();

                    Console.WriteLine("Insert product's price: ");
                    double productPrice = double.Parse(Console.ReadLine());

                    using (EcommerceContext context = new EcommerceContext())
                    {
                        Product newProduct = new Product { Name = productName, Description = productDescription, Price = productPrice };
                        context.Add(newProduct);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid values");
                    Console.WriteLine();
                }
                break;

            case ("order"):
                insertOrder(customer);
                break;
        }

    } while (userInput != "stop");

}

void insertOrder(Customer customer)
{
    using (EcommerceContext context = new EcommerceContext())
    {
        //View of all the products
        Console.WriteLine("****Product's List****");
        Console.WriteLine();

        List<Product> products = context.Product.OrderBy(product => product.Name).ToList<Product>();

        foreach (Product product in products)
        {
            Console.WriteLine($"Product: {product.Id} - {product.Name}");
        }
    }
}

