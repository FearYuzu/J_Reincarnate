using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemCore : MonoBehaviour {

    ItemString ItemStr;
    public string GameWorldSeason = "Spring";
    public List<int> ItemDropListKey_Spring = new List<int>();
    public List<int> ItemDropListKey_Summer = new List<int>();
    public List<int> ItemDropListKey_Autumn = new List<int>();
    public List<int> ItemDropListKey_Winter = new List<int>();
	// Use this for initialization
	void Start () {
        ItemStr = GetComponent<ItemString>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ItemDropKeyGenerator()
    {
        for (int i = 0; i < ItemStr.ItemStringTable.Count; i++)
        {
            if (ItemStr.ItemStringTable[i].ItemSeason == "Spring")
            {
                ItemDropListKey_Spring.Add(ItemStr.ItemStringTable[i].ItemKey);
            }
            if (ItemStr.ItemStringTable[i].ItemSeason == "Summer")
            {
                ItemDropListKey_Summer.Add(ItemStr.ItemStringTable[i].ItemKey);
            }
            if (ItemStr.ItemStringTable[i].ItemSeason == "Autumn")
            {
                ItemDropListKey_Autumn.Add(ItemStr.ItemStringTable[i].ItemKey);
            }
            if (ItemStr.ItemStringTable[i].ItemSeason == "Winter")
            {
                ItemDropListKey_Winter.Add(ItemStr.ItemStringTable[i].ItemKey);
            }
            
        }
    }
}
public class DropPlace
{
    enum ItemDropPlaces
    {
        Grassland,Forest,Marsh,River, Waterfall,Snowfield,Desert,AdjacentSea,PelagicSea,Coast,AncientRuin
    }

}
