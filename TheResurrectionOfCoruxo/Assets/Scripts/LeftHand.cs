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
    public LayerMask interactLayerMask;
    Vector3 desPosition;
    
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

    public void OnDisable()
    {
        PlayerControl.Instance.CurrentActiveHand = PlayerControl.Hand.Right;
    }

    public void UseTo(float posX, float posY){


		StartCoroutine (UseAnimation(torch, posX, posY));
		leftH.PlayOneShot (left, 0.6f);

		Debug.Log ("Use " + torch.gameObject.name + " at " + posX + ", " + posY);
	}



    public void InteractAt(Vector2 position)
    {
        if(handState == LeftHandState.None)
            UseTo(position.x, position.y);
    }


	IEnumerator UseAnimation(UsableObject usable, float posX, float posY){

		Vector3 pos = new Vector3();
		pos.x = posX;
		pos.y = posY;
        
		desPosition = transform.parent.InverseTransformPoint (pos);

		desPosition.z = defaultPosition.z;

		handState = LeftHandState.UsingTo;

		yield return new WaitForSeconds (movingTime - lightUpTime/2);
		mask.SetActive (true);
		sprite.sprite = sprite1;
		yield return new WaitForSeconds (lightUpTime/2);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 100, interactLayerMask);
        
        usable.Use (posX, posY, hit.collider==null?null: hit.collider.gameObject);
        
		handState = LeftHandState.UsingBack;

		yield return new WaitForSeconds (lightUpTime/2);

		mask.SetActive (false);
		sprite.sprite = sprite0;



		yield return new WaitForSeconds (movingTime - lightUpTime/2);


		handState = LeftHandState.None;

	}



}
