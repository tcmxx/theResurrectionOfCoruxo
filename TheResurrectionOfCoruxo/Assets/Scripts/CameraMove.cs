using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public int offY = 5;
	public int offY2 = 5;
	public int offYPuzzle6 = -42;
	//public int offCannotMoveHorizontally = 8;
	public int offRight1 = -130;
	public int offRight2 = -90;
	public int offRight3 = -43;
	public int offRight4 = 6;
	public int offRight5 = 53;
	public int offRight6 = 116;
	public int offRight8 = 156;
	public int offXLeft = -148;
	public int offY7 = 5;
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
		//changeIndex (2);
		Unlock (currentOffsetIndex);
	}

	public void changeIndex(int offs){
		currentOffsetIndex = offs;
	}

	public void EnableCamera(){
		cameraEnabled = true;
	}

	public void DisableCamera(){
		cameraEnabled = false;
	}



	public void ChangeY7(){
		offY7 = 32;
	}

	public void Unlock(int offset){

		if (cameraEnabled == false) {
			return;
		} 

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		if (transform.localPosition.y > 10) {
			if (x > 0)
				x = 0;
		}




		/*if (offset == 1 || offset == 2 || offset == 3 || offset == 4) {
            if (transform.localPosition.x > offRight1) {
                if (y > 0) //Cannot go up after OffRight1 (starting from offset = 5)
                    y = 0;
            }
        }*/

		/*if (transform.localPosition.y > offCannotMoveHorizontally) {
		if (transform.localPosition.x > offRight1) {
			if (x > 0) {
				x = 0;
			}
		}
	}*/
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

		if (transform.localPosition.y > offY) {
			if (y > 0)
				y = 0; //Cannot go up more than offY (starts from offset = 5)
		}
		y = 0;
		if (transform.localPosition.x > offRight1) {
			if (x > 0) {
				x = 0;
			}
		}
	}



	if (offset == 2) {
		y = 0;
		/*if (transform.localPosition.y < offY2) {
                if (y < 0)
                    y = 0; //Cannot go down
            }
                */

		if (transform.localPosition.y > offY) {
			if (y > 0)
				y = 0; //Cannot go up more than offY (starts from offset = 5)
		}
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

		if (transform.localPosition.y > offY) {
			if (y > 0)
				y = 0; //Cannot go up more than offY (starts from offset = 5)
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
		if (transform.localPosition.y > offY) {
			if (y > 0)
				y = 0; //Cannot go up more than offY (starts from offset = 5)
		}
		y = 0;
		if (transform.localPosition.x > offRight4) {
			if (x > 0) {
				x = 0;
			}
		}
	}




	if (offset == 5) {
		y = 0;
		if (transform.localPosition.y < offY2) {
			if (y < 0)
				y = 0; //Cannot go down
		}

		if (transform.localPosition.y > offY) {
			if (y > 0)
				y = 0; //Cannot go up more than offY (starts from offset = 5)
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
		 
			if (transform.localPosition.y > offY2) {
				if (y > 0)
					y = 0; //Cannot go up more than offY (starts from offset = 5)
				//if (x < 0)
				//    x = 0;
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
		if ((transform.localPosition.y > offYPuzzle6 && transform.localPosition.y < offY2-2) || transform.localPosition.y < offYPuzzle6) {
			if (transform.localPosition.x < offRight6) {
				if (x < 0) 
					x = 0;

			}
		}
	}





	if (offset == 7) {
		offXLeft = -173;
		if ((transform.localPosition.x > offXLeft && transform.localPosition.x < -148) || transform.localPosition.x < offXLeft || (transform.localPosition.x > -148 && transform.localPosition.x < offRight6)) {
			if (transform.localPosition.y < offY) {
				if (y < 0)
					y = 0; //Cannot go down
			}
		}

		if ((transform.localPosition.x > offXLeft && transform.localPosition.x < -148) || transform.localPosition.x < offXLeft){
			if (transform.localPosition.y > offY7) {
				if (y > 0)
					y = 0;
			}
		}


		if (transform.localPosition.x > -148 && transform.localPosition.x < offRight6) {
			if (transform.localPosition.y > offY) {
				if (y > 0)
					y = 0; //Cannot go up more than offY (starts from offset = 5)
			}
		}


		if (transform.localPosition.x > offRight6) {
			if (x > 0) {
				x = 0;
			}
		}

		if (transform.localPosition.x < offXLeft) {
			if (x < 0) { //Cannot go to the left more than offXLeft (beginning of game)
				x = 0;
			}
		}
	}



	if (offset == 8) {
		offXLeft = -173;


		if (transform.localPosition.x > -148 && transform.localPosition.x < offRight8) {
			if (transform.localPosition.y > offY) {
				if (y > 0)
					y = 0; //Cannot go up more than offY (starts from offset = 5)
			}
		}
		if (transform.localPosition.x < offRight6) {
			if(transform.localPosition.y < offY2){
				if (y < 0)
					y = 0; //Cannot go down
			}
		}
		if (transform.localPosition.x > offRight5 && transform.localPosition.x < offRight6) {
			if (transform.localPosition.y > offY2) {
				if (y > 0)
					y = 0; //Cannot go up more than offY (starts from offset = 5)
				//if (x < 0)
				//    x = 0;
			}
		}
		if ((transform.localPosition.x > offXLeft && transform.localPosition.x < -148) || transform.localPosition.x < offXLeft){
			if (transform.localPosition.y > offY7) {
				if (y > 0)
					y = 0;
			}
		}

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