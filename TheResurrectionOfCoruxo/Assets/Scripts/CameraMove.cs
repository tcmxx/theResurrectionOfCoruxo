using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {


	public GameObject cube;
	bool isDestroyed = false;


	// Use this for initialization
	void Start () {
	
	}

	void OnMouseClick()
	{
		Destroy (cube);
		if (cube.activeInHierarchy == false) {
			isDestroyed = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("d")) {
			transform.localPosition += new Vector3 (0.05F, 0F, 0F);
		}
		if (Input.GetKey ("a")) {
			transform.localPosition += new Vector3 (-0.05F, 0F, 0F);
		}

	
	}
		



}
