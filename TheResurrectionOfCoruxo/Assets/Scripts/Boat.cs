using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	public int dragTimesRequired;
	public float dragDistanceEachTime;
	public Vector3 dragDirection;
	public SpriteRenderer sprite;
	public Sprite sprite1;
    public float activeScale = 1.5f;
    public GameObject ghostCaptainPref;

	Vector3 initialPosition;
	Vector3 savedinitialPosition;


	bool ghostState = false;

	bool dragging = false;
	int dragTimes = 0;

    Vector3 mouseInitPos;
    protected Camera mainCamera;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		savedinitialPosition = initialPosition;
        mainCamera = Camera.main;
    }

	// Update is called once per frame
	void Update () {
		initialPosition = savedinitialPosition + Vector3.up * Mathf.Sin (Time.time*3);
		if (!dragging) {
			transform.position = initialPosition;
		}
	}


    public void OnDragStart()
    {
        if (!ghostState)
        {
            dragging = true;
            mouseInitPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseInitPos.z = initialPosition.z;
            transform.localScale *= activeScale;
        }
    }
	public void OnDragging(){
		if (dragging && !ghostState) {
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouseWorldPos.z = initialPosition.z;

			float length = Vector3.Dot (dragDirection.normalized, mouseWorldPos - mouseInitPos);
			if (length <= 0) {
				length = 0;
			}
			Vector3 projectedMouseDelta = length * dragDirection.normalized ;

			DraggingPositionAdjust (projectedMouseDelta);

			if ((projectedMouseDelta).magnitude > dragDistanceEachTime) {
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
        if(!ghostState)
            transform.localScale /= activeScale;
    }


	void DraggingPositionAdjust(Vector3 projectedMousePos){
		transform.position = projectedMousePos * 0.6f + initialPosition  + dragDirection.normalized*dragTimes*0.2f;
	}

	void TurnIntoGhost(){
		GameObject.Instantiate (ghostCaptainPref, transform.position,Quaternion.identity);
		ghostState = true;
		sprite.sprite = sprite1;
	}

	void GoBack(){
		dragging = false;
		transform.position = initialPosition + dragDirection.normalized*dragTimes*0.2f;
	}
}
