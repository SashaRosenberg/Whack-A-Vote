using UnityEngine;
using System.Collections;

public class BrickSpawner : MonoBehaviour {

    public GameObject brickPrefab;
    public int bricksToSpawn = 50;
    private int bricksSpawned = 0;
    private float invokeTime = 0.1f;

	// Use this for initialization
	void Start () {
	    while (bricksSpawned < bricksToSpawn)
        {
            Invoke("spawnBrick", invokeTime);
            bricksSpawned++;
            invokeTime += 0.1f;
        }    
	}

    void spawnBrick()
    {
        GameObject brick = Instantiate(brickPrefab, this.transform.position, Quaternion.identity) as GameObject;
        brick.name = "Brick";
        brick.transform.SetParent(this.transform);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

}
