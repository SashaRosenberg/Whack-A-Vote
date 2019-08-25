using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour {
    public float speed = 0;

    void Update()
    {
        if (speed != 0)
        {
            transform.Rotate(Vector3.right, speed * Time.deltaTime);
            // if it is spinning, continue spinning
        }
    }

    public void stop()
    {
        speed = 0;
        //cease spinning
    }
 
    public void PlaySpinAudio()
    {

    }
}
