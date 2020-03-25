using System;


namespace Fitnes.BL.Model
{
    [Serializable]
   public  class Activiaty
    {
        public string Name { get; }

        public double CaloriesPerMinute { get; set; }

        public Activiaty(string name, double caloriesPerMinute)
        {
            //Проверка
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
            

        }

        public override string ToString()
        {
            return Name;
        }


    }
}
