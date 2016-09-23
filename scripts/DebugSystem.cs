using UnityEngine;
using System;
using System.Text;
using System.Collections;
using UnityEngine.UI;

public class DebugSystem : MonoBehaviour {

    //Debugging System such as call loaded strings, etc.
    
    public Dropdown dropdown;
    public Dropdown dropdown1;
    public InputField input;
    public Text result;
    public Text result_item;
    public Text result_desc;
    public string stringtype = "Area";
    public string stringseason = "Spring";
	// Use this for initialization
	void Start () {
        dropdown = GameObject.Find("Canvas/Debugging/SelectStringType").GetComponent<Dropdown>();
        dropdown1 = GameObject.Find("Canvas/Debugging/SelectSeason").GetComponent<Dropdown>();
        input = GameObject.Find("Canvas/Debugging/Input").GetComponent<InputField>();
        result = GameObject.Find("Canvas/Debugging/Result").GetComponent<Text>();
        result_item = GameObject.Find("Canvas/Debugging/Result_Item").GetComponent<Text>();
        result_desc = GameObject.Find("Canvas/Debugging/Result_desc").GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartQuery();
            CallRamdomizedItemKey();
        }
	
	}
    public void OnValueChanged(int result)
    {
        // 処理
        if (dropdown.captionText.text == "Area")
        {
            stringtype = "Area";
            Debug.Log("Set to Type:Area");
        }
        if (dropdown.captionText.text == "Item")
        {
            stringtype = "Item";
            Debug.Log("Set to Type:Item");
        }
        if (dropdown.captionText.text == "System")
        {
            stringtype = "System";
            Debug.Log("Set to Type:System");
        }
    }
    public void StartQuery()
    {
        try
        {
            int keynumber = int.Parse(input.text);
            if (stringtype == "Area")
            {
                if (keynumber < AreaString.AreaName.Count || keynumber != null)
                {
                    result.text = AreaString.AreaName[keynumber];
                    Debug.Log("Queried");
                }
                else
                {
                    result.text = SystemMessageDefine.SMDefineTable[33].Content;
                }

            }
            if (stringtype == "Item")
            {
                if (keynumber < ItemString.ItemStringTable.Count || keynumber != null)
                {
                    result.text = ItemString.ItemStringTable[keynumber].ItemName;
                    Debug.Log("Queried");
                }
                else
                {
                    result.text = SystemMessageDefine.SMDefineTable[33].Content;
                }
            }
            if (stringtype == "System")
            {
                if (keynumber < SystemMessageDefine.SMDefineTable.Count || keynumber != null)
                {
                    result.text = SystemMessageDefine.SMDefineTable[keynumber].Content;
                }
                else
                {
                    result.text = SystemMessageDefine.SMDefineTable[33].Content;
                }
            }
            
        }
        catch (FormatException e)
        {
            result.text = SystemMessageDefine.SMDefineTable[33].Content;
        }
       
        
    }
    public void SeasonSelect()
    {
        if (dropdown1.captionText.text == "Any")
        {
            stringseason = "Any";
        }
        if (dropdown1.captionText.text == "Spring")
        {
            stringseason = "Spring";
            Debug.Log("Set to Type:Area");
        }
        if (dropdown1.captionText.text == "Summer")
        {
            stringseason = "Summer";
            Debug.Log("Set to Type:Item");
        }
        if (dropdown1.captionText.text == "Autumn")
        {
            stringseason = "Autumn";
            Debug.Log("Set to Type:System");
        }
    }
    public void CallRamdomizedItemKey()
    {
        if (stringseason == "Spring")
        {
            SystemCore.ItemDropKeyGenerator();
            var ItemKey = UnityEngine.Random.Range(1, SystemCore.ItemDropListKey_Spring.Count);
            Debug.Log(SystemCore.ItemDropListKey_Spring.Count);
            Debug.Log(ItemString.ItemStringTable.Count);
            var Amount = UnityEngine.Random.Range(1, 3);
            result_item.text = ItemKey.ToString();
            result_desc.text = Amount.ToString();
        }
        if (stringseason == "Any")
        {
            
            var Itemkey = UnityEngine.Random.Range(1, SystemCore.ItemDropListKey_Any.Count);
            var Amount = UnityEngine.Random.Range(1, 4);
            Debug.Log(SystemCore.ItemDropListKey_Any.Count);
            result_item.text = Itemkey.ToString();
            result_desc.text = Amount.ToString();
        }
    }

}
