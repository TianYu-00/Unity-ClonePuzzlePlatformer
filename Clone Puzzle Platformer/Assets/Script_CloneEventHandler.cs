using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CloneEventHandler : MonoBehaviour
{
    
    [SerializeField] GameObject clone;
    Script_PlayerMovement playerMoveScript;
    Script_PlayerMechanics playerMechanics;
    GameObject player;

    public float maxDistance = 1.5f;
    public LayerMask obstacleMask;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerMoveScript = player.GetComponent<Script_PlayerMovement>();
        playerMechanics = player.GetComponent<Script_PlayerMechanics>();


    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.J) && playerMechanics.hasClone == false) 
        {
            ClonePlayer();

        }
        if (Input.GetKeyDown(KeyCode.K) && playerMechanics.hasClone == true)
        {
            GameObject tempClone = GameObject.FindWithTag("PlayerClone");
            Destroy(tempClone);
            playerMoveScript.enabled = true;
            playerMechanics.hasClone = false;
        }
    }

    void ClonePlayer()
    {
        //Instantiate(clone);
        Vector3 origin = player.transform.position;
        Vector3 direction = player.transform.right;
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, maxDistance, obstacleMask)) //if facing is detected wall
        {
            Debug.DrawRay(origin, direction * hit.distance, Color.red);
        }
        else //if facing is empty
        {
            Debug.DrawRay(origin, direction * maxDistance, Color.green);
            playerMechanics.hasClone = true;
            playerMoveScript.enabled = false;
            Instantiate(clone, player.transform.position + direction * maxDistance, Quaternion.identity);
            
        }
    }


}
