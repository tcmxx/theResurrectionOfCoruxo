using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GamePlayUI : MonoBehaviour {
	AudioSource exit;
	public AudioClip leave;

	// Use this for initialization
	void Start () {
		exit = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Quit(){
		exit.PlayOneShot (leave, 0.3f);
		SceneManager.LoadScene ("MenuScene");
	}
}
