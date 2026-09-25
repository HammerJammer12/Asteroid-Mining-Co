using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [Tooltip("Stable identifier for save data independent of the asset's file name.")]
    public string Id;
    public string DisplayName;
    public ItemCategory Category;

    [Tooltip("kg per unit.")]
    [Min(0.01f)]
    public float Mass = 1f;
    [Tooltip("m^3 per unit.")]
    [Min(0.01f)]
    public float Volume = 1f;
    [Min(1)]
    public float SellValue = 1f;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(Id))
        {
            Id = GenerateRandomId();
        }
    }

    private static readonly System.Random _random = new System.Random();

    private static string GenerateRandomId(int length = 8)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = chars[_random.Next(chars.Length)];
        }
        return new string(result);
    }
#endif
}

public enum ItemCategory
{
    RawResource,
    ProcessedMaterial,
    ShipModule,
    ShipHull
}