using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipActionButton : MonoBehaviour
{
    private ShipActionPanel shipActionPanel;
    private ShipLocationDropdown shipLocationDropdown;

    public void Init(List<Location> _locations, FleetDispatcher _dispatcher, Ship _ship)
    {
        shipActionPanel = GetComponentInChildren<ShipActionPanel>();
        shipLocationDropdown = GetComponentInChildren<ShipLocationDropdown>();
        shipLocationDropdown.Init(_locations, _dispatcher, _ship, shipActionPanel.gameObject);
        shipActionPanel.gameObject.SetActive(false);
    }
    public void OnClick()
    {
        shipActionPanel.gameObject.SetActive(!shipActionPanel.gameObject.activeSelf);
    }
}
