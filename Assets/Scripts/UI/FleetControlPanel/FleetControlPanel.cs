using System.Collections.Generic;
using UnityEngine;

public class FleetControlPanel : MonoBehaviour
{
    private FleetRegistry fleet;
    private GameObject ShipInfoDisplayPrefab;
    private List<ShipInfoDisplay> shipInfos;
    public void Init(FleetRegistry _fleet, GameObject _displayPrefab)
    {
        fleet = _fleet;
        ShipInfoDisplayPrefab = _displayPrefab;
        shipInfos = new();

        foreach (Ship ship in fleet.Ships)
        {
            AddShip(ship);
        }
    }

    public void AddShip(Ship ship)
    {
        ShipInfoDisplay newShipDisplay = Instantiate(ShipInfoDisplayPrefab, transform).GetComponent<ShipInfoDisplay>();
        shipInfos.Add(newShipDisplay);
        newShipDisplay.Init(shipInfos.Count, ship);
    }

    public void RenderFleetInformation()
    {
        foreach (ShipInfoDisplay shipInfo in shipInfos)
        {
            shipInfo.UpdateDisplay();
        }
    }
}
