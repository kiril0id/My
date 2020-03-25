using System;


namespace Fitnes.BL.Model
{
    [Serializable]
     public class Exercise
    {
        public DateTime Start { get;  }
        public DateTime Finish { get; }
        public Activiaty Activiaty { get;  }

        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activiaty activiaty, User user)
        {
            // Проверка 
            Start = start;
            Finish = finish;
            Activiaty = activiaty;
            User = user;
        }
    }
}
