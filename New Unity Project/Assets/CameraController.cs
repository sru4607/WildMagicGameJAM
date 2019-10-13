using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public List<Transform> CameraPositions;
    public List<BoxCollider> CameraZone;
    public float TransitionSpeed;
    public float RotationSpeed;
    public SpiritMovementController spirit;

    private int currentPos;

    public void SetPlayerPos(int ZoneNum) {
        if (!spirit.gameObject.activeInHierarchy) {
            MoveToPosition(ZoneNum);
        }
    }

    public void SetSpiritPos(int ZoneNum) {
        if (spirit.gameObject.activeInHierarchy) {
            MoveToPosition(ZoneNum);
        }
    }

    public void MoveToPosition(int position) {
        if (position != currentPos) {
            if (position < CameraPositions.Count) {
                currentPos = position;
                StartCoroutine(MoveCamera(CameraPositions[position]));
            }
            else {
                throw new System.IndexOutOfRangeException("Camera position " + position + " not set");
            }
        }
    }

    private IEnumerator MoveCamera(Transform targetPos) {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, TransitionSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.rotation.eulerAngles, targetPos.rotation.eulerAngles, 6, RotationSpeed * Time.deltaTime));
        return new WaitUntil(() => transform.position == targetPos.transform.position);
    }

}
