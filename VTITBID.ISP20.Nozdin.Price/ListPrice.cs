using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTITBId.ISP20.Nozdrin.Price
{
    class ListPrice : IComparable
    {
        private string _ProductName { get; set; }
        private string _ShopName { get; set; }
        private double _ProductPrice { get; set; }
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
            }
        }
        public string ShopName
        {
            get { return _ShopName; }
            set
            {
                _ShopName = value;
            }
        }
        public double ProductPrice
        {
            get { return _ProductPrice; }
            set
            {
                _ProductPrice = value;
            }
        }
        public void FillStore(int n, ListPrice[] listPrices)
        {
            for (int i = 0; i < n; i++)
            {
                listPrices[i] = new ListPrice();
                Console.WriteLine("введите название товара");
                ShopNameInput(listPrices,i);

                Console.WriteLine("введите название магазина");
                ProductNameInput(listPrices, i);

                Console.WriteLine("введите стоимость товара");
                FullInputPrice(listPrices, i);

                Console.Clear();
            }
            StoreSort(n, listPrices);
        }

        public void StoreSort(int n, ListPrice[] listPrices)
        {
            Array.Sort(listPrices);

            Console.WriteLine("сортированный список: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(listPrices[i]);
                Console.WriteLine();
            }
            Console.WriteLine();

            InformationPrice(listPrices);
        }

        private static void InformationPrice(ListPrice[] listPrices)
        {
            Console.WriteLine("Введите название магазина для вывода товаров");
            string nameShop = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < listPrices.Length; i++)
            {
                if (listPrices[i].ShopName == nameShop)
                {
                    Console.WriteLine(listPrices[i]);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Такого магазина нет в списках");
            }
        }
        public void InformationOutput(int n, ListPrice[] listPrices, ListPrice price)
        {
            while (true)
            {
                price.FillStore(n, listPrices);

                Console.WriteLine("продолжить?(да, нет)");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "да":
                        Console.Clear();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"Название магазина: {ShopName}\n Название товара: {ProductName}\n цена в рублях:{ProductPrice}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is ListPrice listRusPrice) return ShopName.CompareTo(listRusPrice.ShopName);
            else throw new ArgumentException("Ошибка");
        }

        private static string ShopNameInput(ListPrice[] listPrices, int i)
        {
            bool prov;
            do
            {
                listPrices[i].ShopName = Console.ReadLine();
                if (string.IsNullOrEmpty(listPrices[i].ShopName) || string.IsNullOrWhiteSpace(listPrices[i].ShopName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите название товара ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return listPrices[i].ShopName;
        }
        private static string ProductNameInput(ListPrice[] listPrices, int i)
        {
            bool prov;
            do
            {
                listPrices[i].ProductName = Console.ReadLine();
                if (string.IsNullOrEmpty(listPrices[i].ProductName) || string.IsNullOrWhiteSpace(listPrices[i].ProductName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите название магазина ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return listPrices[i].ProductName;
        }
        private static double FullInputPrice(ListPrice[] listPrices, int i)
        {
            bool prov;
            do
            {
                listPrices[i].ProductPrice = InputPrice();
                if (!(listPrices[i].ProductPrice > 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка ввода! Введите цену товара еще раз: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return listPrices[i].ProductPrice;
        }
        private static double InputPrice()
        {
            while (true)
            {
                double i;
                if (double.TryParse(Console.ReadLine(), out i))
                    return (int)i;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка ввода! Введите цену товара еще раз: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }                    
            }
        }
    }
}