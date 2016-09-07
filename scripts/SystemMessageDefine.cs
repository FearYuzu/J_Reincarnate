using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SystemMessageDefine : MonoBehaviour {
    [SerializeField]
    public List<String> SysMsgKey = new List<String>(1000);
    public List<String> SysMsgTag = new List<String>(1000);
    public List<String> Content = new List<String>(1000);
    
    public string GetSysMsgContent(int Key)
    {
        string content = Content[Key];
        return content;

    }


}
