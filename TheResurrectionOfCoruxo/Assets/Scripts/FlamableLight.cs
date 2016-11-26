using UnityEngine;
using System.Collections;

public class FlamableLight : Flamable {


	public GameObject darkness;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public override void SetOnFire(){
		if (darkness != null) {
			darkness.SetActive (false);
		}
		GetComponent <SpriteRenderer>().color = Color.red;
	}
}
