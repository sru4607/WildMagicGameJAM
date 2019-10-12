using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        if(Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(new Vector3(-speed, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(new Vector3(0, 0, -speed), Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(new Vector3(speed, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(new Vector3(0, 0, speed),Space.World);
        }
    }
}
