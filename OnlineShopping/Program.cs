using System;
using OnlineShopping.BL;
using OnlineShopping.DL;
using OnlineShoppingCommon;

namespace OnlineShopping
{
    public class Program
    {
        public char optionSelected;
        public int attempt = 3;
        string username, password;
        int quantityOrder;
        User user = new User();
        Order orders = new Order();
        int itemStocks;

        public void LogIn()
        {
            do
            {
                Console.WriteLine("----------Welcome to A' Online Shop---------");
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();

                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.WriteLine("Password: ");
                password = Console.ReadLine();

                if (username.Equals(user.Username) && password.Equals(user.Password))
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
            while (!username.Equals(user.Username) || (!password.Equals(user.Password)));
        }
        public void Ordering()
        {
            Console.WriteLine("What do you want to buy?");
            Console.WriteLine("1) P.999 - Logitech Mouse");
            Console.WriteLine($"Stock: " + );
            Console.WriteLine($"Total Stocks as of {DateTime.Now}: {DataConnection.GetItemStocks()}");
            optionSelected = Console.ReadLine()[0];

            switch (optionSelected)
            {
                case '1':
                    orders.GetOrder.Add(quantityOrder);
                    BuyItem();
                    break;
                default:
                    break;
            }
        }
        public int GettingCurrentStocks()
        {
            return 
        }
        public void BuyItem()
        {
            Console.WriteLine("How Many?\n");
            var buyingItem = Convert.ToInt32(Console.ReadLine());
            var currentStocks = DataConnection.GetItemStocks(itemName);

            if (buyingItem < currentStocks)
            {

            }
        }
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.LogIn();

        }

    }
}
