/// <summary>
/// Any location that can have other locations/bodies orbit it
/// </summary>
public interface IGravitySource
{
    /// <summary>
    /// G * mass equivelent, tuned for game context
    /// </summary>
    float GravitationalParameter { get; }
}
