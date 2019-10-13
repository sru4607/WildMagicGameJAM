using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PossessableObject : MonoBehaviour
{
    // Inspector Assigned Variables
    // Public Variables
    // Private Variables
    private bool _possessed = false;
    // Properties
    public bool Possessed { get { return _possessed; }  set { _possessed = value; } }



	[Header("Moveable Object")]
	public bool Moveable;
    public bool UseGravity;
	public Rigidbody rb;
	public float baseSpeed;     // Base Speed
	public float turnSpeed;     // Turning Speed
    public float distCheck;
	[Header("Action Button")]
	public UnityEvent OnActionPress;
	public bool HasAction { get { return OnActionPress != null; } }

	public void OnActionKeyPress() {
		OnActionPress.Invoke();
	}

    public void Start()
    {
        rb.useGravity = UseGravity;
    }

	public void Update() {
		if (Possessed) {
			if (Moveable) {
				float speed = Input.GetAxis("Vertical");
				float rotation = (Input.GetAxis("Horizontal") * turnSpeed);

				transform.Rotate(0, rotation, 0);
				rb.velocity = transform.forward * speed * baseSpeed;
			}
			if (HasAction) {
				if (Input.GetKey(KeyCode.E)) {
					OnActionKeyPress();
				}
			}
			CheckLeave();
		}
        else
            CheckDist();
	}

	public void CheckLeave()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            LeavePossess();
        }
    }

    public void OnPossess()
    {
        Possessed = true;
		if (Moveable) {
			rb.maxAngularVelocity = 0;
			gameObject.GetComponent<Rigidbody>().useGravity = !Possessed;
		}
        EnableShader[] shaders = GetComponentsInChildren<EnableShader>();
        foreach(EnableShader s in shaders)
        {
            s.activate();
        }
    }
    public void CheckDist()
    {
        EnableShader[] shaders = GetComponentsInChildren<EnableShader>();
        if ((GameObject.FindGameObjectWithTag("Spirit").transform.position - gameObject.transform.position).sqrMagnitude <= distCheck)
        {
            foreach (EnableShader s in shaders)
            {
                s.activateClose();
            }
        }
        else
        {
            foreach (EnableShader s in shaders)
            {
                s.deactivateClose();
            }
        }

    }
	public void LeavePossess() {
		Possessed = false;
		if (Moveable) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.maxAngularVelocity = float.PositiveInfinity;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.useGravity = true;
		}
        EnableShader[] shaders = GetComponentsInChildren<EnableShader>();
        foreach (EnableShader s in shaders)
        {
            s.disable();
        }
    }

}
