using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class MouseSpiritController : MonoBehaviour
{
    [SerializeField] GameObject possessEffectPrefab;
    public Rigidbody rb;

    public bool activated;
    public bool possessing;

    public ThirdPersonUserControl playerControl;
    public ThirdPersonCharacter playerControlChar;
    public Animator playerAnimator;
    public CameraController cameraController;
    public GameObject BlueOverlay;


    // Start is called before the first frame update
    void Start() {
        rb.velocity = Vector3.zero;
        rb.angularDrag = float.PositiveInfinity;
        SkinnedMeshRenderer[] renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers) {
            r.enabled = false;
        }
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            OnClick();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (possessing) {
                LeavePossess();
                return;
            }
            if (!activated) {
                Activate();
            }
            else {
                SetActive(false);
            }
        }
    }

    private void Activate() {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.transform.position = new Vector3(playerTransform.position.x, gameObject.transform.position.y, playerTransform.position.z);
        gameObject.transform.rotation = playerTransform.rotation;
        SetActive(true);
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<PossessableObject>() != null) {
            if (!possessing) {
                collision.gameObject.GetComponent<PossessableObject>().OnPossess();
                OnPossess();
            }
        }
    }


    private void SetActive(bool active) {
        activated = active;
        SkinnedMeshRenderer[] renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers) {
            r.enabled = active;
        }
        gameObject.GetComponent<CapsuleCollider>().enabled = active;
        playerControl.enabled = !active;
        playerControlChar.enabled = !active;
        if (active) {
            playerAnimator.SetFloat("Forward", 0.0f);
            playerAnimator.SetBool("Praying", true);
            playerControlChar.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else if (!possessing) {
            playerAnimator.SetBool("Praying", false);
        }
    }

    private void OnPossess() {
        possessing = true;
        if (possessEffectPrefab) {
            GameObject possessEffect = Instantiate(possessEffectPrefab, transform.position, Quaternion.identity);
            Destroy(possessEffect, 1.0f);
        }
        SetActive(false);
        playerControl.enabled = false;
        playerControlChar.enabled = false;
        playerAnimator.SetFloat("Forward", 0.0f);
        playerAnimator.SetBool("Praying", true);
        playerControlChar.rigidbody.velocity = Vector3.zero;
    }

    private void LeavePossess() {
        activated = false;
        possessing = false;
        SkinnedMeshRenderer[] renderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer r in renderers) {
            r.enabled = false;
        }
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        playerControl.enabled = true;
        playerControlChar.enabled = true;
        playerAnimator.SetBool("Praying", false);
        gameObject.transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, gameObject.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
    }

    private void OnClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.Log(hit.transform.gameObject.name);
        GetComponent<NavMeshAgent>().destination = hit.point;
    }
}
