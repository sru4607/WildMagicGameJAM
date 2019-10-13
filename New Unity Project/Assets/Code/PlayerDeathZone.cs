using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerDeathZone : MonoBehaviour
{
    // Inspector Assigned Variables
    [SerializeField] Transform checkpointTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonCharacter.Instance.transform.position = checkpointTransform.position;
            ThirdPersonCharacter.Instance.transform.rotation = checkpointTransform.rotation;
            ThirdPersonCharacter.Instance.animator.SetFloat("Forward", 0.0f);
            ThirdPersonCharacter.Instance.animator.SetBool("Praying", false);
            ThirdPersonCharacter.Instance.animator.SetBool("OnGround", true);
            ThirdPersonCharacter.Instance.grounded = true;
            ThirdPersonCharacter.Instance.rigidbody.velocity = Vector3.zero;
        }
    }
}
