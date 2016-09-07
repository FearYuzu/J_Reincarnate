using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AreaString : MonoBehaviour {

    [SerializeField]
    public List<String> AreaKey = new List<String>(1000);
    public List<String> AreaName = new List<String>(1000);
    public List<String> AreaRegion = new List<String>(1000);
    void Start()
    {
    }
    public string GetItemKey(int Key)
    {
        string key = AreaKey[Key];
        return key;
    }
    public string GetItemName(int Key)
    {
        string name = AreaName[Key];
        return name;
    }
    public string GetItemDesc(int Key)
    {
        string region = AreaRegion[Key];
        return region;
    }

}
