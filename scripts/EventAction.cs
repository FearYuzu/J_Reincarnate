using UnityEngine;
using System.Collections;
using System;

public class EventAction : MonoBehaviour {
    TalkString TalkStr;
    static string NPCName, NPCType, Desc1, Desc2, Desc3, Desc4, Desc5, Desc6, Desc7, Desc8, Desc9, Desc10;
    static bool isTalkReady = false;
    static bool isTalkEnded = true;
    // Use this for initialization
    void Start () {
        TalkStr = GameObject.Find("EventSystem").GetComponent<TalkString>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isTalkReady == true)
        {
            StartCoroutine("UpdateTalkContent");
            Debug.Log("Talk Processing Started");
            isTalkReady = false;
        }
        if(isTalkEnded == true)
        {
            StopCoroutine("UpdateTalkContent");
            isTalkEnded = false;
        }

	
	}
    public static void StartTalkWithNPC(string Key)
    {
        //Initialize
        //Debug.Log("Errrr" + Key + " " + UIString.UIStringTable[0].UINameKey);
        for (int i = 0; i < TalkString.TalkStringTable.Count; i++) //設定格納List内を検索
        {
            string preload = TalkString.TalkStringTable[i].Key;
            Debug.Log("Processing..." + Key + " " + TalkString.TalkStringTable[i].Key);
            
            if (String.Equals(Key, preload)) //検索対象と検索結果が一致したら
            {
                NPCName = TalkString.TalkStringTable[i].NPCName;
                NPCType = TalkString.TalkStringTable[i].NPCType;
                Desc1 = TalkString.TalkStringTable[i].Desc1;
                Desc2 = TalkString.TalkStringTable[i].Desc2;
                Desc3 = TalkString.TalkStringTable[i].Desc3;
                Desc4 = TalkString.TalkStringTable[i].Desc4;
                Desc5 = TalkString.TalkStringTable[i].Desc5;
                Desc6 = TalkString.TalkStringTable[i].Desc6;
                Desc7 = TalkString.TalkStringTable[i].Desc7;
                Desc8 = TalkString.TalkStringTable[i].Desc8;
                Desc9 = TalkString.TalkStringTable[i].Desc9;
                Desc10 = TalkString.TalkStringTable[i].Desc10;
                Debug.Log(Key + ":" + preload);
                Debug.Log("All Talk Data Loaded");
            }
            if (NPCName == null ||  NPCName == "")
            {
                Debug.LogError("Cannot Assign the Content. Target Content Name: " + Key);
            }
        }
        //Show Talking UI
        UserInterface.EngageTalkPanel(true);
        UserInterface.AssignTalkHeader(NPCType, NPCName);
        isTalkReady = true;
        Debug.Log("Talk is now ready.");
        


    }
    IEnumerator UpdateTalkContent()
    {
        var wait = new WaitForSeconds(0.001f);
        int ReadCount = 0;
        while (true)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                ReadCount++;
                Debug.Log("ReadCount++");
            }
           // Debug.Log("Processing..");
            switch (ReadCount)
            {
                case 1:
                    UserInterface.UpdateTalkContent(Desc1);
                    break;
                case 2:
                    UserInterface.UpdateTalkContent(Desc2);
                    break;
                case 3:
                    UserInterface.UpdateTalkContent(Desc3);
                    break;
                case 4:
                    UserInterface.UpdateTalkContent(Desc4);
                    break;
                case 5:
                    UserInterface.UpdateTalkContent(Desc5);
                    break;
                case 6:
                    UserInterface.UpdateTalkContent(Desc6);
                    break;
                case 7:
                    UserInterface.UpdateTalkContent(Desc7);
                    break;
                case 8:
                    UserInterface.UpdateTalkContent(Desc8);
                    break;
                case 9:
                    UserInterface.UpdateTalkContent(Desc9);
                    break;
                case 10:
                    UserInterface.UpdateTalkContent(Desc10);
                    break;

            }
            yield return wait;
        }
    }
    public void test()
    {
        StartCoroutine("UpdateTalkContent");
    }
    public static void EndTalkWithNPC()
    {
        //Close Talking UI
        UserInterface.EngageTalkPanel(false);
        //SystemCore.IsTalkStarted = false;
        isTalkEnded = true;
        

         
    }
    public static void StartFishing(string placetype)
    {

    }
    IEnumerator FishingProcess()
    {
        var wait = new WaitForSeconds(1);
        var baitcount = 0;
        var baitflag = UnityEngine.Random.Range(15, 30);
        while (true)
        {
            baitcount++;
            if(baitcount == baitflag)
            {

            }
            yield return wait;
        }
    }
    public static void IncreaseAdaptationRate(float IncreaseValue)
    {
        PlayerStats.AdaptationRate += IncreaseValue;
    }
    public static void DecreaseAdaptationRate(float DecreaseValue)
    {
        PlayerStats.AdaptationRate -= DecreaseValue;
    }
}
