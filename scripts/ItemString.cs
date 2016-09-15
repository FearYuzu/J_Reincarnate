using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class ItemString : MonoBehaviour {
   
    [SerializeField]
    public static List<Item> ItemStringTable = new List<Item>();                 // declaration
    public List<String> ItemKey = new List<String>();
    public List<String> ItemName = new List<String>();
    public List<String> ItemDesc = new List<String>();
    public List<String> ItemType = new List<String>();
    public List<String> ItemSeason = new List<String>();
    public List<float> ItemWeight = new List<float>();
    public List<bool> IsPoisonus = new List<bool>();
    void Start()
    {

    }
    public string GetItemKey(int Key)
    {
        string key = ItemKey[Key];
        return key;
    }
    public string GetItemName(int Key)
    {
        string key = ItemKey[Key];
        string name = ItemName[Key];
        return name;
    }
    public string GetItemDesc(int Key)
    {
        string desc = ItemDesc[Key];
        return desc;
    }

}
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
public class Item
{
    public int ItemKey;
    public string ItemName;
    public string ItemDesc;
    public string ItemType;
    public string ItemSeason;
    public double ItemWeight;
    public string ItemPlaceIdentifier;
    public bool IsPoisonus;
    public Item(int Key,string Name, string Desc, string Type, string Season, double Weight, string ItemPlaceID, bool isPoisonus)
    {
        ItemKey = Key;
        ItemName = Name;
        ItemDesc = Desc;
        ItemType = Type;
        ItemSeason = Season;
        ItemWeight = Weight;
        ItemPlaceIdentifier = ItemPlaceID;
        IsPoisonus = isPoisonus;
    }
}
