using Fitnes.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitnes.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISE_FILE_NAME = "exercise.dat";
        private const string ACTIVIATIES_FILE_NAME = "activities.dat";
        public readonly User user;
        public List<Exercise> Exercises;
        public List<Activiaty> Activiaties;
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercise();
            Activiaties = GetAllActiviaty();
        }

        private List<Exercise> GetAllExercise()
        {
            return Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
        }
        private List<Activiaty> GetAllActiviaty()
        {
            return Load<List<Activiaty>>(ACTIVIATIES_FILE_NAME) ?? new List<Activiaty>();
        }
        private void Save()
        {
            Save(EXERCISE_FILE_NAME, Exercises);
            Save(ACTIVIATIES_FILE_NAME, Activiaties);
        }

        public void Add(Activiaty activity, DateTime begin, DateTime end)
        {
            var act = Activiaties.SingleOrDefault(a => a.Name == activity.Name);
            
            if (act == null)
            {
                Activiaties.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            
            Save();
        }
          

    }
}
