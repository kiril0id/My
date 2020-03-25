using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class EatingController: ControllerBase
    {
        private const string FOODS_FILE_NAME= "food.dat";
        private const string EATING_FILE_NAME = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Этот пользоваетель не должен быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

           
        
        public void Add(Food food,double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product==null)
            {
                Foods.Add(food);
                Eating.Add(food,weight);
               

            }
            else
            {
                Eating.Add(product, weight);
                
            }
            Save();
        }
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }
        private  void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
