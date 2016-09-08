using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RandomDialogString : MonoBehaviour {
    [SerializeField]
    public List<String> RandomDialogKey = new List<String>(1000);
    public List<String> RandomDialogText = new List<String>(1000);
    
    public string GetRDKey(int Key)
    {
        string key = RandomDialogKey[Key];
        return key;
    }
    public string GetRDText(int Key)
    {
        string text = RandomDialogText[Key];
        return text;
    }

}
