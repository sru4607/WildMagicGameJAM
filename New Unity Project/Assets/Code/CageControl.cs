using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageControl : MonoBehaviour
{
    // Inspector Assigned Variables
    [SerializeField] GameObject floorCollider;
    [SerializeField] GameObject normalCage;
    [SerializeField] GameObject brokenCage;
    // Public Variables
    public bool isBroken;
    public bool isFalling;
    // Private Variables
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isBroken = false;
        isFalling = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!isBroken && !isFalling && Input.GetKeyDown(KeyCode.Space))
        {
            Release();
        }
    }

    public void Release()
    {
        if (!isFalling && !isBroken)
        {
            isFalling = true;
            rb.useGravity = true;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isBroken)
        {
            isBroken = true;
            normalCage.SetActive(false);
            brokenCage.SetActive(true);
        }
    }
}
