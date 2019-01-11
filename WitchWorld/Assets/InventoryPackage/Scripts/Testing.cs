using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InventoryData.Loot(InventoryData.itemDB.itemList[0]);
        InventoryData.Loot(InventoryData.itemDB.itemList[1]);
    }
}
