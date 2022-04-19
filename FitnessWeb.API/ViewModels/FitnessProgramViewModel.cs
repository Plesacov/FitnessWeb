namespace FitnessWeb.API.ViewModels
{
    public class FitnessProgramViewModel
    {
        public int Id { get; set; }
        public FitnessTypeViewModel Type { get; set; }
        public List<TrainingViewModel> Trainings { get; set; }
        public List<FitnessTipViewModel> FitnessTips { get; set; }
    }
}
