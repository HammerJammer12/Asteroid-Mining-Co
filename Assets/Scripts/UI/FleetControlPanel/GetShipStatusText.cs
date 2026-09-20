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
                return $"Mining Volume at {ship.CargoHold.UsedVolume} / {ship.CargoHold.MaxVolume} Mass At{ship.CargoHold.TotalMass} / {ship.CargoHold.MaxMass}";
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
}
