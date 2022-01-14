using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvObj", menuName = "InventoryObjects")]
public class InventoryItem : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool unique;
}
