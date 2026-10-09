using System.Linq;
using UnityEngine;

public class FleetDispatcher
{
    private readonly UniverseClock _clock;
    private Player _player;
    public FleetDispatcher(UniverseClock clock, Player player)
    {
        _clock = clock;
        _player = player;
    }

    public bool TryTravelTo(Ship ship, Location destination)
    {
        if (!ship.IsIdle || ship.CurrentLocation == destination) return false;
        
        Location origin = ship.CurrentLocation;
        float departureTime = (float)_clock.UniverseElapsedEpoch();
        var plan = TravelPlanCalculator.Calcualte(origin, destination, departureTime, 50f);

        int hoursPerTick = _clock.GetUniverseHoursPerTick();
        int durationTicks = Mathf.Max(1, Mathf.CeilToInt(plan.TravelTimeHours / hoursPerTick));
        float actualArrivalTime = departureTime + durationTicks * hoursPerTick;

        var travelJob = new TravelJob(ship, origin, destination, plan, 
            actualArrivalTime, durationTicks, hoursPerTick, 50f);

        ship.AssignJob(travelJob, ShipStatus.Travelling);
        return true;
    }

    public bool TryMineAt(Ship ship, AsteroidDeposit deposit, float yieldPerTick)
    {
        if (!ship.IsIdle) return false;
        if (ship.CurrentLocation != deposit.Field) return false;

        ship.AssignJob(new RecurringJob(new MiningJob(new MiningJobRequest(ship, deposit, yieldPerTick))), ShipStatus.Mining);
        return true;
    }

    public float TrySellAt(Ship ship, ItemStack itemsToSell)
    {
        if (!ship.IsIdle || ship.CurrentLocation is not IMarketLocation marketLocation) return 0f;
        return marketLocation.Market.SellItems(ship.CargoHold, _player, itemsToSell);
    }

    public float TrySellAllAt(Ship ship)
    {
        float total = 0f;
        foreach (ItemStack stack in ship.CargoHold.Items.ToList()) // copy: selling mutates the list
            total += TrySellAt(ship, stack);
        return total;
    }
}
