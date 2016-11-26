using UnityEngine;
using System.Collections;

public class TreasureBox : MonoBehaviour {

	public Sprite newSprite;
	public Sprite newSprite2;
	public SpriteRenderer sprite;

	public bool containTreasure;

	public GameObject legToGivePref;

	bool opened = false;
	bool treasureShown = false;



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
		if (containTreasure == true) {
			sprite.sprite = newSprite;
		} else {
			sprite.sprite = newSprite2;
		}
	}
}
