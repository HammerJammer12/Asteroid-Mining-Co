using UnityEngine;

public class UIController : GameTickSubscriber
{
    [Header("Fleet Control")]
    [SerializeField] private FleetControlPanel _fleetControlPanel;
    [SerializeField] private GameObject ShipInfoDisplayPrefab;
    private FleetRegistry _fleetRegistry;

    public void Init(GameTick _tick, FleetRegistry fleetRegistry)
    {
        base.Init(_tick);
        _fleetRegistry = fleetRegistry;

        _fleetControlPanel.Init(_fleetRegistry, ShipInfoDisplayPrefab);
    }
    protected override void HandleTick(float dt)
    {
        _fleetControlPanel.RenderFleetInformation();
    }
    
}
