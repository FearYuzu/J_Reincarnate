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
    private string StringTablePath;
    private string LogPath;
    private string GeneralSettingPath;
    private string StringTable_UIPath_JP;
    private string StringTable_UIPath_EN;
    private string StringTable_UIPath_HANT;
    private string StringTable_UIPath_HANS;
    private string StringTable_UIPath_Mod1;
    private string StringTable_UIPath_Mod2;
    private string StringTable_ItemPath_JP;
    private string StringTable_ItemPath_EN;
    private string StringTable_ItemPath_HANT;
    private string StringTable_ItemPath_HANS;
    private string StringTable_ItemPath_Mod1;
    private string StringTable_ItemPath_Mod2;
    private string StringTable_AreaPath_JP;
    private string StringTable_AreaPath_EN;
    private string StringTable_AreaPath_HANT;
    private string StringTable_AreaPath_HANS;
    public Text GameStartBtnTextPath;
    public Text ClickText;
    
    public string stringtable_UI_FileName = "stringtable_ui.csv";
    public string stringtable_CharacterMetaData_FileName = "stringtable_cmd.csv";
    public string stringtable_CharacterSpecificWords_FileName = "stringtable_csw.csv";
    public string stringtable_Item_FileName = "stringtable_item.csv";
    public string stringtable_area_FileName = "stringtablearea.csv";
    public const string _Extension = ".csv";
    public const char _Split_Char = ',';
    string HeaderString = "~";


    // Use this for initialization
    void Start()
    {
        Define = GetComponent<GameObjectDefine>();
        SMDefine = GetComponent<SystemMessageDefine>();
        ItemStr = GetComponent<ItemString>();
        RDStr = GetComponent<RandomDialogString>();
        AreaStr = GetComponent<AreaString>();
        TalkStr = GetComponent<TalkString>();
        LangLdr = GetComponent<LanguageLoader>();
        SysSet = GetComponent<SystemSettings>();
        DefineLoadFiles();
        LoadFiles();
        LoggingSystemInfo();

        if (File.Exists(GeneralSettingPath))
        {
            LoadSettings(GeneralSettingPath);
            WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(18) + "(" + GeneralSettingPath + ")");
        }
        else
        {
            DisableGameObject();
            WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(8) + SMDefine.GetSysMsgContent(29) + "(" + GeneralSettingPath + ")");
            //QuitForSafe();
        }
        //GameStartBtnTextPath = GameObject.Find(Define.GameMenu_StartBtnText).GetComponent<Text>();
        //ClickText = GameObject.Find(Define.GameMenu_ClickText).GetComponent<Text>();
        



    }
    public void QuitForSafe()
    {
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(9) + SMDefine.GetSysMsgContent(30));
        Application.Quit();
    }
    public void LoggingSystemInfo()
    {
        WriteStartupLog(LogPath, "--------------------------------------------------------------------");
        WriteStartupLog(LogPath, "                Game System Startup Log ");
        WriteStartupLog(LogPath, "--------------------------------------------------------------------");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(5) + SMDefine.GetSysMsgContent(0) + " (Ver." + SMDefine.GetSysMsgContent(1) + " | Rev." + SMDefine.GetSysMsgContent(2) + " | Type:" + SMDefine.GetSysMsgContent(3) + ")");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(6) + SMDefine.GetSysMsgContent(19));
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(20));
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(11) + SystemInfo.operatingSystem);
        //WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.DN_Tag + SystemInfo.deviceName);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(15) + SystemInfo.processorType);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(17) + SystemInfo.systemMemorySize + "MB");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(13) + SystemInfo.graphicsDeviceName);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(14) + SystemInfo.graphicsDeviceVendor);
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(16) + SystemInfo.graphicsMemorySize + "MB");
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(21));

    }
    public void DisableGameObject()
    {
        GameObject.Find(Define.GameMenu_ClickText).SetActive(false);
    }
    private void DefineLoadFiles()
    {
        StringTablePath = Application.dataPath + "/Resources/stringtable/";
        StringTable_UIPath_JP = StringTablePath + "jp/" + stringtable_UI_FileName;
        StringTable_UIPath_EN = StringTablePath + "en/" + stringtable_UI_FileName;
        StringTable_UIPath_HANS = StringTablePath + "hans/" + stringtable_UI_FileName;
        StringTable_UIPath_HANT = StringTablePath + "hant/" + stringtable_UI_FileName;
        StringTable_UIPath_Mod1 = StringTablePath + "ext1/" + stringtable_UI_FileName;
        StringTable_UIPath_Mod2 = StringTablePath + "ext2/" + stringtable_UI_FileName;
        StringTable_ItemPath_JP = StringTablePath + "jp/" + stringtable_Item_FileName;
        StringTable_ItemPath_EN = StringTablePath + "en/" + stringtable_Item_FileName;
        
        GeneralSettingPath = Application.dataPath + "/Resources/GeneralSettings.csv";
        LogPath = Application.dataPath + "/log/Startup.log";
    }
    private void LoadFiles()
    {
        switch (SysSet.language)
        {
            case "Japanese":
                if (File.Exists(StringTable_ItemPath_JP))
                {
                    CsvLoadItemString(StringTable_ItemPath_JP);
                    CsvLoadAreaString(StringTable_AreaPath_JP);

                    WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + SMDefine.GetSysMsgContent(18) + "(" + StringTable_UIPath_JP + ")");
                }
                else
                {
                    WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(8) + SMDefine.GetSysMsgContent(29) + "(" + StringTable_UIPath_JP + ")");
                    //QuitForSafe();
                }
                break;
            case "English":
                CsvLoadString(StringTable_ItemPath_EN);
                break;
            case "Han_T":
                CsvLoadString(StringTable_UIPath_HANT);
                break;
            case "Han_S":
                CsvLoadString(StringTable_UIPath_HANS);
                break;
        }
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
            //Debug.Log(fields[4]);

            var metaid = fields[0]; //Define
            var content = fields[1]; //Define

            if (metaid.Contains(HeaderString) || metaid == "") //Ignore Header String
            {
                continue; //Go A Head
            }
            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
            SysSet.SSStringTable.Add(new SS(metaid, content));
        }
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + ItemStr.ItemKey.Count + SMDefine.GetSysMsgContent(22));
    }
    
    public void CsvLoadString(string LoadPath)
    {
        StreamReader sr = new StreamReader(new FileStream(LoadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        Debug.Log("File Loaded");
        int counter = 0;
        string line = "";
        while((line = sr.ReadLine()) != null)
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
            //Debug.Log(fields[4]);
            
            var key = fields[0]; //Define
            var name = fields[1]; //Define
            var desc = fields[2]; //Define
            var type = fields[3]; //Define
            var season = fields[4]; //Define
            if(key.Contains(HeaderString) || key == "") //Ignore Header String
            {
                    continue; //Go A Head
            }
            ItemStr.ItemKey.Add(fields[0]); //Write ItemKey to ItemKeyList.
            //Debug.Log("Key Added.");
            ItemStr.ItemName.Add(fields[1]); //Write ItemName to ItemNameList.
            ItemStr.ItemDesc.Add(fields[2]); //Write ItemDesc to ItemDescList.
            ItemStr.ItemType.Add(fields[3]); //Write ItemType to ItemTypeList.
            ItemStr.ItemSeason.Add(fields[4]); //Write ItemSeason to ItemSeasonList.
            
            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
        }
        
    }
    public void CsvLoadItemString(string LoadPath)
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
            //Debug.Log(fields[0]);
            //Debug.Log(fields[1]);
            //Debug.Log(fields[2]);
            //Debug.Log(fields[3]);
            //Debug.Log(fields[4]);

            int key = int.Parse(fields[0]); //Define
            var name = fields[1]; //Define
            var desc = fields[2]; //Define
            var type = fields[3]; //Define
            var season = fields[4]; //Define
            float weight = float.Parse(fields[5]);
            bool IsPoisonus = bool.Parse(fields[6]);
            if (name.Contains(HeaderString) || name == "") //Ignore Header String
            {
                continue; //Go A Head
            }
            ItemStr.ItemKey.Add(fields[0]); //Write ItemKey to ItemKeyList.
            //Debug.Log("Key Added.");
            ItemStr.ItemName.Add(fields[1]); //Write ItemName to ItemNameList.
            ItemStr.ItemDesc.Add(fields[2]); //Write ItemDesc to ItemDescList.
            ItemStr.ItemType.Add(fields[3]); //Write ItemType to ItemTypeList.
            ItemStr.ItemSeason.Add(fields[4]); //Write ItemSeason to ItemSeasonList.

            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
            ItemStr.ItemStringTable.Add(new Item(key, fields[1], fields[2], fields[3], fields[4], weight, IsPoisonus));
        }
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + ItemStr.ItemKey.Count + SMDefine.GetSysMsgContent(22));
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

            var key = fields[0]; //Define
            var name = fields[1]; //Define
            var region = fields[2]; //Define
            if (key.Contains(HeaderString) || key == "") //Ignore Header String
            {
                continue; //Go A Head
            }
            AreaStr.AreaKey.Add(fields[0]);
            AreaStr.AreaName.Add(fields[1]);
            AreaStr.AreaRegion.Add(fields[2]);
        }
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + AreaStr.AreaKey.Count + SMDefine.GetSysMsgContent(23));
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
            //Debug.Log(fields[4]);

            int key = int.Parse(fields[0]); //Define
            var lang = fields[1]; //Define
            var rcode = fields[2]; //Define
            
            if (lang.Contains(HeaderString) || lang == "") //Ignore Header String
            {
                continue; //Go A Head
            }
            //Debug.Log(ItemStr.ItemKey[0]);
            //Debug.Log(ItemStr.ItemName[0]);
            LangLdr.LanguageStringTable.Add(new LL(key, lang, rcode));
        }
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + ItemStr.ItemKey.Count + SMDefine.GetSysMsgContent(22));
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

            int key = int.Parse(fields[0]); //Define
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
            if (name.Contains(HeaderString) || name == "") //Ignore Header String
            {
                continue; //Go A Head
            }
            TalkStr.TalkStringTable.Add(new Talk(key, name, type, desc1, desc2, desc3, desc4, desc5, desc6, desc7, desc8, desc9, desc10));
        }
        WriteStartupLog(LogPath, DateTime.Now + SMDefine.GetSysMsgContent(4) + SMDefine.GetSysMsgContent(7) + AreaStr.AreaKey.Count + SMDefine.GetSysMsgContent(23));
    }
    public void WriteStartupLog(string WritePath, string LogContent)
    {
        StreamWriter sw = new StreamWriter(LogPath,true);
        sw.WriteLine(LogContent);
        sw.Close();
        
    }
}
