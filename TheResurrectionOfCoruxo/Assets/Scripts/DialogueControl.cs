using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour {


	public static DialogueControl dialogueControl;
	public GameObject dialogText;

	bool isInDialogue = false;



	void Awake(){
		dialogueControl = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isInDialogue) {
			if (Input.GetMouseButtonDown (0)) {
			}
		}
	
	}



	public void StartDialogue(int dialogueNum){
		dialogText.SetActive (true);
		dialogText.GetComponent <Text>().text = Dialogues.dialogues[dialogueNum];
		SetControlsActive (false);
	}


	public void EndDialog(){

		dialogText.SetActive (false);
		SetControlsActive (true);

	}


	void SetControlsActive(bool active){
	}


}



class Dialogues{

	public static readonly string[] dialogues = new string[10] {
		"test 1",
		"test 2",
		"test 3",
		"test 4",
		"test 5",
		"test 6",
		"test 7",
		"test 8",
		"test 9",
		"test 10",
	};


}







