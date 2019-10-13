using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour{

    public bool pressed;

    private void Start() {
        pressed = false;
    }

    private void OnTriggerEnter(Collider other) {
        pressed = true;
    }

    private void OnTriggerExit(Collider other) {
        pressed = false;
    }
}
