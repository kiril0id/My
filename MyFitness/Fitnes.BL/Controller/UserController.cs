using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitnes.BL.Controller
{
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
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
        /// Получить список пользователей
        /// </summary>
        /// <returns>Пользователь приложения </returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
           
        public void Save()
        {
            Save(USERS_FILE_NAME, User);
        }
        
    }
}
