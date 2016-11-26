using UnityEngine;
using System.Collections;

public class LegToGive : UsableObject {

	public bool triggerBeliever = false;
	public bool burnt = false;


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



	/// <summary>
	/// Use the object at position x, y on object obj
	/// </summary>
	/// <param name="posX">Position x.</param>
	/// <param name="posY">Position y.</param>
	/// <param name="obj">Object.</param>
	public override bool Use(float posX, float posY, GameObject obj = null){
		base.Use (posX, posY, obj);
		if (obj != null) {
			Cthulhu creature = obj.GetComponent <Cthulhu> ();
			if (creature != null) {
				if (burnt) {
					creature.ObtainWrongLeg ();
				} else {
					creature.ObtainLeg ();
				}

				Destroy (gameObject, 0.1f);
				return true;
			}

			Believer believer = obj.GetComponent <Believer> ();
			if (believer != null) {
				if (triggerBeliever) {
					believer.GetRightLeg ();
				} else {
					believer.GetWrongLeg ();
				}
				return true;
			}

		}
		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}


}
