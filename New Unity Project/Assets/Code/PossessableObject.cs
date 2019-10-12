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
    void Update()
    {
        
    }

    public abstract void OnPossess();

    void OnTriggerEnter(Collider other)
    {
        OnPossess();
    }
}
