using UnityEngine;
using System.Collections;

public class CutSceneController : MonoBehaviour {


	public static CutSceneController cutSceneController;


	void Awake(){
		cutSceneController = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	void PlayCutScene(int index){
		if (index == 0) {
			StartCoroutine(CutScene0 ());
		} else if (index == 1) {
			StartCoroutine(CutScene1 ());
		} else if (index == 2) {
			StartCoroutine(CutScene2 ());
		}
	}


	IEnumerator CutScene0(){
		yield return null;
	}

	IEnumerator CutScene1(){
		yield return null;
	}

	IEnumerator CutScene2(){
		yield return null;
	}
}
