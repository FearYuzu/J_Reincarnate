using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
    SystemCore SysCore;
    Inventory _Inventory;
    ItemString ItemStr;
	// Use this for initialization
	void Start () {
        _Inventory = GetComponent<Inventory>();
        SysCore = GameObject.Find("EventSystem").GetComponent<SystemCore>();
        ItemStr = GameObject.Find("EventSystem").GetComponent<ItemString>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GatherItems(Collision col)
    {
        if (col.gameObject.tag == "Plexus")
        {
            if (SysCore.GameWorldSeason == "Spring")
            {
                var ItemKey = Random.Range(1,SysCore.ItemDropListKey_Spring.Count);
                var Amount = Random.Range(1, 3);
                _Inventory.AddItems(ItemKey, Amount);
            }
            
        }
        if (col.gameObject.tag == "Branch")
        {
            var ItemKey = Random.Range(1, 50);
            var Amount = Random.Range(1, 3);
            _Inventory.AddItems(ItemKey, Amount);
        }
    }
}
