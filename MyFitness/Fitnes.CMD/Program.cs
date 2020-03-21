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

            Console.WriteLine(Controller.CurrentUser);

            Console.ReadKey();
          
        } 
    }
}
