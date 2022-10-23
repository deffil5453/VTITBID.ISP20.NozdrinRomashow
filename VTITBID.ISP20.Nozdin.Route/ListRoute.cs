using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTITBId.ISP20.Nozdrin.Route
{
    class ListRoute : IComparable
    {
        private string _NameInitialRoute { get; set; }
        private string _NameFinalRoute { get; set; }
        public int NumberRoute { get; set; }

        public string NameInitialRoute
        {
            get { return _NameInitialRoute; }
            set
            {
                _NameInitialRoute = value;
            }
        }
        public string NameFinalRoute
        {
            get { return _NameFinalRoute; }
            set
            {
                _NameFinalRoute = value;
            }
        }
        private void EnteringRoute(int n, ListRoute[] route)
        {
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                route[i] = new ListRoute();
                num++;
                Random randomRoute = new Random();
                Console.WriteLine($"{num}-й маршрут");
                Console.WriteLine("введите название начального маршрута");
                _NameInitialRouteInput(route, i);

                Console.WriteLine("введите название конечного маршрута");
                NameFinalRouteInput(route, i);

                route[i].NumberRoute = randomRoute.Next(0, 1000);     
                Console.WriteLine("номер маршрута: " + route[i].NumberRoute);                

                Console.WriteLine("нажмите enter для продолжения");
                Console.ReadLine();
                Console.Clear();
            }
            SortListRoute(n, route);
        }
        private static void SortListRoute(int n, ListRoute[] route)
        {
            Array.Sort(route);
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                j++;
                Console.WriteLine($"список {j} маршрута");
                Console.WriteLine(route[i]);
                Console.WriteLine();
            }

            InformationRoute(n, route);
        }

        private static void InformationRoute(int n, ListRoute[] route)
        {
            Console.WriteLine("введите номер маршрута, чтобы узнать о нем информацию");
            int numroute = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (numroute == route[i].NumberRoute)
                {
                    count++;
                    Console.WriteLine(route[i].NameInitialRoute, route[i].NameFinalRoute);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("информация о данном маршруте отсутсвует");
            }
        }

        public void InformationOutput(int n, ListRoute[] listroute, ListRoute route)
        {
            bool continuation = true;
            while (continuation)
            {
                route.EnteringRoute(n, listroute);


                Console.WriteLine("продолжить?(да, нет)");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "да" or "Да":
                        continuation = true;
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
            return $"\nмаршрут: {NameInitialRoute}-{NameFinalRoute}\nномер маршрута {NumberRoute}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is ListRoute route) return NumberRoute.CompareTo(route.NumberRoute);
            else throw new ArgumentException("Ошибка");
        }
        private static string _NameInitialRouteInput(ListRoute[] route, int i)
        {
            bool prov;
            do
            {
                route[i].NameInitialRoute = Console.ReadLine();
                if (string.IsNullOrEmpty(route[i].NameInitialRoute) || string.IsNullOrWhiteSpace(route[i].NameInitialRoute))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода название начального маршрута ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return route[i].NameInitialRoute;
        }
        private static string NameFinalRouteInput(ListRoute[] route, int i)
        {
            bool prov;
            do
            {
                route[i].NameFinalRoute = Console.ReadLine();
                if (string.IsNullOrEmpty(route[i].NameFinalRoute) || string.IsNullOrWhiteSpace(route[i].NameFinalRoute))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода название конечного маршрута ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return route[i].NameFinalRoute;
        }
    }
}