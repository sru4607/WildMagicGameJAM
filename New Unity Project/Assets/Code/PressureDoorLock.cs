using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureDoorLock : DoorLockCheck
{
    public List<PressurePlate> pressurePlates;

    private void Update() {
        foreach (PressurePlate plate in pressurePlates) {
            if (plate.pressed) {
                Locked = true;
            }
            else {
                Locked = false;
            }
        }
    }
}
