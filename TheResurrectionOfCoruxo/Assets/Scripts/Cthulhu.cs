using UnityEngine;
using System.Collections;
using System;

public class Cthulhu : MonoBehaviour {



	public int currentLegs;

	public int requiredFishedToGrow;

	int currentFedFished = 0;
	bool grownLeg = false;


	bool wakeUp = false;


	// Use this for initialization
	void Start () {
		currentLegs = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void ObtainLeg(){
		currentLegs++;
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
			}
		}
	}

	void Poop(){
	}



}
