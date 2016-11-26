using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {


	public GameObject legToGivePref;


	bool empty = false;

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


	public void HitByStone(){
	}

	public void HitByAsh(){
		if (empty == false) {
			GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
			empty = true;
		}
	}


}
