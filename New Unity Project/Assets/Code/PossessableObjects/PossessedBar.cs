using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedBar : PossessableObject {

	public float maxHeight;
	public float AscendSpeed;

	public void Action() {
		rb.useGravity = false;
		if (transform.position.y < maxHeight) {
			rb.transform.Translate(0, AscendSpeed, 0, Space.World);
		}
	}

}
