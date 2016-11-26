using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		InputControl ();

	
	}


	void InputControl(){
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.right*x + Vector3.up * y);
	}



}
