using Unity;
using UnityEngine;

public static class GetShipStatusText 
{
    public static string Get(Ship ship)
    {
        switch (ship.shipStatus)
        {
            case ShipStatus.Idle:
                return $"Idling at {ship.CurrentLocation.Name}";
            case ShipStatus.Travelling:
                return GetTravellingText(ship);
            case ShipStatus.Mining:
                return GetMiningText(ship);
        }

        return "something went wrong";
    }

    private static string GetTravellingText(Ship ship)
    {
        if (ship.CurrentJob is ITravelInfo travelInfo)
        {
            return $"En Route {travelInfo.Origin.Name} -> {travelInfo.Destination.Name} : {TimeTextConverter.HoursToText((int)travelInfo.RemainingTimeHours)}, {travelInfo.RemainingDistanceKm}km remaining";
        }

        return "Travel Info Unavailable";
    }

    private static string GetMiningText(Ship ship)
    {
        Debug.Log(ship.CurrentJob);
        if (ship.CurrentJob is RecurringJob recurring && recurring.InnerJob is IMiningInfo miningInfo)
        {
            return $"Mining {miningInfo.Ore} : {miningInfo.DepositRemainingDisplay} left in deposit";
        }

        return "Mining Info Unavailable";
    }
}
