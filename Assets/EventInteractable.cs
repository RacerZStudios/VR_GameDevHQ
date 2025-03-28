using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteractable : MonoBehaviour
{
    [SerializeField]
    private GameObject eventObj;

    [SerializeField]
    private CharacterController characterController;

    private LayerMask layerMask;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.detectCollisions = true; 
    }

    private void OnCollisionEnter(Collision collision) // by default the character controller doesn't know how to detect collisions without a Rigidbody reference 
    {
        if (characterController != null)
        {
            if(collision.collider.CompareTag("Event") || layerMask == 8)
            {
                print(layerMask.value);
                eventObj.gameObject.SetActive(false);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            Vector3 dir = hit.moveDirection.normalized;
            dir.z = dir.z + 1;
            dir.Normalize();

            rigidbody.AddForce(dir * 100);
            eventObj.gameObject.SetActive(true);
        }
    }
}
