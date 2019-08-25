using UnityEngine;
using System.Collections.Generic;

public class BackgroundMusic : MonoBehaviour
{
    public List<AudioClip> tracks;
    public int playing_track = 0;
    private AudioSource src;

    void Start ()
    {
        src = gameObject.GetComponent<AudioSource>();
        Debug.Log("Now playing background music track: " + tracks[playing_track].name);
        src.PlayOneShot(tracks[playing_track], (tracks[playing_track].name == "Battle_Hymn_of_the_Republic_8_Bit" ? 1 : 0.5f));
    }
	
	void Update ()
    {
	    if (!src.isPlaying)
        {
            playing_track = (playing_track + 1) % tracks.Count;
            Debug.Log("Now playing background music track: " + tracks[playing_track].name);
            src.PlayOneShot(tracks[playing_track], (tracks[playing_track].name == "Battle_Hymn_of_the_Republic_8_Bit" ? 1 : 0.5f));
        }
	}
}
