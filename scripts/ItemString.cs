using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class ItemString : MonoBehaviour {
    public string ItemString00001 = "";
    public string ItemString00002 = "";
    [SerializeField]
    public List<Type> ItemStringTable = new List<Type>();                 // declaration
    public List<String> ItemKey = new List<String>();
    public List<String> ItemName = new List<String>();
    public List<String> ItemDesc = new List<String>();
    public List<String> ItemType = new List<String>();
    public List<String> ItemSeason = new List<String>();
    public List<String> ItemWeight = new List<String>();
    public List<String> IsPoisonus = new List<String>();
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
