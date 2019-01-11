using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public InventoryItem itemInSlot;
    public Image itemImage;
    public Color opaque;
    public Color transparent;
    public ItemType allowedItems;

    public void CellClick()
    {
        if (InventoryData.holdingThis != null)
        {
            SwapAttempt();
        } else
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        InventoryData.holdingThis = itemInSlot;
        InventoryData.fromThisSlot = this;
    }

    private void SwapAttempt()
    {
        if (ItemIsOfAllowedType(InventoryData.holdingThis.itemType))
        {
            if (IsEmpty())
            {
                Swap();
            } else if (InventoryData.fromThisSlot.ItemIsOfAllowedType(itemInSlot.itemType))
            {
                Swap();
            }
        }
    }

    private void Swap()
    {
        if (itemInSlot != null)
        {
            InventoryData.fromThisSlot.AddItemToSlot(itemInSlot);
            AddItemToSlot(InventoryData.holdingThis);
        }
        else
        {
            AddItemToSlot(InventoryData.holdingThis);
            InventoryData.fromThisSlot.RemoveItem();
        }
        InventoryData.holdingThis = null;
        InventoryData.fromThisSlot = null;
    }

    public void AddItemToSlot(InventoryItem inventoryItem)
    {
            itemInSlot = inventoryItem;
            itemImage.sprite = inventoryItem.itemImage;
            itemImage.color = opaque;
    }

    public void RemoveItem()
    {
        itemInSlot = null;
        itemImage.color = transparent;
    }

    public bool IsEmpty()
    {
        return (itemInSlot == null);
    }

    public bool ItemIsOfAllowedType(ItemType type)
    {
        bool isAllowed = false;
        if (allowedItems == ItemType.any)
        {
            isAllowed = true;
        } else if (allowedItems == type)
        {
            isAllowed = true;
        } else if (allowedItems == ItemType.none)
        {
            isAllowed = false;
        }
        return isAllowed;
    }
}
