using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    ItemString ItemStr;
    // Inventory Management (Set Inventory Weight/Space, Earn/Delete/Convert the Items.)
    [SerializeField]
    private static float InventoryMaxWeight = 100.0f;
    private static int InventoryMaxSpace = 100;
    public static List<int> InventoryItemKey = new List<int>();
    public static List<String> InventoryItemName = new List<String>();
    public static List<String> InventoryItemDesc = new List<String>();
    public static List<double> InventoryItemWeight = new List<double>();
    void Start()
    {
        ItemStr = GetComponent<ItemString>();
        StartCoroutine("UpdateInventoryItems");
    }
    public void SetInventoryStatus(int weight, int space)
    {
        InventoryMaxWeight = weight;
        InventoryMaxSpace = space;
    }
    IEnumerator UpdateInventoryItems()
    {
        var wait = new WaitForSeconds(0.5f);
        while (true)
        {
            
            yield return wait;
        }
    }
    public static void AddItems(int itemkey, int itemamount)
    {
        for (int i = 0; i <= itemamount; i++)
        {
            InventoryItemKey.Add(ItemString.ItemStringTable[itemkey].ItemKey);
            InventoryItemName.Add(ItemString.ItemStringTable[itemkey].ItemName);
            InventoryItemDesc.Add(ItemString.ItemStringTable[itemkey].ItemDesc);
            InventoryItemWeight.Add(ItemString.ItemStringTable[itemkey].ItemWeight);
        }
    }
    public static void DeleteItems(int itemkey, int itemamount)
    {
        for (int i = 0; i <= itemamount; i++)
        {
            InventoryItemKey.Remove(ItemString.ItemStringTable[itemkey].ItemKey);
            InventoryItemName.Remove(ItemString.ItemStringTable[itemkey].ItemName);
            InventoryItemDesc.Remove(ItemString.ItemStringTable[itemkey].ItemDesc);
            InventoryItemWeight.Remove(ItemString.ItemStringTable[itemkey].ItemWeight);
        }
    }
    public static void ConvertItems(int passeditemkey, int resultitemkey, int passeditemamount, int resultitemamount)
    {
        for (int i = 0; i <= resultitemamount; i++)
        {
            InventoryItemKey.Add(ItemString.ItemStringTable[resultitemkey].ItemKey);
            InventoryItemName.Add(ItemString.ItemStringTable[resultitemkey].ItemName);
            InventoryItemDesc.Add(ItemString.ItemStringTable[resultitemkey].ItemDesc);
            InventoryItemWeight.Add(ItemString.ItemStringTable[resultitemkey].ItemWeight);
        }
        for (int i = 0; i <= passeditemamount; i++)
        {
            InventoryItemKey.Remove(ItemString.ItemStringTable[passeditemkey].ItemKey);
            InventoryItemName.Remove(ItemString.ItemStringTable[passeditemkey].ItemName);
            InventoryItemDesc.Remove(ItemString.ItemStringTable[passeditemkey].ItemDesc);
            InventoryItemWeight.Remove(ItemString.ItemStringTable[passeditemkey].ItemWeight);
        }
    }
}
