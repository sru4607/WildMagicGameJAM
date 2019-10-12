using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PossessableObject : MonoBehaviour
{
    // Inspector Assigned Variables
    // Public Variables
    // Private Variables
    private bool _possessed = false;
    // Properties
    public bool Possessed { get { return _possessed; }  set { _possessed = value; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void CheckLeave()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LeavePossess();
        }
    }

    public void OnPossess()
    {
        Possessed = true;
    }
    public virtual void LeavePossess()
    {
        Possessed = false;
    }


    public abstract void PossessAction();

    void OnTriggerEnter(Collider other)
    {
        OnPossess();
    }
}
