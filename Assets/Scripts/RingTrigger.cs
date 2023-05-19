using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RingTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    private void OnTriggerEnter(Collider other)
    {
        //Cinemachine camera switches to camera looking at the the Ring object
        //The text "Type this to complete the challenge" is displayed 

        if (other.gameObject.CompareTag("Player"))
        {
            cam = GameObject.Find("RingCam").GetComponent<CinemachineVirtualCamera>(); 
            if (CameraSwitcher.ActiveCamera != cam)
                CameraSwitcher.SwitchCamera(cam);
            Debug.Log("Got here");
        }   

        Debug.Log("Type this to complete the challenge");
    }

    private void OnTriggerExit(Collider other)
    {
        //Call a method that gives the Player 50 gold (Player is the GameObject that has "other" collider as a component)
        //GameObject player = other.gameObject; //get reference to the player from collider        

        if (other.gameObject.CompareTag("Player"))
        {
            cam = GameObject.Find("PlayerFollowCam").GetComponent<CinemachineVirtualCamera>();
            if (CameraSwitcher.ActiveCamera != cam)
                CameraSwitcher.SwitchCamera(cam);
        }

        Debug.Log("Gained 50 gold!");    
    }
}
