using System;
using UnityEngine;
public class Game : MonoBehaviour
{
    [SerializeField] private GameTick _tick;
    [SerializeField] private UniverseClock _clock;
    [SerializeField] private JobQueue _jobQueue;
    [SerializeField] private UIController _UIController;

    private StarSystem system;
    private FleetRegistry fleet;
  
    void Awake()
    {
        _clock.Init(_tick);
        _jobQueue.Init(_tick);

        system = TestStarSystemSetup.BuildSol();
        fleet = new FleetRegistry();
        SetupDummyFleet();

        _UIController.Init(_tick, fleet);
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
        Ship testShip = new Ship(_jobQueue, system.GetLocation("earth"));
        fleet.Add(testShip);
    }
}