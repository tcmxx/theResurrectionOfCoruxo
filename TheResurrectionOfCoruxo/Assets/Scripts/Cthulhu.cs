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

    protected GameObject poopRef;

	// Use this for initialization
	void Start () {
		currentLegs = 0;
		ending = GetComponent<AudioSource> ();
		unl = GetComponent<AudioSource> ();
        Initialize();

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    protected void Initialize()
    {
        var events = GameSaveManager.Instance.OccurredEvents();
        for(int i = 0; i < events.Count; ++i)
        {
            legs[currentLegs].SetActive(true);
            currentLegs++;
            if (currentLegs != 6)
                CameraMove.Instance.Unlock(currentLegs);
        }

        if(events.Count > 0)
        {
            spriteRenderer.sprite = cthulhuNormalSprite;
            wakeUp = true;
            CameraMove.Instance.Unlock(0);
        }
    }

	public void ObtainLeg(string eventName){


		unl.PlayOneShot (unlock, 0.5f);

		if (currentLegs == 3) {
			PlayerControl.Instance.LoseTorch ();
		}

        
		legs [currentLegs].SetActive (true);
		currentLegs++;
        if (currentLegs != 6)
            CameraMove.Instance.Unlock(currentLegs);
        if (currentLegs >= 8) {
			CutSceneController.cutSceneController.PlayCutScene ();
			ending.PlayOneShot (end, 0.6f);
            GameSaveManager.Instance.ClearRecord();
		}
        if(!string.IsNullOrEmpty(eventName)){
            GameSaveManager.Instance.SetEventOccurred(eventName);
            GamePlayUI.Instance.ShowSavedPanel();
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
				ObtainLeg ("Leg_FeedFish");
				Poop ();
				grownLeg = true;
				currentFedFished = 0;
			}
		}
	}

    public void OnFeedFishOccurred()
    {
        Poop();
        grownLeg = true;
        currentFedFished = 0;
    }

    public void OnCaptainOccurred()
    {
        poopPref = null;
        if (poopRef)
            poopRef.SetActive(false);
    }

    void Poop(){
        if(poopPref != null)
            poopRef = GameObject.Instantiate (poopPref,transform.position + Vector3.right * 2,Quaternion.identity);
	}



}
