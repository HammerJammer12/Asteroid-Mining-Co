using UnityEngine;

public readonly struct RadialCoordinate
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

    public Vector2 ToCartesian() => new Vector2(Radius * Mathf.Cos(Angle), Radius *Mathf.Sin(Angle));
    public static RadialCoordinate FromCartesian(Vector2 point) => new RadialCoordinate(point.magnitude, Mathf.Atan2(point.y, point.x));

    public static RadialCoordinate operator + (RadialCoordinate a, RadialCoordinate b) => FromCartesian(a.ToCartesian() + b.ToCartesian());
}
