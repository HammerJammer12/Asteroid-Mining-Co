/// <summary>
/// Anyplace a ship can be at or travel to
/// </summary>
public abstract class Location
{
    public string Id { get; }
    public string Name { get; }
    public StarSystem System { get; }

    protected Location(string id, string name, StarSystem system)
    {
        Id = id;
        Name = name;
        System = system;
    }
}
