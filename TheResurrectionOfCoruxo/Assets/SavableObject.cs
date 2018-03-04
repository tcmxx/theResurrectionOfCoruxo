using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SavableObject : MonoBehaviour {
    public string eventName;
    public UnityEvent onOccurred;
    // Use this for initialization
    void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void Initialize()
    {
        if(!string.IsNullOrEmpty(eventName) && GameSaveManager.Instance.GetEventOccurred(eventName))
        {
            onOccurred.Invoke();
        }
    }


    public void SetOccurred()
    {
        GameSaveManager.Instance.SetEventOccurred(eventName);
    }

}
