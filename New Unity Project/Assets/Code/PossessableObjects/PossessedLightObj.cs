using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedLightObj : PossessableObject
{

    public Rigidbody rb;

    public float baseSpeed;     // Base Speed
    public float turnSpeed;     // Turning Speed

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        PossessAction();
        CheckLeave();
    }

    public override void PossessAction()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = !Possessed;

        if (Possessed)
        {

            float speed = Input.GetAxis("Vertical");
            float rotation = (Input.GetAxis("Horizontal") * turnSpeed);

            transform.Rotate(0, rotation, 0);
            rb.velocity = transform.forward * speed * baseSpeed;
        }
    }
    public override void LeavePossess()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        base.LeavePossess();
    }
    private void HitWall()
    {
        transform.Rotate(0, 180, 0);
        rb.angularVelocity = Vector3.zero;

    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.tag == "Wall")
        {
            HitWall();
        }
        */
    }
}
