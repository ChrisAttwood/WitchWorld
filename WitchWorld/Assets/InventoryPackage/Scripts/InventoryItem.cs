using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Item")]
public class InventoryItem : ScriptableObject {

    public string itemName;
    public Sprite itemImage;
    public int itemID;
    public ItemType itemType;
}
