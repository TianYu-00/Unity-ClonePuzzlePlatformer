using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_StartFinish : MonoBehaviour
{
    public GameObject startPad;
    [HideInInspector] public Vector3 startPadVector3;
    public GameObject finishPad;
    public GameObject playerToSpawn;
    public GameObject finishPanel;

    public LayerMask finishLayerMask; // The layer mask of the ground

    //audio
    public AudioSource as_finishSFX;
    bool finishAudioPlayed;

    //particle
    public ParticleSystem finishParticles;


    // Start is called before the first frame update
    private void Awake()
    {
        //Spawn player upon awake.
        startPadVector3 = new Vector3(startPad.transform.position.x, startPad.transform.position.y, startPad.transform.position.z);
        playerToSpawn = Instantiate(playerToSpawn, startPadVector3, Quaternion.identity);
    }
    void Start()
    {
        Time.timeScale = 1f;
        finishPanel.SetActive(false);


        finishAudioPlayed = false;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerToSpawn.transform.position, Vector3.down, out hit, 0.7f, finishLayerMask))
        {
            //What to do when it raycast detects layermask of finish
            //What happens when player complete level
            if (!finishAudioPlayed)
            {
                as_finishSFX.Play();
                finishAudioPlayed = true;
                finishParticles.Play();
            }
            

            finishPanel.SetActive(true);
            Time.timeScale = 0.02f;
            Debug.Log("FinishLayer");

            

        }
        else
        { 
            
        }
    }
}
