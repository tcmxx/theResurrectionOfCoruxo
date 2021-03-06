﻿using UnityEngine;
using System.Collections;

public class BurningBox : Flamable {


	public float maxBurningTime;
	public Sprite sprite0;
	AudioSource burn;
	public AudioClip burning1;
	public Sprite sprite1;
	public Sprite sprite2;
	public SpriteRenderer sprite;
	public GameObject ashPrefeb;
	public GameObject legToGivePref;
	public GameObject legBurntPref;

    public string legEventName;
	[HideInInspector]
	public bool burning = false;
	bool burned = false;

	float currentBurningTime = 0;
    protected GameObject ashRef;
	// Use this for initialization
	void Start () {
		burn = GetComponent<AudioSource> ();
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
			Vector3 tempPos = transform.position;
			tempPos.z = legBurntPref.transform.position.z;
			GameObject.Instantiate (legBurntPref, tempPos,Quaternion.identity);
		} else {
			Vector3 tempPos = transform.position;
			tempPos.z = legToGivePref.transform.position.z;
			var obj = GameObject.Instantiate (legToGivePref, tempPos,Quaternion.identity);
            ashRef = GameObject.Instantiate (ashPrefeb, transform.position,Quaternion.identity);

            obj.GetComponent<LegToGive>().eventName = legEventName;
        }
	}

    public void OnBurntOccurredAshNot()
    {
        burned = true;
        burning = false;
        sprite.sprite = null;
        if(ashPrefeb != null)
            ashRef = GameObject.Instantiate(ashPrefeb, transform.position, Quaternion.identity);
    }

    public void OnAshOccurred()
    {
        ashPrefeb = null;
        if (ashRef)
            ashRef.SetActive(false);
    }

	public void PutOutFire(){
		BurnOut ();
	}


	public override void SetOnFire(){
		if (burned == false) {
			burning = true;
			burn.PlayOneShot (burning1, 0.8f);
		}
	}


	public void Reset(){
		burned = false;
		burning = false;
		currentBurningTime = 0;
		sprite.sprite = sprite0;
	}
}
