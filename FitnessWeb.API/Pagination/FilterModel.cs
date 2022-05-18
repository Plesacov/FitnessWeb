using Newtonsoft.Json;

namespace FitnessWeb.API.Pagination
{
    public class FilterModel : FilterModelBase
    {
        public string Term { get; set; }
        public bool SortAsc { get; set; }
        public string SortedField { get; set; }

        public FilterModel() : base()
        {
            Limit = 3;
        }


        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, GetType());
        }
    }
}



