using UnityEngine;
using System.Collections;

public class RightHand : MonoBehaviour {



	private Vector3 defaultPosition;

	[HideInInspector]
	public UsableObject currentUsable;
    [HideInInspector]
    public Interactable currentInteracable;

    public float movingSpeed;
    public float effectRadius = 1.5f;
	AudioSource pick;
	public AudioClip pickup;

    public LayerMask interactLayerMask;
    protected bool interacting = false;
	public enum RightHandState{
		None,
		GoingTo,
		GoingBack,
        Dragging

	}


	public RightHandState state {get{ return handState;}}
	private RightHandState handState;

	private Vector3 desPosition;

    private Vector3 lastMousePos;
    private Camera mainCamera;

	void Awake(){
	}
	// Use this for initialization
	void Start () {
		handState = RightHandState.None;
		pick = GetComponent<AudioSource> ();
        defaultPosition = transform.localPosition;
        mainCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(handState == RightHandState.Dragging && interacting)
        {
            if (currentInteracable)
            {
                currentInteracable.OnDrag.Invoke();
            }
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 deltaMouse = mousePos - lastMousePos;
            deltaMouse.z = 0;
            transform.position += deltaMouse;
        }
        else if(handState == RightHandState.Dragging && !interacting)
        {
            StartCoroutine(GoBackCoroutine());
            if (currentInteracable)
            {
                currentInteracable.OnClickUp.Invoke();
                currentInteracable = null;
            }
        }

	    lastMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }



    public void InteractAt(Vector2 position)
    {
        if (handState != RightHandState.None)
            return;
        interacting = true;
        desPosition = transform.parent.InverseTransformPoint(position);
        desPosition.z = defaultPosition.z;

        StartCoroutine(GoToCoroutine());
    }

    public void EndInteract()
    {
        interacting = false;
    }

   
    IEnumerator GoBackCoroutine()
    {
        handState = RightHandState.GoingBack;
        //move to default
        Vector3 moveDir = defaultPosition - transform.localPosition;
        float movedDist = 0;
        while (movedDist < moveDir.magnitude)
        {
            yield return null;
            transform.localPosition = transform.localPosition + moveDir.normalized * Time.deltaTime * movingSpeed;
            movedDist += Time.deltaTime * movingSpeed;
        }

        transform.localPosition = defaultPosition;
        handState = RightHandState.None;
    }

	IEnumerator GoToCoroutine(){

		handState = RightHandState.GoingTo;

        //move to destination
        Vector3 moveDir = desPosition - transform.localPosition;
        float movedDist = 0;
        while (movedDist < moveDir.magnitude)
        {
            yield return null;
            transform.localPosition = transform.localPosition + moveDir.normalized*Time.deltaTime* movingSpeed;
            movedDist += Time.deltaTime * movingSpeed;
        }

        transform.localPosition = desPosition;

        //interact
        
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, effectRadius, Vector2.zero, 100, interactLayerMask);

        if (currentUsable)
        {
            currentUsable.Use(transform.position.x, transform.position.y, hit.collider==null?null: hit.collider.gameObject);
            currentUsable.transform.SetParent(null);
            currentUsable = null;

        }else if (hit.collider != null)
        {
            currentUsable = hit.collider.gameObject.GetComponent<UsableObject>();
            if (currentUsable != null)
            {
                //obtain the usable
                currentUsable.Obtain();
                currentUsable.transform.SetParent(this.transform);
                Vector3 localP = currentUsable.transform.localPosition;
                localP.x = 0;
                localP.y = 0;
                currentUsable.transform.localPosition = localP;
                pick.PlayOneShot(pickup, 0.6f);
            }
            else
            {
                //interact
                currentInteracable = hit.collider.gameObject.GetComponent<Interactable>();
                if(currentInteracable != null)
                    currentInteracable.OnClickLeft.Invoke();
            }
            
        }
        handState = RightHandState.Dragging;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, effectRadius);
    }
}
