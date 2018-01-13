using UnityEngine;
using System.Collections;

public class UsableObject : MonoBehaviour {




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
	public virtual bool Use(float posX, float posY, GameObject obj = null){
		//set the physics
		GetComponent <Collider2D>().enabled = true;
		GetComponent <Rigidbody2D>().isKinematic = false;

		transform.localScale /= 3f;

		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}

	public virtual void Obtain(){
		//set the physical state
		GetComponent <Collider2D>().enabled = false;
		GetComponent <Rigidbody2D>().isKinematic = true;
		transform.localScale *= 3f;

	}



}
