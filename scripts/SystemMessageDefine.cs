using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemMessageDefine : MonoBehaviour {
    [SerializeField]
    public static List<SysMsgDefine> SMDefineTable = new List<SysMsgDefine>();
    public static List<String> SysMsgKey = new List<String>(1000);
    public static List<String> SysMsgTag = new List<String>(1000);
    public static List<String> Content = new List<String>(1000);
    
    public string GetSysMsgContent(int Key)
    {
        string content = SMDefineTable[Key].Content.Replace("\"","");
        return content;
    }


}
public class SysMsgDefine
{
    public int SysMessageKey;
    public string SysMessageTag;
    public string Content;
    public SysMsgDefine(int key, string tag, string content)
    {
        SysMessageKey = key;
        SysMessageTag = tag;
        Content = content;
    }
}
