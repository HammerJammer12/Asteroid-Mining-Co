using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipLocationDropdown : MonoBehaviour
{
    private List<Location> _locations;
    private TMP_Dropdown _dropdown;
    private FleetDispatcher _dispatcher;
    private Ship _ship;
    private GameObject _shipActionPanel;
    
    public void Init(List<Location> locations, FleetDispatcher dispatcher, Ship ship, GameObject shipActionPanel)
    {
        _locations = locations;
        _dispatcher = dispatcher;
        _ship = ship;
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
        _shipActionPanel = shipActionPanel;
        PopulateDropdown();
    }

    private void PopulateDropdown()
    {
        _dropdown.options.Clear();
        foreach (var location in _locations)
        {
            _dropdown.options.Add(new TMP_Dropdown.OptionData(location.Name));
        }
    }

    public void OnSelect(int index)
    {
        Location location = _locations[index];
        _dispatcher.TryTravelTo(_ship, location);
        _dropdown.Hide();
        _shipActionPanel.SetActive(false);
    }
}
