namespace FitnessWeb.API.ViewModels
{
    public class FitnessProgramViewModel
    {
        public string Type { get; set; }
        public List<TrainingViewModel> Trainings { get; set; }
        public List<FitnessTipViewModel> FitnessTips { get; set; }
    }
}
