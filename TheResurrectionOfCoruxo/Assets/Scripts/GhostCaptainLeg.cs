using UnityEngine;
using System.Collections;

public class GhostCaptainLeg : MonoBehaviour {


	public GameObject legToGivePref;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void TakeLeg(){
		GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
		PlayerControl.playerControl.DisableControls ();
	}


	public void EnableControls(){
		PlayerControl.playerControl.EnableControls ();
	}
}
