using UnityEngine;
using System.Collections;
using VRTK;

public class DragCoin : MonoBehaviour {
    public GameObject insertingpoint;
    private GameObject coin;
    private bool moving;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (moving == true)
        {
          //  coin.transform.LookAt(insertingpoint.transform);
          if (coin == null)
            {
                coin = null;
                moving = false;
            }
          else
            {
                  if (Vector3.Distance(coin.transform.position, insertingpoint.transform.position) < 0.08)
            {
                coin = null;
                moving = false;
            }
            else
            {
coin.transform.position += coin.transform.forward * Time.deltaTime * 3;
            }
            }
         
              
        }
    }
    void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Coin")
        {
            moving = true;
            coin = col.gameObject;
            FixedJoint fix;
            VRTK_InteractableObject interact;
            Rigidbody rig;
            fix = col.GetComponent<FixedJoint>();
            interact = col.GetComponent<VRTK_InteractableObject>();
            rig = col.GetComponent<Rigidbody>();
            rig.useGravity = false;
            rig.isKinematic = true;
            Destroy(fix);
            Destroy(interact);
            col.transform.LookAt(insertingpoint.transform);
        }
    }
}
