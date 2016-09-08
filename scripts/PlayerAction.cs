using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
    Inventory _Inventory;
	// Use this for initialization
	void Start () {
        _Inventory = GetComponent<Inventory>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GatherItems(Collision col)
    {
        if (col.gameObject.tag == "Plexus")
        {
            var ItemKey = Random.Range(1, 50);
            var Amount = Random.Range(1,3);
            _Inventory.AddItems(ItemKey, Amount);
        }
        if (col.gameObject.tag == "Branch")
        {
            var ItemKey = Random.Range(1, 50);
            var Amount = Random.Range(1, 3);
            _Inventory.AddItems(ItemKey, Amount);
        }
    }
}
