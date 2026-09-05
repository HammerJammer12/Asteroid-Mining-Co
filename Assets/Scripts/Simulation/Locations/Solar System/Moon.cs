public class Moon : Location, IOrbitable
{
    public Planet Parent { get; }
    public Orbit Orbit { get; }

    public Moon(
        string id,
        string name,
        StarSystem system,
        Planet parent,
        Orbit orbit
    ) : base(id, name, system)
    {
        Parent = parent;
        Orbit = orbit;
    }

    public RadialCoordinate GetCurrentPosition(float elapsedTime) => Parent.GetCurrentPosition(elapsedTime) + Orbit.GetPosition(elapsedTime);
}
