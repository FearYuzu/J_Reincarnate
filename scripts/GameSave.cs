using UnityEngine;
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;

public class GameSave : MonoBehaviour {
    private string SaveFileNamePrefix = "Save";
    private int SaveFileNameSerial = 001;
    private string SaveFileExtension = ".sav";
    private string SaveFileName;
    GameObject Player = GameObject.Find("Player");
    public const string _Split_Char = "::";
    public List<GameDB> GameDatabase = new List<GameDB>();
	// Use this for initialization
	void Start () {
       
        SaveFileName = SystemCore.GameSaveDataPath + SaveFileNamePrefix + SaveFileNameSerial + SaveFileExtension;
	
	}
    public void SaveGame()
    {
        if(File.Exists(SaveFileName)){
            SaveFileNameSerial++;
            SaveFileName = SystemCore.GameSaveDataPath + SaveFileNamePrefix + SaveFileNameSerial + SaveFileExtension;
        }
        StreamWriter sw = new StreamWriter(SaveFileName,true);
        DataCollection();

        for (int i = 0; i < GameDatabase.Count; i++)
        {
            sw.WriteLine(GameDatabase[i].DKN + _Split_Char + GameDatabase[i].DC);
            
        }
        sw.Close();
        sw = null;
        
       
    }
    public void DataCollection()
    {
        GameDatabase.Add(new GameDB("PlayerPosition_X",Player.transform.position.x.ToString()));
        GameDatabase.Add(new GameDB("PlayerPosition_Y", Player.transform.position.y.ToString()));
        GameDatabase.Add(new GameDB("PlayerPosition_Z",Player.transform.position.z.ToString()));
        GameDatabase.Add(new GameDB("PlayerRotation_X",Player.transform.rotation.x.ToString()));
        GameDatabase.Add(new GameDB("PlayerRotation_Y",Player.transform.rotation.y.ToString()));
        GameDatabase.Add(new GameDB("PlayerRotation_Z",Player.transform.rotation.z.ToString()));
        GameDatabase.Add(new GameDB("ElapsedPlayTime", SystemCore.ElapsedGamePlayTime.ToString()));




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

