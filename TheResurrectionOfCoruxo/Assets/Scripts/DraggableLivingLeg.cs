﻿using UnityEngine;
using System.Collections;

public class DraggableLivingLeg : MonoBehaviour {


	public bool CanBeDragDown = false;

	public int dragTimesRequired;
	public float dragDistanceEachTime;
	public Vector3 dragDirection;
    public float activeScale = 1.5f;
    public GameObject legToGivePref;

	public Cthulhu cthulhu;
    public Sprite angrySprite;
    public Sprite normalSprite;
    public SpriteRenderer rendererRef;

	Vector3 initialPosition;



	bool dragging = false;
	int dragTimes = 0;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

	}


	public void OnDragStart(){
		dragging = true;
        transform.localScale *= activeScale;
        if(rendererRef != null && angrySprite != null)
        {
            rendererRef.sprite = angrySprite;
        }
    }

	public void OnDragging(){
		if (dragging) {
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
				if (CanBeDragDown && dragTimes >= dragTimesRequired) {
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
        if (rendererRef != null && normalSprite != null)
        {
            rendererRef.sprite = normalSprite;
        }
    }


	void DraggingPositionAdjust(Vector3 projectedMousePos){
		if (CanBeDragDown) {
			transform.position = (projectedMousePos + initialPosition + dragDirection.normalized * dragTimes * 0.3f) * 0.5f;
		} else {
			transform.position = (projectedMousePos + initialPosition) * 0.5f;
		}
	}

	void Spawn(){
		GameObject.Instantiate (legToGivePref, transform.position,Quaternion.identity);
		transform.position = initialPosition;
		gameObject.SetActive (false);
		cthulhu.LoseLeg ();
        //CanBeDragDown = false;
        dragTimes = 0;
        dragging = false;
    }

	void GoBack(){
		dragging = false;
		if (CanBeDragDown) {
			transform.position = initialPosition + dragDirection.normalized * dragTimes * 0.3f;
		}
		else {
			transform.position = initialPosition;
		}
	}

}
