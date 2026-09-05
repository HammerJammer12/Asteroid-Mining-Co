using UnityEngine;

/// <summary>
/// Single mineable pocket of resources within an AsteroidField. Currently Minimal, needs to be fleshed out once I handle inventory/storage
/// </summary>
public class AsteroidDeposit
{
    public ResourceType ResourceType { get; }
    private float _remainingYield;

    public AsteroidDeposit(ResourceType resourceType, float startingYield)
    {
        ResourceType = resourceType;
        _remainingYield = startingYield;
    }

    public bool IsDepleted() => _remainingYield <= 0f;

    public void Extract(float amount) => _remainingYield = Mathf.Max(0f, _remainingYield - amount);
}
