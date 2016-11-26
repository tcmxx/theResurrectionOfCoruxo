﻿using UnityEngine;
using System.Collections;

public class LeftHand : MonoBehaviour {



	public Vector3 defaultPosition;


	public UsableObject torch;


	public float movingTime;
	public float movingRate;



	public enum LeftHandState{
		None,
		UsingTo,
		UsingBack,

	}


	public LeftHandState state {get{ return handState;}}
	private LeftHandState handState;

	Vector3 desPosition;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (handState == LeftHandState.UsingTo) {

			transform.localPosition = Vector3.Lerp (transform.localPosition, desPosition, movingRate);

		} else if (handState == LeftHandState.UsingBack) {

			transform.localPosition = Vector3.Lerp (transform.localPosition, defaultPosition, movingRate);
		} else if (handState == LeftHandState.None) {
			transform.localPosition = defaultPosition;
		}


	}



	public void UseTo(float posX, float posY, GameObject obj = null){


		StartCoroutine (UseAnimation(torch, posX, posY, obj));


		Debug.Log ("Use " + torch.gameObject.name + " at " + posX + ", " + posY);
	}






	IEnumerator UseAnimation(UsableObject usable, float posX, float posY, GameObject obj = null){

		Vector3 pos = new Vector3();
		pos.x = posX;
		pos.y = posY;


		desPosition = transform.parent.InverseTransformPoint (pos);

		desPosition.z = defaultPosition.z;

		handState = LeftHandState.UsingTo;

		yield return new WaitForSeconds (movingTime);

		usable.Use (posX, posY, obj);

		handState = LeftHandState.UsingBack;

		yield return new WaitForSeconds (movingTime);

		handState = LeftHandState.None;

	}



}