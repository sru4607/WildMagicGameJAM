using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    public Transform target;
    public Transform defaultTarget;
    public float smoothing = 5.0f;
    Vector3 offset;

    Vector3 defaultPosition;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        defaultPosition = transform.position;
        defaultTarget = target;
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

    public void ChangeCameraTarget(Transform newTransform)
    {
        target = newTransform;
    }
}
