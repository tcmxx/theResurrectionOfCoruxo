using UnityEngine;
using System.Collections;

public class FireExtinguisher : UsableObject {

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
			BurningBox box = obj.GetComponent <BurningBox> ();
			if (box != null) {
				box.PutOutFire ();
				//Destroy (gameObject, 0.1f);
				return true;
			}
		}
		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}


}
