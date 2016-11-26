using UnityEngine;
using System.Collections;
using System;

public class Cthulhu : MonoBehaviour {



	public int currentLegs;

	public int requiredFishedToGrow;

	public GameObject poopPref;


	public GameObject[] legs;

	public BurningBox burningBox;

	public Sprite cthulhuNormalSprite;

	public SpriteRenderer spriteRenderer;


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
		CameraMove.cam.changeIndex (1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void ObtainLeg(){


		CameraMove.cam.changeIndex ((currentLegs + 3) >= 8? 8:(currentLegs + 3));




		legs [currentLegs].SetActive (true);
		currentLegs++;

		if (currentLegs >= 8) {
			CutSceneController.cutSceneController.PlayCutScene ();
		}
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
		spriteRenderer.sprite = cthulhuNormalSprite;
		CameraMove.cam.changeIndex (2);
		wakeUp = true;

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
