using Fitnes.BL.Controller;
using System;


namespace Fitnes.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветсвует прложение FitnessBlog");

            Console.WriteLine("Введите имя пользователя ");
            var name = Console.ReadLine();
                                              
           
 

            var Controller = new UserController(name);
            if (Controller.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();


                DateTime birthDate=ParseDate(); ;
                double weight = ParseDouble("Вес");

                double height = ParseDouble("Рост");
                 

                Controller.SetNewUserDate(gender, birthDate, weight, height);
            }
            Console.WriteLine(Controller.CurrentUser);

            Console.ReadKey();
          
        }

        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения(dd.mm.yyyy) ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не верный формат даты");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");

                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат {name}а");
                }
            }




        }
    }
}
