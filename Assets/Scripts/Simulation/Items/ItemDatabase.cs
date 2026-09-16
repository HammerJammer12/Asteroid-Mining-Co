using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Looks up an Item asset by its Id. 
/// </summary>
[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Items/Item Database")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<Item> _allItems;

    private Dictionary<string, Item> _byId;

    public Item GetById(string id)
    {
        _byId ??= _allItems.ToDictionary(item => item.Id);
        return _byId.TryGetValue(id, out var item) ? item : null;
    }

    #if UNITY_EDITOR
    [ContextMenu("Refresh From Project")]
    private void RefreshFromProject()
    {   
        var itemIds = UnityEditor.AssetDatabase.FindAssets("t:Item");
        _allItems = itemIds
            .Select(itemId => UnityEditor.AssetDatabase.LoadAssetAtPath<Item>(UnityEditor.AssetDatabase.GUIDToAssetPath(itemId)))
            .ToList();
            
        UnityEditor.EditorUtility.SetDirty(this);

        var duplicateIds = _allItems.GroupBy(item => item.Id).Where(g => g.Count() > 1);
        foreach (var group in duplicateIds)
        {
            Debug.LogWarning($"Duplicate item Id '{group.Key}' on: {string.Join(", ", group.Select(i => i.name))}");
        }
    }
    #endif
}