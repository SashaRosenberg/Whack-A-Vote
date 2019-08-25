using UnityEngine;
using System.Collections;

public class SpinLight : MonoBehaviour
{

    float timer;
    Light linkedlight;

    void Start()
    {
        linkedlight = GetComponent<Light>();
        linkedlight.enabled = false;

    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > .5 && timer < 1)
        {
            linkedlight.enabled = true;
            Debug.Log("lightON!");
        }
        else if (timer > 1)
        {
            linkedlight.enabled = false;
            Debug.Log("lightOFF");
            timer = 0;
        }
        Debug.Log(timer);
    }
}