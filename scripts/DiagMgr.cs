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
        FPSValue = GameObject.Find("Canvas/DiagWindow/FPS").GetComponent<Text>();
        UsedMemoryValue = GameObject.Find("Canvas/DiagWindow/Used Memory").GetComponent<Text>();
        StartCoroutine("GetFPS");
        StartCoroutine("GetPerfInfo");
        StartCoroutine("GetUsedMemory");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator GetPerfInfo()
    {
        while (true)
        {
            FPSValue.text = "FPS: " + (int)fps;
            UsedMemoryValue.text = "Used Memory: "+ usedmemory/1048576 +"MB";
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator GetFPS()
    {
        while (true)
        {
            fps = 1f / Time.deltaTime;
            yield return new WaitForSeconds(0.5f);
        }
        
        
    }
    IEnumerator GetUsedMemory()
    {
        while (true)
        {
            usedmemory = System.GC.GetTotalMemory(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
