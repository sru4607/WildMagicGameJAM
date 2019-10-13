using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
	// Inspector Assigned Variables
	public PossessedBar LockBar;
	public DoorLockCheck leftDoor;
	public DoorLockCheck rightDoor;
	public float proximity;
    // Public Variables
    public bool isOpen;
	// Private Variables
	private bool locked;
    Animator anim;
	private GameObject player;
    public bool leverOpenable;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!leverOpenable && Input.GetKeyDown(KeyCode.E) && !isOpen && PlayerNear() && !leftDoor.Locked && !rightDoor.Locked)
        {
            Open();
        }
    }

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            anim.SetBool("isOpen", true);
        }
    }

	private bool PlayerNear() {
		return Vector3.Distance(transform.position, player.transform.position) < proximity;
	}

    public void LeverOpen()
    {
        Open();
    }


}
