using UnityEngine;
using System.Collections;
using UnityEditor;

public class BreakableWall : MonoBehaviour {


	public int requiredHitTimes;

	int currentHitTimes = 0;

	bool broken = false;

	public SpriteRenderer spriteRenderer;
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
		spriteRenderer.sprite = null;
		GetComponent <Collider2D>().enabled = false;
		broken = true;
	}

}
