public class SpaceStation : Location, IOrbitable
{
    public Orbit Orbit { get; }
    //private readonly faciltiies list

    public SpaceStation(
        string id,
        string name,
        StarSystem system,
        Orbit orbit
    ) : base(id, name, system)
    {
        Orbit = orbit;
    }

    public RadialCoordinate GetCurrentPosition(float elapsedTime) => Orbit.GetPosition(elapsedTime);
    //addFacility void
}
