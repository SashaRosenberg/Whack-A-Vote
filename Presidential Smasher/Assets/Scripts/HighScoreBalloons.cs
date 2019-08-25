using UnityEngine;
using System.Collections;

public class HighScoreBalloons : MonoBehaviour {
    public GameObject Balloon1;
    public GameObject Balloon2;
    public int balloonstospawn = 10;
    private int balloonsSpawned = 0;
    private float invokeTime = 0.2f;
    

    // Use this for initialization
    void Start()
    {

    }
    public void spawningBallonsNow()
    {
        while (balloonsSpawned < balloonstospawn)
        {
            Invoke("spawnBalloon", invokeTime);
            balloonsSpawned++;
            invokeTime += 0.4f;
        }
        if (balloonsSpawned == balloonstospawn)
        {
            balloonsSpawned = 0;
        }
    }
    void spawnBalloon()
    {
        Vector3 position = new Vector3(Random.Range(-0.5f, .5f), Random.Range(-0.5f, .5f), Random.Range(-0.5f, .5f));
        GameObject loon1 = Instantiate(Balloon1, this.transform.position + position, Quaternion.identity) as GameObject;
        GameObject loon2 = Instantiate(Balloon2, this.transform.position + position, Quaternion.identity) as GameObject;

    }
}
