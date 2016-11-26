using UnityEngine;
using System.Collections;
using System;

public class Cthulhu : MonoBehaviour {



	public int currentLegs;

	public int requiredFishedToGrow;

	public GameObject poopPref;


	public GameObject[] legs;

	public BurningBox burningBox;

	int currentFedFished = 0;
	bool grownLeg = false;


	bool wakeUp = false;

	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}
	// Use this for initialization
	void Start () {
		currentLegs = 0;
		CameraMove.cam.Unlock (5);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void ObtainLeg(){
		CameraMove.cam.Unlock (currentLegs+1);
		legs [currentLegs].SetActive (true);
		currentLegs++;
	}

	public void LoseLeg(){
		currentLegs--;
	}


	public void ObtainWrongLeg(){
		burningBox.Reset ();
		DialogueControl.dialogueControl.StartDialogue (2);
	}

	public void OnClicked(){
		if (wakeUp == false) {
			WakeUp ();
		}
	}


	public void WakeUp(){
		DialogueControl.dialogueControl.StartDialogue (0);


	}


	public void Feed(){
		if(!grownLeg){
			currentFedFished++;
			if (currentFedFished >= requiredFishedToGrow) {
				ObtainLeg ();
				Poop ();
				grownLeg = true;
				currentFedFished = 0;
			}
		}
	}

	void Poop(){
		GameObject.Instantiate (poopPref,transform.position + Vector3.right * 2,Quaternion.identity);
	}



}
