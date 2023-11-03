using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_InGameAudio : MonoBehaviour
{
    public AudioClip ac_bgmSFX;
    private AudioSource as_bgmSFX;
    bool ac_bgmPlayed;

    // Start is called before the first frame update
    void Start()
    {
        as_bgmSFX = gameObject.AddComponent<AudioSource>();
        as_bgmSFX.clip = ac_bgmSFX;
        as_bgmSFX.loop = true;
        as_bgmSFX.volume = 0.5f;
        as_bgmSFX.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
