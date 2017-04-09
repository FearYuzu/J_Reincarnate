using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
    SystemCore SysCore;
    Inventory _Inventory;
    ItemString ItemStr;
    private Animator animator;
    private CharacterController cc;
    private Vector3 moveDirection = Vector3.zero;
    private float speed = 10f;
    bool TalkAvailable;
	// Use this for initialization
	void Start () {
        _Inventory = GetComponent<Inventory>();
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape) && SystemCore.IsTalkStarted)
        {
            EventAction.EndTalkWithNPC();

            Invoke("TalkEndFlag", 1);
            
        }
        if (Input.GetKeyDown(KeyCode.R) && TalkAvailable == true && SystemCore.IsTalkStarted == false)
        {
            Debug.Log("yes?");
            EventAction.StartTalkWithNPC("Talk_001");
            SystemCore.IsTalkStarted = true;
        }

    }
    void FixedUpdate()
    {
        move();
        Debug.Log(TalkAvailable);
    }
    public void GatherItems(Collision col)
    {
        if (col.gameObject.tag == "Plexus")
        {
            if (SystemCore.GameWorldSeason == "Spring")
            {
                var ItemKey = Random.Range(1,SystemCore.ItemDropListKey_Spring.Count);
                var Amount = Random.Range(1, 3);
                Inventory.AddItems(ItemKey, Amount);
            }
            
        }
        if (col.gameObject.tag == "Branch")
        {
            var ItemKey = Random.Range(1, 50);
            var Amount = Random.Range(1, 3);
            Inventory.AddItems(ItemKey, Amount);
        }
    }
    private void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            cc.Move(moveDirection * Time.fixedDeltaTime);
            animator.SetBool("isRunning", true);
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isJump", true);
            }
           
            
        }
        else
        {
            animator.SetBool("isRunning", false);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -10, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJump", true);
           
        }
        //else
        //{
          //  animator.SetBool("isJump", false);
            
        //}
        
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collide?");
        if(col.gameObject.tag == "NPC")
        {
           // Debug.Log("Collide");
            UserInterface.EngageInteraction(1);
        }
    }
    void TalkEndFlag()
    {
        SystemCore.IsTalkStarted = false;
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("Collide?");
        if (hit.gameObject.tag == "NPC")
        {
            //Debug.Log("Collide");
            UserInterface.EngageInteraction(1);
            TalkAvailable = true;
            
        }
        if (hit.gameObject.tag != "NPC")
       {
            //Debug.Log("Terrain!");
            UserInterface.EngageInteraction(0);
            TalkAvailable = false;
        }

    }
    void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "NPC")
        {
            Debug.Log("Collide");
            UserInterface.EngageInteraction(1);
            TalkAvailable = true;
        }
        
    }

}
