using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessSwitch : MonoBehaviour {

    bool activated;
    public GameObject toControl;
    public GameObject lever;
    // Update is called once per frame
    void Update()
    {
        //PossessAction();
    }


    public void OnActionKeyPress()
    {
        if(toControl.GetComponent<CageControl>() !=null)
        {
            toControl.GetComponent<CageControl>().Release();
        }
        lever.transform.rotation = Quaternion.Euler(-30, 0, 0);
    }

}
