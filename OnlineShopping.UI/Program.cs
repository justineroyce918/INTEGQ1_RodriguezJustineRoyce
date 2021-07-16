using System;
using System.Collections.Generic;
using OnlineShopping.BL;

namespace OnlineShopping.UI
{
    public class Program
    {
        public char optionSelected;
        public int attempt = 3;
        string username, password;
        int quantityOrder, neededQuantity;  
        Order orders = new Order();


        static User buyerUser;
           
        int itemStocks;

        static List<string> action = new List<string>()
        {
            "Order (Type 1)", "Exit App (Type 2)" };
        public void LogIn()
        {
            do
            {
                buyerUser = new User("client123", "12345678");
                Console.WriteLine("----------Welcome to A' Online Shop---------");
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();

                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();

                if (username.Equals(buyerUser.Username) || password.Equals(buyerUser.BuyerPassword))
                {
                    Console.WriteLine("Successfully Log In.\n");
                    Ordering();

                }
                else if (username.Equals("") || password.Equals(""))
                {
                    Console.WriteLine("Please Input Your Username or Password.");
                }
                else
                {
                    Console.WriteLine("Invalid Input ");
                    --attempt;
                    if (attempt == 0)
                    {
                        Console.WriteLine("\nTry Again\n");
                    }
                }
            }
            while (!username.Equals(buyerUser.Username) && password.Equals(buyerUser.BuyerPassword));
        }
        public void Ordering()
        {
            //mag order ng products

            Inventory inventory = new Inventory();
            Console.WriteLine("Welcome");
            var biñanStore =
                      new Store { StoreName = "Biñan", Address = "Biñan, Laguna" };
            Console.WriteLine(biñanStore);
            Console.WriteLine("Choice By Category: \n1.)Keyboard: ");
            optionSelected = Console.ReadLine()[0];
            var currentQuantities = GetCurrentQuantity();

            switch (optionSelected)
            {
                case '1':
                    Console.WriteLine("Keyboard");
                    //Nag oorder

                    Console.WriteLine("Price: 1900");
                    Console.WriteLine("Current Quantity" +GetCurrentQuantity());
                    Console.WriteLine($"Enter a Quantity: ");
                    neededQuantity = Convert.ToInt32(Console.ReadLine());

                    break;
                    
                default:
                    Ordering();
                    break;
            }
        }

        static int GetCurrentQuantity()
        {
            return Inventory.GetQuantities(buyerUser.BuyerUsername).Quantity;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.LogIn();

        }
    }
}
