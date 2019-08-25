using UnityEngine;
using Steamworks;
using System.Collections;

public class SteamIntegration : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            Debug.Log(name);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
