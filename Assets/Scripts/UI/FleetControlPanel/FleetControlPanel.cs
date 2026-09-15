using System.Collections.Generic;
using UnityEngine;

public class FleetControlPanel : MonoBehaviour
{
    private FleetRegistry fleet;
    private GameObject ShipInfoDisplayPrefab;
    private List<ShipInfoDisplay> shipInfos;
    private List<Location> locations;
    public void Init(FleetRegistry _fleet, GameObject _displayPrefab, List<Location> _locations)
    {
        fleet = _fleet;
        ShipInfoDisplayPrefab = _displayPrefab;
        shipInfos = new();
        locations = _locations;

        foreach (Ship ship in fleet.Ships)
        {
            AddShip(ship);
        }
    }

    public void AddShip(Ship ship)
    {
        ShipInfoDisplay newShipDisplay = Instantiate(ShipInfoDisplayPrefab, transform).GetComponent<ShipInfoDisplay>();
        shipInfos.Add(newShipDisplay);
        newShipDisplay.Init(shipInfos.Count, ship, locations);
    }

    public void RenderFleetInformation()
    {
        foreach (ShipInfoDisplay shipInfo in shipInfos)
        {
            shipInfo.UpdateDisplay();
        }
    }
}
