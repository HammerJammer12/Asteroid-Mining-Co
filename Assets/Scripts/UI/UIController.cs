using System.Linq;
using UnityEngine;

public class UIController : GameTickSubscriber
{
    [Header("Fleet Control")]
    [SerializeField] private FleetControlPanel _fleetControlPanel;
    [SerializeField] private GameObject ShipInfoDisplayPrefab;
    [SerializeField] private StarSystemVisualizer starSystemVisualizer;
    private FleetRegistry _fleetRegistry;
    private StarSystem _system;
    private FleetDispatcher _dispatcher;
    private UniverseClock _clock;

    public void Init(GameTick _tick, FleetRegistry fleetRegistry, StarSystem system, FleetDispatcher dispatcher, UniverseClock clock)
    {
        base.Init(_tick);
        _fleetRegistry = fleetRegistry;
        _system = system;
        _dispatcher = dispatcher;
        _clock = clock;

        _fleetControlPanel.Init(_fleetRegistry, ShipInfoDisplayPrefab, system.Locations.ToList(), dispatcher);
        _fleetControlPanel.gameObject.SetActive(false); //REMOVE DEBUGGING ONLY
        starSystemVisualizer.Init(_system, (float)_clock.UniverseElapsedEpoch());
    }
    protected override void HandleTick(float dt)
    {
        _fleetControlPanel.RenderFleetInformation();
        starSystemVisualizer.UpdateViews((float)_clock.UniverseElapsedEpoch());
    }
    
}
