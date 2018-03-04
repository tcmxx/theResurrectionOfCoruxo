using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GamePlayUI : MonoBehaviour {
    public static GamePlayUI Instance { get; private set; }
	AudioSource exit;
	public AudioClip leave;


    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    protected GraphicRaycaster raycaster;
    private void Awake()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		exit = GetComponent<AudioSource>();
    }
	

	public void Quit(){
		exit.PlayOneShot (leave, 0.3f);
		SceneManager.LoadScene ("MenuScene");
	}

    protected void InitializeMoveButton()
    {
        //upButton.
    }

   public void SaveButtonClicked()
    {
        GameSaveManager.Instance.Save();
    }

    public bool WhetherOnButton()
    {
        //Set up the new Pointer Event
        var m_PointerEventData = new PointerEventData(EventSystem.current);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;

        //Create a list of Raycast Results
        List<RaycastResult> results = new List<RaycastResult>();

        //Raycast using the Graphics Raycaster and mouse click position
        raycaster.Raycast(m_PointerEventData, results);

        return results.Count > 0;
    }
}
