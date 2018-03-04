using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	public GameObject legToGivePref;
    public string legEventName;

    bool empty = false;

	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void HitByStone(){
		anim.SetTrigger ("hit");
		DialogueControl.dialogueControl.StartDialogue (5);
	}

	public void HitByAsh(){
		if (empty == false) {
			var obj = GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
			empty = true;
			anim.SetTrigger ("legtaken");

            obj.GetComponent<LegToGive>().eventName = legEventName;
        }
	}

    public void InitializeAfter()
    {
        empty = true;
        anim.SetTrigger("legtaken");
    }
}
