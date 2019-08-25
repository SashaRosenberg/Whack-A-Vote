using UnityEngine;
using System.Collections;

public class Breathing : MonoBehaviour
{

    public AudioSource bubbles;
    public AudioSource breathing;
    public ParticleSystem bubble_particle;
    public int breath = 4;
    public float timer = 3.0f;
    float currentTime = 0f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SoundOut());
    }
    

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime % 2 == 0)
        {
            breathing.Play();
        }
    }

    IEnumerator SoundOut()
    {
        if (timer > 2.0f)
        {
            Debug.Log("Here");
            bubbles.Play();
            
            bubble_particle.Play();
            timer -= 1;
                 
        }
        if (timer < 2.0f)
        {
            timer += 1;
        }
        yield return false;
    }
}
