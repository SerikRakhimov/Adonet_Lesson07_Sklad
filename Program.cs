using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OstatokSklad.Services;

namespace OstatokSklad
{
    class Program
    {
        static void Main(string[] args)
        {



            //using (var contex = new UserContext())
            //{
            //    var ostatok = new Ostatok
            //    {
            //        TovarName = "Сыр",
            //        Price = 100,
            //        Count = 10
            //    };
            //    contex.Ostatki.Add(ostatok);
            //    contex.SaveChanges();

            //    var ostatki = contex.Ostatki.ToList();
            //    foreach (var item in ostatki)
            //    {
            //        Console.WriteLine(item.Count);
            //    }
            //}

            string menu;

            WorkSklad workSklad = new WorkSklad();
           

            Console.WriteLine("\n\t\t О С Т А Т К И  Н А  С К Л А Д Е");


            while (true)
            {
                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\n\t\tГлавное меню:\n");
                Console.WriteLine("\t1 - Добавить товар на склад");
                Console.WriteLine("\t2 - Откорректировать товар на складе");
                Console.WriteLine("\t3 - Удалить товар на складе");
                Console.WriteLine("\t4 - Вывести список товаров на складе");
                Console.WriteLine("\t0 - Выход\n");
                Console.Write("\tВаше выбор = ");
                menu = Console.ReadLine();

                if (menu == "0")
                {
                    break;
                }
                if (menu == "1")   // добавить
                {
                    workSklad.InputTovar();
                }
                else if (menu == "2")   // корректировать
                {
                    workSklad.EditTovar();
                }
                else if (menu == "3")   // удалить
                {
                    workSklad.DeleteTovar();
                }
                else if (menu == "4")   // список товаров
                {
                    workSklad.ListTovars();
                }
            }

        }
    }
}
