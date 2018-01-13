using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour {
	AudioSource exit;
	public AudioClip leave;


    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

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

    protected void InitializeMoveButton()
    {
        //upButton.
    }

}
