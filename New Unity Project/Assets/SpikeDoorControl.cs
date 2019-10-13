using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDoorControl : MonoBehaviour
{

    public List<PressurePlate> pressurePlates;

    private void Update() {
        Open();
        foreach (PressurePlate plate in pressurePlates) {
            if (!plate.pressed) {
                Close();
            }
        }
    }

    public void Open() {
        GetComponent<Animator>().SetBool("IsOpen", true);
    }

    public void Close() {
        GetComponent<Animator>().SetBool("IsOpen", false);
    }
}
