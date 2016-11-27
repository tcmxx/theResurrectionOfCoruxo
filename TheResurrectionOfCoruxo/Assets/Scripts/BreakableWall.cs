using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	public SpriteRenderer sprite;

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
		sprite.sprite = sprite1;
		if (!broken && currentHitTimes >= requiredHitTimes) {
			Break ();
		}
	}


	void Break(){
		sprite.sprite = sprite2;
		GetComponent <Collider2D>().enabled = false;
		broken = true;
	}

}
