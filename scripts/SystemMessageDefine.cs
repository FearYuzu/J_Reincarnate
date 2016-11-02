using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemMessageDefine : MonoBehaviour {
    [SerializeField]
    public static List<SysMsgDefine> SMDefineTable = new List<SysMsgDefine>();
    string ReturnedContent;
    public string GetSysMsg(string msgtag)
    {
        for(int i = 0; i < SMDefineTable.Count; i++)
        {
            if(SMDefineTable[i].SysMessageTag.Contains(msgtag))
            {
                ReturnedContent = SMDefineTable[i].Content;
            }
            
        }
        return ReturnedContent;
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
