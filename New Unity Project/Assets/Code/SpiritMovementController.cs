using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class SpiritMovementController : MonoBehaviour {

    public Rigidbody rb;

    public float baseSpeed;     // Base Speed
    public float turnSpeed;     // Turning speed
    public float wSpeedMult;    // Multiplier for speed when w is held
    public float sSpeedMult;    // Multiplier for speed when s is held
    public float acceleration;  // Rate at which speed changes

    public bool activated;
    public bool possessing;

    public ThirdPersonUserControl playerControl;
    public ThirdPersonCharacter playerControlChar;
    public Animator playerAnimator;

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
        rb.velocity = Vector3.zero;
		rb.angularDrag = float.PositiveInfinity;
        SkinnedMeshRenderer[] renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(SkinnedMeshRenderer r in renderers)
        {
            r.enabled = false;
        }
        gameObject.GetComponent<SphereCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update() {
        if (activated) {
            float deltaSpeed = Input.GetAxis("Vertical");
            float rotation = (Input.GetAxis("Horizontal") * turnSpeed);
            ChangeSpeed(deltaSpeed);
            transform.Rotate(0, rotation, 0);
            rb.velocity = transform.forward * currentSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
			if (possessing) {
				LeavePossess();
				return;
			}
			if (!activated) {
				Activate();
			} else {
				SetActive(false);
			}
        }
    }

	private void Activate() {
		Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		gameObject.transform.position = new Vector3(playerTransform.position.x, gameObject.transform.position.y, playerTransform.position.z);
		gameObject.transform.rotation = playerTransform.rotation;
		SetActive(true);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            HitWall();
        }
        if (collision.gameObject.GetComponent<PossessableObject>() != null)
        {
            collision.gameObject.GetComponent<PossessableObject>().OnPossess();
            OnPossess();
        }
    }


	private void SetActive(bool active) {
		activated = active;
        SkinnedMeshRenderer[] renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers)
        {
            r.enabled = active;
        }
        gameObject.GetComponent<SphereCollider>().enabled = active;
		playerControl.enabled = !active;
		playerControlChar.enabled = !active;
		if (active)
			playerAnimator.SetFloat("Forward", 0.0f);
	}

	private void OnPossess() {
		possessing = true;
		SetActive(false);
		playerControl.enabled = false;
		playerControlChar.enabled = false;
		playerAnimator.SetFloat("Forward", 0.0f);
	}

	private void LeavePossess() {
		activated = false;
		possessing = false;
        SkinnedMeshRenderer[] renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers)
        {
            r.enabled = false;
        }
        gameObject.GetComponent<SphereCollider>().enabled = false;
		playerControl.enabled = true;
		playerControlChar.enabled = true;
		gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, gameObject.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
	}






}
