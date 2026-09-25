/// <summary>
/// Anyplace a ship can be at or travel to
/// </summary>
public abstract class Location
{
    public string Id { get; }
    public string Name { get; }
    public StarSystem System { get; }
    #nullable enable
    public Market? Market { get; }

    protected Location(string id, string name, StarSystem system, Market? market = null)
    {
        Id = id;
        Name = name;
        System = system;
        Market = market;
    }
}
