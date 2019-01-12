using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBox : MonoBehaviour {

    public int slotsX;
    public int slotsY;
    public List<ItemType> presetSlotTypes;
    public List<InventorySlot> inventorySlots;
    public GameObject prefabSlot;
    private GridLayoutGroup gridLayoutGroup;
    public float paddingBounds;
    public bool defaultInventory;

    void Awake()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        inventorySlots = new List<InventorySlot>();
        if (defaultInventory)
        {
            InventoryData.defaultInventoryBox = this;
        }
    }

    void Start()
    {
        CreateInventory();
    }

    void CreateInventory()
    {
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = slotsX;
        for (int i = 0; i < slotsX * slotsY; i++)
        {
            GameObject goSlot = GameObject.Instantiate(prefabSlot, Vector3.zero, prefabSlot.transform.rotation);
            InventorySlot iSlot = goSlot.GetComponent<InventorySlot>();
            if (presetSlotTypes.Count > i)
            {
                iSlot.allowedItems = presetSlotTypes[i];
                iSlot.SetCellText(presetSlotTypes[i].ToString());
            }
            goSlot.transform.SetParent(this.transform);
            inventorySlots.Add(iSlot);
        }
        SetAllPaddingBounds();
        
        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, prefabSlot.GetComponent<RectTransform>().sizeDelta.x * slotsX + (paddingBounds * 2));
        this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, prefabSlot.GetComponent<RectTransform>().sizeDelta.y * slotsY + (paddingBounds * 2));
    }

    void SetAllPaddingBounds()
    {
        gridLayoutGroup.padding.right.Equals(paddingBounds);
        gridLayoutGroup.padding.left.Equals(paddingBounds);
        gridLayoutGroup.padding.top.Equals(paddingBounds);
        gridLayoutGroup.padding.bottom.Equals(paddingBounds);
    }

    public bool AddItemToInventory(InventoryItem itemToAdd)
    {
        bool foundSlot = false;
        for (int i = 0; i < inventorySlots.Count && foundSlot == false; i++)
        {
            if (inventorySlots[i].IsEmpty() && inventorySlots[i].ItemIsOfAllowedType(itemToAdd.itemType))
            {
                inventorySlots[i].AddItemToSlot(itemToAdd);
                foundSlot = true;
            }
        }
        return foundSlot;
    }
}
