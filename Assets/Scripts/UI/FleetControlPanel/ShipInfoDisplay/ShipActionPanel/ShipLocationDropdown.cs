using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipLocationDropdown : MonoBehaviour
{
    private List<Location> _locations;
    private TMP_Dropdown _dropdown;
    
    public void Init(List<Location> locations)
    {
        _locations = locations;
        _dropdown = GetComponentInChildren<TMP_Dropdown>();
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

    private void OnSelect()
    {
        Location location = _locations[_dropdown.value];
    }
}
