using UnityEngine;
using System.Collections;

public class WallAudioStarter : MonoBehaviour {

    public GameObject audioSource;
    private int bricksInside = 0;
    private bool hasPlayedAudio = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Brick")
        {
            bricksInside++;
            if (bricksInside > 4 && !hasPlayedAudio)
            {
                audioSource.GetComponent<AudioSource>().Play();
                hasPlayedAudio = true;
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.name == "Brick")
        {
            bricksInside--;
        }
    }
}
