using UnityEngine;
using System.Collections;

public class SmashParticleKiller : MonoBehaviour {

    public float timeToLive = 1f;
    public float timeAlive = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (timeAlive > timeToLive)
        {
            Destroy(this.gameObject);
            Destroy(this);
        } else
        {
            timeAlive += Time.deltaTime;
        }
        
    }
}
