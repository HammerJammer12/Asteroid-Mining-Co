using System;
using System.Linq;
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

        Debug.Log(system.Locations.ToList());

        _UIController.Init(_tick, fleet, system);
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

        DispatchTravelJob(testShip, testShip.CurrentLocation, belt);
    }

    //Delete in next commit, setup assigning these in UI
    private int _testShipSpeedKmPerHour = 25;
    private void DispatchTravelJob(Ship ship, Location origin, Location destination)
    {
        float departureTime = (float)_clock.UniverseElapsedEpoch();
        var plan = TravelPlanCalculator.Calcualte(origin, destination, departureTime, _testShipSpeedKmPerHour);
 
        int hoursPerTick = _clock.GetUniverseHoursPerTick();
        int durationTicks = Mathf.Max(1, Mathf.CeilToInt(plan.TravelTimeHours / hoursPerTick));
        float actualArrivalTime = departureTime + durationTicks * hoursPerTick;
 
        var travelJob = new TravelJob(ship, origin, destination, plan, actualArrivalTime,
            durationTicks, hoursPerTick, _testShipSpeedKmPerHour);
 
        ship.AssignJob(travelJob, ShipStatus.Travelling);
    }
}