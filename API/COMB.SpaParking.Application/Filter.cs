namespace COMB.SpaParking.Application;

public interface IFilter
{
    int Skip { get; }
    int Length { get; }
}

public abstract class Filter : IFilter
{
    public int Skip { get; set; }
    public int Length { get; set; } = 10;
}
