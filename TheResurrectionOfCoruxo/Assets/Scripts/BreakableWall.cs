using UnityEngine;
using System.Collections;
using UnityEditor;

public class BreakableWall : MonoBehaviour {


	public int requiredHitTimes;

	int currentHitTimes = 0;

	bool broken = false;


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


	public void HitOn(){
		currentHitTimes++;
		if (!broken && currentHitTimes >= requiredHitTimes) {
			Break ();
		}
	}


	void Break(){
		GetComponent <SpriteRenderer>().sprite = null;
		GetComponent <Collider2D>().enabled = false;
		broken = true;
	}

}
