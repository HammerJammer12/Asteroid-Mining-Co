/// <summary>
/// Exposes Travel Info for UI
/// </summary>
public interface ITravelInfo
{
    Location Origin { get; }
    Location Destination { get; }
    float RemainingTimeHours { get; }
    float RemainingDistanceKm { get; }
}