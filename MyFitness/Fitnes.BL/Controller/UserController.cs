using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class UserController
    {
        public List<User> User { get; }

        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        public UserController(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Имя пользователя не может бысть пустым", nameof(username));
            }
            User = GetUsersData();
            CurrentUser = User.SingleOrDefault(u => u.Name == username);
            if (CurrentUser==null)
            {
                CurrentUser = new User(username);
                User.Add(CurrentUser);
                IsNewUser = true;
                Save();

            }
           
           
        }

        public void SetNewUserDate(string genderName, DateTime birthDate, double weight=1, double height=1)
        {
            //Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }





        /// <summary>
        /// Сохранение в файл
        /// </summary>
        public   void Save()
        {
            var formator = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formator.Serialize(fileStream, User);
            }

        }
        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <returns>Пользователь приложения </returns>
        private List<User>  GetUsersData()
        {
            var formator = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {



                if (fileStream.Length!=0)
                {
                    List<User> users = (List<User>)formator.Deserialize(fileStream);
                    return users;
                }
                else
                {
                    return new List<User>();
                }


            
            }

        }
    }
}
