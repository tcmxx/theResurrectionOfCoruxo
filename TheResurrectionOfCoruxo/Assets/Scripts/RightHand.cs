using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {



	public Vector3 defaultPosition;

	[HideInInspector]
	public UsableObject currentUsable;


	public float movingTime;
	public float movingRate;



	public enum RightHandState{
		None,
		PickingTo,
		PickingBack,
		ThrowingTo,
		ThrowingBack,
		Holding,

	}


	public RightHandState state {get{ return handState;}}
	private RightHandState handState;

	Vector3 desPosition;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (handState == RightHandState.PickingTo || handState == RightHandState.ThrowingTo) {

			transform.localPosition = Vector3.Lerp (transform.localPosition, desPosition, movingRate);

		} else if (handState == RightHandState.ThrowingBack || handState == RightHandState.PickingBack) {

			transform.localPosition = Vector3.Lerp (transform.localPosition, defaultPosition, movingRate);
		} else if (handState == RightHandState.None || handState == RightHandState.Holding) {
			transform.localPosition = defaultPosition;
		}

	
	}



	public bool UseCurrentUsable(float posX, float posY, GameObject obj = null){


		if (currentUsable != null) {
			currentUsable.Use (posX, posY, obj);

			StartCoroutine (UseAnimation(currentUsable, posX, posY, obj));


			Debug.Log ("Use " + currentUsable.gameObject.name + " at " + posX + ", " + posY);
			currentUsable = null;
			return true;
		} else {
			return false;
		}
	}



	public void PickAt(UsableObject usable){

		StartCoroutine (PickAnimation(usable));

		currentUsable = usable;

	}


	IEnumerator UseAnimation(UsableObject usable, float posX, float posY, GameObject obj = null){

		Vector3 pos = new Vector3();
		pos.x = posX;
		pos.y = posY;


		desPosition = transform.parent.InverseTransformPoint (pos);

		desPosition.z = defaultPosition.z;

		handState = RightHandState.ThrowingTo;

		yield return new WaitForSeconds (movingTime);

		usable.Use (posX, posY, obj);


		usable.transform.SetParent (null);

		//set the physics
		//usable.GetComponent <Collider2D>().enabled = true;
		usable.GetComponent <Rigidbody2D>().isKinematic = false;


		handState = RightHandState.ThrowingBack;

		yield return new WaitForSeconds (movingTime);

		handState = RightHandState.None;

	}


	IEnumerator PickAnimation(UsableObject usable){

		desPosition = transform.parent.InverseTransformPoint (usable.transform.position);

		desPosition.z = defaultPosition.z;

		handState = RightHandState.PickingTo;

		yield return new WaitForSeconds (movingTime);

		usable.Obtain ();
		usable.transform.SetParent (this.transform);

		//set the physical state
		//usable.GetComponent <Collider2D>().enabled = false;
		usable.GetComponent <Rigidbody2D>().isKinematic = true;

		handState = RightHandState.PickingBack;

		yield return new WaitForSeconds (movingTime);

		handState = RightHandState.Holding;

	}
}
