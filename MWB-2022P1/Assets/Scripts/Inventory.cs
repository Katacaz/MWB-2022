using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] private List<InventoryItem> playerInventory;
    private NotificationSystem notiSystem;

    public string itemAddedText = " has been added to Inventory.";
    public string itemRemovedText = " has been removed from Inventory.";

    private void Awake()
    {
        Instance = this;
        notiSystem = NotificationSystem.instance;
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
                ItemNotification(item, item.name + itemAddedText);
            }
        } else
        {
            playerInventory.Add(item);
            ItemNotification(item, item.name + itemAddedText);
        }
    }
    private void ItemNotification(InventoryItem item, string message)
    {
        Notification noti = notiSystem.CreateNotification(
            message, 
            item.Icon, Notification.NotiType.Inventory);
        notiSystem.RecieveNotification(noti);
    }
    public bool InventoryContains(InventoryItem item)
    {
        return playerInventory.Contains(item);
    }
    public void RemoveItem(InventoryItem item)
    {
        playerInventory.Remove(item);
        ItemNotification(item, item.name + itemRemovedText);
    }

    public void MissingItemWarning(InventoryItem item)
    {
        Debug.Log("Item is missing from Inventory");
    }
}

