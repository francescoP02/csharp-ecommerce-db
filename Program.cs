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
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("-If you want to register insert 'register'");
    Console.WriteLine("-Are you register? 'login' for login");
    Console.WriteLine("-For terminate the process insert 'exit'");
    choice = Console.ReadLine();
    switch(choice)
    {
        case ("register"):
            try
            {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid values");
            }
            break;

        case ("login"):
            try
            {
                Console.WriteLine("Insert your email:");
                string loginMail = Console.ReadLine();

                Customer customer;
                customer = db.Customer.Where(customer => customer.Email == loginMail).First();
                customer = (from s in db.Customer
                            where s.Email == loginMail
                            select s).First();
                Console.WriteLine($"Hello {customer.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email not found");
            }
            break;
    }

}while (choice != "exit");

