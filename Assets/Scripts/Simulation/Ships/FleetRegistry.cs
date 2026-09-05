using System.Collections.Generic;
using System.Linq;

/// <summary>
/// List of Ships player owns
/// </summary>
public class FleetRegistry
{
    private readonly List<Ship> _ships = new();
    public IReadOnlyList<Ship> Ships => _ships;

    public void Add(Ship ship) => _ships.Add(ship);

    public IEnumerable<Ship> GetIdleShips() => _ships.Where(ship => ship.shipStatus == ShipStatus.Idle);
    public IEnumerable<Ship> GetShipsAt(Location location) => _ships.Where(ship => ship.CurrentLocation == location);
}
