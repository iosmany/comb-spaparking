namespace COMB.SpaParking.MVC.Models
{
    public enum NextPage { Next, Previous }
    public abstract class FilterModel
    {
        public NextPage? Next { get; set; }
        public int Page { get; set; }
        public int Length { get; set; } = 10;
    }
}
