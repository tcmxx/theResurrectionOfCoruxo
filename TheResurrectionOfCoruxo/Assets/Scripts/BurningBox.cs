using UnityEngine;
using System.Collections;

public class BurningBox : Flamable {


	public float maxBurningTime;
	public Sprite sprite0;
	public Sprite sprite1;
	public Sprite sprite2;
	public SpriteRenderer sprite;
	public GameObject ashPrefeb;
	public GameObject legToGivePref;
	public GameObject legBurntPref;

	bool burning = false;
	bool burned = false;

	float currentBurningTime = 0;

	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (burning && !burned) {
			currentBurningTime += Time.deltaTime;
			if (currentBurningTime <= 0.5 * maxBurningTime) {
				sprite.sprite = sprite1;
			} else {
				sprite.sprite = sprite2;
			}
			if (currentBurningTime >= maxBurningTime) {
				BurnOut ();
			}

			Color col = GetComponent <SpriteRenderer> ().color;
			col.b = 1.0f * (1 - currentBurningTime / maxBurningTime);
			col.g = 1.0f * (1 - currentBurningTime / maxBurningTime);
			GetComponent <SpriteRenderer> ().color = col;
		}
	
	}


	void BurnOut(){
		burned = true;
		burning = false;
		sprite.sprite = null;
		if (currentBurningTime >= maxBurningTime) {
			GameObject.Instantiate (legBurntPref, transform.position,Quaternion.identity);
		} else {
			GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
			GameObject.Instantiate (ashPrefeb, transform.position,Quaternion.identity);
		}
	}


	public void PutOutFire(){
		BurnOut ();
	}


	public override void SetOnFire(){
		if (burned == false) {
			burning = true;
		}
	}


	public void Reset(){
		burned = false;
		burning = false;
		currentBurningTime = 0;
		sprite.sprite = sprite0;
	}
}
