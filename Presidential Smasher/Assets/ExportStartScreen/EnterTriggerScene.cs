using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterTriggerScene : MonoBehaviour {

    public bool didEnter = false;

    void OnTriggerEnter(Collider other)
    {
        if (other == true)
        {
            Debug.Log("add load level script here");
            SceneManager.LoadScene("main");
        }
    }
}
