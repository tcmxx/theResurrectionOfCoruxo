using UnityEngine;
using System.Collections;

public class Stone : UsableObject {

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

		//set the physics
		GetComponent <Collider2D>().enabled = true;
		GetComponent <Rigidbody2D>().isKinematic = false;

		transform.localScale /= 4f;

		if (obj != null) {
			BreakableWall wall = obj.GetComponent <BreakableWall> ();
			if (wall != null) {

				wall.HitOn ();
				//Destroy (gameObject, 0.1f);
				return true;
			}

			Monster monster = obj.GetComponent <Monster> ();
			if (monster != null) {

				monster.HitByStone ();
				//Destroy (gameObject, 0.1f);
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
