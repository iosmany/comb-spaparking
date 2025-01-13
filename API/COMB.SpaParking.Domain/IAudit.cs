namespace COMB.SpaParking.Domain;

public interface IAudit
{
    public DateTime DateCreated { get; }
    void MarkCreated();
}
