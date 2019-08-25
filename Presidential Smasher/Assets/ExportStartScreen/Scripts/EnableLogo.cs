using UnityEngine;
using System.Collections;

public class EnableLogo : MonoBehaviour {

    public Renderer rend;
    //public GameObject trigger;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update ()
    {
        GameObject Trigger = GameObject.Find("Trigger");
        EnterTrigger enterTrigger = Trigger.GetComponent<EnterTrigger>();
        if (enterTrigger.didEnter == true)
        {
            rend.enabled = true;
        }
    }
}
