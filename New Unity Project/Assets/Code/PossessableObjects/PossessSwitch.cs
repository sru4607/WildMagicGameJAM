using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessSwitch : PossessableObject {

    bool activated;

    // Update is called once per frame
    void Update()
    {
        PossessAction();
    }

    public override void PossessAction()
    {
        if (Possessed && Input.GetKeyDown(KeyCode.E))
        {
            activated = true;
        }
    }
}
