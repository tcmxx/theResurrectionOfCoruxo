using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMove : MonoBehaviour {
	public static CameraMove Instance;


    public float moveSpeed = 5;


    protected Rigidbody2D rBody;

    protected float horizontalMove;
    protected float verticalMove;

    [SerializeField]
    protected List<UnlockDetail> unlocks;

    [System.Serializable]
    protected struct UnlockDetail
    {
        public List<GameObject> objectsToDisable;
        public List<GameObject> objectsToEnable;
    }


	// Use this for initialization
	void Awake () {
        Instance = this;
        rBody = GetComponent<Rigidbody2D>();

    }



	// Update is called once per frame
	void Update () {
	}

    public void Unlock(int index) {
        Debug.Assert(index < unlocks.Count, "Unlock index out of bound");
        var detail = unlocks[index];
        foreach(var d in detail.objectsToEnable)
        {
            d.SetActive(true);
        }
        foreach(var d in detail.objectsToDisable)
        {
            d.SetActive(false);
        }
    }

    public void Lock(int index)
    {
        Debug.Assert(index < unlocks.Count, "Lock index out of bound");
        var detail = unlocks[index];
        foreach (var d in detail.objectsToEnable)
        {
            d.SetActive(false);
        }
        foreach (var d in detail.objectsToDisable)
        {
            d.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontalMove, verticalMove)* moveSpeed;
    }

    public void SetVerticalMove(float value)
    {
        verticalMove = Mathf.Clamp(value, -1, 1);
    }

    public void SetHorizontalMove(float value)
    {
        horizontalMove = Mathf.Clamp(value, -1, 1);
    }

    

}
