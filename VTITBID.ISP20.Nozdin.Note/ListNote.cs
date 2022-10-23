using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTITBid.ISP20.Nozdrin.Note
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

    class ListNote : IComparable
    {

        public Birthday birthday = new Birthday();

        private string _FirstName { get; set; }

        public string FirstName
        {
            get { return _FirstName; }
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

        private string _PhoneNumber { get; set; }

        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }
        private void PersonDefinity(int n, ListNote[] person)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"введите {i + 1}-го человека");
                person[i] = new ListNote();

                Console.Write("введите имя:");
                FirstnamesInput(person, i);

                Console.Write("введите фамилию:");
                LastNamesInput(person, i);

                Console.WriteLine("введите номер телефона");
                PhoneNumbersInput(person, i);

                Console.WriteLine("введите день рождения(введите цифры)");
                InputDay(person, i);

                Console.WriteLine("введите месяц рождения(01 02..)");
                InputMonth(person, i);

                Console.WriteLine("введите год рожения (гггг)");
                InputYear(person, i);

                Console.Clear();
            }
            PersonWithdrawal(n, person);
        }
        private static void PersonWithdrawal(int n, ListNote[] person)
        {
            Array.Sort(person);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"информация о {i+1} человеке ");
                Console.WriteLine(person[i]);
                Console.WriteLine();
            }

            SearchPerson(n, person);
        }

        private static void SearchPerson(int n, ListNote[] person)
        {
            Console.WriteLine("введите месяц рождения человека или людей, которых вы хотите найти");
            int monthname = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (monthname == person[i].birthday.Month)
                {
                    Console.WriteLine(person[i]);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("данные о таком человеке отсутствуют");
            }
        }
        public void InformationOutput(int n, ListNote[] listNote, ListNote person)
        {
            while (true)
            {
                person.PersonDefinity(n, listNote);

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
            return $"\nИмя: {FirstName}\nФамилия: {LastName}\nНомер телефона: +7{PhoneNumber}\nдата рождения: {birthday.Day}.{birthday.Month}.{birthday.Year}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is ListNote person) return birthday.Day.CompareTo(person.birthday.Day);
            else throw new ArgumentException("Ошибка");
        }
        private static string FirstnamesInput(ListNote[] person, int i)
        {
            bool prov;
            do
            {
                person[i].FirstName = Console.ReadLine();
                if (string.IsNullOrEmpty(person[i].FirstName) || string.IsNullOrWhiteSpace(person[i].FirstName))
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
            return person[i].FirstName;
        }
        private static string LastNamesInput(ListNote[] person, int i)
        {
            bool prov;
            do
            {
                person[i].LastName = Console.ReadLine();
                if (string.IsNullOrEmpty(person[i].LastName) || string.IsNullOrWhiteSpace(person[i].LastName))
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
            return person[i].LastName;
        }
        private static string PhoneNumbersInput(ListNote[] person, int i)
        {
            bool prov;
            do
            {
                Console.Write("+7");
                person[i].PhoneNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(person[i].PhoneNumber) || string.IsNullOrWhiteSpace(person[i].PhoneNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите номер телефона ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return person[i].PhoneNumber;
        }
        private static int InputDay(ListNote[] person, int i)
        {
            bool prov;
            do
            {
                person[i].birthday.Day = InputDate();
                if (!(person[i].birthday.Day > 0 && person[i].birthday.Day <= 31))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите день ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return person[i].birthday.Day;
        }
        static int InputMonth(ListNote[] person, int i)
        {
            bool prov;
            do
            {
                person[i].birthday.Month = InputDate();
                if (!(person[i].birthday.Month > 0 && person[i].birthday.Month <= 12))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите месяц ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return person[i].birthday.Month;

        }
        static int InputYear(ListNote[] person, int i)
        {
            bool prov;
            do
            {
                person[i].birthday.Year = InputDate();
                if (!(person[i].birthday.Year >= 1875))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите год ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return person[i].birthday.Year;
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