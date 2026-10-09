using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellAtMarketButton : MonoBehaviour
{
    private FleetDispatcher _dispatcher;
    private Ship _ship;
    private Button _button;

    public void Init(Ship ship, FleetDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        _ship = ship;
        _button = GetComponent<Button>();
    }

    public void OnClick() => _dispatcher.TrySellAllAt(_ship);

    public void Refresh() => _button.interactable = _ship.IsIdle && _ship.CurrentLocation is IMarketLocation;

    
}
