using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR; // get XR namespace library
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private Transform spawn;

    [SerializeField]
    private BoxCollider cabCollider;

    [SerializeField]
    private bool canInteract;

    [SerializeField]
    private Transform []otherSpawns;

    private InputDevice inputDevice; // get VR input device 

    private void Start()
    {
        bool connectedDevice; 
        inputDevice.TryGetFeatureValue(CommonUsages.userPresence, out connectedDevice);
        if(inputDevice != null && connectedDevice)
        {
            inputDevice.subsystem.Start();
            Debug.Log(inputDevice); 
        }

        var leftHandedDevice = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandedDevice);

        if (connectedDevice)
        {
            if (leftHandedDevice.Count == 0)
            {
                UnityEngine.XR.InputDevice inputDevice = leftHandedDevice[0];
                print(inputDevice);
            }
            else if (leftHandedDevice.Count > 1)
            {
                print(inputDevice + "More than one input found");
            }
        }
        else
        {
            print(connectedDevice + "Not Connected to Device"); 
        }

        // get connected input device
        List<InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevice.Equals(this, inputDevices);

        if (inputDevices.Count > 0)
        {
            inputDevice = inputDevices[0];
            inputDevice.GetType(); 
        }

        // find vr controller or headset 
        foreach(InputDevice device in inputDevices)
        {
            if(device.characteristics == InputDeviceCharacteristics.Left || device.characteristics == InputDeviceCharacteristics.Right)
            {
                Debug.Log("Device found"); 
                inputDevice = device;
                print(device.characteristics);
                break; 
            }
        }
    }

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

        // check if button pressed
        if (inputDevice.isValid)
        {
            bool buttonPressed;
            if (inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPressed) && buttonPressed)
            {
                print("Button Pressed");
            }

            // Get Trigger input 
            float trigger;
            if (inputDevice.TryGetFeatureValue(CommonUsages.trigger, out trigger))
            {
                print("Trigger Pressed");
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
