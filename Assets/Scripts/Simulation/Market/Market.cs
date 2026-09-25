public class Market 
{
    /// <summary>
    /// Sells as many items as exists in the inventory up until itemsToSell's quantity
    /// </summary>
    /// <param name="inventory">Inventory to sell from</param>
    /// <param name="itemsToSell">Item and Quantity to Sell</param>
    /// <returns>Credits gained from transaction</returns>
    public float SellItems(Inventory inventory, Player player, ItemStack itemsToSell)
    {
        if (!inventory.TryRemoveFromInventory(itemsToSell.Item, itemsToSell.Quantity, out ItemStack removed)) return 0f;

        float creditsToReturn = removed.Item.SellValue * removed.Quantity;
        player.AddCredits(creditsToReturn);
        return creditsToReturn;
    }
    
}
