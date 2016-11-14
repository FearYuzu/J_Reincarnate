using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Reflection;

public class AssemblyLoader : MonoBehaviour {
    public const char _Split_Char = ',';
    public const string HeaderString = "~";
    private static List<AssemblyLoad> AssemblyFileList = new List<AssemblyLoad>();
    private static List<ClassLoad> ClassLoadList = new List<ClassLoad>();
	// Use this for initialization
	void Start () {
	
	}
    private static void CollectAssemblyFileData(string LoadPath)
    {
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains(HeaderString))
            {
                continue;
            }
            string[] fields = line.Split(_Split_Char);
            var ModName = fields[0];
            var AssemblyFileName = fields[1];
            var ModDataPath = fields[2];
            if (AssemblyFileName.Contains(HeaderString) || AssemblyFileName == "")
            {
                continue;
            }
            AssemblyFileList.Add(new AssemblyLoad(ModName, AssemblyFileName,ModDataPath));
            //Debug.Log(SystemMessageDefine.SMDefineTable[0].SysMessageKey);

        }
        
        //Debug.Log("a:"+SMDefine.GetSysMsg("Game_Version"));
        sr.Close();
        sr = null;
    }
    private static void AssemblyFileLoad()
    {
        CollectAssemblyFileData(Application.dataPath + "/Resources/AssemblyFileList.csv");
        for (int i = 0; i < AssemblyFileList.Count; i++)
        {
            var AssemblyDLLPath = Application.dataPath + "/Resources/mod_assembly/" + AssemblyFileList[i].AssemblyName;
            var ModDataPath = Application.dataPath + "/Resources/" + AssemblyFileList[i].ModDataPath;
            var ClassProfilePath = ModDataPath + "ClassProfile.csv";
            var LoadedAsm = Assembly.LoadFrom(AssemblyDLLPath);
            //
            StreamReader sr = new StreamReader(new FileStream(ClassProfilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(HeaderString))
                {
                    continue;
                }
                string[] fields = line.Split(_Split_Char);
                var ModClassPath = fields[0];
                var ModClass = "";
                if (ModClassPath.Contains(HeaderString) || ModClassPath == "")
                {
                    continue;
                }
                ClassLoadList.Add(new ClassLoad(ModClassPath));
                //Debug.Log(SystemMessageDefine.SMDefineTable[0].SysMessageKey);

            }

            //Debug.Log("a:"+SMDefine.GetSysMsg("Game_Version"));
            sr.Close();
            sr = null;
            //
            for (int cl = 0; cl < ClassLoadList.Count; cl++)
            {
                var GetTypeInfo = LoadedAsm.GetType(ClassLoadList[cl].ModClassNamePath);
                dynamic MakeInstance = Activator.CreateInstance(GetTypeInfo);
                Debug.Log("Instance Created! : " + ClassLoadList[cl].ModClassNamePath);
            }
        }

    }
}
public class AssemblyLoad
{
    public string ModName;
    public string AssemblyName;
    public string ModDataPath;

    public AssemblyLoad(string _ModName, string _AssemblyName , string _ModDataPath)
    {
        ModName = _ModName;
        AssemblyName = _AssemblyName;
        ModDataPath = _ModDataPath;
    }
}
public class ClassLoad
{
    public string ModClassNamePath;
    public ClassLoad(string _ModClassNamePath)
    {
        ModClassNamePath = _ModClassNamePath;
    }
}