using UnityEngine;
using System.Collections;

public class SpinPropellers : MonoBehaviour {

    public float speed = 10f;
    //public GameObject propeller1;
    //public GameObject propeller2;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        //propeller1.transform.Rotate(0, 0, speed * Time.deltaTime);
        //propeller2.transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}