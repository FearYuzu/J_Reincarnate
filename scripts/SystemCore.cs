using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemCore : MonoBehaviour {

    public static string GameWorldSeason = "Spring";
    public static string GameTimezone = "Noon";
    public static string GameSaveDataPath;
    public static float GameWorldTime;
    public static float ElapsedGamePlayTime;
    public static string GameWorldView = "N/A";
    public static int GraphicSettingValue;
    public static bool IsGameStarted = false;
    public static bool IsTalkStarted = false;
    public static long Day, Hour, Minute, Second;
    public static List<int> ItemDropListKey_Spring = new List<int>();
    public static List<int> ItemDropListKey_Summer = new List<int>();
    public static List<int> ItemDropListKey_Autumn = new List<int>();
    public static List<int> ItemDropListKey_Winter = new List<int>();
    public static List<int> ItemDropListKey_Any = new List<int>();
	// Use this for initialization
	void Start () {
        GameSaveDataPath = Application.dataPath + "/save/";
        ItemDropKeyGenerator();
        Cursor.visible = true;
        IsGameStarted = true;
        StartCoroutine("StartCalculateElapsedTime");
	
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
        Debug.Log("IsTalkStarted:" + IsTalkStarted);
        



    }
    public void IncreaseGraphicSettings()
    {
        QualitySettings.IncreaseLevel();
        Debug.Log("LevelIncreased");
    }
    public void DecreaseGraphicSettings()
    {
        QualitySettings.DecreaseLevel();
        Debug.Log("LevelDecreased");
    }
    public void CallSavedata()
    {
        Debug.Log("called");
        GameSave.SaveGame();
    }
    public static void ItemDropKeyGenerator()
    {
        for (int i = 0; i < ItemString.ItemStringTable.Count; i++)
        {
            if (ItemString.ItemStringTable[i].ItemSeason == "Any")
            {
                ItemDropListKey_Any.Add(ItemString.ItemStringTable[i].ItemKey);
            }
           
            if (ItemString.ItemStringTable[i].ItemSeason == "Spring")
            {
                ItemDropListKey_Spring.Add(ItemString.ItemStringTable[i].ItemKey);
            }
           
            if (ItemString.ItemStringTable[i].ItemSeason == "Summer")
            {
                ItemDropListKey_Summer.Add(ItemString.ItemStringTable[i].ItemKey);
            }
            
            if (ItemString.ItemStringTable[i].ItemSeason == "Autumn")
            {
                ItemDropListKey_Autumn.Add(ItemString.ItemStringTable[i].ItemKey);
            }
            
            if (ItemString.ItemStringTable[i].ItemSeason == "Winter")
            {
                ItemDropListKey_Winter.Add(ItemString.ItemStringTable[i].ItemKey);
            }
            
            
        }
    }
    public void ItemConvertKeyGenerator()
    {

    }
    IEnumerator StartCalculateElapsedTime()
    {
        var wait = new WaitForSeconds(1);
        while (true)
        {
            Second++;
            if(Second > 59)
            {
                Minute++;
                Second = 0;
            }
            if(Minute > 59)
            {
                Hour++;
                Minute = 0;
            }
            if(Hour > 23)
            {
                Day++;
                Hour = 0;
            }
            yield return wait;
        }
        
    }
    private void AdaptationRateManaging()
    {

    }

}
public class DropPlace
{
    enum ItemDropPlaces
    {
        Grassland,Forest,Marsh,River, Waterfall,Snowfield,Desert,AdjacentSea,PelagicSea,Coast,AncientRuin
    }

}
public class ItemDropKey{

}