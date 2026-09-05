public class Planet : Location, IOrbitable, IGravitySource
{
    public Orbit Orbit { get; }
    public float GravitationalParameter { get; }

    public Planet(
        string id,
        string name,
        StarSystem system,
        Orbit orbit,
        float gravitationalParemeter
    ) : base (id, name, system)
    {
        Orbit = orbit;
        GravitationalParameter = gravitationalParemeter;
    }

    public RadialCoordinate GetCurrentPosition(float elapsedTime) => Orbit.GetPosition(elapsedTime);
}
