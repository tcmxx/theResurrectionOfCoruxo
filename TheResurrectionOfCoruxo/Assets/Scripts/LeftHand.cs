using UnityEngine;
using System.Collections;

public class LeftHand : MonoBehaviour {


	public SpriteRenderer sprite;
	public Sprite sprite0;
	public Sprite sprite1;
	public AudioClip left;
	AudioSource leftH;
	public Vector3 defaultPosition;


	public UsableObject torch;


	public float movingTime;
	public float movingRate;
	public float lightUpTime;


	public GameObject mask;

	public enum LeftHandState{
		None,
		UsingTo,
		UsingBack,

	}


	public LeftHandState state {get{ return handState;}}
	private LeftHandState handState;

	Vector3 desPosition;

	Animator anim;
	void Awake(){
		anim = GetComponent <Animator> ();
	}
	// Use this for initialization
	void Start () {
		handState = LeftHandState.None;
		leftH = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

		if (handState == LeftHandState.UsingTo) {

			transform.localPosition = Vector3.Lerp (transform.localPosition, desPosition, movingRate);

		} else if (handState == LeftHandState.UsingBack) {

			transform.localPosition = Vector3.Lerp (transform.localPosition, defaultPosition, movingRate);
		} else if (handState == LeftHandState.None) {
			transform.localPosition = defaultPosition;
		}


	}



	public void UseTo(float posX, float posY, GameObject obj = null){


		StartCoroutine (UseAnimation(torch, posX, posY, obj));
		leftH.PlayOneShot (left, 0.3f);

		Debug.Log ("Use " + torch.gameObject.name + " at " + posX + ", " + posY);
	}






	IEnumerator UseAnimation(UsableObject usable, float posX, float posY, GameObject obj = null){

		Vector3 pos = new Vector3();
		pos.x = posX;
		pos.y = posY;

		PlayerControl.playerControl.DisableControls ();

		desPosition = transform.parent.InverseTransformPoint (pos);

		desPosition.z = defaultPosition.z;

		handState = LeftHandState.UsingTo;

		yield return new WaitForSeconds (movingTime - lightUpTime/2);
		mask.SetActive (true);
		sprite.sprite = sprite1;
		yield return new WaitForSeconds (lightUpTime/2);
		usable.Use (posX, posY, obj);

		PlayerControl.playerControl.EnableControls ();
		handState = LeftHandState.UsingBack;

		yield return new WaitForSeconds (lightUpTime/2);

		mask.SetActive (false);
		sprite.sprite = sprite0;



		yield return new WaitForSeconds (movingTime - lightUpTime/2);


		handState = LeftHandState.None;

	}



}
