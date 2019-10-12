using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    // Inspector Assigned Variables
    // Public Variables
    public bool isOpen;
    // Private Variables
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen && Input.GetKeyDown(KeyCode.F))
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
}
