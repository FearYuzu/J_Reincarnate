using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIString : MonoBehaviour {
    public static List<UI> UIStringTable = new List<UI>();
    string ReturnedContent;
    public string GetUIString(string uikey)
    {
        for (int i = 0; i < UIStringTable.Count; i++)
        {
            if (UIStringTable[i].UINameKey.Contains(uikey))
            {
                ReturnedContent = UIStringTable[i].String;
            }

        }
        return ReturnedContent;
    }
}
public class UI{
    public string UINameKey;
    public string String;
    public UI(string uikey, string str){
        UINameKey = uikey;
        String = str;
    }
}
