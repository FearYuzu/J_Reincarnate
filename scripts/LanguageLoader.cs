using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LanguageLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public List<LL> LanguageStringTable = new List<LL>();
}
public class LL
{
    public int Key;
    public string Language;
    public string RegionCode;
    
    public LL(int IKey, string ILanguage, string IRegionCode)
    {
        Key = IKey;
        Language = ILanguage;
        RegionCode = IRegionCode;
        
    }
}
