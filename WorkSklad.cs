using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OstatokSklad
{
    public class WorkSklad
    {

        public void InputTovar()
        {
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tВвод товара на складе:\n");

            string tovarName, check;
            int price, count;

            do
            {
                Console.Write("\tНазвание товара = ");
                tovarName = Console.ReadLine();
            } while (tovarName == "");

            while (true)
            {
                Console.Write("\tЦена = ");
                check = Console.ReadLine();
                try
                {
                    price = int.Parse(check);
                    break;
                }
                catch
                {
                }
            };

            while (true)
            {
                Console.Write("\tКоличество = ");
                check = Console.ReadLine();
                try
                {
                    count = int.Parse(check);
                    break;
                }
                catch
                {
                }
            };

            using (var context = new UserContext())
            {
                context.Ostatki.Add(new Ostatok{TovarName = tovarName, Price = price, Count = count });
                context.SaveChanges();
                Console.WriteLine("\n\tИнформация добавлена.");
            }
        }

        public void EditTovar()
        {
            int i, number;
            string tovarName, check;
            int price, count;

            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tКорректировка товара на складе\n");
            Console.WriteLine("\n\tВыберите нужную строку:");
            Console.WriteLine("\t№ - Наименование - Цена - Остаток\n");

            while (true)
            {
                i = 0;
                using (var context = new UserContext())
                {

                    var ostatki = context.Ostatki.ToList();

                    if (ostatki.Count == 0)
                    {
                        return;
                    }

                    foreach (var item in ostatki)
                    {
                        i++;
                        Console.WriteLine($"\t{i} - {item.TovarName} {item.Price} {item.Count}");
                    }

                    while (true)
                    {
                        Console.Write("\tКод товара = ");
                        check = Console.ReadLine();
                        number = 0;
                        try
                        {
                            number = int.Parse(check);

                            if (1 <= number && number <= ostatki.Count)
                            {
                                break;
                            }
                        }
                        catch
                        {
                        }

                    }

                    do
                    {
                        Console.Write("\n\tНазвание товара = ");
                        tovarName = Console.ReadLine();
                    } while (tovarName == "");

                    while (true)
                    {
                        Console.Write("\tЦена = ");
                        check = Console.ReadLine();
                        try
                        {
                            price = int.Parse(check);
                            break;
                        }
                        catch
                        {
                        }
                    };

                    while (true)
                    {
                        Console.Write("\tКоличество = ");
                        check = Console.ReadLine();
                        try
                        {
                            count = int.Parse(check);
                            break;
                        }
                        catch
                        {
                        }
                    };

                    ostatki[number - 1].TovarName = tovarName;
                    ostatki[number - 1].Price = price;
                    ostatki[number - 1].Count = count;
                    context.SaveChanges();
                    Console.WriteLine("\n\tИнформация изменена.");
                    break;
                }
            }
        }

        public void DeleteTovar()
        {
            int i, number;
            string check;

            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tУдаление товара на складе\n");
            Console.WriteLine("\n\tВыберите нужную строку:");
            Console.WriteLine("\t№ - Наименование - Цена - Остаток\n");

            while (true)
            {
                i = 0;
                using (var context = new UserContext())
                {

                    var ostatki = context.Ostatki.ToList();

                    if (ostatki.Count == 0)
                    {
                        return;
                    }

                    foreach (var item in ostatki)
                    {
                        i++;
                        Console.WriteLine($"\t{i} - {item.TovarName} {item.Price} {item.Count}");
                    }

                    while (true)
                    {
                        Console.Write("\tКод товара = ");
                        check = Console.ReadLine();
                        number = 0;
                        try
                        {
                            number = int.Parse(check);

                            if (1 <= number && number <= ostatki.Count)
                            {
                                break;
                            }
                        }
                        catch
                        {
                        }

                    }

                    //ostatki.RemoveAt(number - 1);
                    context.Ostatki.Remove(ostatki[number - 1]);
                    context.SaveChanges();
                    Console.WriteLine("\n\tИнформация удалена.");
                    break;
                }
            }
        }

        public void ListTovars()
        {
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tСписок остатков товаров на складе:");
            Console.WriteLine("\tНаименование - Цена - Остаток\n");


            using (var context = new UserContext())
            {

                var ostatki = context.Ostatki.ToList();

                ostatki.Sort(delegate (Ostatok ost1, Ostatok ost2)
                { return ost1.TovarName.CompareTo(ost2.TovarName); });

                foreach (var item in ostatki)
                {
                    Console.WriteLine($"\t{item.TovarName} {item.Price} {item.Count}");
                }
            }
        }

    }
}
