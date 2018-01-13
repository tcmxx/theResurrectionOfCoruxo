using UnityEngine;
using System.Collections;

public class SeaGrass : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Grow(){

		transform.localScale += Vector3.up * 5;
	}
}
