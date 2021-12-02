using System;
using System.Collections;
using System.Collections.Generic;

namespace LW_2_11
{
    class Program
    {
        static Random rn = new();

        static void Main(string[] args)
        {
            Task1Menu();
        }

        static void Task1Menu()
        {
            ArrayList collection = new ArrayList();
            string vvod = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Task 1 (ArrayList)\n");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("1 - Вывод коллекции");
                Console.WriteLine("2 - Добавление элемента в коллекцию");
                Console.WriteLine("3 - Удаление элемента из коллекции");
                Console.WriteLine("4 - Запрос 1 (вывести все библиотеки)");
                Console.WriteLine("5 - Запрос 2 (вывести количество фабрик)");
                Console.WriteLine("6 - Запрос 3 (вывести страховые, где колво клиентов > 70)");
                Console.WriteLine("7 - Демонстрация клонирования коллекции");
                Console.WriteLine("8 - Поиск элемента");
                Console.WriteLine("9 - Сортирoвка коллекции");

                vvod = Console.ReadLine();

                switch (vvod)
                {
                    case "0": break;
                    case "1": Print(collection); break;
                    case "2": collection = AddElement(collection); break;
                    case "3": collection = DeleteElement(collection); break;
                    case "4": Request1(collection); break;
                    case "5": Request2(collection); break;
                    case "6": Request3(collection); break;
                    case "7": CloneDemonstration(collection); break;
                    case "8": FindElement(collection); break;
                    case "9": collection = SortCollection(collection); break;
                }                
            } while (vvod != "0");
        }

        static void Print(ArrayList arr)
        {
            if (arr != null && arr.Count > 0)
            {
                Console.WriteLine("Вывод ArrayList");
                string res = "";
                foreach (var elem in arr)
                {
                    if (elem is Organization org)
                    {
                        res += org.Print() + "\n";
                    }
                }
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("ArrayList пуст");
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static ArrayList AddElement(ArrayList arr)
        {
            Console.WriteLine("Добавление элемента");

            Console.WriteLine("1 - Добавить экземпляр класса Organisation");
            Console.WriteLine("2 - Добавить экземпляр класса Factory");
            Console.WriteLine("3 - Добавить экземпляр класса InsuranceCompany");
            Console.WriteLine("4 - Добавить экземпляр класса ShipConstructingCompany");
            Console.WriteLine("5 - Добавить экземпляр класса Library");

            int vvod = CorrectConsoleInput.GetInt(1, 6);

            switch (vvod)
            {
                case 1: arr.Add(new Organization(ref rn)); break;
                case 2: arr.Add(new Factory(ref rn)); break;
                case 3: arr.Add(new InsuranceCompany(ref rn)); break;
                case 4: arr.Add(new ShipConstructingCompany(ref rn)); break;
                case 5: arr.Add(new Library(ref rn)); break;
            }

            Console.WriteLine("Добавление завершено. Нажмите любую клавишу...");
            Console.ReadKey();

            return arr;
        }

        static ArrayList DeleteElement(ArrayList arr)
        {
            Console.WriteLine("Удаление элемента");

            int ind = CorrectConsoleInput.GetInt(1, arr.Count + 1);
            ind--;

            arr.RemoveAt(ind);

            Console.WriteLine("Удаление завершено. Нажмите любую клавишу...");
            Console.ReadKey();

            return arr;
        }

        static void Request1(ArrayList arr)
        {
            // all libraries
            ArrayList req_list = new();

            foreach (var elem in arr)
            {
                if (elem is Library lib)
                {
                    req_list.Add(lib);
                }
            }

            Print(req_list);
        }

        static void Request2(ArrayList arr)
        {
            // number of factories
            int n = 0;

            foreach (var elem in arr)
            {
                if (elem is Factory)
                {
                    n++;
                }
            }

            Console.WriteLine($"Количество фабрик - {n}");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void Request3(ArrayList arr)
        {
            // insurance company with more than 70 
            ArrayList req_list = new();

            foreach (var elem in arr)
            {
                if (elem is InsuranceCompany ins && ins.NumberOfClients > 70)
                {
                    req_list.Add(ins);
                }
            }

            Print(req_list);
        }

        static void CloneDemonstration(ArrayList arr)
        {
            ArrayList clone_arr = (ArrayList)arr.Clone();

            Console.WriteLine("Исходный ArrayList");
            Print(arr);
            Console.WriteLine("Скопированный ArrayList");
            Print(clone_arr);
        }

        static void FindElement(ArrayList arr)
        {
            if (arr != null && arr.Count > 0)
            {
                Console.Write("Введите название организации: ");
                string name = Console.ReadLine();
                Console.Write("Введите город организации: ");
                string city = Console.ReadLine();

                bool isFind = false;
                for (int i = 0; i < arr.Count && !isFind; i++)
                {
                    if (arr[i] is Organization org)
                    {
                        isFind = org.Name == name && org.City == city;
                    }
                }

                Console.WriteLine($"Элемент найден: {isFind}");
            }
            else
            {
                Console.WriteLine("ArrayList пуст");
            }

            Console.WriteLine("Поиск завершен. Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static ArrayList SortCollection(ArrayList arr)
        {
            arr.Sort();

            Console.WriteLine("Сортировка завершена. Нажмите любую клавишу...");
            Console.ReadKey();

            return arr;
        }
    }
}