﻿using UnityEngine;
using System.Collections;

public class TreasureBox : MonoBehaviour {

	public Sprite newSprite;
	public Sprite newSprite2;
	public SpriteRenderer sprite;

	public bool containTreasure;

	public GameObject legToGivePref;


	public GameObject ghostPref;
    public string legEventName;

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
			PlayerControl.Instance.SetEnableControls (false);
			Invoke ("EnableControls", 0.5f);
			var obj = GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
            obj.GetComponent<LegToGive>().eventName = legEventName;
            treasureShown = true;
		}
	}

	public void EnableControls(){
        PlayerControl.Instance.SetEnableControls(true);
    }

	void Open(){
		opened = true;
		if (containTreasure == true) {
			sprite.sprite = newSprite;
			 GameObject.Instantiate (ghostPref, transform.position + Vector3.up * 3,Quaternion.identity);
            
        } else {
			sprite.sprite = newSprite2;
		}
	}

    public void InitializedOpen()
    {
        opened = true;
        if (containTreasure == true)
        {
            sprite.sprite = newSprite;
             GameObject.Instantiate(ghostPref, transform.position + Vector3.up * 3, Quaternion.identity);
            treasureShown = true;

        }
        else
        {
            sprite.sprite = newSprite2;
        }
        
    }
}
