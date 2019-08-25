using UnityEngine;
using System.Collections;

public class StopPlane : MonoBehaviour {

    public bool isHeightPlane = false;
    public GameObject whackAMoleLogicObject;
    private WhackAMoleLogic whackAMoleLogic;

	// Use this for initialization
	void Start () {
        whackAMoleLogic = whackAMoleLogicObject.GetComponent<WhackAMoleLogic>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name.Contains("Puppet"))
        {
            if (isHeightPlane)
            {
                c.gameObject.GetComponent<PuppetLogic>().stopPlaneHit(true);
            } else
            {
                c.gameObject.GetComponent<PuppetLogic>().stopPlaneHit(false);
            }
        }
        
    }
}
