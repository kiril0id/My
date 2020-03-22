using Fitnes.BL.Controller;
using Fitnes.BL.Model;
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
                                              
           
 

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();


                DateTime birthDate=ParseDate(); ;
                double weight = ParseDouble("Вес");

                double height = ParseDouble("Рост");


                userController.SetNewUserDate(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E -ввести приём пищи");
           
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key== ConsoleKey.E)
            {
                var foods=EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key}-{item.Value}");
                }
            }
            Console.ReadKey();
          
        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта:");
            var food = Console.ReadLine();

            var calories = ParseDouble("Калорийность");
            var proteins = ParseDouble("Белки");
            var fats = ParseDouble("Жиры");
            var carbohydrates = ParseDouble("Углеводы");

            Console.Write("Введите ");
            var weight = ParseDouble("вес порции");
            var product = new Food(food,calories,proteins,fats,carbohydrates);
            return  (Food: product, Weight: weight);
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
                Console.Write($"Введите {name}: ");

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
