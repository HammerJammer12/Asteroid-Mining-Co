using System.Collections.Generic;
using UnityEngine;

public class ShipInfoDisplay : MonoBehaviour
{
    private ShipNumber _shipNumber;
    private ShipStatusText _shipStatusText;
    private ShipActionButton _shipActionButton;

    private int number;
    private Ship ship;

    public void Init(int shipNumber, Ship _ship, List<Location> _locations)
    {
        ship = _ship;
        _shipNumber = GetComponentInChildren<ShipNumber>();
        _shipStatusText = GetComponentInChildren<ShipStatusText>();
        _shipActionButton = GetComponentInChildren<ShipActionButton>();

        _shipActionButton.Init(_locations);

        number = shipNumber;

        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        _shipNumber.UpdateText(number);
        _shipStatusText.UpdateText(GetShipStatusText.Get(ship));
    }
}
