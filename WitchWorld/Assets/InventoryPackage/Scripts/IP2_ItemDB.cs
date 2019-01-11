using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IP2_ItemDB : MonoBehaviour {

    public List<InventoryItem> itemList;

    void Awake()
    {
        InventoryData.itemDB = this;
    }
}
