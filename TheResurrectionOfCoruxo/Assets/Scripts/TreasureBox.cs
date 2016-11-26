using UnityEngine;
using System.Collections;

public class TreasureBox : MonoBehaviour {


	public bool containTreasure;

	public GameObject legToGivePref;

	bool opened = false;
	bool treasureShown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void OnClicked(){
		if (!opened) {
			Open ();
		} else if (opened && containTreasure && !treasureShown) {
			PlayerControl.playerControl.DisableControls ();
			GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
			treasureShown = true;
		}
	}

	public void EnableControls(){
		PlayerControl.playerControl.EnableControls ();
	}

	void Open(){
		opened = true;
	}
}
