using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadStringTable : MonoBehaviour {

    GameObjectDefine Define;
    SystemMessageDefine SMDefine;
    ItemString ItemStr;
    AreaString AreaStr;
    RandomDialogString RDStr;
    TalkString TalkStr;
    LanguageLoader LangLdr;
    SystemSettings SysSet;
    private string StringTablePath, LogPath, GeneralSettingPath, StringTable_UIPath, StringTable_ItemPath, StringTable_AreaPath, StringTable_System, StringTable_TalkPath;
    private string StringTablePrefix;
    public Text GameStartBtnTextPath;
    public Text ClickText;
    
    public string stringtable_UI_FileName = "stringtable_ui.csv";
    public string stringtable_CharacterMetaData_FileName = "stringtable_cmd.csv";
    public string stringtable_CharacterSpecificWords_FileName = "stringtable_csw.csv";
    public string stringtable_Item_FileName = "stringtable_item.csv";
    public string stringtable_area_FileName = "stringtable_area.csv";
    public string stringtable_system_FileName = "stringtable_system.csv";
    public string stringtable_talk_FileName = "stringtable_talk.csv";
    public const string _Extension = ".csv";
    public const char _Split_Char = ',';
    string HeaderString = "~";


    // Use this for initialization
    void Start()
    {
        if (File.Exists(GeneralSettingPath))
        {
            Debug.Log("aaa");
            LoadSettings(GeneralSettingPath);
            WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_001") + "(" + GeneralSettingPath + ")");
        }
        Define = GetComponent<GameObjectDefine>();
        SMDefine = GetComponent<SystemMessageDefine>();
        ItemStr = GetComponent<ItemString>();
        RDStr = GetComponent<RandomDialogString>();
        AreaStr = GetComponent<AreaString>();
        TalkStr = GetComponent<TalkString>();
        LangLdr = GetComponent<LanguageLoader>();
        SysSet = GetComponent<SystemSettings>();
        StringTablePath = Application.dataPath + "/Resources/stringtable/";
        StringTable_UIPath = StringTablePath + "jp/" + stringtable_UI_FileName;

        GeneralSettingPath = Application.dataPath + "/Resources/GeneralSettings.csv";
        LogPath = Application.dataPath + "/log/Startup.log";
        if (!Directory.Exists(Application.dataPath + "/log/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/log/");
        }
        if (!File.Exists(LogPath))
        {
            File.Create(LogPath).Close();
        }
        DefineLoadFiles();
        //Debug.Log("File Define Loaded");
        LoadSystemDefine(StringTable_System);
        //Debug.Log("System Define Loaded");
        LoggingSystemInfo();
        //Debug.Log("SystemInfo Loaded");
        LoadFiles();
        //Debug.Log("System Loaded");

        Debug.Log(GeneralSettingPath);
        
       
        //GameStartBtnTextPath = GameObject.Find(Define.GameMenu_StartBtnText).GetComponent<Text>();
        //ClickText = GameObject.Find(Define.GameMenu_ClickText).GetComponent<Text>();
        



    }
    public void QuitForSafe()
    {
        //WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Terminate_Tag") + SMDefine.GetSysMsg("Terminate_Reason001"));
        Application.Quit();
    }
    public void LoggingSystemInfo()
    {
        WriteStartupLog(LogPath, "--------------------------------------------------------------------");
        WriteStartupLog(LogPath, "                Game System Startup Log ");
        WriteStartupLog(LogPath, "--------------------------------------------------------------------");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Welcome_Tag") + SMDefine.GetSysMsg("Game_Title") + " (Ver." + SMDefine.GetSysMsg("Game_Version") + " | Rev." + SMDefine.GetSysMsg("Game_Revision") + " | Type:" + SMDefine.GetSysMsg("Game_ReleaseType") + ")");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Started_Tag") + SMDefine.GetSysMsg("OperationMsg_002"));
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_003"));
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OS_Tag") + SystemInfo.operatingSystem);
        //WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.DN_Tag + SystemInfo.deviceName);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("Processor_Tag") + SystemInfo.processorType);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("SMS_Tag") + SystemInfo.systemMemorySize + "MB");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("GDN_Tag") + SystemInfo.graphicsDeviceName);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("GDV_Tag") + SystemInfo.graphicsDeviceVendor);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("GMS_Tag") + SystemInfo.graphicsMemorySize + "MB");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_004"));

    }
    public void DisableGameObject()
    {
        GameObject.Find(Define.GameMenu_ClickText).SetActive(false);
    }
    private void DefineLoadFiles()
    {
        StringTablePath = Application.dataPath + "/Resources/stringtable/";
        StringTable_UIPath = StringTablePath + "jp/" + stringtable_UI_FileName;

        StringTable_AreaPath = StringTablePath + "jp/" + stringtable_area_FileName;
      
        StringTable_ItemPath = StringTablePath + "jp/" + stringtable_Item_FileName;
        StringTable_System = StringTablePath + "jp/" + stringtable_system_FileName;
        StringTable_TalkPath = StringTablePath + "jp/" + stringtable_talk_FileName;
        GeneralSettingPath = Application.dataPath + "/Resources/GeneralSettings.csv";
        LogPath = Application.dataPath + "/log/Startup.log";
    }
    private void LoadFiles()
    {
        Debug.Log("ldr");
        
        Debug.Log("ldr_jp");
        
        //}
        //else
        //{
        //WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("FatalError_Tag") + SMDefine.GetSysMsg("UnexpectedError_Reason001") + "(" + StringTable_UIPath_JP + ")");
        //QuitForSafe();
        CsvLoadItemString(StringTable_ItemPath);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_001") + "(" + StringTable_ItemPath + ")");
        CsvLoadAreaString(StringTable_AreaPath);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_001") + "(" + StringTable_AreaPath + ")");
        CsvLoadUIString(StringTable_UIPath);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_001") + "(" + StringTable_UIPath + ")");
        CsvLoadTalkString(StringTable_TalkPath);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + SMDefine.GetSysMsg("OperationMsg_001") + "(" + StringTable_TalkPath + ")");

        Debug.Log(SystemSettings.language);
        Debug.Log(ItemString.ItemStringTable[0].ItemName);
    }
    // Update is called once per frame
    void Update()
    {
       
        // Debug.Log(ItemStr.ItemKey[1]);
        //Debug.Log(ItemStr.ItemName[1]);
    }
    public void LoadSettings(string LoadPath)
    {
        
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        Debug.Log("File Loaded");
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains(HeaderString))
            {
                continue;
            }
            //Debug.Log("Start to spliting.");
            string[] fields = line.Split(_Split_Char);
            //Debug.Log(fields[0]);
            //Debug.Log(fields[1]);
            //Debug.Log(fields[2]);
            //Debug.Log(fields[3]);
            //Debug.Log(fields["Space_Tag"]);

            var metaid = fields[0]; //Define
            var content = fields[1]; //Define

            if (metaid.Contains(HeaderString) || metaid == "") //Ignore Header String
            {
                continue; //Go A Head
            }
            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
           try
            {
                SystemSettings.SSStringTable.Add(new SS(metaid, content));
            }
            catch (NullReferenceException e)
            {
                WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Terminate_Tag") + SMDefine.GetSysMsg("UnexpectedError_Reason001") + "("+LoadPath+")");
                QuitForSafe();
            }
        }
        sr.Close();
        sr = null;
    }
    public void LoadSystemDefine(string LoadPath)
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
            int key = int.Parse(fields[0]);
            var tag = fields[1];
            var content = fields[2];
            if (tag.Contains(HeaderString) || tag == "")
            {
                continue;
            }
            SystemMessageDefine.SMDefineTable.Add(new SysMsgDefine(key, tag, content));
            Debug.Log(SystemMessageDefine.SMDefineTable[0].SysMessageKey);
            
        }
        Debug.Log(SystemMessageDefine.SMDefineTable[1].SysMessageKey);
        Debug.Log(SystemMessageDefine.SMDefineTable[2].SysMessageKey);
        //Debug.Log("a:"+SMDefine.GetSysMsg("Game_Version"));
        sr.Close();
        sr = null;

    }
    public void CsvLoadItemString(string LoadPath)
    {
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        Debug.Log("File Loaded");
        int counter = 0;
        string line = "";
        while ((line = sr.ReadLine()) != null) //Read Until End of Lines. 
        {
            if (line.Contains(HeaderString))
            {
                continue; //Ignore Strings that contains HeaderString, then go a head!
            }
            //Debug.Log("Start to spliting.");
            string[] fields = line.Split(_Split_Char); //Split the line data.
            //Debug.Log(fields[0]);
            //Debug.Log(fields[1]);
            //Debug.Log(fields[2]);
            //Debug.Log(fields[3]);
            //Debug.Log(fields["Space_Tag"]);
            string getboolvalue;
            if (fields[7] == "True")
            {
                getboolvalue = bool.TrueString;
            }
            else
            {
                getboolvalue = bool.FalseString;
            }
            
            int key = int.Parse(fields[0]); //Define
            var name = fields[1]; //Define
            var desc = fields[2]; //Define
            var type = fields[3]; //Define
            var season = fields[4]; //Define
            double weight = double.Parse("100.1");
            var ItemPlaceIdentifier = fields[6];
            bool IsPoisonus = bool.Parse(getboolvalue);
            if (name.Contains(HeaderString) || name == "") 
            {
                continue; //Ignore Strings that contains HeaderString, then go a head!
            }
            

            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
            ItemString.ItemStringTable.Add(new Item(key, name, desc, type, season, weight,ItemPlaceIdentifier , IsPoisonus)); //Write Item Elements to the In-game ItemDB. 
        }
        sr.Close();
        sr = null;
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + ItemString.ItemStringTable.Count + SMDefine.GetSysMsg("OperationMsg_ItemStrLoaded"));
    }
    public void CsvLoadAreaString(string LoadPath)
    {
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        Debug.Log("File Loaded");
        int counter = 0;
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains(HeaderString))
            {
                continue;
            }
            //Debug.Log("Start to spliting.");
            string[] fields = line.Split(_Split_Char);

            var key = int.Parse(fields[0]); //Define
            var name = fields[1]; //Define
            var region = fields[2]; //Define
            if (name.Contains(HeaderString) || name == "") 
            {
                continue; //Ignore Strings that contains HeaderString, then go a head!
            }
            AreaString.AreaStringTable.Add(new Area(key,name,region));
            
        }
        sr.Close();
        sr = null;
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + AreaString.AreaStringTable.Count + SMDefine.GetSysMsg("OperationMsg_AreaStrLoaded"));
    }
    public void CsvLoadUIString(string LoadPath)
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
            var UIKey = fields[0];
            var Str = fields[1];
            UIString.UIStringTable.Add(new UI(UIKey, Str));
        }
        sr.Close();
        sr = null;
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + UIString.UIStringTable.Count + SMDefine.GetSysMsg("OperationMsg_UIStrLoaded"));
    }
    public void CsvLoadLanguage(string LoadPath)
    {
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        Debug.Log("File Loaded");
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains(HeaderString))
            {
                continue;
            }
            //Debug.Log("Start to spliting.");
            string[] fields = line.Split(_Split_Char);
            //Debug.Log(fields[0]);
            //Debug.Log(fields[1]);
            //Debug.Log(fields[2]);
            //Debug.Log(fields[3]);
            //Debug.Log(fields["Space_Tag"]);

            int key = int.Parse(fields[0]); //Define
            var lang = fields[1]; //Define
            var rcode = fields[2]; //Define
            
            if (lang.Contains(HeaderString) || lang == "") 
            {
                continue; //Ignore Strings that contains HeaderString, then go a head!
            }
            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
            LangLdr.LanguageStringTable.Add(new LL(key, lang, rcode));
        }
        sr.Close();
        sr = null;
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + ItemStr.ItemKey.Count + SMDefine.GetSysMsg("OperationMsg_LangStrLoaded"));
    }
    public void CsvLoadTalkString(string LoadPath)
    {
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        Debug.Log("File Loaded");
        string line = "";
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains(HeaderString))
            {
                continue;
            }
            //Debug.Log("Start to spliting.");
            string[] fields = line.Split(_Split_Char);

            var key = fields[0]; //Define
            var name = fields[1]; //Define
            var type = fields[2]; //Define
            var desc1 = fields[3];
            var desc2 = fields[4];
            var desc3 = fields[5];
            var desc4 = fields[6];
            var desc5 = fields[7];
            var desc6 = fields[8];
            var desc7 = fields[9];
            var desc8 = fields[10];
            var desc9 = fields[11];
            var desc10 = fields[12];
            if (key.Contains(HeaderString))
            {
                continue;
            }
            TalkString.TalkStringTable.Add(new Talk(key, name, type, desc1, desc2, desc3, desc4, desc5, desc6, desc7, desc8, desc9, desc10));
        }
        sr.Close();
        sr = null;
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsg("Space_Tag") + SMDefine.GetSysMsg("Operation_Tag") + TalkString.TalkStringTable.Count + SMDefine.GetSysMsg("OperationMsg_TalkStrLoaded"));
    }
    public void WriteStartupLog(string WritePath, string LogContent)
    {
        StreamWriter sw = new StreamWriter(LogPath,true);
        Debug.Log("Wrote:" + LogContent);
        sw.WriteLine(LogContent);
        sw.Close();
        
        
    }
}
