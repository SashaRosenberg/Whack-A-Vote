using UnityEngine;
using System.Collections;
using VRTK;

public class WeaponCollection : MonoBehaviour {
    private bool boolio;
    private Collider col;
	// Use this for initialization
    void Start ()
    {
        InvokeRepeating("Repeating", 0, 15);
    }
	void OnTriggerStay (Collider col2)
    {
        
        if ((col2.GetComponent("WeaponScripts") as WeaponScripts) != null)
        {
            boolio = true;
            col = col2;
          }
           
            
        }
  void Repeating()
    {
        if (boolio == true)
        {
  Debug.Log(col.transform.root);
            Debug.Log(col.gameObject);
            if (col.transform.root.gameObject == col.gameObject)
            {
 WeaponScripts wep;
            wep = col.GetComponent<WeaponScripts>();
            wep.returntostart();
                Rigidbody rib;
                rib = col.GetComponent<Rigidbody>();
                rib.velocity = new Vector3(0,0,0);
                rib.angularVelocity = new Vector3(0, 0, 0);
                boolio = false;
        }
    }

    } 
  

}
