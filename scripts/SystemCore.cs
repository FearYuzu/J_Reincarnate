using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemCore : MonoBehaviour {

    ItemString ItemStr;
    public static string GameWorldSeason = "Spring";
    public static string GameTimezone = "Noon";
    public static string GameSaveDataPath = Application.dataPath + "/save/";
    public static float GameWorldTime;
    public static float ElapsedGamePlayTime;
    public static bool IsGameStarted = false;
    public List<int> ItemDropListKey_Spring = new List<int>();
    public List<int> ItemDropListKey_Summer = new List<int>();
    public List<int> ItemDropListKey_Autumn = new List<int>();
    public List<int> ItemDropListKey_Winter = new List<int>();
	// Use this for initialization
	void Start () {
        ItemStr = GetComponent<ItemString>();
	
	}
    enum GameWorldSeasonList
    {
        Spring,Summer,Autumn,Winter
    }
    enum GameTimezoneList
    {
        EarlyMorning,Morning,Noon,Evening,MidNight
    }
	// Update is called once per frame
	void Update () {
        if (IsGameStarted)
        {
            GameWorldTime += Time.deltaTime;
            ElapsedGamePlayTime = GameWorldTime;
        }	
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
    public void ItemConvertKeyGenerator()
    {

    }
    IEnumerator StartCalculateElapsedTime()
    {
        return;
    }

}
public class DropPlace
{
    enum ItemDropPlaces
    {
        Grassland,Forest,Marsh,River, Waterfall,Snowfield,Desert,AdjacentSea,PelagicSea,Coast,AncientRuin
    }

}
