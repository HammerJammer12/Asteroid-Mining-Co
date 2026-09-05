/// <summary>
/// Any location that orbits a body
/// </summary>
public interface IOrbitable
{
    Orbit Orbit { get; }
    RadialCoordinate GetCurrentPosition(float elapsedTime); 
}
