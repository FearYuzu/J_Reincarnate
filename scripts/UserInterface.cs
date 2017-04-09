using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class UserInterface : MonoBehaviour {
    GameObject dashboard;
    bool DashboardStatus;
    int CategoryValue;
    int CategoryValueLimit;
    static public int InteractionMode;
    string Cat_Overview, Cat_Inventory, Cat_Config, Cat_Save, Cat_Load, Cat_Exit;
    string Qua_vlow, Qua_low, Qua_mid, Qua_midhigh, Qua_high, Qua_vhigh;
    string Day, Hour, Minute, Second, ConvertedPlayedTime;
    static string IA_Talk, IA_Steal, IA_Take, IA_Use, IA_Gather, IA_Harvest;
    GameObject CategoryTitle, Overview, Inventory, Config, Save, Load, Exit; //Category Title Related Object
    GameObject PlayedTime, Sanity, Reputation; //Overview Related Object
    GameObject Language, LDD,LDD_Label,LDD_Arrow, GraphicsQuality, TextureQuality, FoV, QualityValue, GQ_LeftArrow, GQ_RightArrow, PlayerCamera,FoVSliderValue; //Config Related Object
    static GameObject TalkPanel, TalkContent, TalkHeader, Next; //Talk Related Object
    static GameObject InteractionGuide; //Interaction Related Object
    static GameObject AdaptationRate; //Information Related Object
	// Use this for initialization
	void Start () {
        dashboard = GameObject.Find("DashBoard/Canvas/MainPanel");
        CategoryValue = 0;
        CategoryValueLimit = 5;
        Invoke("UIDefineInitalize", 1f);
        StartCoroutine("IntervalProcess");
        StartCoroutine("PlayedTimeConvert");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!DashboardStatus&& SystemCore.IsTalkStarted == false)
            {
                EnableDashBoard();
                CategoryValue = 0;
                StartCoroutine("UpdateUI");
            }
            else
            {
                DisableDashBoard();
                StopCoroutine("UpdateUI");
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!DashboardStatus)
            {
                EnableDashBoard();
                CategoryValue = 1;
                StartCoroutine("UpdateUI");
               
            }
            else
            {
                DisableDashBoard();
                StopCoroutine("UpdateUI");
            }
        }
        
        //CategorySetection();
    }
    IEnumerator IntervalProcess()
    {
        var initwait = new WaitForSeconds(3f);
        var wait = new WaitForSeconds(0.01f);
        yield return initwait;
        
        while (true)
        {
            if (!DashboardStatus)
            {
                DisableDashBoard();
            }
            CategorySetection();
            RenewAdaptationRateOnUI();
            PlayedTime.GetComponent<Text>().text = "Played Time: " + ConvertedPlayedTime;
            
           // FoVSliderUpdate();
            yield return wait;
        }


    }
    IEnumerator PlayedTimeConvert()
    {
        var wait = new WaitForSeconds(1);
        while (true)
        {
            ConvertedPlayedTime = SystemCore.Day + " " + Day + SystemCore.Hour + " " + Hour + SystemCore.Minute + " " + Minute + SystemCore.Second + " " + Second;
            yield return wait;
        }
    }
    
    IEnumerator UpdateUI()
    {
        var wait = new WaitForSeconds(0.5f);
        var colorTargeted = new Color(255f, 216f, 0f, 255f);
        var colorDefault = new Color(255f, 255f, 255f, 255f);
        while (true)
        {
            switch (CategoryValue)
            {
                default:
                    CategoryTitle.GetComponent<Text>().text = Cat_Overview;
                    Overview.GetComponent<Text>().color = colorTargeted;
                    Inventory.GetComponent<Text>().color = colorDefault;
                    Config.GetComponent<Text>().color = colorDefault;
                    Save.GetComponent<Text>().color = colorDefault;
                    Load.GetComponent<Text>().color = colorDefault;
                    Exit.GetComponent<Text>().color = colorDefault;
                    SetUICategoryContent(0);
                    break;
                case 0:
                    CategoryTitle.GetComponent<Text>().text = Cat_Overview;
                    Overview.GetComponent<Text>().color = colorTargeted;
                    Inventory.GetComponent<Text>().color = colorDefault;
                    Config.GetComponent<Text>().color = colorDefault;
                    Save.GetComponent<Text>().color = colorDefault;
                    Load.GetComponent<Text>().color = colorDefault;
                    Exit.GetComponent<Text>().color = colorDefault;
                    SetUICategoryContent(0);
                    break;
                case 1:
                    CategoryTitle.GetComponent<Text>().text = Cat_Inventory;
                    Overview.GetComponent<Text>().color = colorDefault;
                    Inventory.GetComponent<Text>().color = colorTargeted;
                    Config.GetComponent<Text>().color = colorDefault;
                    Save.GetComponent<Text>().color = colorDefault;
                    Load.GetComponent<Text>().color = colorDefault;
                    Exit.GetComponent<Text>().color = colorDefault;
                    SetUICategoryContent(1);
                    break;
                case 2:
                    CategoryTitle.GetComponent<Text>().text = Cat_Config;
                    Overview.GetComponent<Text>().color = colorDefault;
                    Inventory.GetComponent<Text>().color = colorDefault;
                    Config.GetComponent<Text>().color = colorTargeted;
                    Save.GetComponent<Text>().color = colorDefault;
                    Load.GetComponent<Text>().color = colorDefault;
                    Exit.GetComponent<Text>().color = colorDefault;
                    SetUICategoryContent(2);
                    RenewQualityLevel();
                    break;
                case 3:
                    CategoryTitle.GetComponent<Text>().text = Cat_Save;
                    Overview.GetComponent<Text>().color = colorDefault;
                    Inventory.GetComponent<Text>().color = colorDefault;
                    Config.GetComponent<Text>().color = colorDefault;
                    Save.GetComponent<Text>().color = colorTargeted;
                    Load.GetComponent<Text>().color = colorDefault;
                    Exit.GetComponent<Text>().color = colorDefault;
                    SetUICategoryContent(3);
                    break;
                case 4:
                    CategoryTitle.GetComponent<Text>().text = Cat_Load;
                    Overview.GetComponent<Text>().color = colorDefault;
                    Inventory.GetComponent<Text>().color = colorDefault;
                    Config.GetComponent<Text>().color = colorDefault;
                    Save.GetComponent<Text>().color = colorDefault;
                    Load.GetComponent<Text>().color = colorTargeted;
                    Exit.GetComponent<Text>().color = colorDefault;
                    SetUICategoryContent(4);
                    break;
                case 5:
                    CategoryTitle.GetComponent<Text>().text = Cat_Exit;
                    Overview.GetComponent<Text>().color = colorDefault;
                    Inventory.GetComponent<Text>().color = colorDefault;
                    Config.GetComponent<Text>().color = colorDefault;
                    Save.GetComponent<Text>().color = colorDefault;
                    Load.GetComponent<Text>().color = colorDefault;
                    Exit.GetComponent<Text>().color = colorTargeted;
                    SetUICategoryContent(5);
                    break;

            }
            yield return wait;
        }
        
    }
    private void RenewQualityLevel()
    {
        var currentqv = QualitySettings.GetQualityLevel();
        switch (currentqv)
        {
            case 0:
                QualityValue.GetComponent<Text>().text = Qua_vlow;
                break;
            case 1:
                QualityValue.GetComponent<Text>().text = Qua_low;
                break;
            case 2:
                QualityValue.GetComponent<Text>().text = Qua_mid;
                break;
            case 3:
                QualityValue.GetComponent<Text>().text = Qua_midhigh;
                break;
            case 4:
                QualityValue.GetComponent<Text>().text = Qua_high;
                break;
            case 5:
                QualityValue.GetComponent<Text>().text = Qua_vhigh;
                break;

        }
    }
    private void OnSelectedCategory()
    {

    }
    private void SetUICategoryContent(int Category)
    {
        switch (Category)
        {
            default:
                PlayedTime.SetActive(true);
                Reputation.SetActive(true);
                Language.SetActive(false);
                GraphicsQuality.SetActive(false);
                TextureQuality.SetActive(false);
                FoV.SetActive(false);
                GQ_LeftArrow.SetActive(false);
                GQ_RightArrow.SetActive(false);
                LDD.SetActive(false);
                FoVSliderValue.SetActive(false);
                break;
            case 1:
                PlayedTime.SetActive(true);
                Reputation.SetActive(true);
                Language.SetActive(false);
                GraphicsQuality.SetActive(false);
                TextureQuality.SetActive(false);
                FoV.SetActive(false);
                GQ_LeftArrow.SetActive(false);
                GQ_RightArrow.SetActive(false);
                LDD.SetActive(false);
                FoVSliderValue.SetActive(false);
                break;
            case 2:
                PlayedTime.SetActive(false);
                Reputation.SetActive(false);
                Language.SetActive(true);
                GraphicsQuality.SetActive(true);
                TextureQuality.SetActive(true);
                FoV.SetActive(true);
                GQ_LeftArrow.SetActive(true);
                GQ_RightArrow.SetActive(true);
                LDD.SetActive(true);
                FoVSliderValue.SetActive(true);
                break;
            case 3:
                PlayedTime.SetActive(false);
                Reputation.SetActive(false);
                Language.SetActive(false);
                GraphicsQuality.SetActive(false);
                TextureQuality.SetActive(false);
                FoV.SetActive(false);
                GQ_LeftArrow.SetActive(false);
                GQ_RightArrow.SetActive(false);
                LDD.SetActive(false);
                FoVSliderValue.SetActive(false);
                break;
            case 4:
                PlayedTime.SetActive(false);
                Reputation.SetActive(false);
                Language.SetActive(false);
                GraphicsQuality.SetActive(false);
                TextureQuality.SetActive(false);
                FoV.SetActive(false);
                GQ_LeftArrow.SetActive(false);
                GQ_RightArrow.SetActive(false);
                LDD.SetActive(false);
                FoVSliderValue.SetActive(false);
                break;
            case 5:
                PlayedTime.SetActive(false);
                Reputation.SetActive(false);
                Language.SetActive(false);
                GraphicsQuality.SetActive(false);
                TextureQuality.SetActive(false);
                FoV.SetActive(false);
                GQ_LeftArrow.SetActive(false);
                GQ_RightArrow.SetActive(false);
                LDD.SetActive(false);
                break;
            case 44:
                PlayedTime.SetActive(false);
                Reputation.SetActive(false);
                Language.SetActive(false);
                GraphicsQuality.SetActive(false);
                TextureQuality.SetActive(false);
                FoV.SetActive(false);
                GQ_LeftArrow.SetActive(false);
                GQ_RightArrow.SetActive(false);
                LDD.SetActive(false);
                FoVSliderValue.SetActive(false);
                break;

        }
    }
    private void UIDefineInitalize()
    {
        CategoryTitle = GameObject.Find("DashBoard/Canvas/MainPanel/CategoryTitle");
        Overview = GameObject.Find("DashBoard/Canvas/MainPanel/Overview");
        Inventory = GameObject.Find("DashBoard/Canvas/MainPanel/Inventory");
        Config = GameObject.Find("DashBoard/Canvas/MainPanel/Config");
        Save = GameObject.Find("DashBoard/Canvas/MainPanel/Save");
        Load = GameObject.Find("DashBoard/Canvas/MainPanel/Load");
        Exit = GameObject.Find("DashBoard/Canvas/MainPanel/Exit");
        PlayedTime = GameObject.Find("DashBoard/Canvas/MainPanel/Overview/PlayedTime");
        Reputation = GameObject.Find("DashBoard/Canvas/MainPanel/Overview/Reputation");
        Language = GameObject.Find("DashBoard/Canvas/MainPanel/Config/Language");
        GraphicsQuality = GameObject.Find("DashBoard/Canvas/MainPanel/Config/GraphicsQuality");
        TextureQuality = GameObject.Find("DashBoard/Canvas/MainPanel/Config/TextureQuality");
        FoV = GameObject.Find("DashBoard/Canvas/MainPanel/Config/FoV");
        QualityValue = GameObject.Find("DashBoard/Canvas/MainPanel/Config/GraphicsQuality/QualityValue");
        GQ_LeftArrow = GameObject.Find("DashBoard/Canvas/MainPanel/GQ_LeftArrow/Text");
        GQ_RightArrow = GameObject.Find("DashBoard/Canvas/MainPanel/GQ_RightArrow/Text");
        LDD = GameObject.Find("DashBoard/Canvas/MainPanel/Config/Language/LangDropdown");
        LDD_Label = GameObject.Find("DashBoard/Canvas/MainPanel/Config/Language/LangDropdown/Label");
        LDD_Arrow = GameObject.Find("DashBoard/Canvas/MainPanel/Config/Language/LangDropdown/Arrow");
        PlayerCamera = GameObject.Find("Environment/Player/Camera");
        FoVSliderValue = GameObject.Find("DashBoard/Canvas/MainPanel/FoVSlider");
        InteractionGuide = GameObject.Find("DashBoard/Canvas/InteractionPanel/InteractionGuide");
        AdaptationRate = GameObject.Find("DashBoard/Canvas/InfoPanel/AdaptationRate");
        TalkPanel = GameObject.Find("DashBoard/Canvas/TalkPanel");
        TalkHeader = GameObject.Find("DashBoard/Canvas/TalkPanel/TalkHeader");
        TalkContent = GameObject.Find("DashBoard/Canvas/TalkPanel/TalkContent");
        Cat_Overview = GetUITextContent("DashBoard_OverView");
        Cat_Inventory = GetUITextContent("DashBoard_Inventory");
        Cat_Config = GetUITextContent("DashBoard_Settings");
        Cat_Load = GetUITextContent("DashBoard_Load");
        Cat_Save = GetUITextContent("DashBoard_Save");
        Cat_Exit = GetUITextContent("DashBoard_Exit");
        Qua_vlow = GetUITextContent("Config_GraphicQuality_Level1");
        Qua_low = GetUITextContent("Config_GraphicQuality_Level2");
        Qua_mid = GetUITextContent("Config_GraphicQuality_Level3");
        Qua_midhigh = GetUITextContent("Config_GraphicQuality_Level4");
        Qua_high = GetUITextContent("Config_GraphicQuality_Level5");
        Qua_vhigh = GetUITextContent("Config_GraphicQuality_Level6");
        Day = GetUITextContent("Overview_Day");
        Hour = GetUITextContent("Overview_Hour");
        Minute = GetUITextContent("Overview_Minute");
        Second = GetUITextContent("Overview_Second");
        IA_Talk = GetUITextContent("Interaction_Talk");
        IA_Steal = GetUITextContent("Interaction_Steal");
        IA_Gather = GetUITextContent("Interaction_Gather");
        IA_Harvest = GetUITextContent("Interaction_Harvest");
        IA_Take = GetUITextContent("Interaction_Take");
        IA_Use = GetUITextContent("Interaction_Use");
        Overview.GetComponent<Text>().text = GetUITextContent("DashBoard_OverView");
        Inventory.GetComponent<Text>().text = GetUITextContent("DashBoard_Inventory");
        Config.GetComponent<Text>().text = GetUITextContent("DashBoard_Settings");
        Save.GetComponent<Text>().text = GetUITextContent("DashBoard_Save");
        Load.GetComponent<Text>().text = GetUITextContent("DashBoard_Load");
        Exit.GetComponent<Text>().text = GetUITextContent("DashBoard_Exit");

        FoVSliderValue.GetComponent<Slider>().value = PlayerCamera.GetComponent<Camera>().fieldOfView;
    }
    private void EnableDashBoard()
    {
        //Debug.Log(CategoryTitle);
        dashboard.GetComponent<Image>().CrossFadeAlpha(1f, 0.3f, false);
        CategoryTitle.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Overview.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Inventory.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Config.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Save.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Load.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Exit.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        Language.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        GraphicsQuality.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        TextureQuality.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        FoV.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        QualityValue.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        GQ_LeftArrow.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        GQ_RightArrow.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        LDD_Label.GetComponent<Text>().CrossFadeAlpha(1f, 0.3f, false);
        DashboardStatus = true;
    }
    private void DisableDashBoard()
    {
        dashboard.GetComponent<Image>().CrossFadeAlpha(0.01f, 0.3f, false);
        CategoryTitle.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Overview.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Inventory.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Config.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Save.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Load.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Exit.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        PlayedTime.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Reputation.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        Language.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        GraphicsQuality.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        TextureQuality.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        FoV.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        QualityValue.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        GQ_LeftArrow.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        GQ_RightArrow.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        LDD_Label.GetComponent<Text>().CrossFadeAlpha(0.01f, 0.3f, false);
        LDD_Arrow.GetComponent<Image>().CrossFadeAlpha(0.01f, 0.3f, false);
        SetUICategoryContent(44);
        DashboardStatus = false;
        
    }
    
    private string GetUITextContent(string Key) //設定ファイルからロードしListに格納したデータを取り出し
    {

        //Debug.Log("Errrr" + Key + " " + UIString.UIStringTable[0].UINameKey);
        string return_value = "";
        for (int i = 0; i < UIString.UIStringTable.Count; i++) //設定格納List内を検索
        {
            string preload = UIString.UIStringTable[i].UINameKey;
            //Debug.Log("Processing..." + Key + " " + UIString.UIStringTable[i].UINameKey);

            if (String.Equals(Key, preload)) //検索対象と検索結果が一致したら
            {

                return_value = UIString.UIStringTable[i].String;
                Debug.Log("loaded. " + return_value);

            }
            

        }
        if(return_value == null || return_value == "")
        {
            Debug.LogError("Cannot Find the target key. Target Key Name: " + Key);
        }
        return return_value; //一致した検索結果を返す

    }
    private void CategorySetection()
    {
        if (DashboardStatus)
        {
            //Debug.Log(CategoryValue);
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (CategoryValue < CategoryValueLimit)
                {
                    CategoryValue++;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (CategoryValue > 0)
                {
                    CategoryValue--;
                }
            }
            

        }
    }
    public void FoVSliderUpdate()
    {
        var SliderValue = FoVSliderValue.GetComponent<Slider>().value;
        PlayerCamera.GetComponent<Camera>().fieldOfView = SliderValue;
    }
    public static void EngageInteraction(int InteractionMode)
    {
        switch (InteractionMode)
        {
            case 0:
                InteractionGuide.SetActive(false);
                break;
            case 1:
                InteractionGuide.GetComponent<Text>().text = "<color=\"#FFBF00\">R</color> " + IA_Talk;
                InteractionGuide.SetActive(true);
                UserInterface.InteractionMode = InteractionMode;
                break;
        }
    }
    public static void EngageTalkPanel(bool mode)
    {
        if (mode)
        {
            TalkPanel.SetActive(true);
        }
        else
        {
            TalkPanel.SetActive(false);
        }
        
    }
    public static void AssignTalkHeader(string _NPCName,string _NPCType)
    {
        TalkHeader.GetComponent<Text>().text = _NPCType +"     "+ _NPCName;
    }
    public static void UpdateTalkContent(string _TalkContent)
    {
        TalkContent.GetComponent<Text>().text = _TalkContent;
    }
    public static void FishingBited()
    {
        //Something is biting.

    }
    public static void LevelUpPopup()
    {

    }
    public static void RenewAdaptationRateOnUI()
    {
        AdaptationRate.GetComponent<Slider>().value = PlayerStats.AdaptationRate;
    }
}
