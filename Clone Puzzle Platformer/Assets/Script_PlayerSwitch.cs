using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerSwitch : MonoBehaviour
{
    //public GameObject objectToCheck;
    public float raycastDistance;
    GameObject player;
    GameObject playerClone;
    public List<GameObject> listOfSwitches;

    public bool canRaycast = true;


    //sfx
    public AudioSource as_buttonPressSFX;
    bool buttonAudioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        buttonAudioPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerClone = GameObject.FindGameObjectWithTag("PlayerClone");
        // Cast a ray from the object's position in the forward direction

        if (canRaycast)
        {
            if (playerClone == null) //Player Only
            {
                PlayerDetection();

            }
            else //clone detected
            {
                CloneDetection();

            }

        }



    }

    void PlayerDetection()
    {
        Vector3 origin = player.transform.position;
        Vector3 direction = -player.transform.up;
        RaycastHit hit;
        // Check if the ray hits the assigned object
        if (Physics.Raycast(origin, direction, out hit, raycastDistance) && listOfSwitches.Contains(hit.collider.gameObject))
        {
            canRaycast = false;
            Debug.Log("Player ray is touching the assigned object!");
            hit.collider.gameObject.GetComponent<Script_Switch>().doorScript.DecideDoorState();
            PlaySound();
            buttonAudioPlayed = false;
        }
        else
        {
            //canRaycast = true;
        }
    }

    void CloneDetection()
    {
        Vector3 origin = playerClone.transform.position;
        Vector3 direction = -playerClone.transform.up;
        RaycastHit hit;
        // Check if the ray hits the assigned object
        if (Physics.Raycast(origin, direction, out hit, raycastDistance) && listOfSwitches.Contains(hit.collider.gameObject))
        {
            canRaycast = false;
            Debug.Log("Clone ray is touching the assigned object!");
            //if it is the switch then...
            hit.collider.gameObject.GetComponent<Script_Switch>().doorScript.DecideDoorState();
            PlaySound();
            buttonAudioPlayed = false;
        }
        else
        {
            //canRaycast = true;
        }
    }


    void PlaySound()
    {
        if (!buttonAudioPlayed)
        {
            as_buttonPressSFX.Play();
            buttonAudioPlayed = true;
        }
    }
}
