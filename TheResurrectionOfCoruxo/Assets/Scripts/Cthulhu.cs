using UnityEngine;
using System.Collections;
using System;

public class Cthulhu : MonoBehaviour {



	public int currentLegs;

	public int requiredFishedToGrow;

	public GameObject poopPref;

	AudioSource unl;
	public AudioClip unlock;

	AudioSource ending;
	public AudioClip end;


	public GameObject[] legs;

	public BurningBox burningBox;

	public Sprite cthulhuNormalSprite;

	public SpriteRenderer spriteRenderer;


	int currentFedFished = 0;
	bool grownLeg = false;

	[HideInInspector]
	public bool wakeUp = false;

	// Use this for initialization
	void Start () {
		currentLegs = 0;
		ending = GetComponent<AudioSource> ();
		unl = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void ObtainLeg(){


		unl.PlayOneShot (unlock, 0.5f);

		if (currentLegs == 3) {
			PlayerControl.Instance.LoseTorch ();
		}

		legs [currentLegs].SetActive (true);
		currentLegs++;
        CameraMove.Instance.Unlock(currentLegs);
        if (currentLegs >= 8) {
			CutSceneController.cutSceneController.PlayCutScene ();
			ending.PlayOneShot (end, 0.6f);
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
		wakeUp = true;
        CameraMove.Instance.Unlock(0);

	}


	public void Feed(){
		if(!grownLeg){
			currentFedFished++;

			DialogueControl.dialogueControl.StartDialogue (6);
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
