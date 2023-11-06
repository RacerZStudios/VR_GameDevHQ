using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    [SerializeField]
    public Transform playerPos;

    [SerializeField]
    public Transform spawn;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerPos.gameObject.GetComponent<CharacterController>().enabled = false; 
            playerPos.position = spawn.position;
            playerPos.gameObject.GetComponent<CharacterController>().enabled = true; 
        }
    }
}
