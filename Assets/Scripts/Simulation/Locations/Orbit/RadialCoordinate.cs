public class RadialCoordinate
{
    /// <summary>
    /// Radius from center point in kilometers
    /// </summary>
    public readonly float Radius;
    /// <summary>
    /// In Radians, measured from the star/center of a system
    /// </summary>
    public readonly float Angle;

    public RadialCoordinate(float _radius, float _angle)
    {
        Radius = _radius;
        Angle = _angle;
    }
}
