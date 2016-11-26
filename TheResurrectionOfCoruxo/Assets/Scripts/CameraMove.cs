using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {



	public int offY = 23;
	public int offY2 = 2;
	public int offYPuzzle6 = -3;
	public int offCannotMoveHorizontally = 3;
	public int offRight1 = -85;
	public int offRight2 = -80;
	public int offRight3 = -75;
	public int offRight4 = -70;
	public int offRight5 = -65;
	public int offRight6 = -60;
	public int offRight7 = -55;
	public int offRight8 = -50;
	public int offXLeft = -98;
	public static CameraMove cam;
	float x;
	float y;
	bool cameraEnabled = true;
	int currentOffsetIndex;
	// Use this for initialization
	void Awake () {
		cam = this;
	}


	
	// Update is called once per frame
	void Update () {
		changeIndex (6);
		Unlock (currentOffsetIndex);
	}

	public void changeIndex(int offs){
		currentOffsetIndex = offs;
	}


	public void DisableCamera(){
		cameraEnabled = false;
	}
		


	public void Unlock(int offset){

		if (cameraEnabled == false) {
			return;
		} 

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");



		if (transform.localPosition.y > offY) {
			if (y > 0)
				y = 0; //Cannot go up more than offY (starts from offset = 5)
		}
		if (offset == 1 || offset == 2 || offset == 3 || offset == 4) {
			if (transform.localPosition.x > offRight1) {
				if (y > 0) //Cannot go up after OffRight1 (starting from offset = 5)
			y = 0;
			}
		}

		if (transform.localPosition.y > offCannotMoveHorizontally) {
			if (transform.localPosition.x > offRight1) {
				if (x > 0) {
					x = 0;
				}
			}
		}
		if (transform.localPosition.x < offXLeft) {
			if (x < 0) { //Cannot go to the left more than offXLeft (beginning of game)
				x = 0;
			}
		} 

		if (offset == 1) {
			if (transform.localPosition.y < offY2) {
				if (y < 0)
					y = 0; //Cannot go down
			}
			y = 0;
			if (transform.localPosition.x > offRight1) {
				if (x > 0) {
					x = 0;
				}
			}
		}
		if (offset == 2) {
			if (transform.localPosition.y < offY2) {
				if (y < 0)
					y = 0; //Cannot go down
			}
			y = 0;
			if (transform.localPosition.x > offRight2) {
				if (x > 0) {
					x = 0;
				}
			}
		}
		if (offset == 3) {
			if (transform.localPosition.y < offY2) {
				if (y < 0)
					y = 0; //Cannot go down
			}
			y = 0;
			if (transform.localPosition.x > offRight3) {
				if (x > 0) {
					x = 0;
				}
			}
		}
		if (offset == 4) {
			if (transform.localPosition.y < offY2) {
				if (y < 0)
					y = 0; //Cannot go down
			}
			y = 0;
			if (transform.localPosition.x > offRight4) {
				if (x > 0) {
					x = 0;
				}
			}
		}

		if (offset == 5) {
			if (transform.localPosition.y < offY2) {
				if (y < 0)
					y = 0; //Cannot go down
			}
			
			if (transform.localPosition.x > offRight5) {
				if (x > 0) {
					x = 0;
				}
			}
		}

		if (offset == 6) {

			if (transform.localPosition.x < offRight6) {
				if(transform.localPosition.y < offY2){
					if (y < 0)
						y = 0; //Cannot go down
				}
			}
			if (transform.localPosition.x > offRight6 && transform.localPosition.x < offRight7) {
				if (transform.localPosition.y > offY2) {
					if (y > 0)
						y = 0; //Cannot go up more than offY (starts from offset = 5)
					if (x < 0)
						x = 0;
				}
			}


				if (transform.localPosition.y < offYPuzzle6) {
					if (y < 0)
						y = 0; //Cannot go down
				
			}
			if (transform.localPosition.x > offRight6) {
				if (x > 0) {
					x = 0;
				}
			}
			if ((transform.localPosition.y > offYPuzzle6 && transform.localPosition.y < offY2) || transform.localPosition.y < offYPuzzle6) {
				if (transform.localPosition.x < offRight5) {
					if (x < 0) 
						x = 0;
					
				}
			}
		}
	

		if (offset == 7) {
			if (transform.localPosition.x > offRight7) {
				if (x > 0) {
					x = 0;
				}
			}
		}

		if (offset == 8) {
			if (transform.localPosition.x > offRight8) {
				if (x > 0) {
					x = 0;
				}
			}
		}
		transform.Translate (Vector3.right * x + Vector3.up * y);
	}

		/* if (transform.localPosition.x > offX2 && transform.localPosition.x < offX) {
			if (transform.localPosition.y < offY) {
				if (Input.GetKey ("w")) {
					transform.localPosition += new Vector3 (0f, 0.5f, 0f);
				}
			}
			if (transform.localPosition.y > offY2) {
				if (Input.GetKey ("s")) {
					transform.localPosition += new Vector3 (0f, -0.5f, 0f);
				}
			}
		}
		if (transform.localPosition.y < offCannotMoveHorizontally) {

			if (Input.GetKey ("d")) {
				transform.localPosition += new Vector3 (0.5f, 0f, 0f);
			}
			if (Input.GetKey ("a")) {
				transform.localPosition += new Vector3 (-0.5f, 0f, 0f);
			}
		} else {
			if (transform.localPosition.x < offX) {
				if (Input.GetKey ("d")) {
					transform.localPosition += new Vector3 (0.5f, 0f, 0f);
				}
			}
				if (transform.localPosition.x > offX2) {
					if (Input.GetKey ("a")) {
						transform.localPosition += new Vector3 (-0.5f, 0f, 0f);
					}
				}
			}

		} */


		}
	



