using System;

public static class GetShipStatusText
{
    public static String Get(Ship ship)
    {
        switch (ship.shipStatus)
        {
            case ShipStatus.Idle:
                return $"Idling at {ship.CurrentLocation.Name}";
            case ShipStatus.Travelling:
                return $"En Route to ??";
            case ShipStatus.Mining:
                return ""; //TODO during when I add mining logic
        }

        return "something went wrong";
    }
}
