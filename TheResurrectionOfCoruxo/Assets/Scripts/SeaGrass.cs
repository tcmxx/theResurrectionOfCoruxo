using UnityEngine;
using System.Collections;

public class SeaGrass : MonoBehaviour {




	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Grow(){

		transform.localScale += Vector3.up * 10;
		CameraMove.cam.ChangeY7 ();
	}
}
