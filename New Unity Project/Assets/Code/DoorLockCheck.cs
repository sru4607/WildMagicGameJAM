using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockCheck : MonoBehaviour
{
	public PossessedBar LockBar;
	public bool Locked;

	private void OnCollisionStay(Collision collision) {
		if (collision.gameObject == LockBar.gameObject) {
			Locked = true;
		} else {
			Locked = false;
		}
	}

	private void OnCollisionExit(Collision collision) {
		Locked = false;
	}
}
