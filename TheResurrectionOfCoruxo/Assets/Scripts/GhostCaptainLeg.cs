using UnityEngine;
using System.Collections;

public class GhostCaptainLeg : MonoBehaviour {


	public GameObject legToGivePref;

	bool taken = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void TakeLeg(){
		if (!taken) {
			GameObject.Instantiate (legToGivePref, transform.position, Quaternion.identity);
			taken = true;
		}
		PlayerControl.playerControl.DisableControls ();
	}


	public void EnableControls(){
		PlayerControl.playerControl.EnableControls ();
	}
}
