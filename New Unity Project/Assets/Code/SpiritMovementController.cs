using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovementController : MonoBehaviour {

    public Rigidbody rb;

    public float baseSpeed;     // Base Speed
    public float turnSpeed;     // Turning speed
    public float wSpeedMult;    // Multiplier for speed when w is held
    public float sSpeedMult;    // Multiplier for speed when s is held
    public float acceleration;  // Rate at which speed changes

    private float wSpeed;
    private float sSpeed;

    private float _currentSpeed;
    private float currentSpeed {
        get { return _currentSpeed; }
        set { _currentSpeed = Mathf.Clamp(value, sSpeed, wSpeed); }
    }

    // Start is called before the first frame update
    void Start() {
        wSpeed = baseSpeed * wSpeedMult;
        sSpeed = baseSpeed * sSpeedMult;
        currentSpeed = baseSpeed;

    }

    // Update is called once per frame
    void Update() {
        float deltaSpeed = Input.GetAxis("Vertical");
        float rotation = (Input.GetAxis("Horizontal") * turnSpeed);
        ChangeSpeed(deltaSpeed);

        
        transform.Rotate(0, rotation, 0);
        rb.velocity = transform.forward * currentSpeed;
    }

    private void ChangeSpeed(float deltaSpeed) {
        if (deltaSpeed == 0) {
            NoVertInput();
        }
        else {
            currentSpeed += (deltaSpeed * acceleration);
        }
    }

    private void NoVertInput() {
        float diff = currentSpeed - baseSpeed;
        float delta = .3f * acceleration;
        if (diff > delta) {
            currentSpeed = baseSpeed;
            return;
        }
        else if (diff > 0) {
            currentSpeed -= delta;
        }
        else {
            currentSpeed += delta;
        }
    }

    private void HitWall() {
        transform.Rotate(0, 180, 0);
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision) {
        /*
        if (collision.gameObject.GetComponent<PossessableObject>() != null) {

        }
        */
        if (collision.gameObject.tag == "Wall") {
            HitWall();
        }
    }







}
