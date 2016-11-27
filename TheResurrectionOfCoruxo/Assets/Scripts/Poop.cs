using UnityEngine;
using System.Collections;

public class Poop : UsableObject {

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
		//base.Use (posX, posY, obj);

		GetComponent <Collider2D>().enabled = true;
		GetComponent <Rigidbody2D>().isKinematic = false;

		transform.localScale /= 4f;


		GetComponent <Rigidbody2D>().isKinematic = true;
		if (obj != null) {

			SeaGrass grass = obj.GetComponent <SeaGrass> ();
			if (grass != null) {

				grass.Grow ();
				Destroy (gameObject, 0.2f);
				return true;
			}
		}
		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}


	public override void Obtain(){
		//set the physical state
		GetComponent <Collider2D>().enabled = false;
		GetComponent <Rigidbody2D>().isKinematic = true;
		transform.localScale *= 4f;

	}
}
