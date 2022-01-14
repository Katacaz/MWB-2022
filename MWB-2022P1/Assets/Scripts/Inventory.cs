using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] private List<InventoryItem> playerInventory;

    private void Awake()
    {
        Instance = this;
    }
    public void AddItem(InventoryItem item)
    {
        if (item.unique)
        {
            if (playerInventory.Contains(item))
            {
                return;
            } else
            {
                playerInventory.Add(item);
            }
        } else
        {
            playerInventory.Add(item);
        }
    }
    public bool InventoryContains(InventoryItem item)
    {
        return playerInventory.Contains(item);
    }
    public void RemoveItem(InventoryItem item)
    {
        playerInventory.Remove(item);
    }

    public void MissingItemWarning(InventoryItem item)
    {
        Debug.Log("Item is missing from Inventory");
    }
}

