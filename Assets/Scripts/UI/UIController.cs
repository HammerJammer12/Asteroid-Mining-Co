using System.Linq;
using UnityEngine;

public class UIController : GameTickSubscriber
{
    [Header("Fleet Control")]
    [SerializeField] private FleetControlPanel _fleetControlPanel;
    [SerializeField] private GameObject ShipInfoDisplayPrefab;
    private FleetRegistry _fleetRegistry;
    private StarSystem _system;
    private FleetDispatcher _dispatcher;

    public void Init(GameTick _tick, FleetRegistry fleetRegistry, StarSystem system, FleetDispatcher dispatcher)
    {
        base.Init(_tick);
        _fleetRegistry = fleetRegistry;
        _system = system;
        _dispatcher = dispatcher;

        _fleetControlPanel.Init(_fleetRegistry, ShipInfoDisplayPrefab, system.Locations.ToList(), dispatcher);
    }
    protected override void HandleTick(float dt)
    {
        _fleetControlPanel.RenderFleetInformation();
    }
    
}
