using UnityEngine;
using System.Collections;

public class submarine_move : MonoBehaviour {
    public float movementSpeed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
    }
}
