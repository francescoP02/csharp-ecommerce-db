// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using csharp_ecommerce_db;

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
                Console.WriteLine($"Hello {customer.Name}");
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
    Console.WriteLine("Inizia");
    do
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("-If you want to add a product insert 'product'");
        Console.WriteLine("-For terminate the process insert 'stop'");
        userInput = Console.ReadLine();
        switch (userInput)
        {
            case ("product"):
                try
                {
                    Console.Clear();
                    Console.WriteLine("Inserisci un nuovo prodotto: ");
                    Console.WriteLine("Inserisci il nome del prodotto: ");
                    string productName = Console.ReadLine();

                    Console.WriteLine("Inserisci la descrizione del prodotto: ");
                    string productDescription = Console.ReadLine();

                    Console.WriteLine("Inserisci il prezzo del prodotto: ");
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
        }

    } while (userInput != "stop");

}

