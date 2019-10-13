using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritFall : MonoBehaviour
{
    public float desiredY;
    public float gravity;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y > desiredY)
        {
            speed += gravity * Time.deltaTime;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, gameObject.transform.position.z);
        }
        if(gameObject.transform.position.y <= desiredY)
        {
            speed = 0;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, desiredY, gameObject.transform.position.z);
        }
    }
}
