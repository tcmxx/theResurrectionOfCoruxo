using UnityEngine;
using System.Collections;

public class GhostCaptain : MonoBehaviour {


	public float moveSpeed;
	public float changingRate;

	public float maxX, maxY, minX, minY;

	Vector3 moveDir;

	Vector3 initPos;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("ChangeDirection", 1.0f,changingRate);
		initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}



	void Move(){
		transform.Translate (moveDir*moveSpeed*Time.deltaTime);
		if (transform.position.x < minX + initPos.x || transform.position.x > maxX + initPos.x) {
			moveDir.x = -moveDir.x;
			transform.Translate (moveDir*moveSpeed*Time.deltaTime);
		}else if(transform.position.y < minY +initPos.y || transform.position.y > maxY + initPos.y) {
			moveDir.y = -moveDir.y;
			transform.Translate (moveDir*moveSpeed*Time.deltaTime);
		}
	}


	void DragLeg(){
		CancelInvoke ();
	}


	void ChangeDirection(){
		moveDir = Vector3.up * Random.Range (0.01f, 1) + Vector3.right * Random.Range (0.01f, 1);
		moveDir.Normalize ();
	}
}
