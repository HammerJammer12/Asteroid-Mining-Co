using System.Collections.Generic;
using System.Linq;

public enum AddResult
{
    AllAdded,
    PartiallyAdded,
    NoneAdded
}

public readonly struct AddToInventoryResponse
{
    public readonly AddResult Result;
    public readonly float AmountAdded;
    public readonly float AmountRejected;

    public AddToInventoryResponse(float requested, float accepted)
    {
        AmountAdded = accepted;
        AmountRejected = requested - accepted;
        Result = accepted <= 0f ? AddResult.NoneAdded
               : accepted >= requested ? AddResult.AllAdded
               : AddResult.PartiallyAdded;
    }
}


public class Inventory
{
    /// <summary>
    /// kgs
    /// </summary>
    public readonly float MaxMass;

    /// <summary>
    /// m^3
    /// </summary>
    public readonly float MaxVolume;

    private List<ItemStack> _items;

    public float UsedVolume => _items.Sum(s => s.Item.Volume * s.Quantity);
    public float TotalMass => _items.Sum(s => s.Item.Mass * s.Quantity);

    public Inventory(float maxMass, float maxVolume)
    {
        MaxMass = maxMass;
        MaxVolume = maxVolume;
        _items = new();
    }

    
    public AddToInventoryResponse TryAddToInventory(ItemStack itemStack)
    {   
        //TODO
        return new(0, 0);
    }



    /// <returns>True if the full requested quantity was available and removed.</returns>
    public bool TryRemoveFromInventory(Item item, float quantity, out ItemStack removed)
    {
        int index = _items.FindIndex(stack => stack.Item.Id == item.Id);

        if (index == -1 || _items[index].Quantity < quantity)
        {
            removed = default;
            return false;
        }

        float remaining = _items[index].Quantity - quantity;
        if (remaining <= 0f)
        {
            _items.RemoveAt(index);
        }
        else
        {
            _items[index] = new ItemStack(item, remaining);
        }

        removed = new ItemStack(item, quantity);
        return true;
    }
}
