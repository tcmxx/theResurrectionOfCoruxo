using UnityEngine;
using System.Collections;

public class HiddenLeg : MonoBehaviour {




	public int dragTimesRequired;
	public float dragDistanceEachTime;
	public Vector3 dragDirection;
    public float activeScale = 1.5f;
	public GameObject legToGivePref;

    public string legEventName;

	Vector3 initialPosition;

	public float stepSize = 0.3f;

	bool dragging = false;
	int dragTimes = 0;

	Vector3 mouseInitPos;

    protected Camera mainCamera;
    
	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
        mainCamera = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnDragStart(){
		dragging = true;
		mouseInitPos = mainCamera.ScreenToWorldPoint (Input.mousePosition);
		mouseInitPos.z = initialPosition.z;
        transform.localScale *= activeScale;
	}

	public void OnDragging(){
		if (dragging) {
			Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint (Input.mousePosition);
			mouseWorldPos.z = initialPosition.z;

			float length = Vector3.Dot (dragDirection.normalized, mouseWorldPos - mouseInitPos);
			if (length <= 0) {
				length = 0;
			}
			Vector3 mouseMoved = length * dragDirection.normalized;

			DraggingPositionAdjust (mouseMoved);

			if ((mouseMoved).magnitude > dragDistanceEachTime) {
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
        transform.localScale /= activeScale;
    }


	void DraggingPositionAdjust(Vector3 delta){
		transform.position = initialPosition + dragDirection.normalized * dragTimes * stepSize + delta * 0.5f;
	}

	void Spawn(){
		var obj = GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
        obj.GetComponent<LegToGive>().eventName = legEventName;

        Destroy (gameObject);
	}

	void GoBack(){
		dragging = false;
		transform.position = initialPosition + dragDirection.normalized*dragTimes*stepSize;
	}

}
