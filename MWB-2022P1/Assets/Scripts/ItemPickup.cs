using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory inv;
    public InventoryItem item;
    public bool collected;

    public bool collectOnTouch;
    public bool hideOnPickup;

    // Start is called before the first frame update
    void Start()
    {
        inv = Inventory.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (hideOnPickup) 
        { 
            gameObject.SetActive(!collected);
        }
        
    }

    public void PickupItem()
    {
        inv.AddItem(item);
        collected = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collectOnTouch)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                PickupItem();
            }
        }
    }
}
