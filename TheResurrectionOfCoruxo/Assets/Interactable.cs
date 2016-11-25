using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {


	public UnityEvent OnClickRight;
	public UnityEvent OnClickLeft;



	void OnMouseDown(){
		if (PlayerControl.playerControl.rightHand.state == RightHand.RightHandState.None) {
			if (Input.GetMouseButtonDown (0)) {
				OnClickLeft.Invoke ();

			} else {
				OnClickRight.Invoke ();
			}
		}
	}


}
