using UnityEngine;
using System.Collections;

public class GhostCaptainLeg : MonoBehaviour {


	public GameObject legToGivePref;
	public Sprite sprite1;
	public SpriteRenderer sprite;
    public string legEventName;
    bool taken = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void TakeLeg(){
		if (!taken) {
			sprite.sprite = sprite1;
			var obj = GameObject.Instantiate (legToGivePref, transform.position, Quaternion.identity);
            obj.GetComponent<LegToGive>().eventName = legEventName;
            taken = true;
		}
		PlayerControl.Instance.SetEnableControls (false);
	}


	public void EnableControls(){
        PlayerControl.Instance.SetEnableControls(true);
    }
}
