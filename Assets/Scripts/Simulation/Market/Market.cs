public class Market 
{
    /// <summary>
    /// Sells as many items as exists in the inventory up until itemsToSell's quantity
    /// </summary>
    /// <param name="inventory">Inventory to sell from</param>
    /// <param name="itemsToSell">Item and Quantity to Sell</param>
    /// <returns>Credits gained from transaction</returns>
    public float TrySellItems(Inventory inventory, ItemStack itemsToSell)
    {
        float creditsToReturn = 0f;

        if (inventory.TryRemoveFromInventory(itemsToSell.Item, itemsToSell.Quantity, out ItemStack removed))
        {
            creditsToReturn += removed.Item.SellValue * removed.Quantity;
        }

        return creditsToReturn;
    }
    
}
