using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : Location, IOrbitable
{
    public Orbit Orbit { get; }
    public List<AsteroidDeposit> Deposits { get; } = new();

    public AsteroidField(
        string id,
        string name,
        StarSystem system,
        Orbit orbit
    ) : base(id, name, system)
    {
        Orbit = orbit;
    }

    public RadialCoordinate GetCurrentPosition(float elapsedTime) => Orbit.GetPosition(elapsedTime);
}
