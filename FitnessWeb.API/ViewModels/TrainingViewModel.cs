namespace FitnessWeb.API.ViewModels
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }
        public int Duration { get; set; }
        public string FitnessProgramName { get; set; }

    }
}
