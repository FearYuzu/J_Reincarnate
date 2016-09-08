using UnityEngine;
using System.Collections;

public class EventAction : MonoBehaviour {
    TalkString TalkStr;
	// Use this for initialization
	void Start () {
        TalkStr = GameObject.Find("EventSystem").GetComponent<TalkString>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartTalkWithNPC(int key)
    {
        //Show Talking UI

        //Init
        var NPCName = TalkStr.TalkStringTable[key].NPCName;
        var NPCType = TalkStr.TalkStringTable[key].NPCType;
        var Desc1 = TalkStr.TalkStringTable[key].Desc1;
        var Desc2 = TalkStr.TalkStringTable[key].Desc2;
        var Desc3 = TalkStr.TalkStringTable[key].Desc3;
        var Desc4 = TalkStr.TalkStringTable[key].Desc4;
        var Desc5 = TalkStr.TalkStringTable[key].Desc5;
        var Desc6 = TalkStr.TalkStringTable[key].Desc6;
        var Desc7 = TalkStr.TalkStringTable[key].Desc7;
        var Desc8 = TalkStr.TalkStringTable[key].Desc8;
        var Desc9 = TalkStr.TalkStringTable[key].Desc9;
        var Desc10 = TalkStr.TalkStringTable[key].Desc10;

    }
    private void EndTalkWithNPC()
    {
        //Close Talking UI
    }
}
