using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    [SerializeField]
    public Transform playerPos;

    [SerializeField]
    public Transform spawn;

    [SerializeField]
    public BoxCollider cabCollider;

    [SerializeField]
    private bool canInteract;

    [SerializeField]
    public Transform []otherSpawns;  

    private void Update()
    {
        // cab controller 
        if(Input.GetKeyDown(KeyCode.C))
        {
            canInteract = true;
            if(canInteract == true)
            {
                playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
                playerPos.position = spawn.position;
                playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
            }
        }

        Spawn1();
        Spawn2();
        Spawn3();
        Spawn4();
        Spawn5();
    }

    private IEnumerator EnableCollision()
    {
        cabCollider.gameObject.GetComponentInParent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(4);
        cabCollider.gameObject.GetComponentInParent<BoxCollider>().enabled = true;
    }

    // Event #1 
    private void Spawn1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
            playerPos.position = otherSpawns[0].position;
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
        }
    }

    // Evvent #2
    private void Spawn2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
            playerPos.position = otherSpawns[1].position;
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
        }
    }

    // Event #3
    private void Spawn3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
            playerPos.position = otherSpawns[2].position;
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
        }
    }

    // Event #4
    private void Spawn4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
            playerPos.position = otherSpawns[3].position;
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
        }
    }

    // Event #5 
    private void Spawn5()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
            playerPos.position = otherSpawns[4].position;
            playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
        }
    }
}
