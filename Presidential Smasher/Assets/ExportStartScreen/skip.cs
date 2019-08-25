using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour {

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj; 
    // Use this for initialization
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        if (controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            Debug.Log("Put scene load here");
            SceneManager.LoadScene("main");
        }
    }
}