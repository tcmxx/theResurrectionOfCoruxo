using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {



	public static PlayerControl Instance { get; private set; }



	public RightHand rightHand;
	public LeftHand leftHand;
	public GameObject leftHandObj;
    public float handSelectedScale = 1.3f;
	public LayerMask usableLayerMask;
	public LayerMask notAllowLayerMask;

	Camera mainCamera;

    private Vector3 leftHandInitialScale;
    private Vector3 rightHandInitialScale;

    bool controlsEnable = true;


    public enum Hand
    {
        Right,Left
    }
    public Hand CurrentActiveHand
    {
        get { return currentActiveHand; }
        set
        {
            currentActiveHand = value;
            if(currentActiveHand == Hand.Left)
            {
                leftHand.transform.localScale = leftHandInitialScale * handSelectedScale;
                rightHand.transform.localScale = rightHandInitialScale;
            }
            else{
                leftHand.transform.localScale = leftHandInitialScale;
                rightHand.transform.localScale = rightHandInitialScale * handSelectedScale;
            }
        }

    }
    private Hand currentActiveHand;



	void Awake(){
		mainCamera = GetComponent <Camera> ();
        Instance = this;

	}

	// Use this for initialization
	void Start () {
        leftHandInitialScale = leftHand.transform.localScale;
        rightHandInitialScale = rightHand.transform.localScale;
        CurrentActiveHand = Hand.Right;
    }
	
	// Update is called once per frame
	void Update () {
		InputControl ();
	}

    public void ActiveHand(bool left)
    {
        CurrentActiveHand = left?Hand.Left:Hand.Right;
    }

	public void SetEnableControls(bool enable){
		controlsEnable = enable;
        CameraMove.Instance.enabled = enable;
	}


	public void GetTorch(){
		leftHandObj.SetActive (true);
	}

	public void LoseTorch(){
		leftHandObj.SetActive (false);
	}



	void InputControl(){
		if (Input.GetMouseButtonDown (0) && controlsEnable) {
            
			Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (mouseWorldPos, Vector2.zero, 100, usableLayerMask);
            RaycastHit2D hitNotAllow = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100, notAllowLayerMask);

            Debug.Log ("Pointer down at " + mouseWorldPos);

            if (hit.collider != null && hitNotAllow.collider == null)
            {
                if (currentActiveHand == Hand.Right)
                {
                    rightHand.InteractAt(new Vector2(mouseWorldPos.x, mouseWorldPos.y));
                }else if(leftHandObj.activeSelf && currentActiveHand == Hand.Left)
                {
                    leftHand.InteractAt(new Vector2(mouseWorldPos.x, mouseWorldPos.y));
                }
            }
		} else if (Input.GetMouseButtonUp(0))
        {
            if (currentActiveHand == Hand.Right)
            {
                rightHand.EndInteract();
            }
            else if (leftHandObj.activeSelf && currentActiveHand == Hand.Left)
            {
                rightHand.EndInteract();
            }
        }

	}


}
