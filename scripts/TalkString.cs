using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TalkString : MonoBehaviour {
    [SerializeField]
    public List<Talk> TalkStringTable = new List<Talk>();
    public List<String> TalkKey = new List<String>(1000);
    public List<String> TalkNPCName = new List<String>(1000);
    public List<String> TalkDesc1 = new List<String>(1000);
    public List<String> TalkDesc2 = new List<String>(1000);
    public List<String> TalkDesc3 = new List<String>(1000);
    public List<String> TalkDesc4 = new List<String>(1000);
    public List<String> TalkDesc5 = new List<String>(1000);
    public List<String> TalkDesc6 = new List<String>(1000);
    public List<String> TalkDesc7 = new List<String>(1000);
    public List<String> TalkDesc8 = new List<String>(1000);
    public List<String> TalkDesc9 = new List<String>(1000);
    public List<String> TalkDesc10 = new List<String>(1000);
}
public class Talk
{
    public int Key;
    public string NPCName;
    public string NPCType;
    public string Desc1;
    public string Desc2;
    public string Desc3;
    public string Desc4;
    public string Desc5;
    public string Desc6;
    public string Desc7;
    public string Desc8;
    public string Desc9;
    public string Desc10;

    public Talk(int _Key, string _NPCName, string _NPCType, string _Desc1, string _Desc2, string _Desc3, string _Desc4, string _Desc5, string _Desc6, string _Desc7, string _Desc8, string _Desc9, string _Desc10)
    {
        Key = _Key;
        NPCName = _NPCName;
        NPCType = _NPCType;
        Desc1 = _Desc1;
        Desc2 = _Desc2;
        Desc3 = _Desc3;
        Desc4 = _Desc4;
        Desc5 = _Desc5;
        Desc6 = _Desc6;
        Desc7 = _Desc7;
        Desc8 = _Desc8;
        Desc9 = _Desc9;
        Desc10 = _Desc10;

    }
}
