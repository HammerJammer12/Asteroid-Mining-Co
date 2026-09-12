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
                return ""; //TODO during when I add mining logic
        }

        return "something went wrong";
    }

    private static string GetTravellingText(Ship ship)
    {
        if (ship.CurrentJob is ITravelInfo travelInfo)
        {
            return $"En Route {travelInfo.Origin.Name} -> {travelInfo.Destination.Name} : {travelInfo.RemainingTimeHours:F1}h, {travelInfo.RemainingDistanceKm}km remaining";
        }

        return "Travel Info Unavailable";
    }
}
