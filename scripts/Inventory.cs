using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    ItemString ItemStr;
    // Inventory Management (Set Inventory Weight/Space, Earn/Delete/Convert the Items.)
    [SerializeField]
    private int InventoryWeight = 100;
    private int InventorySpace = 100;
    public List<String> InventoryItemKey = new List<String>();
    public List<String> InventoryItemName = new List<String>();
    public List<String> InventoryItemDesc = new List<String>();
    public List<String> InventoryItemWeight = new List<String>();
    void Start()
    {
        ItemStr = GetComponent<ItemString>();
    }
    public void SetInventoryStatus(int weight, int space)
    {
        InventoryWeight = weight;
        InventorySpace = space;
    }
    public void AddItems(int itemkey, int itemamount)
    {
        for (int i = 0; i <= itemamount; i++)
        {
            InventoryItemKey.Add(ItemStr.ItemKey[itemkey]);
            InventoryItemName.Add(ItemStr.ItemName[itemkey]);
            InventoryItemDesc.Add(ItemStr.ItemDesc[itemkey]);
            InventoryItemWeight.Add(ItemStr.ItemWeight[itemkey]);
        }
    }
    public void DeleteItems(int itemkey, int itemamount)
    {
        for (int i = 0; i <= itemamount; i++)
        {
            InventoryItemKey.Remove(ItemStr.ItemKey[itemkey]);
            InventoryItemName.Remove(ItemStr.ItemName[itemkey]);
            InventoryItemDesc.Remove(ItemStr.ItemDesc[itemkey]);
            InventoryItemWeight.Remove(ItemStr.ItemWeight[itemkey]);
        }
    }
    public void ExchangeItems(int passeditemkey, int resultitemkey, int passeditemamount, int resultitemamount)
    {
        for (int i = 0; i <= resultitemamount; i++)
        {
            InventoryItemKey.Add(ItemStr.ItemKey[resultitemkey]);
            InventoryItemName.Add(ItemStr.ItemName[resultitemkey]);
            InventoryItemDesc.Add(ItemStr.ItemDesc[resultitemkey]);
            InventoryItemWeight.Add(ItemStr.ItemWeight[resultitemkey]);
        }
        for (int i = 0; i <= passeditemamount; i++)
        {
            InventoryItemKey.Remove(ItemStr.ItemKey[passeditemkey]);
            InventoryItemName.Remove(ItemStr.ItemName[passeditemkey]);
            InventoryItemDesc.Remove(ItemStr.ItemDesc[passeditemkey]);
            InventoryItemWeight.Remove(ItemStr.ItemWeight[passeditemkey]);
        }
    }
}
