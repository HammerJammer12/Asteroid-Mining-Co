using UnityEngine;

/// <summary>
/// Single mineable pocket of resources within an AsteroidField. Currently Minimal, needs to be fleshed out once I handle inventory/storage
/// </summary>
public class AsteroidDeposit
{
    public Item Item { get; }
    private float _remainingYield;
    public readonly Location Field;

    public AsteroidDeposit(Item item, float startingYield, Location field)
    {
        Item = item;
        _remainingYield = startingYield;
        Field = field;
    }

    public bool IsDepleted() => _remainingYield <= 0f;

    public void Extract(float amount) => _remainingYield = Mathf.Max(0f, _remainingYield - amount);
}
