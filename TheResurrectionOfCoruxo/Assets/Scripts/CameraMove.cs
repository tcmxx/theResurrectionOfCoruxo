using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {


	public GameObject cube;
	bool isDestroyed = false;
	private Vector3 offset;
	public float off1 = 5;
	public float off2 = -5;
	public float off3 = 10;
	public float off4 = -10;


	// Use this for initialization
	void Start () {
		UnlockCamera (1);
		StartCoroutine(Example());
	}

	public void UnlockCamera(int offfset){
		if (offfset == 1) {
			if (transform.localPosition.x < off1) {
				if (Input.GetKey ("d")) {
					transform.localPosition += new Vector3 (0.05F, 0F, 0F);
				}
			}
			if (transform.localPosition.x > -off1) {
				if (Input.GetKey ("a")) {
					transform.localPosition += new Vector3 (-0.05F, 0F, 0F);
				}
			}
		}

		if (offfset == 2) {
			if (transform.localPosition.x < off2) {
				if (Input.GetKey ("d")) {
					transform.localPosition += new Vector3 (0.05F, 0F, 0F);
				}
			}
			if (transform.localPosition.x > -off2) {
				if (Input.GetKey ("a")) {
					transform.localPosition += new Vector3 (-0.05F, 0F, 0F);
				}
			}
		}
	}

	IEnumerator Example(){
		yield return new WaitForSeconds (10);
		UnlockCamera (2);
	}
	
	// Update is called once per frame
	void Update () {
		

	
	}
		



}
