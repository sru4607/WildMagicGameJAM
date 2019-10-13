using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5.0f;
    Vector3 offset;

    Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newCamPos = target.position + offset;
        Vector3 targetCamPos = new Vector3(transform.position.x, transform.position.y, newCamPos.z);

        if (targetCamPos.z < defaultPosition.z)
        {
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }

    }
}
