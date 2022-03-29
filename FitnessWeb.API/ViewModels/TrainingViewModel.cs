namespace FitnessWeb.API.ViewModels
{
    public class TrainingViewModel
    {
        public string Type { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }
        public int Duration { get; set; }
    }
}
