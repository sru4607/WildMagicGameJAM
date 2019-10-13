using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public List<Transform> CameraPositions;
    public float TransitionSpeed;
    public float RotationSpeed;
    public SpiritMovementController spirit;

    private int playerPos = 0;
    private int currentPos = 0;

    public void SetPlayerPos(int ZoneNum) {
        playerPos = ZoneNum;
        if (!spirit.activated) {
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
        //GetComponent<Camera>().
        float transitionedTime = TransitionSpeed;
        while (transform.position.z != targetPos.transform.position.z) { 
            Vector3 toMove = Vector3.Lerp(transform.position, targetPos.transform.position, Time.deltaTime / transitionedTime);
            transitionedTime -= Time.deltaTime;
            transform.position = toMove;
            //transform.position = Vector3.MoveTowards(transform.position, targetPos.position, TransitionSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.rotation.eulerAngles, targetPos.rotation.eulerAngles, 6, RotationSpeed * Time.deltaTime));
            yield return null;
        }
    }

    public void ResetCameraPos() {
        MoveToPosition(playerPos);
    }

}
