using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

	public string gameSceneName;

    public GameObject continueButtonRef;

	// Use this for initialization
	void Start () {
        if (!GameSaveManager.Instance.HasSavedData())
        {
            continueButtonRef.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void StartGame(){
        TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(gameSceneName);
	}
    public void ContinueGame()
    {
        GameSaveManager.Instance.Load();
        TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(gameSceneName);
    }
}
