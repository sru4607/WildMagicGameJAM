using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedTorch : MonoBehaviour
{

    public GameObject flame;
    public Vector3 startScale;
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        startScale = flame.transform.localScale;   
    }

	public void OnActionKeyPress() {
        if (!activated && startScale != null)
        {
            flame.transform.localScale = new Vector3(startScale.x * 5, startScale.y * 5, startScale.z * 5);
            activated = true;
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.E))
        {
            flame.transform.localScale = startScale;
            activated = false;
        }
    }
	/*
    public override void PossessAction()
    {

    }
	*/
}
