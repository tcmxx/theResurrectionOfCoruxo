using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {

	public string gameSceneName;


	// Use this for initialization
	void Start () {
	
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
