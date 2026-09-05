public class Star : Location, IGravitySource
{
    public float GravitationalParameter { get; }

    public Star(
        string id,
        string name,
        StarSystem system,
        float gravitationalParameter
    ) : base(id, name, system)
    {
        GravitationalParameter = gravitationalParameter;
    }
}
