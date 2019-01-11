using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryData {

    public static List<InventoryBox> inventories;
    public static IP2_ItemDB itemDB;
    public static InventoryBox defaultInventoryBox;
    public static InventoryItem holdingThis;
    public static InventorySlot fromThisSlot;
    // The default inventory box will be the one where all items default to when the loot script is called

    public static void Loot (InventoryItem inventoryItem)
    {
        bool success = defaultInventoryBox.AddItemToInventory(inventoryItem);
        Debug.Log(success);
    }
}
