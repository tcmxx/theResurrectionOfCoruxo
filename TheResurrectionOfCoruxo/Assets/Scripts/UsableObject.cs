using UnityEngine;
using System.Collections;

public class UsableObject : MonoBehaviour {



	bool obtained = false;

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

		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}

	public virtual void Obtain(){
		obtained = true;


	}



}
