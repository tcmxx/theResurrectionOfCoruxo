using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour {


	public static CutSceneController cutSceneController;


	public GameObject imageUI;


	public Sprite[] cutScene0Images;



	int currentInd = 0;

	bool playing = false;

	void Awake(){
		cutSceneController = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playing) {
			if (Input.GetMouseButtonDown (0)) {
				currentInd++;
				if (currentInd >= cutScene0Images.Length) {
					playing = false;
					SceneManager.LoadScene ("MenuScene");
				} else {
					imageUI.GetComponent <SpriteRenderer> ().sprite = cutScene0Images [currentInd];
				}

			}
		} else {
		}
	}




	public void PlayCutScene(){
		playing = true;
		imageUI.SetActive (true);
		imageUI.GetComponent <SpriteRenderer>().sprite = cutScene0Images[0];
	}


}
