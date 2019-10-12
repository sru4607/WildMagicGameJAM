using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedTorch : PossessableObject
{

    public GameObject flame;
    public Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = gameObject.transform.localScale;   
    }

    // Update is called once per frame
    void Update()
    {
        PossessAction();
    }

    public override void PossessAction()
    {
        if(Possessed && Input.GetKey(KeyCode.E))
        {
            flame.transform.localScale = new Vector3(startScale.x * 5, startScale.y * 5, startScale.z * 5);
        }
        else
        {
            flame.transform.localScale = startScale;
        }
    }
}
