using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInput : MonoBehaviour
{
    [SerializeField]
    public CharacterController character;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.activeInHierarchy)
        {
            character.Move(Vector3.zero);
        }
    }
}
