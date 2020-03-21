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
                Save();

            }
           
           
        }
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        private  void Save()
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

                
                if (!fileStream.CanSeek)
                {
                    List<User> users = (List<User>)formator.Deserialize(fileStream);
                    return users;
                }
                else
                {
                    return new List<User>();
                } 
                //TODO : что делать если пользователя не прочитали
            }

        }
    }
}
