using System;

namespace ProductShop
{
    class Program
    {
        static void ShowMenu()
        {
            foreach (MenuItems item in Enum.GetValues(typeof(MenuItems)))
            {
                int num = (int)item;
                string text = item.ToString();

                Console.WriteLine($"{num}) {text}");
            }
        }
        static void Main(string[] args)
        {
            Store store = new Store();
            MenuItems chosenItem;

            do
            {
                ShowMenu();
                int choice = 0;
                bool result = false;
                while (!result)
                {
                    Console.Write("Your choice->");
                    string s = Console.ReadLine();
                    result = int.TryParse(s, out int res);
                    choice = res;
                }
                chosenItem = (MenuItems)choice;

                switch (chosenItem)
                {
                    case MenuItems.Show:
                        store.Show();
                        break;
                    case MenuItems.Add:
                        Console.Write("Name->");
                        string name = Console.ReadLine();
                        bool value = false;
                        decimal price = 0;
                        while (!value)
                        {
                            Console.Write("Price->");
                            string s = Console.ReadLine();
                            value = Decimal.TryParse(s, out decimal res);
                            price = res;
                        }
                        store.Add(new Product(name, price));
                        break;
                    case MenuItems.Remove:
                        Console.Write("Name->");
                        string nameofproduct = Console.ReadLine();
                        store.Remove(nameofproduct);
                        break;
                    case MenuItems.Load:
                        store.LoadFromFile();
                        break;
                    case MenuItems.Save:
                        store.SaveToFile();
                        break;
                    case MenuItems.Exit:
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            } while (chosenItem != MenuItems.Exit);
        }
    }
}
