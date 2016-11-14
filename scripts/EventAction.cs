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
        var NPCName = TalkString.TalkStringTable[key].NPCName;
        var NPCType = TalkString.TalkStringTable[key].NPCType;
        var Desc1 = TalkString.TalkStringTable[key].Desc1;
        var Desc2 = TalkString.TalkStringTable[key].Desc2;
        var Desc3 = TalkString.TalkStringTable[key].Desc3;
        var Desc4 = TalkString.TalkStringTable[key].Desc4;
        var Desc5 = TalkString.TalkStringTable[key].Desc5;
        var Desc6 = TalkString.TalkStringTable[key].Desc6;
        var Desc7 = TalkString.TalkStringTable[key].Desc7;
        var Desc8 = TalkString.TalkStringTable[key].Desc8;
        var Desc9 = TalkString.TalkStringTable[key].Desc9;
        var Desc10 = TalkString.TalkStringTable[key].Desc10;

    }
    private void EndTalkWithNPC()
    {
        //Close Talking UI
    }
}
