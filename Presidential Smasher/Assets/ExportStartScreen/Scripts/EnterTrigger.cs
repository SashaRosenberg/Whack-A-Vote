using UnityEngine;
using System.Collections;

public class EnterTrigger : MonoBehaviour {

    public bool didEnter = false;

    void OnTriggerEnter(Collider other)
    {
        if (other == true)
        {
            Debug.Log("Entered");
            didEnter = true;
        }
    }
}
