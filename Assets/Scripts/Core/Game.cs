using System;
using System.Linq;
using UnityEngine;
public class Game : MonoBehaviour
{
    [SerializeField] private GameTick _tick;
    [SerializeField] private UniverseClock _clock;
    [SerializeField] private JobQueue _jobQueue;
    [SerializeField] private UIController _UIController;
    [SerializeField] private ItemDatabase itemDatabase;

    private StarSystem system;
    private FleetRegistry fleet;
    private FleetDispatcher dispatcher;
  
    void Awake()
    {
        _clock.Init(_tick);
        _jobQueue.Init(_tick);

        system = TestStarSystemSetup.BuildSol(itemDatabase.GetById("VQIMHKKK"));
        fleet = new FleetRegistry();
        dispatcher = new FleetDispatcher(_clock);
        SetupDummyFleet();

        _UIController.Init(_tick, fleet, system, dispatcher);
    }

    private void OnEnable()
    {
        _tick.OnTick += HandleTick;
    }

    private void OnDisable()
    {
        _tick.OnTick -= HandleTick;
    }

    private void HandleTick(float dt) {}

    private void SetupDummyFleet()
    {
        Location belt = system.GetLocation("belt-1");

        Ship testShip = new Ship(_jobQueue, system.GetLocation("earth"));
        fleet.Add(testShip);
    }
}