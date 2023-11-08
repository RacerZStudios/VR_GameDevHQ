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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            canInteract = true;
            if(canInteract == true)
            {
                playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = false;
                playerPos.position = spawn.position;
                playerPos.gameObject.GetComponentInParent<CharacterController>().enabled = true;
            }
        }
    }

    private IEnumerator EnableCollision()
    {
        cabCollider.gameObject.GetComponentInParent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(4);
        cabCollider.gameObject.GetComponentInParent<BoxCollider>().enabled = true;
    }
}
