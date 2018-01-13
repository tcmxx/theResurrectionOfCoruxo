using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DialogueControl : MonoBehaviour {


	public static DialogueControl dialogueControl;
	public GameObject dialogText;

    bool isInDialogue = false;
	bool allowHandControl = true;


	int currentDialog = -1;

    private string[] dialoguesToUse;


    void Awake(){
		dialogueControl = this;
	}

	// Use this for initialization
	void Start () {
		dialogText.SetActive (false);

        dialoguesToUse = (Application.systemLanguage == SystemLanguage.Chinese || 
            Application.systemLanguage == SystemLanguage.ChineseSimplified || 
            Application.systemLanguage == SystemLanguage.ChineseTraditional) ? Dialogues.dialoguesChinese : Dialogues.dialogues;

    }
	
	// Update is called once per frame
	void Update () {


        SetControlsActive(allowHandControl);
        
		if (isInDialogue) {
			
			if (Input.GetMouseButtonDown (0)) {
                allowHandControl = true;
                EndDialog ();
            }
		}
	
	}



	public void StartDialogue(int dialogueNum){
		currentDialog = dialogueNum;
		isInDialogue = true;
        
		dialogText.SetActive (true);
		dialogText.GetComponentInChildren <Text>().text = dialoguesToUse[dialogueNum];

        allowHandControl = false;
        SetControlsActive (false);
	}


	public void EndDialog(){

		dialogText.SetActive (false);
		
		isInDialogue = false;
		if (Dialogues.nextDialogue[currentDialog] != -1) {
			StartDialogue (Dialogues.nextDialogue[currentDialog]);
		}

	}


	void SetControlsActive(bool active){
        PlayerControl.Instance.SetEnableControls(active);
	}


}



class Dialogues{

	public static readonly string[] dialogues = new string[10] {
		"Cthultu soul: Hello human",
        "I need my 8 tentacles to resurrect",
        "You burned my leg! I will reverse the time. Don't burn it again!",
        "I want to resurrect the Cthulhu with this tentacle. Bring me something from Cthulhu.",
        "This is not from a living Cthulhu. Don't fool me.",
        "Did you really think a simple rock would hurt me?",
        "The Fish is delicious!",
		"test 8",
		"test 9",
		"test 10",
	};
    public static readonly string[] dialoguesChinese = new string[10] {
        "克苏鲁的灵魂：你好人类",
        "请帮我找到8根触须来复活我",
        "你烧毁了我的脚！但是我会让时光倒流再给你一次机会",
        "给我一件来自克苏鲁的东西。我会把这个触须给你",
        "T这个不是来自克苏鲁。别以为我是傻逼",
        "你真以为一个小石头能够伤到我？",
        "这鱼真好吃！",
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







