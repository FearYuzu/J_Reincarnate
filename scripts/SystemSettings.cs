using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemSettings : MonoBehaviour {
    public List<SS> SSStringTable = new List<SS>();
    public string language = "Japanese";
    int res_w = 1920;
    int res_h = 1080;
    string WindowType = "Window";
    int BGMVol = 100;
    int SEVol = 100;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadSystemSettings(){
        for (int i = 0; i < SSStringTable.Count; i++)
        {
            if (SSStringTable[i].Key == "Language")
            {
                language = SSStringTable[i].content;
            }
            if (SSStringTable[i].Key == "FPS")
            {
                Application.targetFrameRate = int.Parse(SSStringTable[i].content);
            }
            if (SSStringTable[i].Key == "Res_h")
            {
                res_h = int.Parse(SSStringTable[i].content);
            }
            if (SSStringTable[i].Key == "Res_w")
            {
                res_w = int.Parse(SSStringTable[i].content);
            }
            if (SSStringTable[i].Key == "WindowMode")
            {
                WindowType = SSStringTable[i].content;
            }
            if (SSStringTable[i].Key == "BGMVolume")
            {
                BGMVol = int.Parse(SSStringTable[i].content);
            }
            if (SSStringTable[i].Key == "SEVolume")
            {
                SEVol = int.Parse(SSStringTable[i].content);
            }
        }

    }
}
public class SS
{
    public string Key;
    public string content;

    public SS(string IKey, string IContent)
    {
        Key = IKey;
        content = IContent;

    }
}