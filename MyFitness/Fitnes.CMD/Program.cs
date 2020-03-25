using Fitnes.BL.Controller;
using Fitnes.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitnes.CMD
{
    class Program
    {
     

        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitnes.CMD.Languges.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello",culture));
            Console.WriteLine(resourceManager.GetString("EnterName",culture));

            var name = Console.ReadLine();
                                              
           
 

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender",culture)); 
                 var gender = Console.ReadLine();


                DateTime birthDate=ParseDate("дата рождения"); ;
                double weight = ParseDouble("Вес");

                double height = ParseDouble("Рост");


                userController.SetNewUserDate(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E -ввести приём пищи");
                Console.WriteLine("A- ввести упражнение");
                Console.WriteLine("Q - выйти");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:

                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key}-{item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.begin, exe.end);
                       

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activiaty} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:

                        Environment.Exit(0);
                        break;

                }


               
            }
           
          
        }

        private static (DateTime begin, DateTime end, Activiaty activity) EnterExercise()
        {
            Console.WriteLine("Введите назване упражнения:");
            var name = Console.ReadLine();
            var energyActivity = ParseDouble("Расход энергии");
            var activity = new Activiaty(name, energyActivity);
            var begin = ParseDate("Начало упражнения");
            var end = ParseDate("окончание упражнения ");
            return (begin, end, activity);
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

        private static DateTime ParseDate(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Введите {value}(dd.mm.yyyy) ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
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
