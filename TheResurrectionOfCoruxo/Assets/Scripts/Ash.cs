using UnityEngine;
using System.Collections;

public class Ash : UsableObject {

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

			Monster monster = obj.GetComponent <Monster> ();
			if (monster != null) {

				monster.HitByAsh ();
				Destroy (gameObject, 0.1f);
				return true;
			}
		}
		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}


}
