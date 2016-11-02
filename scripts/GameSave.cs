using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;

public class GameSave : MonoBehaviour {
    private static string SaveFileNamePrefix = "Save";
    private static int SaveFileNameSerial = 001;
    private static string SaveFileExtension = ".sav";
    private static string SaveFileName;
    static GameObject Player;
    public const string _Split_Char = "::";
    public static List<GameDB> GameDatabase = new List<GameDB>();
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        SaveFileName = SystemCore.GameSaveDataPath + SaveFileNamePrefix + SaveFileNameSerial + SaveFileExtension;
	
	}
    public static void SaveGame()
    {
        Debug.Log("Save Start");
        if(File.Exists(SaveFileName)){
            SaveFileNameSerial++;
            SaveFileName = SystemCore.GameSaveDataPath + SaveFileNamePrefix + SaveFileNameSerial + SaveFileExtension;
            File.Create(SaveFileName).Close();
        }
        Debug.Log("Create:" + SaveFileName);
        File.Create(SaveFileName).Close();
        
        SaveFileName = SystemCore.GameSaveDataPath + SaveFileNamePrefix + SaveFileNameSerial + SaveFileExtension;

        StreamWriter sw = new StreamWriter(SaveFileName,true);
        DataCollection();

        for (int i = 0; i < GameDatabase.Count; i++)
        {
            sw.WriteLine(GameDatabase[i].DKN + _Split_Char + GameDatabase[i].DC);
            
        }
        sw.Close();
        sw = null;
        GameDatabase = null;
        
       
    }
    public static void DataCollection()
    {
        GameDatabase.Add(new GameDB("PlayerPosition_X",Player.transform.position.x.ToString()));
        GameDatabase.Add(new GameDB("PlayerPosition_Y", Player.transform.position.y.ToString()));
        GameDatabase.Add(new GameDB("PlayerPosition_Z",Player.transform.position.z.ToString()));
        GameDatabase.Add(new GameDB("PlayerRotation_X",Player.transform.rotation.x.ToString()));
        GameDatabase.Add(new GameDB("PlayerRotation_Y",Player.transform.rotation.y.ToString()));
        GameDatabase.Add(new GameDB("PlayerRotation_Z",Player.transform.rotation.z.ToString()));
        GameDatabase.Add(new GameDB("ElapsedPlayTime", SystemCore.ElapsedGamePlayTime.ToString()));
        GameDatabase.Add(new GameDB("PlayerWorldView", SystemCore.GameWorldView));
        GameDatabase.Add(new GameDB("PlayerSanity", PlayerStats.Sanity.ToString()));
        GameDatabase.Add(new GameDB("PlayerHealth", PlayerStats.health.ToString()));
        GameDatabase.Add(new GameDB("PlayerAdaptationRate", PlayerStats.AdaptationRate.ToString()));
        GameDatabase.Add(new GameDB("PlayerMighty", PlayerStats.Mighty.ToString()));
        GameDatabase.Add(new GameDB("PlayerStamina", PlayerStats.Stamina.ToString()));
        GameDatabase.Add(new GameDB("PlayerViralCap", PlayerStats.VitalCapacity.ToString()));
        GameDatabase.Add(new GameDB("PlayerEyeSight", PlayerStats.EyeSight.ToString()));
        GameDatabase.Add(new GameDB("isSurviveInstinct", PlayerStats.SurviveInstinct.ToString()));






    }
}
public class GameDB
{
    public string DKN;
    public string DC;
    public GameDB(string DataKeyName, string DataContent)
    {
        DKN = DataKeyName;
        DC = DataContent;
    }
}

