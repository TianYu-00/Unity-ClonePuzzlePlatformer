using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Script_PlayerCameraController : MonoBehaviour
{
    private Transform playerTransform;
    public Vector3 cameraOffset;

    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject clonePlayer = GameObject.FindGameObjectWithTag("PlayerClone");

        if (clonePlayer != null)
        {
            //if clone is not empty then do...
            playerTransform = clonePlayer.transform;
        }
        else if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            return;
        }


        //playerTransform = player.transform;



        transform.position = playerTransform.position + cameraOffset;
    }


}
