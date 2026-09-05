using System;
using UnityEngine;

/// <summary>
/// A Keplerian orbit around a star or other astral body.
/// Position/speed are computed from an elapsed time value
/// </summary>
public class Orbit
{
    /// <summary>
    /// Highest point of orbit
    /// </summary>
    public float Apoapsis { get; }
    /// <summary>
    /// Lowest point of orbit
    /// </summary>
    public float Periapsis { get; }
    /// <summary>
    /// Angle where periapsis sits
    /// </summary>
    public float ArgumentOfPeriapsis { get; }
    /// <summary>
    /// position at t=0
    /// </summary>
    public float MeanAnomalyAtEpoch { get;}
    public float Period { get; }

    private readonly float _semiMajorAxis;
    private readonly float _eccentricity;
    private readonly float _meanMotion;
    private readonly float _starGravParam;

    public Orbit(
        float apoapsis,
        float periapsis,
        float argumentOfPeriapsis,
        float meanAnomalyAtEpoch,
        float starGravParam
    )
    {
        Apoapsis = apoapsis;
        Periapsis = periapsis;
        ArgumentOfPeriapsis = argumentOfPeriapsis;
        MeanAnomalyAtEpoch = meanAnomalyAtEpoch;
        _starGravParam = starGravParam;

        _semiMajorAxis = (apoapsis + periapsis) / 2f;
        _eccentricity = (apoapsis - periapsis) / (apoapsis + periapsis);

        //Kepler's third law
        Period = 2f * Mathf.PI * Mathf.Sqrt(Mathf.Pow(_semiMajorAxis, 3) / starGravParam);
        _meanMotion = 2f * Mathf.PI / Period;
    }

    /// <returns>Where the body is after a given elapsed time since epoch</returns>
    public RadialCoordinate GetPosition(float elapsedTime)
    {
        float meanAnomaly = (MeanAnomalyAtEpoch + _meanMotion * elapsedTime) % (2f * Mathf.PI);
        float eccentricAnomaly = SolveKepler(meanAnomaly, _eccentricity);

        float trueAnomaly = 2f * Mathf.Atan2(
            Mathf.Sqrt(1 + _eccentricity) * Mathf.Sin(eccentricAnomaly / 2f),
            Mathf.Sqrt(1 - _eccentricity) * Mathf.Cos(eccentricAnomaly / 2f)
        );

        float radius = _semiMajorAxis * (1f - _eccentricity * Mathf.Cos(eccentricAnomaly));
        float angle = ArgumentOfPeriapsis + trueAnomaly;

        return new RadialCoordinate(radius, angle);
    }

    /// <returns>Instantaneous orbital speed at a given radius using vis-viva equaion</returns>
    public float GetSpeed(float radius)
    {
        return Mathf.Sqrt(_starGravParam * (2f / radius - 1f / _semiMajorAxis));
    }

    /// <summary>
    /// Solve Kepler's equation M = E - e sin E, 6 itterations should be more than enough for usage in this context
    /// </summary>
    /// <param name="meanAnomaly">Fraction of the orbital period that has elapsed since the body last passed its closest point to the periapsis (0 to 2pi radians)</param>
    /// <param name="eccentricity">How "squished" the elipse is</param>
    private static float SolveKepler(float meanAnomaly, float eccentricity)
    {
        float e = meanAnomaly;
        for (int i = 0; i < 6; i++)
        {
            e -= (e - eccentricity * Mathf.Sin(e) - meanAnomaly) / (1f - eccentricity * Mathf.Cos(e));
        }

        return e;
    }

}
