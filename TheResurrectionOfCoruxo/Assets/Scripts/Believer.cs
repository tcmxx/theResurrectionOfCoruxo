using UnityEngine;
using System.Collections;

public class Believer : MonoBehaviour {


	public GameObject legToGivePref;
	public SpriteRenderer sprite;
	public Sprite sprite1;

	bool given = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void GetWrongLeg(){
		DialogueControl.dialogueControl.StartDialogue (4);
	}

	public void GetRightLeg(){
		if (!given) {
			GameObject.Instantiate (legToGivePref, transform.position, Quaternion.identity);
			sprite.sprite = sprite1;
			given = true;
		}
	}


	public void Talk(){
		if (!given) {
			DialogueControl.dialogueControl.StartDialogue (3);
		}
	}
}
