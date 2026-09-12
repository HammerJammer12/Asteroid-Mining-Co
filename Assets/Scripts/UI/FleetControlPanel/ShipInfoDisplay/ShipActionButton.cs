using System;
using UnityEngine;

public class ShipActionButton : MonoBehaviour
{
    private ShipActionPanel shipActionPanel;

    public void Init()
    {
        shipActionPanel = GetComponentInChildren<ShipActionPanel>();
        shipActionPanel.gameObject.SetActive(false);
    }
    public void OnClick()
    {
        shipActionPanel.gameObject.SetActive(!shipActionPanel.gameObject.activeSelf);
    }
}
