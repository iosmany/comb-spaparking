using System.ComponentModel.DataAnnotations;

namespace COMB.SpaParking.Domain;

public interface IInactive
{
    bool Inactive { get; }
}

public abstract class Entity : IInactive
{
    public int Id { get; private set; }
    public bool Inactive { get; protected set; }

    public override bool Equals(object obj)
    {
        var other = obj as Entity;

        if (ReferenceEquals(other, null))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetRealType() != other.GetRealType())
            return false;

        if (Id == 0 || other.Id == 0)
            return false;

        return Id == other.Id;
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetRealType().ToString() + Id).GetHashCode();
    }

    private Type GetRealType()
    {
        return ProxyUtils.GetUnproxiedType(this) ?? throw new ArgumentNullException("Unproxied Type cannot be null");
    }
}

public static class ProxyUtils
{
    /// <summary>
    /// Get the unproxied type of an object based on EntityFrameworkCore Castle.Proxies
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Type? GetUnproxiedType(object obj)
    {
        var type = obj.GetType();
        if (type.AssemblyQualifiedName != null && type.AssemblyQualifiedName.Contains("Castle.Proxies"))
        {
            return type.BaseType;
        }
        return type;
    }
}
