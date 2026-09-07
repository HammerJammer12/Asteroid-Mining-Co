/// <summary>
/// Travel Time and location of destination on arrival
/// </summary>
public readonly struct TravelPlan
{
    public readonly float TravelTimeHours;
    public readonly RadialCoordinate ArrivalPosition;

    //TODO: avoiding collisions with other objects in transit (the sun) probably outside of MVP scope, revist in future when I feel like dealing with it 9/6/26
    public TravelPlan(float travelTimeHours, RadialCoordinate arrivalPosition)
    {
        TravelTimeHours = travelTimeHours;
        ArrivalPosition = arrivalPosition;
    }
}