using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTITBID.ISP20.Nozdrin.Zodiac
{
    public struct Birthday
    {
        public int _Day { get; set; }
        private int _Month { get; set; }
        private int _Year { get; set; }
        public int Day
        {
            get { return _Day; }

            set
            {
                _Day = value;
            }
        }
        public int Month
        {
            get { return _Month; }

            set
            {
                _Month = value;
            }
        }
        public int Year
        {
            get { return _Year; }

            set
            {
                _Year = value;
            }
        }
    }
    class ListZodiacs : IComparable
    {

        public Birthday birthday = new Birthday();

        private string _FirstName { get; set; }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        private string _LastName { get; set; }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public string NameZod { get; set; }
        public static string SearchZaodiac(int birthday, int OneMonth)
        {
            if ((birthday >= 01 && (birthday <= 31)) && (OneMonth >= 01 && OneMonth <= 12))
            {
                switch (OneMonth)
                {
                    case 3:
                        if (birthday >= 21)
                        {
                            return "Овен";
                        }
                        else
                        {
                            return "Рыбы";
                        }

                    case 4:
                        if (birthday >= 21)
                        {
                            return "Телец";
                        }
                        else
                        {
                            return "Овен";
                        }

                    case 5:
                        if (birthday >= 21)
                        {
                            return "Близнецы";
                        }
                        else
                        {
                            return  "Телец";
                        }

                    case 6:
                        if (birthday >= 21)
                        {
                            return "Рак";
                        }
                        else
                        {
                            return "Близнецы";
                        }

                    case 7:
                        if (birthday >= 23)
                        {
                            return "Лев";
                        }
                        else
                        {
                            return "Рак";
                        }

                    case 8:
                        if (birthday >= 23)
                        {
                            return "Дева";
                        }
                        else
                        {
                            return "Лев";
                        }

                    case 9:
                        if (birthday >= 23)
                        {
                            return "Весы";
                        }
                        else
                        {
                            return "Дева";
                        }

                    case 10:
                        if (birthday >= 23)
                        {
                            return "Скорпион";
                        }
                        else
                        {
                            return "Весы";
                        }

                    case 11:
                        if (birthday >= 22)
                        {
                            return "Стрелец";
                        }
                        else
                        {
                            return "Скорпион";
                        }
                    case 12:
                        if (birthday >= 22)
                        {
                            return "Козерог";
                        }
                        else
                        {
                            return "Стрелец";
                        }

                    case 1:
                        if (birthday >= 20)
                        {
                            return "Водолей";
                        }
                        else
                        {
                            return "Козерог";
                        }

                    case 2:
                        if (birthday >= 19)
                        {
                            return "Рыбы";
                        }
                        else
                        {
                            return "Водолей";
                        }
                    default:
                        Console.WriteLine("ошибка возможно некоректно введены даты дня и месяца рождения");
                        break;
                }
            }
            else
            {
                Console.WriteLine("ошибочка, возможно некоректно введены даты дня и месяца");
            }


            return "знак зодиака";
        }
        private static void PersonDefinity(int n, ListZodiacs[] zodiacs)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-го человека");
                zodiacs[i] = new ListZodiacs();
                Console.WriteLine("введите имя: ");
                FirstnamesInput(zodiacs,i);
                Console.WriteLine("введите фамилию: ");
                LastNamesInput(zodiacs,i);

                Console.WriteLine("введите день рождения");
                InputDay(zodiacs,i);

                Console.WriteLine("введите месяц рождения(01 02..)");
                InputMonth(zodiacs, i);

                Console.WriteLine("введите год рождения (гггг)");
                InputYear(zodiacs, i);

                zodiacs[i].NameZod = SearchZaodiac(zodiacs[i].birthday.Day, zodiacs[i].birthday.Month);

                Console.Clear();
            }
            PersonWithdrawal(n, zodiacs);

        }
        private static void PersonWithdrawal(int n, ListZodiacs[] zodiacs)
        {

         
            Array.Sort(zodiacs);
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                j++;
                Console.WriteLine($"информация о {j} человеке ");
                if (string.IsNullOrEmpty(zodiacs[i].FirstName))
                {
                    zodiacs[i].FirstName = "Информация отстутствует";
                }

                if (string.IsNullOrEmpty(zodiacs[i].LastName))
                {
                    zodiacs[i].LastName = "Информация отстутствует";
                }
                Console.WriteLine(zodiacs[i]);
                Console.WriteLine();
            }

            ZodiacSearch(n, zodiacs);
        }

        private static void ZodiacSearch(int n, ListZodiacs[] zodiacs)
        {
            Console.WriteLine("введите знак зодиака человека");
            string zodiacname = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (zodiacname == zodiacs[i].NameZod)
                {
                    Console.WriteLine(zodiacs[i]);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("данные о таком человеке отсутствуют");
            }
        }
        public static void Conclusion(int n, ListZodiacs[] zodiacs)
        {
            while (true)
            {
                PersonDefinity(n, zodiacs);

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
            return $"Имя: {FirstName}\nФамилия: {LastName}\nДата рождения: {birthday.Day}.{birthday.Month}.{birthday.Year}\nЗнак зодиака: {NameZod}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is ListZodiacs zodiacs) return birthday.Day.CompareTo(zodiacs.birthday.Day);
            else throw new ArgumentException("Ошибка");
        }

        private static string FirstnamesInput(ListZodiacs[] zodiacs, int i)
        {
            bool prov;
            do
            {
                zodiacs[i].FirstName = Console.ReadLine();
                if (string.IsNullOrEmpty(zodiacs[i].FirstName) || string.IsNullOrWhiteSpace(zodiacs[i].FirstName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите имя ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return zodiacs[i].FirstName;
        }
        private static string LastNamesInput(ListZodiacs[] zodiacs, int i)
        {
            bool prov;
            do
            {
                zodiacs[i].LastName = Console.ReadLine();
                if (string.IsNullOrEmpty(zodiacs[i].LastName) || string.IsNullOrWhiteSpace(zodiacs[i].LastName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите фамилию ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return zodiacs[i].LastName;
        }
        private static int InputDay(ListZodiacs[] zodiacs, int i)
        {
            bool prov;
            do
            {
                zodiacs[i].birthday.Day = InputDate();
                if (!(zodiacs[i].birthday.Day > 0 && zodiacs[i].birthday.Day <= 31))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите день рождения ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return zodiacs[i].birthday.Day;
        }
        private static int InputMonth(ListZodiacs[] zodiacs, int i)
        {
            bool prov;
            do
            {
                zodiacs[i].birthday.Month = InputDate();
                if (!(zodiacs[i].birthday.Month > 0 && zodiacs[i].birthday.Month <= 12))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите месяц рождения ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return zodiacs[i].birthday.Month;

        }
        private static int InputYear(ListZodiacs[] zodiacs, int i)
        {
            bool prov;
            do
            {
                zodiacs[i].birthday.Year = InputDate();
                if (!(zodiacs[i].birthday.Year >= 1875))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите год рождения ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return zodiacs[i].birthday.Year;
        }
        private static int InputDate()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int i))
                {
                    return i;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка ввода! Введите еще раз: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
    }
}