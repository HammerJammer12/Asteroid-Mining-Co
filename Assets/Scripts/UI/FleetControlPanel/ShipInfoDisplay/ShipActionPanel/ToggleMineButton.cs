using System.Linq;
using TMPro;
using UnityEngine;

public class ToggleMineButton : MonoBehaviour
{
    private FleetDispatcher _dispatcher;
    private Ship _ship;
    private TMP_Text _buttonText;

    public void Init(Ship ship, FleetDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
        _ship = ship;
        _buttonText = GetComponentInChildren<TMP_Text>();
        UpdateButtonText();
    }

    public void OnClick()
    {
        if (_ship.shipStatus == ShipStatus.Mining)
        {
            _ship.CurrentJob.Cancel();
        }
        else if (_ship.CurrentLocation is AsteroidField field)
        {
            AsteroidDeposit deposit = field.Deposits.FirstOrDefault();
            if (deposit is not null)
            {
                _dispatcher.TryMineAt(_ship, deposit, 0.5f);
            }
        }

        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        _buttonText.text = _ship.shipStatus == ShipStatus.Mining ? "Stop Mining" : "Mine";
    }
}