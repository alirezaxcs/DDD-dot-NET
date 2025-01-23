using System;
using System.Diagnostics.CodeAnalysis;

namespace Wps.SharedKernel;

public interface IEntity<TId>
{
    public TId Id { get; init; }
}

public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>
{
    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; init; }

    public bool Equals(Entity<TId>? other) => other is not null && Id.Equals(other.Id);

    public override bool Equals(object? obj) => obj is Entity<TId> other && Equals(other);

    public override int GetHashCode() => Id.GetHashCode();


    public static bool operator ==(Entity<TId> x, Entity<TId> y)
    {
        return (x is null && y is null) || (ReferenceEquals(x, y) && EqualityComparer<TId>.Default.Equals(x.Id, y.Id))
           || ((x is not null && y is not null) && EqualityComparer<TId>.Default.Equals(x.Id, y.Id));
    }

    public static bool operator !=(Entity<TId> x, Entity<TId> y)
    {
        return !Equals(x, y);
    }
}
