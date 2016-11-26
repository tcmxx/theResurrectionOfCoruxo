using UnityEngine;
using System.Collections;

public class Torch : UsableObject {

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

		if (obj != null) {
			Flamable flame = obj.GetComponent <Flamable> ();
			if (flame != null) {
				flame.SetOnFire ();
				//Destroy (gameObject, 0.1f);
				return true;
			}
		}
		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}


}
