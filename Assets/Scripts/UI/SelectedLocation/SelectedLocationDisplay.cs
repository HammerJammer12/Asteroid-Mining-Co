using UnityEngine;

public class SelectedLocationDisplay : MonoBehaviour
{
    private SelectedLocationText _selectedLocationText;

    public void Init()
    {
        _selectedLocationText = GetComponentInChildren<SelectedLocationText>();
    }

    public void UpdateSelectedLocationUI(Location location)
    {
        _selectedLocationText.SetSelectedLocation(location);
    }
}
