using UnityEngine;

public class FleetDispatcher
{
    private readonly UniverseClock _clock;
    public FleetDispatcher(UniverseClock clock) => _clock = clock;

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

    public float TrySellAt(Ship ship, Market market, Player player, ItemStack itemsToSell)
    {
        if (ship.CurrentLocation is not IMarketLocation) return 0f;

        return market.SellItems(ship.CargoHold, player, itemsToSell);
    }
}
