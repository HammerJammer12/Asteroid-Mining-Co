using UnityEngine;

/// <summary>
/// Moves a ship to a destination once the calculated travel duration elapses.
/// </summary>
public class TravelJob : TimedJob, ITravelInfo
{
    private readonly Ship _ship;
    private readonly TravelPlan _plan;
    private readonly float _actualArrivalTime;
    private readonly int _hoursPerTick;
    private readonly float _speedKmPerHour;

    public Location Origin { get; }
    public Location Destination { get; }

    public float RemainingTimeHours => RemainingTicks * _hoursPerTick;
    public float RemainingDistanceKm => RemainingTimeHours * _speedKmPerHour;

    public TravelJob(
        Ship ship,
        Location origin,
        Location destination,
        TravelPlan plan,
        float actualArrivalTime,
        int durationTicks,
        int hoursPerTick,
        float speedKmPerHour
    ) : base(durationTicks)
    {
        _ship = ship;
        Origin = origin;
        Destination = destination;
        _plan = plan;
        _actualArrivalTime = actualArrivalTime;
        _hoursPerTick = hoursPerTick;
        _speedKmPerHour = speedKmPerHour;
    }

    protected override bool Validate() => true;

    protected override void Apply() => _ship.SetLocation(Destination);

    protected override void OnComplete()
    {
        RadialCoordinate actualPosition = Destination is IOrbitable orbitable
            ? orbitable.GetCurrentPosition(_actualArrivalTime)
            : new RadialCoordinate(0f, 0f);

        Debug.Log($"[TravelJob] Arrived at {Destination.Name} at t={_actualArrivalTime:F1}h. " +
            $"Predicted position was r={_plan.ArrivalPosition.Radius:F1}km, θ={_plan.ArrivalPosition.Angle:F2}rad : " +
            $"actual position is r={actualPosition.Radius:F1}km, θ={actualPosition.Angle:F2}rad.");
    }
}