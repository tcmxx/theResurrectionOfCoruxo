using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	public int dragTimesRequired;
	public float dragDistanceEachTime;
	public Vector3 dragDirection;

	public GameObject ghostCaptainPref;

	Vector3 initialPosition;
	Vector3 savedinitialPosition;


	bool ghostState = false;

	bool dragging = false;
	int dragTimes = 0;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		savedinitialPosition = initialPosition;
	}

	// Update is called once per frame
	void Update () {
		initialPosition = savedinitialPosition + Vector3.up * Mathf.Sin (Time.time*3);
		if (!dragging) {
			transform.position = initialPosition;
		}
	}


	public void OnDragStart(){
		if(!ghostState)
			dragging = true;
	}

	public void OnDragging(){
		if (dragging && !ghostState) {
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouseWorldPos.z = initialPosition.z;

			float length = Vector3.Dot (dragDirection.normalized, mouseWorldPos - initialPosition);
			if (length <= 0) {
				length = 0;
			}
			Vector3 projectedMousePos = length * dragDirection.normalized + initialPosition;

			DraggingPositionAdjust (projectedMousePos);

			if ((projectedMousePos - initialPosition).magnitude > dragDistanceEachTime) {
				dragTimes++;
				if (dragTimes >= dragTimesRequired) {
					TurnIntoGhost ();

				} 
				GoBack ();

			}
		}
	}

	public void OnDragEnd(){
		GoBack ();
	}


	void DraggingPositionAdjust(Vector3 projectedMousePos){
		transform.position = projectedMousePos * 0.6f + (initialPosition  + dragDirection.normalized*dragTimes*0.2f) * 0.4f;
	}

	void TurnIntoGhost(){
		GameObject.Instantiate (ghostCaptainPref, transform.position,Quaternion.identity);
		ghostState = true;
	}

	void GoBack(){
		dragging = false;
		transform.position = initialPosition + dragDirection.normalized*dragTimes*0.2f;
	}
}
