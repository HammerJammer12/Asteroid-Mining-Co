using System.Collections.Generic;
using UnityEngine;

public class FleetControlPanel : MonoBehaviour
{
    private FleetRegistry fleet;
    private GameObject ShipInfoDisplayPrefab;
    private List<ShipInfoDisplay> shipInfos;
    private List<Location> locations;
    private FleetDispatcher dispatcher;
    public void Init(FleetRegistry _fleet, GameObject _displayPrefab, List<Location> _locations, FleetDispatcher _dispatcher)
    {
        fleet = _fleet;
        ShipInfoDisplayPrefab = _displayPrefab;
        shipInfos = new();
        locations = _locations;
        dispatcher = _dispatcher;

        foreach (Ship ship in fleet.Ships)
        {
            AddShip(ship);
        }
    }

    public void AddShip(Ship ship)
    {
        ShipInfoDisplay newShipDisplay = Instantiate(ShipInfoDisplayPrefab, transform).GetComponent<ShipInfoDisplay>();
        shipInfos.Add(newShipDisplay);
        newShipDisplay.Init(shipInfos.Count, ship, locations, dispatcher);
    }

    public void RenderFleetInformation()
    {
        foreach (ShipInfoDisplay shipInfo in shipInfos)
        {
            shipInfo.UpdateDisplay();
        }
    }
}
