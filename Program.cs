// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using csharp_ecommerce_db;

EcommerceContext db = new EcommerceContext();

Customer francesco = new Customer();
francesco.Name = "Francesco";
francesco.Surname = "Partipilo";
francesco.Email = "francesco@gmail.com";

db.Customer.Add(francesco);

db.SaveChanges();

