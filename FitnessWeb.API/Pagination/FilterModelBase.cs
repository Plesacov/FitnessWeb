namespace FitnessWeb.API.Pagination
{
    public abstract class FilterModelBase : ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public FilterModelBase()
        {
            Page = 1;
            Limit = 100;
        }

        public abstract object Clone();
    }
}
