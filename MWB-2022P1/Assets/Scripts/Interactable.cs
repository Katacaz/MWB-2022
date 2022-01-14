using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;

    public InventoryItem requiredItem;
    public bool removeItemOnUse;

    private Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        inv = Inventory.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        if (requiredItem != null)
        { //Item is Required
            if (inv.InventoryContains(requiredItem))
            {
                onInteract.Invoke();
                if (removeItemOnUse)
                {
                    inv.RemoveItem(requiredItem);
                }
            } else
            {
                inv.MissingItemWarning(requiredItem);
            }

        } else
        { //If no item is required
            onInteract.Invoke();
        }
        
    }
}
