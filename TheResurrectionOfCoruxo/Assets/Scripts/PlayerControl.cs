using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {



	public static PlayerControl playerControl;



	public RightHand rightHand;


	public LayerMask usableLayerMask;
	public LayerMask notAllowPutLayerMask;

	Camera mainCamera;






	void Awake(){
		mainCamera = GetComponent <Camera> ();
		playerControl = this;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		InputControl ();
	}




	void InputControl(){

		if(Input.GetMouseButtonDown (0)){



			Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (mouseWorldPos, Vector2.zero, usableLayerMask);

			RaycastHit2D notallowPutHit =  Physics2D.Raycast (mouseWorldPos, Vector2.zero, notAllowPutLayerMask);



			Debug.Log ("mouse down at " + mouseWorldPos);

			if (rightHand.state == RightHand.RightHandState.None) {
				if (hit.collider) {
					UsableObject usable = hit.collider.gameObject.GetComponent <UsableObject> ();
					rightHand.PickAt (usable);
				}
			} else if (rightHand.state == RightHand.RightHandState.Holding && notallowPutHit.collider == null) {
				if (hit.collider) {
					 rightHand.UseCurrentUsable (mouseWorldPos.x, mouseWorldPos.y, hit.collider.gameObject);
				} else {
					rightHand.UseCurrentUsable (mouseWorldPos.x, mouseWorldPos.y);
				}
			}
				

		}

	}


}
