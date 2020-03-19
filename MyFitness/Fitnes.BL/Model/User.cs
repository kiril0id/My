using System;


namespace Fitnes.BL.Model
{/// <summary>
/// Пользователь
/// </summary>
   public  class User
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender gender { get; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirtDate { get; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Роси
        /// </summary>
        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Cоздать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birtDate">Дата рождения</param>
        /// <param name="weight">Вес</param>
        /// <param name="height">Рост</param>
        public User(string name, 
                    Gender gender, 
                    DateTime birtDate, 
                    double weight, 
                    double height)
        {
            #region Проверка условия
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть простым или  null", nameof(name));
            }
            if (gender==null)

            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(birtDate));
            }
            if(birtDate<DateTime.Parse("01.01.1900") || birtDate==DateTime.Now)
            {
                throw new ArgumentException("Не возможная дата рождения.", nameof(birtDate));
            }
            if (weight<=0)
            {
                throw new ArgumentException("Вас вес не может быть меньше нуля.",nameof(weight));
            }
            if (height<=0)
            {
                throw new ArgumentException("Ваш рост не может быть меньше нуля. ", nameof(height));
            }
            #endregion



            Name = name;
            this.gender = gender;
            BirtDate = birtDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
