using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {



	public static PlayerControl playerControl;



	public RightHand rightHand;
	public LeftHand leftHand;
	public GameObject leftHandObj;

	public LayerMask usableLayerMask;
	public LayerMask notAllowPutLayerMask;

	Camera mainCamera;



	bool controlsEnable = true;


	void Awake(){
		mainCamera = GetComponent <Camera> ();
		playerControl = this;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (controlsEnable) {
			InputControl ();
		}
	}



	public void DisableControls(){
		controlsEnable = false;
		CameraMove.cam.DisableCamera ();
	}

	public void EnableControls(){
		controlsEnable = true;
		CameraMove.cam.EnableCamera ();
	}


	public void GetTorch(){
		leftHandObj.SetActive (true);
	}

	public void LoseTorch(){
		leftHandObj.SetActive (false);
	}



	void InputControl(){

		if (Input.GetMouseButtonDown (0)) {



			Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (mouseWorldPos, Vector2.zero, 100, usableLayerMask);

			RaycastHit2D notallowPutHit = Physics2D.Raycast (mouseWorldPos, Vector2.zero, 100, notAllowPutLayerMask);



			Debug.Log ("mouse down at " + mouseWorldPos);

			if (rightHand.state == RightHand.RightHandState.None) {
				if (hit.collider) {
					UsableObject usable = hit.collider.gameObject.GetComponent <UsableObject> ();
					rightHand.PickAt (usable);
				}
			} else if (rightHand.state == RightHand.RightHandState.Holding && (notallowPutHit.collider == null || hit.collider != null)) {
				if (hit.collider) {
					rightHand.UseCurrentUsable (mouseWorldPos.x, mouseWorldPos.y, hit.collider.gameObject);
				} else {
					rightHand.UseCurrentUsable (mouseWorldPos.x, mouseWorldPos.y);
				}
			}
				

		} else if (Input.GetMouseButtonDown (1 ) && leftHandObj.activeSelf) {

			Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (mouseWorldPos, Vector2.zero, 100, usableLayerMask);

			Debug.Log ("mouse down at " + mouseWorldPos);

			if (leftHand.state == LeftHand.LeftHandState.None) {
				if (hit.collider) {
					leftHand.UseTo (mouseWorldPos.x, mouseWorldPos.y, hit.collider.gameObject);
				} else {
					leftHand.UseTo (mouseWorldPos.x, mouseWorldPos.y);
				}
			} 
		}

	}


}
