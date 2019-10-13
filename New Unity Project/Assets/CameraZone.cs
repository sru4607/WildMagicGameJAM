using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour {

    public int ZoneNumber;
    public CameraController cameraController;


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            cameraController.SetPlayerPos(ZoneNumber);
        }
        if (other.gameObject.tag == "Spirit") {
            cameraController.SetSpiritPos(ZoneNumber);
        }
    }


}
