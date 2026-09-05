using System.Collections.Generic;

/// <summary>
/// Ties a star and everything that orbits it together. Two part set-up.
/// Build system, then the star, then link them.
/// </summary>
public class StarSystem
{
    public string Id { get; }
    public string Name { get; }
    public Star Star { get; private set; }

    private readonly List<Location> _locations = new();
    public IReadOnlyList<Location> Locations => _locations;

    public StarSystem(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetStar(Star star)
    {
        Star = star;
        _locations.Add(star);
    }

    public void AddLocation(Location location) => _locations.Add(location);
}
