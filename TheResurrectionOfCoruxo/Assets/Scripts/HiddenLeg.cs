using UnityEngine;
using System.Collections;

public class HiddenLeg : MonoBehaviour {




	public int dragTimesRequired;
	public float dragDistanceEachTime;
	public Vector3 dragDirection;

	public GameObject legToGivePref;

	Vector3 initialPosition;

	float stepSize = 0.3f;

	bool dragging = false;
	int dragTimes = 0;

	Vector3 mouseInitPos;


	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnDragStart(){
		dragging = true;
		mouseInitPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseInitPos.z = initialPosition.z;
	}

	public void OnDragging(){
		if (dragging) {
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouseWorldPos.z = initialPosition.z;

			float length = Vector3.Dot (dragDirection.normalized, mouseWorldPos - mouseInitPos);
			if (length <= 0) {
				length = 0;
			}
			Vector3 projectedMousePos = length * dragDirection.normalized + initialPosition  + dragDirection.normalized*dragTimes*stepSize;

			DraggingPositionAdjust (projectedMousePos);

			if ((projectedMousePos - mouseInitPos).magnitude > dragDistanceEachTime) {
				dragTimes++;
				if (dragTimes >= dragTimesRequired) {
					Spawn ();
				} else {
					GoBack ();
				}
			}
		}
	}

	public void OnDragEnd(){
		GoBack ();
	}


	void DraggingPositionAdjust(Vector3 projectedMousePos){
		transform.position = (projectedMousePos + initialPosition  + dragDirection.normalized*dragTimes*stepSize) * 0.5f;
	}

	void Spawn(){
		GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
		Destroy (gameObject);
	}

	void GoBack(){
		dragging = false;
		transform.position = initialPosition + dragDirection.normalized*dragTimes*stepSize;
	}

}
