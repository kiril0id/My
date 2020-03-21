﻿using System;


namespace Fitnes.BL.Model
{/// <summary>
 /// Пользователь
 /// </summary>

    [Serializable]
    public class User
    {
       
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Роси
        /// </summary>
        public double Height { get; set; }


        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Cоздать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Проверка условия
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть простым или  null", nameof(name));
            }
            if (gender == null)

            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(birthDate));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate == DateTime.Now)
            {
                throw new ArgumentException("Не возможная дата рождения.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вас вес не может быть меньше нуля.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Ваш рост не может быть меньше нуля. ", nameof(height));
            }
            #endregion



            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пусым или null", nameof(name));

            }
            Name = name;
        }
       
        public override string ToString()
        {
            return Name+" "+ Age;
        }

    }
}
