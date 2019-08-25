using UnityEngine;
using System.Collections;

public class CoinConverter : MonoBehaviour {
    public GameObject spawnbrick;
	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Coin")
        {
            Vector3 tra;
            GameObject spawnclone;
            tra = col.transform.position;
            Destroy(col.gameObject);
            spawnclone = Instantiate(spawnbrick, tra, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
