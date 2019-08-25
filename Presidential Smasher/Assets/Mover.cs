using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    private GameObject parent;
    private Vector3 start;
	// Use this for initialization
	void Start () {
        parent = this.transform.parent.gameObject;
        start = parent.transform.position;
        Debug.Log(parent);
        
	}
	
	// Update is called once per frame
	public void moveback()
    {
        parent.transform.position = start;
        
        Debug.Log("called");
    }
}
