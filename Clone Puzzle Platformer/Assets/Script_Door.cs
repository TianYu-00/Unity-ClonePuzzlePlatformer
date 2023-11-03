using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Door : MonoBehaviour
{
    public Script_PlayerSwitch playerSwitch;
    [SerializeField] Vector3 startVector3;
    [SerializeField] Vector3 endVector3;
    public float animationLerpSpeed;
    public bool isDoorDefault = true;
    private void Start()
    {

        startVector3 = transform.position;

    }
    private void Update()
    {



    }

    public void DecideDoorState()
    {

        isDoorDefault = !isDoorDefault;
        StartCoroutine(OpenDDoor());

    }


    IEnumerator OpenDDoor()
    {
        float t = 0f;
        Vector3 start = isDoorDefault ? startVector3 : endVector3;
        Vector3 end = isDoorDefault ? endVector3 : startVector3;

        while (t < animationLerpSpeed)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, t / animationLerpSpeed);
            yield return null;
        }

        transform.position = end;
        playerSwitch.canRaycast = true;
    }





}
