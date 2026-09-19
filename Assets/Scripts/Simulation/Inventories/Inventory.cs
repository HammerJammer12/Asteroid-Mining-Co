using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        float maxByVolume = (MaxVolume - UsedVolume) / itemStack.Item.Volume;
        float maxByMass = (MaxMass - TotalMass) / itemStack.Item.Mass;

        float accepted = Mathf.Min(itemStack.Quantity, maxByVolume, maxByMass);

        if (accepted > 0f)
        {
            int index = _items.FindIndex(stack => stack.Item.Id == itemStack.Item.Id);
            if (index != -1)
            {
                _items[index] = _items[index].WithAdded(accepted);
            }
            _items.Add(new ItemStack(itemStack.Item, accepted));
        }

        return new AddToInventoryResponse(itemStack.Quantity, accepted);
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
