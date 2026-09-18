public readonly struct ItemStack
{
    public readonly Item Item;
    public readonly float Quantity;

    public ItemStack(Item item, float quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public float TotalMass => Item.Mass * Quantity;
    public float TotalVolume => Item.Volume * Quantity;
}