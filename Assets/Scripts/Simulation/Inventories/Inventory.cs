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

    public List<ItemStack> Items { get; private set; }

    public float UsedVolume => Items.Sum(s => s.Item.Volume * s.Quantity);
    public float TotalMass => Items.Sum(s => s.Item.Mass * s.Quantity);

    public Inventory(float maxMass, float maxVolume)
    {
        MaxMass = maxMass;
        MaxVolume = maxVolume;
        Items = new();
    }

    
    public AddToInventoryResponse TryAddToInventory(ItemStack itemStack)
    {   
        float maxByVolume = itemStack.Item.Volume > 0f 
        ? (MaxVolume - UsedVolume) / itemStack.Item.Volume 
        : itemStack.Quantity;

        float maxByMass = itemStack.Item.Mass > 0f 
        ? (MaxMass - TotalMass) / itemStack.Item.Mass 
        : itemStack.Quantity;

        float accepted = Mathf.Min(itemStack.Quantity, maxByVolume, maxByMass);

        if (accepted > 0f)
        {
            int index = Items.FindIndex(stack => stack.Item.Id == itemStack.Item.Id);
            if (index != -1)
            {
                Items[index] = Items[index].WithAdded(accepted);
            }
            else
            {
                Items.Add(new ItemStack(itemStack.Item, accepted));
            }
        }

        return new AddToInventoryResponse(itemStack.Quantity, accepted);
    }



    /// <returns>True if the full requested quantity was available and removed.</returns>
    public bool TryRemoveFromInventory(Item item, float quantity, out ItemStack removed)
    {
        int index = Items.FindIndex(stack => stack.Item.Id == item.Id);

        if (index == -1 || Items[index].Quantity < quantity)
        {
            removed = default;
            return false;
        }

        float remaining = Items[index].Quantity - quantity;
        if (remaining <= 0f)
        {
            Items.RemoveAt(index);
        }
        else
        {
            Items[index] = new ItemStack(item, remaining);
        }

        removed = new ItemStack(item, quantity);
        return true;
    }
}
