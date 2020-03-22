using System;
using System.Collections.Generic;
using System.Linq;


namespace Fitnes.BL.Model
{

    [Serializable]
    /// <summary>
    /// Приём пищи
    /// </summary>
     public class Eating
    {
        public DateTime Moment { get; set; }
        public Dictionary<Food,double> Foods { get; }
        public User User { get; set; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не определён", nameof(user));
            Moment=  DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();

        }
        public void Add(Food food, double weight)
        {

            
            var produc = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (produc == null)
            {
                Foods.Add(food,weight);
            }
            else
            {
                Foods[produc] += weight;
            }
        }
    }
}
