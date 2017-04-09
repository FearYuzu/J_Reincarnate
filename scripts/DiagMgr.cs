using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiagMgr : MonoBehaviour {
    private Text FPSValue;
    private Text UsedMemoryValue;
    float fps;
    long usedmemory;
	// Use this for initialization
	void Start()
    {
        FPSValue = GameObject.Find("DashBoard/Canvas/DiagWindow/FPS").GetComponent<Text>();
        UsedMemoryValue = GameObject.Find("DashBoard/Canvas/DiagWindow/Used Memory").GetComponent<Text>();
        StartCoroutine("GetFPS");
        StartCoroutine("GetPerfInfo");
        StartCoroutine("GetUsedMemory");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator GetPerfInfo()
    {
        var wait = new WaitForSeconds(0.5f);
        while (true)
        {
            FPSValue.text = "FPS: " + (int)fps;
            UsedMemoryValue.text = "Used Memory: "+ usedmemory/1048576 +"MB";
            yield return wait;
        }
    }
    IEnumerator GetFPS()
    {
        var wait = new WaitForSeconds(0.5f);
        while (true)
        {
            fps = 1f / Time.deltaTime;
            yield return wait;
        }
        
        
    }
    IEnumerator GetUsedMemory()
    {
        var wait = new WaitForSeconds(0.5f);
        while (true)
        {
            usedmemory = System.GC.GetTotalMemory(false);
            yield return wait;
        }
    }
}
