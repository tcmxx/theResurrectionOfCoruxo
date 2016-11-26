using UnityEngine;
using System.Collections;

public class Fish : UsableObject {


	bool swimming = true;

	public Vector3[] relativePoints;

	public float swimmingLerpRate;
	public float swimmingInterval;

	Vector3 initialPosition;
	int currentInd = -1;
	Vector3 des;
	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}


	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		InvokeRepeating ("GetNextDes",0,1/swimmingInterval);
	}
	
	// Update is called once per frame
	void Update () {
		if (swimming) {
			transform.position = Vector3.Lerp (transform.position, des, swimmingLerpRate);
		}
	}

	void GetNextDes(){
		currentInd = (currentInd + 1) % relativePoints.Length;
		des = relativePoints [currentInd] + initialPosition;
		des.z = initialPosition.z;
	}


	/// <summary>
	/// Use the object at position x, y on object obj
	/// </summary>
	/// <param name="posX">Position x.</param>
	/// <param name="posY">Position y.</param>
	/// <param name="obj">Object.</param>
	public override bool Use(float posX, float posY, GameObject obj = null){
		base.Use (posX, posY, obj);
		swimming = true;
		initialPosition = transform.position;
		GetComponent <Rigidbody2D>().isKinematic = true;
		if (obj != null) {

			Cthulhu cthulhu = obj.GetComponent <Cthulhu> ();
			if (cthulhu != null) {

				cthulhu.Feed ();
				Destroy (gameObject, 0.2f);
				return true;
			}
		}
		//PlayerControl.playerControl.Unlcoked (1);
		return false;
	}

	public override void Obtain ()
	{

		base.Obtain ();

		swimming = false;
	}
}
