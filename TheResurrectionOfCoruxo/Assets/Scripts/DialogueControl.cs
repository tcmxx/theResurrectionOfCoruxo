using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DialogueControl : MonoBehaviour {


	public static DialogueControl dialogueControl;
	public GameObject dialogText;

	bool isInDialogue = false;
	bool allowClick = false;


	int currentDialog = -1;

	void Awake(){
		dialogueControl = this;
	}

	// Use this for initialization
	void Start () {
		dialogText.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isInDialogue) {
			
			if (Input.GetMouseButtonDown (0) && allowClick) {
				allowClick = false;
				EndDialog ();
			}
			allowClick = true;
		}
	
	}



	public void StartDialogue(int dialogueNum){
		currentDialog = dialogueNum;
		isInDialogue = true;
		dialogText.SetActive (true);
		dialogText.GetComponent <Text>().text = Dialogues.dialogues[dialogueNum];
		SetControlsActive (false);
	}


	public void EndDialog(){

		dialogText.SetActive (false);
		SetControlsActive (true);
		isInDialogue = false;
		if (Dialogues.nextDialogue[currentDialog] != -1) {
			StartDialogue (Dialogues.nextDialogue[currentDialog]);
		}

	}


	void SetControlsActive(bool active){
	}


}



class Dialogues{

	public static readonly string[] dialogues = new string[10] {
		"I am Awake. ",
		"Please found me 8 legs",
		"test 3",
		"test 4",
		"test 5",
		"test 6",
		"test 7",
		"test 8",
		"test 9",
		"test 10",
	};

	public static readonly int[] nextDialogue = new int[10] {
		1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
	};


}







